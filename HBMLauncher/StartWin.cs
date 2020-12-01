using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace HBMLauncher
{
    public partial class StartWin : Form
    {
        public StartWin()
        {
            InitializeComponent();
            Program.Data.isNext = false;
        }

        private void Field_TextChanged(object sender, EventArgs e)
        {
            if (field.Text != "") next.Enabled = true;
            else next.Enabled = false;
        }

        private void Overview_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    try
                    {
                        field.Text = fbd.SelectedPath;
                    }
                    catch (UnauthorizedAccessException) { }
                    catch (Exception) { }
                }
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (File.Exists($@"{field.Text}\samp.exe"))
            {
                Registry.CurrentUser.CreateSubKey(@"Software\HBMLauncher").SetValue("path", field.Text);
                Program.Data.isNext = true;
                Close();
            }
            else
            {
                MessageBox.Show("Указанная папка не GTA", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
