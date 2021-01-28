using HBMLauncher.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HBMLauncher
{
    public partial class Show : Form
    {
        int count = 0;
        bool isFirstChange = true;
        public Show()
        {
            InitializeComponent();
        }

        private void Show_Load(object sender, EventArgs e)
        {
            MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\HBMLauncher\saves"))
            {
                count = (int)key.GetValue("count");
            }
            Program.saves = new List<Saves>();
            for (int i = 0; i < count; i++)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey($@"Software\HBMLauncher\saves\save{i + 1}"))
                {
                    Program.saves.Add(new Saves(CutName(key.GetValue("filepath").ToString()),
                                      (int)key.GetValue("cleop"),
                                      (int)key.GetValue("csounds"),
                                      key.GetValue("ip").ToString(),
                                      key.GetValue("nickname").ToString(),
                                      key.GetValue("path").ToString()));
                    listBox1.Items.Add(Program.saves[i].GetName());
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                Program.Data.numberSelection = listBox1.SelectedIndex;
                Enabled = false;
                Edit edit = new Edit();
                edit.Show();
                edit.Activate();
                edit.FormClosed += (obj1, args1) =>
                {
                    Enabled = true;
                    listBox1.Items.Clear();
                    for (int i = 0; i < Program.saves.Count; i++)
                    {
                        listBox1.Items.Add(Program.saves[i].GetName());
                    }
                    listBox1.SelectedIndex = Program.Data.numberSelection;
                };
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить сохранение?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey($@"Software\HBMLauncher\saves\save{listBox1.SelectedIndex + 1}"))
                {
                    File.Delete(key.GetValue("filepath").ToString());
                }
                if (listBox1.SelectedIndex >= 0)
                {
                    count--;
                    Registry.CurrentUser.CreateSubKey(@"Software\HBMLauncher\saves").SetValue("count", count);
                    Registry.CurrentUser.DeleteSubKeyTree($@"Software\HBMLauncher\saves\save{listBox1.SelectedIndex + 1}");
                    Program.saves.Remove(Program.saves[listBox1.SelectedIndex]);
                    if (listBox1.SelectedIndex < count)
                    {
                        for (int i = listBox1.SelectedIndex + 2; i < count + 2; i++)
                        {
                            RenameSubKey(Registry.CurrentUser, $@"Software\HBMLauncher\saves\save{i}", $@"Software\HBMLauncher\saves\save{i - 1}");
                        }
                    }
                    listBox1.Items.Clear();
                    for (int i = 0; i < Program.saves.Count; i++)
                    {
                        listBox1.Items.Add(Program.saves[i].GetName());
                    }
                }
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFirstChange)
            {
                removeBtn.BackgroundImage = Resources.DeleteBA;
                editBtn.BackgroundImage = Resources.EditBA;
                removeBtn.Enabled = true;
                editBtn.Enabled = true;
                isFirstChange = false;
            }
            info.Text = "Информация о выбранном сохранении:\n" +
                        $"Название: {Program.saves[listBox1.SelectedIndex].GetName()}\n" +
                        $"Путь к GTA: {Program.saves[listBox1.SelectedIndex].GetGtaPath()}\n" +
                        $"IP: {Program.saves[listBox1.SelectedIndex].GetIp()}\n" +
                        $"Nickname: {Program.saves[listBox1.SelectedIndex].GetNickname()}\n";
            if (Program.saves[listBox1.SelectedIndex].GetCleop() == 1)
                info.Text += "Cleo-прорисовка: Вкл \n";
            else info.Text += "Cleo-прорисовка: Выкл \n";
            if (Program.saves[listBox1.SelectedIndex].GetCsounds() == 1)
                info.Text += "CustomSounds: Вкл \n";
            else info.Text += "CustomSounds: Выкл \n";
        }

        private void RemoveBtn_MouseEnter(object sender, EventArgs e)
        {
            if (!isFirstChange)
                removeBtn.BackgroundImage = Resources.DeleteBN;
        }
        private void RemoveBtn_MouseLeave(object sender, EventArgs e)
        {
            if (!isFirstChange)
                removeBtn.BackgroundImage = Resources.DeleteBA;
        }
        private void EditBtn_MouseEnter(object sender, EventArgs e)
        {
            if (!isFirstChange)
                editBtn.BackgroundImage = Resources.EditBN;
        }
        private void EditBtn_MouseLeave(object sender, EventArgs e)
        {
            if (!isFirstChange)
                editBtn.BackgroundImage = Resources.EditBA;
        }

        #region Header

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void MenuHorizontal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void MinBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void MaxBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            normalBtn.Visible = true;
            maxBtn.Visible = false;
        }
        private void NormalBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            maxBtn.Visible = true;
            normalBtn.Visible = false;
        }

        #endregion

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

        string CutName(string str)
        {
            char[] str1 = str.ToCharArray();
            for (int i = str1.Length - 1; i > -1; i--)
            {
                if (str1[i] == '.')
                {
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

        public bool RenameSubKey(RegistryKey parentKey,
            string subKeyName, string newSubKeyName)
        {
            CopyKey(parentKey, subKeyName, newSubKeyName);
            parentKey.DeleteSubKeyTree(subKeyName);
            return true;
        }

        public bool CopyKey(RegistryKey parentKey,
            string keyNameToCopy, string newKeyName)
        {
            RegistryKey destinationKey = parentKey.CreateSubKey(newKeyName);
            RegistryKey sourceKey = parentKey.OpenSubKey(keyNameToCopy);
            RecurseCopyKey(sourceKey, destinationKey);
            return true;
        }

        private void RecurseCopyKey(RegistryKey sourceKey, RegistryKey destinationKey)
        {
            foreach (string valueName in sourceKey.GetValueNames())
            {
                object objValue = sourceKey.GetValue(valueName);
                RegistryValueKind valKind = sourceKey.GetValueKind(valueName);
                destinationKey.SetValue(valueName, objValue, valKind);
            }
            foreach (string sourceSubKeyName in sourceKey.GetSubKeyNames())
            {
                RegistryKey sourceSubKey = sourceKey.OpenSubKey(sourceSubKeyName);
                RegistryKey destSubKey = destinationKey.CreateSubKey(sourceSubKeyName);
                RecurseCopyKey(sourceSubKey, destSubKey);
            }
        }
    }
}