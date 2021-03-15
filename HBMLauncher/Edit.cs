using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HBMLauncher
{
    public partial class Edit : Form
    {
        string sensfix = "";

        public Edit()
        {
            InitializeComponent();
        }
        string CutNameWE(string str)
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
        private void MoveButton(Label label, Button btnF, Button btnC)
        {
            btnF.Location = new Point(label.Location.X + label.Size.Width + 3, btnF.Location.Y);
            btnC.Location = new Point(btnF.Location.X + 28, btnC.Location.Y);
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
            radarCB.Items.Add("Нет");
            radarCB.Items.Add("Да");
            if (Program.saves[Program.Data.numberSelection].GetRadar() == 1) radarCB.SelectedIndex = 1;
            else radarCB.SelectedIndex = 0;
            binderPathL.Text += $"{Program.saves[Program.Data.numberSelection].GetBinderPath()}";
            MoveButton(binderPathL, binderBtn, nbinderBtn);
            macrosPathL.Text += $"{Program.saves[Program.Data.numberSelection].GetMacrosPath()}";
            MoveButton(macrosPathL, macrosBtn, nmacrosBtn);
            if (binderPathL.Text == "Путь к биндеру: ")
                nbinderBtn.Visible = false;
            if (macrosPathL.Text == "Путь к макросу: ")
                nmacrosBtn.Visible = false;
            sensfix = Program.saves[Program.Data.numberSelection].GetSensfix();
            if (sensfix == "")
                nsensfixBtn.Visible = false;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            Program.saves[Program.Data.numberSelection].SetGtaPath(gtaPathL.Text.Remove(0, 12));
            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{Program.Data.numberSelection + 1}").SetValue("path", gtaPathL.Text.Remove(0, 12));
            Program.saves[Program.Data.numberSelection].SetIp(tbip.Text);
            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{Program.Data.numberSelection + 1}").SetValue("ip", tbip.Text);
            Program.saves[Program.Data.numberSelection].SetNickname(tbnickname.Text);
            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{Program.Data.numberSelection + 1}").SetValue("nickname", tbnickname.Text);
            Program.saves[Program.Data.numberSelection].SetCleop(cleopCB.SelectedIndex);
            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{Program.Data.numberSelection + 1}").SetValue("cleop", cleopCB.SelectedIndex);
            Program.saves[Program.Data.numberSelection].SetCsounds(csoundsCB.SelectedIndex);
            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{Program.Data.numberSelection + 1}").SetValue("csounds", csoundsCB.SelectedIndex);
            Program.saves[Program.Data.numberSelection].SetRadar(radarCB.SelectedIndex);
            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{Program.Data.numberSelection + 1}").SetValue("radar", radarCB.SelectedIndex);
            Program.saves[Program.Data.numberSelection].SetBinderPath(binderPathL.Text.Remove(0, 16));
            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{Program.Data.numberSelection + 1}").SetValue("binder", binderPathL.Text.Remove(0, 16));
            Program.saves[Program.Data.numberSelection].SetMacrosPath(macrosPathL.Text.Remove(0, 16));
            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{Program.Data.numberSelection + 1}").SetValue("macros", macrosPathL.Text.Remove(0, 16));
            Program.saves[Program.Data.numberSelection].SetSensfix(sensfix);
            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{Program.Data.numberSelection + 1}").SetValue("sensfix", sensfix);

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
        private void BinderBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Укажите путь к биндеру",
                InitialDirectory = @"C:\"
            };
            ofd.Filter = "Executable files (*.exe)|*.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                binderPathL.Text = $"Путь к биндеру: {ofd.FileName}";
                MoveButton(binderPathL, binderBtn, nbinderBtn);
                nbinderBtn.Visible = true;
            }
        }
        private void MacrosBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Укажите путь к макросу",
                InitialDirectory = @"C:\"
            };
            ofd.Filter = "Executable files (*.exe)|*.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                macrosPathL.Text = $"Путь к макросу: {ofd.FileName}";
                MoveButton(macrosPathL, macrosBtn, nmacrosBtn);
                nmacrosBtn.Visible = true;
            }
        }
        private void SensfixBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK &&
                    CutNameWE(openFileDialog1.FileName) == "sensfix.ini")
            {
                string[] temp = File.ReadAllLines(openFileDialog1.FileName);
                for (int i = 1; i < 4; i++)
                {
                    sensfix += temp[i].Split('=')[1] + " ";
                }
                sensfix.Remove(sensfix.Length - 1);
                nsensfixBtn.Visible = true;
            }
            else
            {
                MessageBox.Show("Указанный файл не sensfix.ini", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NbinderBtn_Click(object sender, EventArgs e)
        {
            binderPathL.Text = "Путь к биндеру: ";
            MoveButton(binderPathL, binderBtn, nbinderBtn);
            nbinderBtn.Visible = false;
        }
        private void NmacrosBtn_Click(object sender, EventArgs e)
        {
            macrosPathL.Text = "Путь к макросу: ";
            MoveButton(macrosPathL, macrosBtn, nmacrosBtn);
            nmacrosBtn.Visible = false;
        }
        private void NsensfixBtn_Click(object sender, EventArgs e)
        {
            sensfix = "";
            nsensfixBtn.Visible = false;
        }
    }
}