using System;
using System.Threading;
using System.IO;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Collections.Specialized;
using Ionic.Zlib;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Editor
{
    internal class Palworld
    {

        public static dynamic Deserialize(byte[] data)
        {
            using (var stream = new MemoryStream(data))
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            using (var jsonReader = new JsonTextReader(reader))
                return JsonSerializer.Create().Deserialize<dynamic>(jsonReader);
        }

        public static byte[] Serialize(dynamic data)
        {
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream, new UTF8Encoding(false)))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                JsonSerializer.Create().Serialize(jsonWriter, data);
                jsonWriter.Flush();
                writer.Flush();
                return stream.ToArray();
            }
        }
        public static (byte[], int) SavToGVAS(byte[] raw)
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

            if (type == 0x32)
            {
                byte[] tmp = new byte[data.Length];
                Array.Copy(data, 0, tmp, 0, tmp.Length);

                using (MemoryStream ms = new MemoryStream(tmp, 0, tmp.Length))
                using (MemoryStream os = new MemoryStream())
                using (var ds = new ZlibStream(ms, CompressionMode.Decompress))
                {
                    ds.CopyTo(os);
                    data = os.ToArray();
                }
            }

            return (data, type);
        }

        public static byte[] GVASToSav(byte[] raw, int saveType)
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

            int uncompressedLength = raw.Length;
            int compressedLength = compressed.Length;

            if (saveType == 0x32)
            {
                byte[] tmp = new byte[compressed.Length];
                Array.Copy(compressed, tmp, tmp.Length);

                using (MemoryStream ms = new MemoryStream(tmp, 0, tmp.Length))
                using (MemoryStream os = new MemoryStream())
                {
                    using (var ds = new ZlibStream(os, CompressionMode.Compress))
                    {
                        ms.CopyTo(ds);
                    }
                    compressed = os.ToArray();
                }
            }

            MemoryStream s = new MemoryStream();

            s.Write(BitConverter.GetBytes((uint)uncompressedLength), 0, 4);
            s.Write(BitConverter.GetBytes((uint)compressedLength), 0, 4);
            s.Write(new byte[] { 0x50, 0x6C, 0x5A, (byte)saveType }, 0, 4);
            s.Write(compressed, 0, compressed.Length);

            byte[] data = s.ToArray();

            return data;
        }

        public static (byte[], int) ReadSave(string saveFile, string tmpFolder)
        {
            var uesave = Path.GetFullPath("uesave.exe");
            var tmpGVAS = Path.Combine(tmpFolder, "tmp_r.gvas");
            var tmpJSON = Path.Combine(tmpFolder, "tmp_r.json");

            File.Delete(tmpGVAS);
            File.Delete(tmpJSON);

            int saveType;
            {
                byte[] fileData;
                (fileData, saveType) = SavToGVAS(File.ReadAllBytes(saveFile));

                File.WriteAllBytes(tmpGVAS, fileData);

                ProcessStartInfo startInfo = new ProcessStartInfo(uesave)
                {
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
                    throw new Exception(error);
                }
            }
            GC.Collect();

            var save = File.ReadAllBytes(tmpJSON);
            return (save, saveType);
        }

        public static void WriteSave(byte[] save, string saveFile, string tmpFolder, int saveType)
        {
            var uesave = Path.Combine(Path.GetFullPath("uesave.exe"));
            var tmpGVAS = Path.Combine(tmpFolder, "tmp_w.gvas");
            var tmpJSON = Path.Combine(tmpFolder, "tmp_w.json");

            File.Delete(tmpGVAS);
            File.Delete(tmpJSON);

            File.WriteAllBytes(tmpJSON, save);

            ProcessStartInfo startInfo = new ProcessStartInfo(uesave)
            {
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
                throw new Exception(error);
            }

            byte[] fileData = GVASToSav(File.ReadAllBytes(tmpGVAS), saveType);

            File.WriteAllBytes(saveFile, fileData);
            GC.Collect();

        }

        public static (string, string) InspectWorldMetadata(byte[] data)
        {
            var parser = Deserialize(data);

            var subsection = parser["root"]["properties"]["SaveData"]["Struct"]["value"]["Struct"];

            var worldName = subsection["WorldName"]["Str"]["value"];
            var playerName = subsection["HostPlayerName"]["Str"]["value"];

            return (worldName, playerName);
        }

        public static Dictionary<string, string> InspectWorld(byte[] data)
        {
            // parsing this json properly takes many GB of memory, do a partial parsing.
            Dictionary<string, string> players = new Dictionary<string, string>();

            using (MemoryStream ms = new MemoryStream(data))
            using (StreamReader sr = new StreamReader(ms))
            using (JsonTextReader reader = new JsonTextReader(sr))
            {
                List<string> stack = new List<string>();
                string stackLocation()
                {
                    string position = "";
                    foreach (string entry in stack)
                    {
                        position += entry + "/";
                    }
                    return position;
                }

                string property = null;
                const string target = "root/properties/worldSaveData/Struct/value/Struct/CharacterSaveParameterMap/Map/";
                const string internal_target = target + "*/struct_id/value/Struct/Struct/RawData/Struct/value/RawDataParsed/props/SaveParameter/Struct/value/Struct/";
                const string guid_key = target + "*/struct_id/key/Struct/Struct/PlayerUId/Struct/value/Guid/";
                const string is_player_key = internal_target + "IsPlayer/Bool/value/";
                const string nickname_key = internal_target + "NickName/Str/value/";

                string guid_value = null;
                string nickname_value = null;

                string location = "";
                while (reader.Read())
                {
                    switch (reader.TokenType)
                    {
                        case JsonToken.PropertyName:
                            property = (string)reader.Value;
                            location = stackLocation() + property + "/";

                            if (target.StartsWith(location) || location.StartsWith(target))
                            {
                                switch (location)
                                {
                                    case guid_key:
                                        reader.Skip();
                                        guid_value = ((string)reader.Value).Replace("-", "").ToUpper();
                                        break;
                                    case nickname_key:
                                        reader.Skip();
                                        nickname_value = (string)reader.Value;
                                        break;
                                    case is_player_key:
                                        reader.Skip();
                                        if ((bool)reader.Value == true)
                                        {
                                            players[guid_value] = nickname_value;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                reader.Skip();
                                reader.Skip();
                                property = null;
                            }
                            break;
                        case JsonToken.StartObject:
                            if (property != null)
                            {
                                stack.Add(property);
                            }
                            break;
                        case JsonToken.StartArray:
                            if (property != null)
                            {
                                stack.Add("*");
                            }
                            break;
                        case JsonToken.EndObject:
                        case JsonToken.EndArray:
                            if (property != null && stack.Count != 0)
                            {
                                stack.RemoveAt(stack.Count - 1);
                            }
                            break;
                    }
                }
            }
            GC.Collect();

            return players;
        }

        public static byte[] TransferAppearance(byte[] destination, byte[] source)
        {
            var dstData = Deserialize(destination);
            var srcData = Deserialize(source);

            var appearance = srcData["root"]["properties"]["SaveData"]["Struct"]["value"]["Struct"]["PlayerCharacterMakeData"];
            dstData["root"]["properties"]["SaveData"]["Struct"]["value"]["Struct"]["PlayerCharacterMakeData"] = appearance;

            byte[] newSave = Serialize(dstData);
            return newSave;
        }

        public static byte[] RenamePlayer(byte[] destination, string oldName, string newName)
        {
            // parsing this json properly takes many GB of memory, do a stream string replace instead.

            newName = newName.Replace("\"", "'").Replace("\\", "");

            var prefix = "\"NickName\":{\"Str\":{\"value\":\"";
            var suffix = "\"}}";

            var oldData = Encoding.UTF8.GetBytes(prefix + oldName + suffix);
            var newData = Encoding.UTF8.GetBytes(prefix + newName + suffix);

            var renamed = false;

            var m = 0;
            using (MemoryStream i = new MemoryStream(destination))
            using (MemoryStream o = new MemoryStream())
            {
                int b;
                while ((b = i.ReadByte()) != -1)
                {
                    if (b == oldData[m])
                    {
                        m += 1;
                        if (m == oldData.Length)
                        {
                            o.Write(newData, 0, newData.Length);
                            renamed = true;
                            m = 0;
                        }
                    }
                    else
                    {
                        if (m != 0)
                        {
                            o.Write(oldData, 0, m);
                        }
                        o.WriteByte((byte)b);
                        m = 0;
                    }
                }
                destination = o.ToArray();
            }

            if(!renamed)
            {
                throw new Exception("Specified name couldnt be found, nothing was changed.");
            }

            return destination;
        }
    }
}
