using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HBMLauncher
{
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            nameL.Text += $"{Program.saves[Program.Data.numberSelection].GetName()}";
            gtaPathL.Text += $"{Program.saves[Program.Data.numberSelection].GetGtaPath()}";
            folderBtn.Location = new Point(gtaPathL.Location.X + gtaPathL.Size.Width + 3, folderBtn.Location.Y);
            tbip.Text = $"{Program.saves[Program.Data.numberSelection].GetIp()}";
            tbnickname.Text = $"{Program.saves[Program.Data.numberSelection].GetNickname()}";
            cleopCB.Items.Add("Выкл");
            cleopCB.Items.Add("Вкл");
            if (Program.saves[Program.Data.numberSelection].GetCleop() == 1) cleopCB.SelectedIndex = 1;
            else cleopCB.SelectedIndex = 0;
            csoundsCB.Items.Add("Выкл");
            csoundsCB.Items.Add("Вкл");
            if (Program.saves[Program.Data.numberSelection].GetCsounds() == 1) csoundsCB.SelectedIndex = 1;
            else csoundsCB.SelectedIndex = 0;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            string str = gtaPathL.Text.Remove(0, 12);
            Program.saves[Program.Data.numberSelection].SetGtaPath(str);
            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{Program.Data.numberSelection + 1}").SetValue("path", str);
            Program.saves[Program.Data.numberSelection].SetIp(tbip.Text);
            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{Program.Data.numberSelection + 1}").SetValue("ip", tbip.Text);
            Program.saves[Program.Data.numberSelection].SetNickname(tbnickname.Text);
            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{Program.Data.numberSelection + 1}").SetValue("nickname", tbnickname.Text);
            Program.saves[Program.Data.numberSelection].SetCleop(cleopCB.SelectedIndex);
            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{Program.Data.numberSelection + 1}").SetValue("cleop", cleopCB.SelectedIndex);
            Program.saves[Program.Data.numberSelection].SetCsounds(csoundsCB.SelectedIndex);
            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{Program.Data.numberSelection + 1}").SetValue("csounds", csoundsCB.SelectedIndex);

            Close();
        }

        private void FolderBtn_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    try
                    {
                        if (File.Exists($@"{fbd.SelectedPath}\samp.exe") && File.Exists($@"{fbd.SelectedPath}\gta_sa.exe"))
                        {
                            gtaPathL.Text = $"Путь к GTA: {fbd.SelectedPath}";
                            folderBtn.Location = new Point(gtaPathL.Location.X + gtaPathL.Size.Width + 3, folderBtn.Location.Y);
                        }
                    }
                    catch (UnauthorizedAccessException) { }
                    catch (Exception) { }
                }
            }
        }
    }
}