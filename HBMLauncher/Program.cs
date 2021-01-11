using System;
using System.Collections.Generic;
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
            Application.Run(new MainForm());
        }

        public static List<Saves> saves;
        public static class Data
        {
            public static bool isSave { get; set; }
            public static string ip { get; set; }
            public static string nickname { get; set; }
            public static int numberSelection { get; set; }
        }
    }
}
