﻿using HBMLRunFile.Properties;
using System;
using System.Diagnostics;
using System.IO;

namespace HBMLRunFile
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string gtaPath, ip, nickname, binderPath, macrosPath, sensfix;
            int save = 0, cleop, csounds, radar;

            //Поиск сейва
            int countSaves = 0;
            string filepath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\HBMLauncher\saves"))
                countSaves = (int)key.GetValue("count");
            for (int i = 1; i < countSaves + 1; i++)
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey($@"Software\HBMLauncher\saves\save{i}"))
                {
                    if (key.GetValue("filepath").ToString() == filepath)
                    {
                        save = i;
                        break;
                    }
                }
            }

            //Получение данных из найденного сейва
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey($@"Software\HBMLauncher\saves\save{save}"))
            {
                gtaPath = (string)key.GetValue("path");
                cleop = Convert.ToInt32(key.GetValue("cleop"));
                csounds = Convert.ToInt32(key.GetValue("csounds"));
                radar = Convert.ToInt32(key.GetValue("radar"));
                binderPath = (string)key.GetValue("binder");
                macrosPath = (string)key.GetValue("macros");
                sensfix = (string)key.GetValue("sensfix");
                ip = (string)key.GetValue("ip");
                nickname = (string)key.GetValue("nickname");
            }

            //Передача значений в SA-MP лаунчер через реестр
            Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\SAMP").SetValue("gta_sa_exe", $@"{gtaPath}\gta_sa.exe");
            if (nickname != "")
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\SAMP").SetValue("PlayerName", nickname);

            //CustomSounds до запуска SA-MP (без исключений)
            string[] text = null, def_vals = null, filesToCopy = null;
            string APPath = "";
            int filesCount = 0;
            try
            {
                if (csounds == 1)
                {
                    APPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\SA-MP Audio Plugin";
                    filesCount = Directory.GetFiles($@"{APPath}\audiopacks\default_pack").Length;
                    File.Delete($@"{APPath}\audiopacks\default_pack\maushi8.mp3");
                    using (var streamReader = new StreamReader(new FileStream($@"{APPath}\audio.ini", FileMode.Open)))
                    {
                        text = streamReader.ReadToEnd().Split('\n');
                    }
                    bool isContains = false;
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i].Contains("stream_files_from_internet"))
                        {
                            text[i] = "stream_files_from_internet = 0";
                            File.WriteAllLines($@"{APPath}\audio.ini", text);
                            isContains = true;
                            break;
                        }
                    }
                    if (!isContains)
                    {
                        using (var streamWriter = new StreamWriter(new FileStream($@"{APPath}\audio.ini", FileMode.Append)))
                        {
                            if (text[text.Length - 1] != "") streamWriter.WriteLine(Environment.NewLine + "stream_files_from_internet = 0");
                            else streamWriter.WriteLine("stream_files_from_internet = 0");
                        }
                    }

                    def_vals = File.ReadAllLines($@"{APPath}\audiopacks\default_pack\default_pack.ini");
                    filesToCopy = Directory.GetFiles($@"{gtaPath}\Sounds");
                    long size = 0;
                    string ext = "";

                    foreach (var file1 in filesToCopy)
                    {
                        var crc32 = new Crc32();
                        var hash = String.Empty;

                        using (var fs = File.Open(file1, FileMode.Open))
                            foreach (byte b in crc32.ComputeHash(fs)) hash += b.ToString("x2").ToLower();

                        size = new FileInfo(file1).Length;
                        for (int i = 0; i < def_vals.Length; i++)
                        {
                            if (def_vals[i].Contains(CutNameNR(file1, ref ext)))
                            {
                                def_vals[i] = $@"{CutNameNR(file1, ref ext)}.{ext}Size = {size}";
                                def_vals[i + 1] = $@"{CutNameNR(file1, ref ext)}.{ext}CRC = {hash}";
                                break;
                            }
                        }
                        File.Copy(file1, $@"{APPath}\audiopacks\default_pack\{CutName(file1)}", true);
                    }
                    File.WriteAllLines($@"{APPath}\audiopacks\default_pack\default_pack.ini", def_vals);
                }

                //Запуск Binder'а
                if (binderPath.Contains("ACiBinder") && binderPath.EndsWith(".exe"))
                    Process.Start(binderPath);
                else
                {
                    foreach (var process in Process.GetProcessesByName("AciBinder"))
                    {
                        if (binderPath == process.StartInfo.FileName) process.Kill();
                    }
                }

                //Запуск Macros'а
                if (macrosPath.Contains("HBM Macros") && macrosPath.EndsWith(".exe"))
                    Process.Start(macrosPath);
                else
                {
                    foreach (var process in Process.GetProcessesByName("HBM Macros"))
                    {
                        if (macrosPath == process.StartInfo.FileName) process.Kill();
                    }
                }

                //Настройка sensfix'а
                if (sensfix != "")
                {
                    string[] temp = sensfix.Split(' ');
                    string[] sens = new string[4];
                    sens[0] = " [sensfix]";
                    sens[1] = $" global={temp[0]}";
                    sens[2] = $" aiming_sniper={temp[1]}";
                    sens[3] = $" aiming={temp[2]}";
                    File.WriteAllLines($@"{gtaPath}\sensfix.ini", sens);
                }

                //Cleo-прорисовка (вызов исключений)
                bool isRun = false;
                foreach (var process in Process.GetProcessesByName("gta_sa"))
                {
                    if (gtaPath == process.StartInfo.FileName &&
                        File.Exists($@"{gtaPath}\cleo\SightDistance_by_0x688.cleo") &&
                        File.Exists($@"{gtaPath}\cleo\Timecyc.cs"))
                    {
                        isRun = true;
                    }
                }
                if (cleop == 0)
                {
                    if (File.Exists($@"{gtaPath}\cleo\Timecyc.cs"))
                    {
                        if (isRun) throw new Exception();
                        else File.Delete($@"{gtaPath}\cleo\Timecyc.cs");
                    }
                    if (File.Exists($@"{gtaPath}\cleo\SightDistance_by_0x688.cleo"))
                    {
                        if (isRun) throw new Exception();
                        else File.Delete($@"{gtaPath}\cleo\SightDistance_by_0x688.cleo");
                    }
                }
                else if (cleop == 1)
                {
                    if (!File.Exists($@"{gtaPath}\cleo\Timecyc.cs"))
                    {
                        if (isRun) throw new Exception();
                        else File.WriteAllBytes($@"{gtaPath}\cleo\Timecyc.cs", Resources.Timecyc);
                    }
                    if (!File.Exists($@"{gtaPath}\cleo\SightDistance_by_0x688.cleo"))
                    {
                        if (isRun) throw new Exception();
                        else File.WriteAllBytes($@"{gtaPath}\cleo\SightDistance_by_0x688.cleo", Resources.SightDistance_by_0x688);
                    }
                }

                //Радар
                if (radar == 0)
                {
                    if (File.Exists($@"{gtaPath}\InterfaceEditor.asi.bak"))
                    {
                        if (isRun) throw new Exception();
                        else File.Move($@"{gtaPath}\InterfaceEditor.asi.bak", $@"{gtaPath}\InterfaceEditor.asi");
                    }
                }
                else if (radar == 1)
                {
                    if (File.Exists($@"{gtaPath}\InterfaceEditor.asi"))
                    {
                        if (isRun) throw new Exception();
                        else File.Move($@"{gtaPath}\InterfaceEditor.asi", $@"{gtaPath}\InterfaceEditor.asi.bak");
                    }
                }

                //Запуск SA-MP
                Run(nickname, ip, gtaPath);

                //CustomSounds после запуска SA-MP (если не вызвалось исключение)
                if (csounds == 1)
                {
                    while (Directory.GetFiles($@"{APPath}\audiopacks\default_pack").Length < filesCount)
                    {
                        System.Threading.Thread.Sleep(5000);
                    }
                    foreach (var file1 in filesToCopy)
                    {
                        File.Copy(file1, $@"{APPath}\audiopacks\default_pack\{CutName(file1)}", true);
                    }
                    System.Threading.Thread.Sleep(5000);
                    File.WriteAllLines($@"{APPath}\audiopacks\default_pack\default_pack.ini", def_vals);
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("Не удалось внести изменения в указанную GTA, т.к. она уже открыта.\n" +
                                "Запустить лаунчер/GTA без замены файлов?", "Ошибка", System.Windows.Forms.MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Run(nickname, ip, gtaPath);
                    if (csounds == 1)
                    {
                        while (Directory.GetFiles($@"{APPath}\audiopacks\default_pack").Length < filesCount)
                        {
                            System.Threading.Thread.Sleep(5000);
                        }
                        foreach (var file1 in filesToCopy)
                        {
                            File.Copy(file1, $@"{APPath}\audiopacks\default_pack\{CutName(file1)}", true);
                        }
                        System.Threading.Thread.Sleep(5000);
                        File.WriteAllLines($@"{APPath}\audiopacks\default_pack\default_pack.ini", def_vals);
                    }
                }
            }
        }

        static void Run(string nickname, string ip, string gtaPath)
        {
            if (ip != "" && nickname != "")
            {
                string[] temp = new string[3];
                temp[0] = ip.Split(':')[0];
                temp[1] = ip.Split(':')[1];
                temp[2] = nickname;
                File.WriteAllLines($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\Resources\run.ini", temp, System.Text.Encoding.GetEncoding(1251));
                File.WriteAllBytes($@"{gtaPath}\HBMInjector.exe", Resources.HBMInjector);

                Process p1 = new Process();
                p1.StartInfo.FileName = "cmd";
                p1.StartInfo.Arguments = "/c cd /d \"" + gtaPath + "\" & HBMInjector.exe";
                p1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p1.EnableRaisingEvents = true;
                p1.Exited += (s, ev) =>
                {
                    while (Process.GetProcessesByName("HBMInjector").Length > 0) {}
                    File.Delete($@"{gtaPath}\HBMInjector.exe");
                };
                p1.Start();
            }
            else Process.Start($@"{gtaPath}\samp.exe");
        }

        static string CutName(string str)
        {
            char[] str1 = str.ToCharArray();
            for (int i = str1.Length - 1; i > -1; i--)
            {
                if (str1[i] == '\\')
                {
                    str = str.Remove(0, i + 1);
                    break;
                }
            }
            return str;
        }

        static string CutNameNR(string str, ref string extension)
        {
            char[] str1 = str.ToCharArray();
            for (int i = str1.Length - 1; i > -1; i--)
            {
                if (str1[i] == '.')
                {
                    extension = str.Substring(i + 1);
                    str = str.Remove(i, str.Length - i);
                }
                if (str1[i] == '\\')
                {
                    str = str.Remove(0, i + 1);
                    break;
                }
            }
            return str;
        }
    }
}