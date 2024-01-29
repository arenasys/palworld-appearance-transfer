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
        private string tmpFolder;
        private string backupFolder;
        private string saveFolder;

        private void LaunchDialog()
        {
            if (dialog == null)
            {
                var thread = new Thread(delegate ()
                {
                    dialog = new Dialog();
                    dialog.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
                    Application.Run(dialog);
                    dialog = null;
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();

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

        public void DoTransfer(string srcFile, string dstFile)
        {
            dialog.SetLabel("Transferring...");
            int saveType;

            byte[] srcSave = null;
            byte[] dstSave = null;
            try
            {
                var backupFile = DateTime.Now.ToString("dd_MM_yyyy-HH_mm_ss-ff") + ".bak.sav";
                File.Copy(dstFile, Path.Combine(backupFolder, backupFile));

                if (srcFile.EndsWith(".bak.sav"))
                {
                    File.Copy(srcFile, dstFile, true);
                    dialog.SetLabel("Restored");
                    return;
                }

                (srcSave, saveType) = Palworld.ReadSave(srcFile, tmpFolder);
                (dstSave, saveType) = Palworld.ReadSave(dstFile, tmpFolder);

                dstSave = Palworld.TransferAppearance(dstSave, srcSave);
            }
            catch (Exception e)
            {
                LaunchError("Preparation Failed: " + e.Message + "\n" + e.StackTrace);
                dialog.SetLabel("Failed");
                return;
            }

            try
            {
                Palworld.WriteSave(dstSave, dstFile, tmpFolder, saveType);
            }
            catch (Exception e)
            {
                LaunchError("Saving Failed: " + e.Message + "\n" + e.StackTrace);
                dialog.SetLabel("Failed");
                return;
            }

            dialog.SetLabel("Saved");
        }

        public void Transfer(string srcFile, string dstFile)
        {
            new Thread(delegate ()
            {
                DoTransfer(srcFile, dstFile);
                Thread.Sleep(1000);
                GC.Collect();
            }).Start();
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        public void DoRename(string world, string oldName, string newName)
        {
            try
            {
                var worldFile = Path.Combine(world, "Level.sav");
                var worldName = Path.GetFileName(world);

                dialog.SetLabel("Backing up...");
                var worldBackup = Path.Combine(backupFolder, DateTime.Now.ToString("dd_MM_yyyy-HH_mm_ss-ff"), worldName);
                CopyAll(new DirectoryInfo(world), new DirectoryInfo(worldBackup));

                dialog.SetLabel("Reading...");
                (byte[] worldJson, int saveType) = Palworld.ReadSave(worldFile, tmpFolder);

                dialog.SetLabel("Renaming...");
                byte[] newWorldJson = Palworld.RenamePlayer(worldJson, oldName, newName);

                dialog.SetLabel("Writing...");
                Palworld.WriteSave(newWorldJson, worldFile, tmpFolder, saveType);

                dialog.SetLabel("Saved");
            }
            catch (Exception e)
            {
                LaunchError("Rename Failed: " + e.Message + "\n" + e.StackTrace);
                dialog.SetLabel("Failed");
                return;
            }
        }

        public void Rename(string world, string oldName, string newName)
        {
            new Thread(delegate ()
            {
                DoRename(world, oldName, newName);
                Thread.Sleep(1000);
                GC.Collect();
            }).Start();
        }
        public void DoRefresh()
        {
            try
            {
                dialog.SetLabel("Reading...");

                var uesave = Path.GetFullPath("uesave.exe");
                if (!File.Exists(uesave))
                {
                    LaunchError("Failed to find uesave.exe!");
                    return;
                }

                OrderedDictionary saves = new OrderedDictionary();
                OrderedDictionary names = new OrderedDictionary();

                var ids = Directory.GetDirectories(saveFolder);
                foreach (var id in ids)
                {
                    var worlds = Directory.GetDirectories(id);
                    foreach (var world in worlds)
                    {
                        string worldName = Path.GetFileName(world);
                        Dictionary<string, string> playerNames = new Dictionary<string, string>();
                        try
                        {
                            var worldMetadataFile = Path.Combine(world, "LevelMeta.sav");
                            if (File.Exists(worldMetadataFile))
                            {
                                (var worldMetadataJson, _) = Palworld.ReadSave(Path.Combine(world, "LevelMeta.sav"), tmpFolder);
                                string playerName;
                                (worldName, playerName) = Palworld.InspectWorldMetadata(worldMetadataJson);
                                playerNames["00000000000000000000000000000001"] = playerName;
                            }
                        }
                        catch (Exception e)
                        {
                            LaunchError("World Failed: " + e.Message + "\n" + e.StackTrace);
                            dialog.SetLabel("Failed");
                            return;
                        }

                        try
                        {
                            var players = Directory.GetFiles(Path.Combine(world, "Players"));

                            if (players.Length > 1) // Multiplayer, so actually inspect the world save.
                            {
                                try
                                {
                                    dialog.SetLabel(String.Format("Reading {0}...", worldName));
                                    var worldFile = Path.Combine(world, "Level.sav");

                                    {
                                        (byte[] worldJson, int saveType) = Palworld.ReadSave(worldFile, tmpFolder);

                                        var worldPlayers = Palworld.InspectWorld(worldJson);
                                        foreach (var entry in worldPlayers)
                                        {
                                            playerNames[entry.Key] = entry.Value;
                                        }
                                    }
                                    GC.Collect();
                                }
                                catch (Exception e)
                                { Console.WriteLine(e.StackTrace); }
                            }

                            foreach (var player in players)
                            {
                                var playerFilename = Path.GetFileName(player).Split('.')[0];

                                if (playerNames.ContainsKey(playerFilename))
                                {
                                    names[player] = playerNames[playerFilename];
                                }
                                else
                                {
                                    names[player] = playerFilename;
                                }
                            }

                            names[world] = worldName;
                            saves[world] = players;
                        }
                        catch { }
                    }
                }

                var backups = Directory.GetFiles(backupFolder);
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
            catch (Exception e)
            {
                LaunchError("Refresh Failed: " + e.Message + "\n" + e.StackTrace);
                dialog.SetLabel("Failed");
                return;
            }
        }
        public void Refresh()
        {
            new Thread(delegate ()
            {
                DoRefresh();
                Thread.Sleep(1000);
                GC.Collect();
            }).Start();
        }

        public void Open(string type)
        {
            if (type == "saves")
            {
                Process.Start("explorer.exe", this.saveFolder);
            }
            else if(type == "backups")
            {
                Process.Start("explorer.exe", this.backupFolder);
            }
        }

        public void Work(string[] args)
        {
            try
            {
                var exe = Assembly.GetEntryAssembly().Location;
                var exe_dir = Path.GetDirectoryName(exe);
                Directory.SetCurrentDirectory(exe_dir);
                LaunchDialog();

                var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                this.dataFolder = Path.Combine(appData, "PalTransfer");
                this.tmpFolder = Path.Combine(this.dataFolder, "tmp");
                this.backupFolder = Path.Combine(this.dataFolder, "backup");

                Directory.CreateDirectory(this.dataFolder);
                Directory.CreateDirectory(this.tmpFolder);
                Directory.CreateDirectory(this.backupFolder);

                this.saveFolder = "SaveGames";
                if (!Directory.Exists(this.saveFolder))
                {
                    this.saveFolder = Path.Combine(appData, "Pal", "Saved", "SaveGames");
                    if (!Directory.Exists(this.saveFolder))
                    {
                        LaunchError("Failed to find save location!");
                        return;
                    }
                }

                dialog.transferCallback = Transfer;
                dialog.refreshCallback = Refresh;
                dialog.renameCallback = Rename;
                dialog.openCallback = Open;

                Refresh();

                while (dialog != null)
                {
                    Thread.Sleep(10);
                }

                Environment.Exit(0);
            }
            catch (Exception e)
            {
                LaunchError("Unhandled Error: " + e.Message + "\n" + e.StackTrace);
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