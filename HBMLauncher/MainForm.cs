﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using Microsoft.Win32;
using HBMLauncher.Properties;
using System.Text;
using System.Runtime.InteropServices;

namespace HBMLauncher
{
    public partial class MainForm : Form
    {
        string gtaPath, binderPath = "", macrosPath = "", sensfix = "";
        int count, cleopr, csounds, radar;
        public MainForm()
        {
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            Directory.CreateDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher");
            Directory.CreateDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\Resources");
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\HBMLauncher"))
                {
                    gtaPath = key.GetValue("path").ToString();
                    position.Text = "Текущее расположение GTA:\n" + gtaPath;
                }
            }
            catch (Exception) 
            {
                position.Text = "Текущее расположение GTA:\n" + "Не указано.";
            }

            for (Opacity = 0; Opacity < 100; Opacity += 0.02)
            {
                await Task.Delay(10);
            }
            await Task.Run(() =>
            {
                if (!File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\Resources\img.exe"))
                    File.WriteAllBytes($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\Resources\img.exe", Resources.img);
                if (!File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\Resources\zlib1.dll"))
                    File.WriteAllBytes($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\Resources\zlib1.dll", Resources.zlib1);
            });
        }

        private void BinderCB_CheckedChanged(object sender, EventArgs e)
        {
            if (binderCB.Checked)
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Title = "Укажите путь к биндеру",
                    InitialDirectory = @"C:\"
                };
                ofd.Filter = "Executable files (*.exe)|*.exe";
                if (ofd.ShowDialog() == DialogResult.OK) binderPath = ofd.FileName;
                else binderCB.Checked = false;
            }
        }
        private void MacrosCB_CheckedChanged(object sender, EventArgs e)
        {
            if (macrosCB.Checked)
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Title = "Укажите путь к макросу",
                    InitialDirectory = @"C:\"
                };
                ofd.Filter = "Executable files (*.exe)|*.exe";
                if (ofd.ShowDialog() == DialogResult.OK) macrosPath = ofd.FileName;
                else macrosCB.Checked = false;
            }
        }
        private void SensfixCB_CheckedChanged(object sender, EventArgs e)
        {
            if (sensfixCB.Checked)
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
                }
                else
                {
                    MessageBox.Show("Указанный файл не sensfix.ini", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sensfixCB.Checked = false;
                }
            }
        }

        #region Menu
        string CutName(string str, ref string pn)
        {
            char[] str1 = str.ToCharArray();
            for (int i = str1.Length - 1; i > -1; i--)
            {
                if (str1[i] == '.')
                {
                    str = str.Remove(i, str.Length - i);
                    pn = str;
                }
                if (str1[i] == '\\')
                {
                    str = str.Remove(0, i + 1);
                    break;
                }
            }
            return str;
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

        private void LogoBtn_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher");
            if (File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\img.exe"))
                File.Delete($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\img.exe");
            if (File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\zlib1.dll"))
                File.Delete($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\zlib1.dll");
            foreach (var file in dir.GetFiles())
            {
                File.Delete($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\{file.Name}");
                File.WriteAllBytes($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\{file.Name}", Resources.HBMLRunFile);
            }

            int saves = 0;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\HBMLauncher\saves"))
            {
                saves = (int)key.GetValue("count");
            }
            for (int i = 0; i < saves; i++)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey($@"Software\HBMLauncher\saves\save{i + 1}"))
                {
                    if ((int)key.GetValue("cleop", -1) == -1)
                        Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{i + 1}").SetValue("cleop", 0);
                    if ((int)key.GetValue("csounds", -1) == -1)
                        Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{i + 1}").SetValue("csounds", 0);
                    if ((int)key.GetValue("radar", -1) == -1)
                        Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{i + 1}").SetValue("radar", 0);
                    if (key.GetValue("binder", "-1").ToString() == "-1")
                        Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{i + 1}").SetValue("binder", "");
                    if (key.GetValue("macros", "-1").ToString() == "-1")
                        Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{i + 1}").SetValue("macros", "");
                    if (key.GetValue("sensfix", "-1").ToString() == "-1")
                        Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{i + 1}").SetValue("sensfix", "");
                    if (key.GetValue("ip", "-1").ToString() == "-1")
                        Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{i + 1}").SetValue("ip", "");
                    if (key.GetValue("nickname", "-1").ToString() == "-1")
                        Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{i + 1}").SetValue("nickname", "");
                }
            }
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Выберите папку с GTA";
                DialogResult result = fbd.ShowDialog();
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    if (File.Exists($@"{fbd.SelectedPath}\samp.exe"))
                    {
                        gtaPath = fbd.SelectedPath;
                        Registry.CurrentUser.CreateSubKey(@"Software\HBMLauncher").SetValue("path", gtaPath);
                        position.Text = "Текущее расположение GTA:\n" + gtaPath;
                    }
                    else MessageBox.Show("Указанная папка не GTA", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\HBMLauncher\saves"))
                    count = (int)key.GetValue("count") + 1;
                if (cleop.Checked) cleopr = 1;
                else cleopr = 0;
                if (csoundsCB.Checked) csounds = 1;
                else csounds = 0;
                if (radarCB.Checked) radar = 1;
                else radar = 0;
                string pn = "";
                string name = CutName(saveFileDialog1.FileName, ref pn);
                Registry.CurrentUser.CreateSubKey(@"Software\HBMLauncher\saves").SetValue("count", count);
                Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("path", gtaPath);
                Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("cleop", cleopr);
                Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("csounds", csounds);
                Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("radar", radar);
                Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("binder", binderPath);
                Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("macros", macrosPath);
                Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("sensfix", sensfix);
                Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("filepath", $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\{name}.exe");
                Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("ip", "");
                Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("nickname", "");
                File.WriteAllBytes($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\{name}.exe", Resources.HBMLRunFile);
                ShortCut.Create($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\{name}.exe", $@"{pn}.lnk", "", "");
                if (MessageBox.Show("Вы хотите указать IP сервера и ник для запуска?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Enabled = false;
                    Save save = new Save();
                    save.Show();
                    save.Activate();
                    save.FormClosed += (obj1, args1) =>
                    {
                        if (Program.Data.isSave)
                        {
                            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("ip", Program.Data.ip);
                            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("nickname", Program.Data.nickname);
                        }
                        Enabled = true;
                    };
                }
            }
        }
        private void ShowBtn_Click(object sender, EventArgs e)
        {
            Enabled = false;
            Hide();
            Show sh = new Show();
            sh.Show();
            sh.Activate();
            sh.FormClosed += (obj1, args1) =>
            {
                Enabled = true;
                Show();
            };
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить все сохранения?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\HBMLauncher\saves"))
                {
                    for (int i = 1; i <= (int)key.GetValue("count"); i++)
                    {
                        using (RegistryKey key1 = Registry.CurrentUser.OpenSubKey($@"Software\HBMLauncher\saves\save{i}"))
                        {
                            if (File.Exists(key1.GetValue("filepath").ToString()))
                                File.Delete(key1.GetValue("filepath").ToString());
                        }
                        Registry.CurrentUser.DeleteSubKey($@"Software\HBMLauncher\saves\save{i}");
                    }
                    Registry.CurrentUser.CreateSubKey(@"Software\HBMLauncher\saves").SetValue("count", 0);
                }
            }
        }
        #endregion

        #region Header
        private void MenuBtn_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 170) MenuVertical.Width = 40;
            else MenuVertical.Width = 170;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void MenuHorizontal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #region Header's control buttons
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MinBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void MaxBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            NormalBtn.Visible = true;
            MaxBtn.Visible = false;
        }
        private void NormalBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            MaxBtn.Visible = true;
            NormalBtn.Visible = false;
        }
        #endregion
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
    }

    static class ShellLink
    {
        [ComImport,
        Guid("000214F9-0000-0000-C000-000000000046"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IShellLinkW
        {
            [PreserveSig]
            int GetPath(
                [Out, MarshalAs(UnmanagedType.LPWStr)]
                StringBuilder pszFile,
                int cch, ref IntPtr pfd, uint fFlags);

            [PreserveSig]
            int GetIDList(out IntPtr ppidl);

            [PreserveSig]
            int SetIDList(IntPtr pidl);

            [PreserveSig]
            int GetDescription(
                [Out, MarshalAs(UnmanagedType.LPWStr)]
                StringBuilder pszName, int cch);

            [PreserveSig]
            int SetDescription(
                [MarshalAs(UnmanagedType.LPWStr)]
                string pszName);

            [PreserveSig]
            int GetWorkingDirectory(
                [Out, MarshalAs(UnmanagedType.LPWStr)]
                StringBuilder pszDir, int cch);

            [PreserveSig]
            int SetWorkingDirectory(
                [MarshalAs(UnmanagedType.LPWStr)]
                string pszDir);

            [PreserveSig]
            int GetArguments(
                [Out, MarshalAs(UnmanagedType.LPWStr)]
                StringBuilder pszArgs, int cch);

            [PreserveSig]
            int SetArguments(
                [MarshalAs(UnmanagedType.LPWStr)]
                string pszArgs);

            [PreserveSig]
            int GetHotkey(out ushort pwHotkey);

            [PreserveSig]
            int SetHotkey(ushort wHotkey);

            [PreserveSig]
            int GetShowCmd(out int piShowCmd);

            [PreserveSig]
            int SetShowCmd(int iShowCmd);

            [PreserveSig]
            int GetIconLocation(
                [Out, MarshalAs(UnmanagedType.LPWStr)]
                StringBuilder pszIconPath, int cch, out int piIcon);

            [PreserveSig]
            int SetIconLocation(
                [MarshalAs(UnmanagedType.LPWStr)]
                string pszIconPath, int iIcon);

            [PreserveSig]
            int SetRelativePath(
                [MarshalAs(UnmanagedType.LPWStr)]
                string pszPathRel, uint dwReserved);

            [PreserveSig]
            int Resolve(IntPtr hwnd, uint fFlags);

            [PreserveSig]
            int SetPath(
                [MarshalAs(UnmanagedType.LPWStr)]
                string pszFile);
        }

        [ComImport,
        Guid("00021401-0000-0000-C000-000000000046"),
        ClassInterface(ClassInterfaceType.None)]
        private class shl_link { }

        internal static IShellLinkW CreateShellLink()
        {
            return (IShellLinkW)(new shl_link());
        }
    }
    public static class ShortCut
    {
        public static void Create(
            string PathToFile, string PathToLink,
            string Arguments, string Description)
        {
            ShellLink.IShellLinkW shlLink = ShellLink.CreateShellLink();

            Marshal.ThrowExceptionForHR(shlLink.SetDescription(Description));
            Marshal.ThrowExceptionForHR(shlLink.SetPath(PathToFile));
            Marshal.ThrowExceptionForHR(shlLink.SetArguments(Arguments));

            ((System.Runtime.InteropServices.ComTypes.IPersistFile)shlLink).Save(PathToLink, false);
        }
    }
}