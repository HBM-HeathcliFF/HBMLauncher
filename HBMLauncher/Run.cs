using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace HBMLauncher
{
    public partial class Run : Form
    {
        public Run()
        {
            InitializeComponent();
            int count = 0;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\HBMLauncher\saves"))
            {
                count = Convert.ToInt32(key.GetValue("count")) - 1;
            }
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey($@"Software\HBMLauncher\saves\save{count}"))
            {
                iptb.Text = key.GetValue("ip").ToString();
                nicktb.Text = key.GetValue("nickname").ToString();
            }
            Program.Data.isSave = false;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Program.Data.ip = iptb.Text;
            Program.Data.nickname = nicktb.Text;
            Program.Data.isSave = true;
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}