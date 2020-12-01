using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HBMLauncher
{
    public partial class Slots : Form
    {
        string instPath;
        string[] pnames;
        public Slots()
        {
            InitializeComponent();
            field.Text = $@"Слот {Program.Data.slotnumber}";
            done.Enabled = false;
            Program.Data.isDone = false;
        }

        private void Choose_Click(object sender, EventArgs e)
        {
            if (instPath == "") instPath = @"C:\";
            OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Выберите файлы",
                InitialDirectory = instPath
            };
            ofd.Filter = "Txd (*.txd)|*.txd";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pnames = ofd.FileNames;
                    Program.Data.names = ofd.SafeFileNames;
                    instPath = Path.GetDirectoryName(ofd.FileName);

                    if (pnames.Length < 144)
                        MessageBox.Show("Вы выбрали не все файлы карты, их должно быть 144", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (pnames.Length > 144)
                        MessageBox.Show("Вы указали слишком много файлов, файлов карты должно быть 144", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        FileStream file = new FileStream($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\1.bat", FileMode.Create);
                        Encoding win866 = Encoding.GetEncoding(866);
                        StreamWriter fout = new StreamWriter(file, win866);
                        fout.WriteLine("@echo off");
                        for (int i = 0; i < pnames.Length; i++)
                        {
                            fout.WriteLine("copy \"" + pnames[i] + "\" \"" + $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\Slot{Program.Data.slotnumber}" + "\"");
                        }
                        fout.Close();
                        done.Enabled = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Произошла непредвиденная ошибка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Done_Click(object sender, EventArgs e)
        {
            Program.Data.isDone = true;
            Program.Data.slotname = field.Text;
            Process p = new Process();
            p.StartInfo.FileName = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\1.bat";
            p.EnableRaisingEvents = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Exited += (s1, ev1) =>
            {
                Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\slot{Program.Data.slotnumber}").SetValue("name", Program.Data.slotname);
                Close();
            };
            p.Start();
        }

        private void Field_TextChanged(object sender, EventArgs e)
        {
            if (field.Text.Length > 20)
            {
                field.Text = field.Text.Remove(19, 1);
                field.SelectionStart = field.Text.Length;
            }
        }
    }
}
