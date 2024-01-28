using System;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Ionic.Zlib;

namespace Editor
{
    class Worker
    {
        private Dialog dialog;
        private string dataFolder;

        private void LaunchDialog()
        {
            if (dialog == null)
            {
                new Thread(delegate ()
                {
                    dialog = new Dialog();
                    dialog.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
                    Application.Run(dialog);
                    dialog = null;
                }).Start();

                while (dialog == null)
                {
                    Thread.Sleep(1); //SPIN!!
                }
            }
        }

        private void LaunchError(string error)
        {
            MessageBox.Show(error, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public byte[] Decompress(byte[] raw)
        {
            int type = raw[11];

            byte[] data = new byte[raw.Length - 12];
            Array.Copy(raw, 12, data, 0, data.Length);

            using (MemoryStream ms = new MemoryStream(data, 0, data.Length))
            using (MemoryStream os = new MemoryStream())
            using (var ds = new ZlibStream(ms, CompressionMode.Decompress))
            {
                ds.CopyTo(os);
                data = os.ToArray();
            }

            if(type == 0x32)
            {
                byte[] tmp = new byte[raw.Length - 2];
                Array.Copy(data, 2, tmp, 0, tmp.Length);

                using (MemoryStream ms = new MemoryStream(tmp, 0, tmp.Length))
                using (MemoryStream os = new MemoryStream())
                using (var ds = new ZlibStream(ms, CompressionMode.Decompress))
                {
                    ds.CopyTo(os);
                    data = os.ToArray();
                }
            }

            return data;
        }

        public byte[] Compress(byte[] raw)
        {
            byte[] compressed;

            using (MemoryStream ms = new MemoryStream(raw, 0, raw.Length))
            using (MemoryStream os = new MemoryStream())
            {
                using (var ds = new ZlibStream(os, CompressionMode.Compress))
                {
                    ms.CopyTo(ds);
                }
                compressed = os.ToArray();
            }

            MemoryStream s = new MemoryStream();

            s.Write(BitConverter.GetBytes((uint)raw.Length), 0, 4);
            s.Write(BitConverter.GetBytes((uint)compressed.Length+2), 0, 4);
            s.Write(new byte[] { 0x50, 0x6C, 0x5A, 0x31 }, 0, 4);
            s.Write(compressed, 0, compressed.Length);

            byte[] data = s.ToArray();

            return data;
        }

        public dynamic ReadSave(string saveFile)
        {
            var uesave = Path.GetFullPath("uesave.exe");
            var tmpGVAS = Path.Combine(this.dataFolder, "tmp", "tmp_r.gvas");
            var tmpJSON = Path.Combine(this.dataFolder, "tmp", "tmp_r.json");

            File.Delete(tmpGVAS);
            File.Delete(tmpJSON);

            byte[] fileData = Decompress(File.ReadAllBytes(saveFile));

            File.WriteAllBytes(tmpGVAS, fileData);

            ProcessStartInfo startInfo = new ProcessStartInfo(uesave)
            {
                WorkingDirectory = this.dataFolder,
                Arguments = String.Format("to-json --input {0} --output {1}", tmpGVAS, tmpJSON),
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = new Process
            {
                StartInfo = startInfo
            };

            process.Start();
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                var error = "UESave read error: " + process.StandardError.ReadToEnd();
                LaunchError(error);
                dialog.SetLabel("Failed");
                throw new Exception(error);
            }

            var saveString = File.ReadAllText(tmpJSON);
            var save = JsonConvert.DeserializeObject(saveString);

            return save;
        }

        public void WriteSave(dynamic save, string saveFile)
        {
            var saveString = JsonConvert.SerializeObject(save, Formatting.Indented);

            var uesave = Path.Combine(Path.GetFullPath("uesave.exe"));
            var tmpGVAS = Path.Combine(this.dataFolder, "tmp", "tmp_w.gvas");
            var tmpJSON = Path.Combine(this.dataFolder, "tmp", "tmp_w.json");

            File.Delete(tmpGVAS);
            File.Delete(tmpJSON);

            File.WriteAllText(tmpJSON, saveString);

            ProcessStartInfo startInfo = new ProcessStartInfo(uesave)
            {
                WorkingDirectory = dataFolder,
                Arguments = String.Format("from-json --input {0} --output {1}", tmpJSON, tmpGVAS),
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = new Process
            {
                StartInfo = startInfo
            };

            process.Start();
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                var error = "UESave read error: " + process.StandardError.ReadToEnd();
                LaunchError(error);
                dialog.SetLabel("Failed");
                throw new Exception(error);
            }

            byte[] fileData = Compress(File.ReadAllBytes(tmpGVAS));

            File.WriteAllBytes(saveFile, fileData);
        }

        public void Transfer(string srcFile, string dstFile)
        {
            dialog.SetLabel("Saving...");

            dynamic dstSave = null;
            try
            {
                var backupFile = DateTime.Now.ToString("dd_MM_yyyy-HH_mm_ss-ff") + ".bak.sav";
                File.Copy(dstFile, Path.Combine(this.dataFolder, "backup", backupFile));

                if (srcFile.EndsWith(".bak.sav"))
                {
                    File.Copy(srcFile, dstFile, true);
                    dialog.SetLabel("Restored");
                    return;
                }
            
                var srcSave = ReadSave(srcFile);
                dstSave = ReadSave(dstFile);

                var srcAppearance = srcSave["root"]["properties"]["SaveData"]["Struct"]["value"]["Struct"]["PlayerCharacterMakeData"];
                dstSave["root"]["properties"]["SaveData"]["Struct"]["value"]["Struct"]["PlayerCharacterMakeData"] = srcAppearance;
            }
            catch (Exception e)
            {
                LaunchError("Preparation Failed: " + e.Message);
                dialog.SetLabel("Failed");
                return;
            }

            try
            {
                WriteSave(dstSave, dstFile);
            }
            catch (Exception e)
            {
                LaunchError("Saving Failed: " + e.Message);
                dialog.SetLabel("Failed");
                return;
            }

            dialog.SetLabel("Saved");
        }

        public void Refresh()
        {
            try
            {
                new Thread(delegate ()
                {
                    Populate();
                }).Start();
            }
            catch (Exception e)
            {
                LaunchError("Refresh Failed: " + e.Message);
                dialog.SetLabel("Failed");
                return;
            }
        }

        public void Populate()
        {
            dialog.SetLabel("Reading...");

            Directory.CreateDirectory(this.dataFolder);
            Directory.CreateDirectory(Path.Combine(this.dataFolder, "tmp"));
            Directory.CreateDirectory(Path.Combine(this.dataFolder, "backup"));

            var uesave = Path.GetFullPath("uesave.exe");
            if (!File.Exists(uesave))
            {
                LaunchError("Failed to find uesave.exe!");
                return;
            }

            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var saveLocation = "SaveGames";
            if (!Directory.Exists(saveLocation))
            {
                saveLocation = Path.Combine(appData, "Pal", "Saved", "SaveGames");
                if (!Directory.Exists(saveLocation))
                {
                    LaunchError("Failed to find save location!");
                    return;
                }
            }

            OrderedDictionary saves = new OrderedDictionary();
            OrderedDictionary names = new OrderedDictionary();

            var ids = Directory.GetDirectories(saveLocation);
            foreach (var id in ids)
            {
                var worlds = Directory.GetDirectories(id);
                foreach (var world in worlds)
                {
                    var worldJson = ReadSave(Path.Combine(world, "LevelMeta.sav"));
                    var worldName = ((string)worldJson["root"]["properties"]["SaveData"]["Struct"]["value"]["Struct"]["WorldName"]["Str"]["value"]);
                    var playerName = ((string)worldJson["root"]["properties"]["SaveData"]["Struct"]["value"]["Struct"]["HostPlayerName"]["Str"]["value"]);
                    names[world] = worldName;

                    var players = Directory.GetFiles(Path.Combine(world, "Players"));

                    foreach (var player in players)
                    {
                        var playerFilename = Path.GetFileName(player);
                        if (playerFilename == "00000000000000000000000000000001.sav")
                        {
                            names[player] = playerName;
                        }
                        else
                        {
                            names[player] = playerFilename.Split('.')[0];
                        }
                    }

                    saves[world] = players;
                }
            }

            var backups = Directory.GetFiles(Path.Combine(this.dataFolder, "backup"));
            if (backups.Length != 0)
            {
                saves["backup"] = backups;
                names["backup"] = "Backup";
                foreach (var entry in (string[])saves["backup"])
                {
                    names[entry] = Path.GetFileName(entry).Split('.')[0];
                }
            }

            dialog.SetSaves(saves, names);
            dialog.SetLabel("Idle");
        }
        public void Work(string[] args)
        {
            var exe = Assembly.GetEntryAssembly().Location;
            var exe_dir = Path.GetDirectoryName(exe);
            Directory.SetCurrentDirectory(exe_dir);
            LaunchDialog();

            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            this.dataFolder = Path.Combine(appData, "PalTransfer");

            dialog.transferCallback = Transfer;
            dialog.refreshCallback = Refresh;

            Refresh();

            while(dialog != null)
            {
                Thread.Sleep(10);
            }
        }
    }
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Worker worker = new Worker();
            worker.Work(args);
        }
    }
}