﻿using HBMLRunFile.Properties;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HBMLRunFile
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string gtaPath, ip, nickname;
            int slot = 0, cleop, csounds;

            //Поиск сейва
            int countSaves = 0;
            string filepath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\HBMLauncher\saves"))
                countSaves = (int)key.GetValue("count");
            for (int i = 1; i < countSaves + 1; i++)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey($@"Software\HBMLauncher\saves\save{i}"))
                {
                    if (key.GetValue("filepath").ToString() == filepath)
                    {
                        slot = i;
                        break;
                    }
                }
            }

            //Получение данных из найденного сейва
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey($@"Software\HBMLauncher\saves\save{slot}"))
            {
                gtaPath = (string)key.GetValue("path");
                cleop = Convert.ToInt32(key.GetValue("cleop"));
                csounds = Convert.ToInt32(key.GetValue("csounds"));
                slot = Convert.ToInt32(key.GetValue("slot"));
                ip = (string)key.GetValue("ip");
                nickname = (string)key.GetValue("nickname");
            }

            //Передача значений в SA-MP лаунчер через реестр
            Registry.CurrentUser.CreateSubKey(@"Software\SAMP").SetValue("gta_sa_exe", $@"{gtaPath}\gta_sa.exe");
            if (nickname != "")
                Registry.CurrentUser.CreateSubKey(@"Software\SAMP").SetValue("PlayerName", nickname);
            string[] files = Directory.GetFiles($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\slot{slot}");

            //CustomSounds до запуска SA-MP (без исключений)
            string[] text = null, def_vals = null, filesToCopy = null;
            string APPath = "";
            int filesCount = 0;
            try
            {
                APPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\SA-MP Audio Plugin";
                filesCount = Directory.GetFiles($@"{APPath}\audiopacks\default_pack").Length;
                if (csounds == 1)
                {
                    File.Delete($@"{APPath}\audiopacks\default_pack\maushi8.mp3");
                    using (var streamReader = new StreamReader(new FileStream($@"{APPath}\audio.ini", FileMode.Open)))
                    {
                        text = streamReader.ReadToEnd().Split('\n');
                    }
                    bool isConstains = false;
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i].Contains("stream_files_from_internet"))
                        {
                            text[i] = "stream_files_from_internet = 0";
                            File.WriteAllLines($@"{APPath}\audio.ini", text);
                            isConstains = true;
                            break;
                        }
                    }
                    if (!isConstains)
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

                //Cleo-прорисовка (вызов исключений)
                if (cleop == 0 && File.Exists($@"{gtaPath}\cleo\SightDistance_by_0x688.cleo")
                               && File.Exists($@"{gtaPath}\cleo\Timecyc.cs"))
                {
                    File.Delete($@"{gtaPath}\cleo\SightDistance_by_0x688.cleo");
                    File.Delete($@"{gtaPath}\cleo\Timecyc.cs");
                }
                else if (cleop == 1 && !File.Exists($@"{gtaPath}\cleo\SightDistance_by_0x688.cleo")
                                    && !File.Exists($@"{gtaPath}\cleo\Timecyc.cs"))
                {
                    File.WriteAllBytes($@"{gtaPath}\cleo\SightDistance_by_0x688.cleo", Resources.SightDistance_by_0x688);
                    File.WriteAllBytes($@"{gtaPath}\cleo\Timecyc.cs", Resources.Timecyc);
                }

                Process[] procs = Process.GetProcessesByName("gta_sa.exe");
                foreach (var proc in procs)
                {
                    if (proc.StartInfo.FileName == $@"{gtaPath}\gta_sa.exe")
                        throw new Exception();
                }

                //Скрипт замены файлов карты (если не вызвалось исключение)
                FileStream file = new FileStream($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\save.txt", FileMode.Create);
                Encoding win1251 = Encoding.GetEncoding(1251);
                using (StreamWriter fout = new StreamWriter(file, win1251))
                {
                    fout.WriteLine("-open \"" + TwoSlashes($@"{gtaPath}\SAMP\CUSTOM.img") + "\"");
                    for (int i = 0; i < files.Length; i++)
                    {
                        fout.WriteLine("-delete \"" + CutName(files[i]) + "\'");
                        fout.WriteLine("-import \"" + TwoSlashes($@"{files[i]}") + "\"");
                    }
                    fout.WriteLine("-rebuild");
                    fout.WriteLine("-close");
                }

                //Батник замены файлов карты (если не вызвалось исключение)
                file = new FileStream($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\save.bat", FileMode.Create);
                using (StreamWriter fout = new StreamWriter(file))
                {
                    fout.WriteLine("chcp 65001");
                    fout.WriteLine("\"" + $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\img.exe" + "\" -script \"" + $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\save.txt" + "\"");
                }

                //Выполнение батника замены файлов карты (если не вызвалось исключение)
                bool contin = false;
                Process p = new Process();
                p.StartInfo.FileName = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\save.bat";
                p.EnableRaisingEvents = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Exited += (s, e) =>
                {
                    File.Delete($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\save.txt");
                    File.Delete($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\save.bat");
                    contin = true;

                    //Запуск SA-MP
                    if (ip != "" && nickname != "")
                    {
                        Process p1 = new Process();
                        p1.StartInfo.FileName = "cmd";
                        p1.StartInfo.Arguments = "/c \"" + $@"{gtaPath}\samp.exe" + "\" " + ip;
                        p1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        p1.Start();
                    }
                    else Process.Start($@"{gtaPath}\samp.exe");
                };
                p.Start();
                while (!contin)
                {
                    Thread.Sleep(100);
                }

                //CustomSounds после запуска SA-MP (если не вызвалось исключение)
                if (csounds == 1)
                {
                    while (Directory.GetFiles($@"{APPath}\audiopacks\default_pack").Length < filesCount)
                    {
                        Thread.Sleep(5000);
                    }
                    foreach (var file1 in filesToCopy)
                    {
                        File.Copy(file1, $@"{APPath}\audiopacks\default_pack\{CutName(file1)}", true);
                    }
                    Thread.Sleep(5000);
                    File.WriteAllLines($@"{APPath}\audiopacks\default_pack\default_pack.ini", def_vals);
                }
            }
            catch (Exception)
            {
                DialogResult result = MessageBox.Show("Не удалось внести изменения в указанную GTA, т.к. она уже открыта.\n" +
                                "Запустить лаунчер/GTA без замены файлов?", "Ошибка", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (ip != "" && nickname != "")
                    {
                        Process p1 = new Process();
                        p1.StartInfo.FileName = "cmd";
                        p1.StartInfo.Arguments = "/c \"" + $@"{gtaPath}\samp.exe" + "\" " + ip;
                        p1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        p1.Start();
                    }
                    else Process.Start($@"{gtaPath}\samp.exe");
                    if (csounds == 1)
                    {
                        while (Directory.GetFiles($@"{APPath}\audiopacks\default_pack").Length < filesCount)
                        {
                            Thread.Sleep(5000);
                        }
                        foreach (var file1 in filesToCopy)
                        {
                            File.Copy(file1, $@"{APPath}\audiopacks\default_pack\{CutName(file1)}", true);
                        }
                        Thread.Sleep(5000);
                        File.WriteAllLines($@"{APPath}\audiopacks\default_pack\default_pack.ini", def_vals);
                    }
                }
            }
        }

        static string TwoSlashes(string OSStr)
        {
            int index = 0;
            while (OSStr.IndexOf("\\", index) != -1)
            {
                if (index >= OSStr.Length)
                    break;
                index = OSStr.IndexOf("\\", index);
                OSStr = OSStr.Insert(OSStr.IndexOf("\\", index) + 1, "\\");
                index += 2;
            }
            return OSStr;
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