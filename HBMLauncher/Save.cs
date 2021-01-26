using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace HBMLauncher
{
    public partial class Save : Form
    {
        public Save()
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
            if (File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\Nicknames.txt"))
            {
                AutoCompleteStringCollection nicknames = new AutoCompleteStringCollection();
                nicknames.AddRange(File.ReadAllLines($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\Nicknames.txt", Encoding.GetEncoding(1251)));
                nicktb.AutoCompleteCustomSource = nicknames;
            }
            AutoCompleteStringCollection source = new AutoCompleteStringCollection()
            {
                "185.71.66.95:7771",
                "185.71.66.95:7772",
                "185.71.66.95:7773",
                "185.71.66.95:7774",
                "185.71.66.95:7775",
                "185.71.66.95:7777"
            };
            iptb.AutoCompleteCustomSource = source;
            Program.Data.isSave = false;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Program.Data.ip = iptb.Text;
            Program.Data.nickname = nicktb.Text;
            string temp = File.ReadAllText($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\Nicknames.txt");
            if (!temp.Contains(nicktb.Text))
            {
                using (StreamWriter fout = new StreamWriter($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\Nicknames.txt", true))
                {
                    fout.WriteLine(nicktb.Text);
                }
            }
            Program.Data.isSave = true;
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }
    }
}