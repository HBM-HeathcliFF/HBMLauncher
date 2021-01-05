using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace HBMLauncher
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\HBMLauncher"))
                {
                    if (File.Exists($@"{key.GetValue("path")}\samp.exe"))
                        Application.Run(new Form1());
                    else
                    {
                        Application.Run(new StartWin());
                        if (Data.isNext) Application.Run(new Form1());
                    }
                }
            }
            catch (NullReferenceException)
            {
                Registry.CurrentUser.CreateSubKey(@"Software\HBMLauncher\saves").SetValue("count", 0);
                Application.Run(new StartWin());
                if (Data.isNext) Application.Run(new Form1());
            }
        }

        public static List<Saves> saves;
        public static class Data
        {
            public static string[] names;
            public static bool isNext { get; set; }
            public static bool isSave { get; set; }
            public static string ip { get; set; }
            public static string nickname { get; set; }
            public static int numberSelection { get; set; }
        }
    }
}
