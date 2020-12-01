using System;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using Microsoft.Win32;
using HBMLauncher.Properties;
using System.Text;
using System.Runtime.InteropServices;

namespace HBMLauncher
{
    public partial class Form1 : Form
    {
        string gtaPath;
        int count, cleopr, csounds;

        public Form1()
        {
            InitializeComponent();
        }
        string GetName(int index)
        {
            string result = "";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey($@"Software\HBMLauncher\slot{index}"))
            {
                result = key.GetValue("name").ToString();
            }
            return result;
        }
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
        void FillSlot(int sn, Button but)
        {
            if (but.Text == "+")
            {
                Enabled = false;
                Directory.CreateDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\slot{sn}");

                Form f = new Slots();
                f.Show();
                f.FormClosed += (obj, args) =>
                {
                    Enabled = true;
                    if (Program.Data.isDone)
                    {
                        but.Text = Program.Data.slotname;
                        if (sn == 1)
                        {
                            slot2.Enabled = true;
                            slot2.Visible = true;
                        }
                        if (sn == 2)
                        {
                            slot3.Enabled = true;
                            slot3.Visible = true;
                        }
                        if (sn == 3)
                        {
                            slot4.Enabled = true;
                            slot4.Visible = true;
                        }
                    }
                };
            }
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            slot2.Visible = false;
            slot3.Visible = false;
            slot4.Visible = false;
            Directory.CreateDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher");
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\HBMLauncher"))
                {
                    gtaPath = key.GetValue("path").ToString();
                    position.Text = "Текущее расположение GTA:\n" + gtaPath;
                }
                slot1.Text = GetName(1);
                slot2.Text = "+";
                slot2.Visible = true;
                slot2.Text = GetName(2);
                slot3.Text = "+";
                slot3.Visible = true;
                slot3.Text = GetName(3);
                slot4.Text = "+";
                slot4.Visible = true;
                slot4.Text = GetName(4);
            }
            catch (Exception) { }

            for (Opacity = 0; Opacity < .96; Opacity += 0.02)
            {
                await Task.Delay(10);
            }
            await Task.Run(() =>
            {
                if (!File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\img.exe"))
                    File.WriteAllBytes($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\img.exe", Resources.img);
                if (!File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\zlib1.dll"))
                    File.WriteAllBytes($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\zlib1.dll", Resources.zlib1);
            });
            Program.Data.slotnumber = 1;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            Enabled = false;
            Form f = new StartWin();
            f.Show();
            f.FormClosed += (obj, args) =>
            { 
                Enabled = true;
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\HBMLauncher"))
                {
                    gtaPath = key.GetValue("path").ToString();
                    position.Text = "Текущее расположение GTA:\n" + gtaPath;
                }
            };
        }

        private void Slot1_Click(object sender, EventArgs e)
        {
            Program.Data.slotnumber = 1;
            FillSlot(1, slot1);
        }

        private void Slot2_Click(object sender, EventArgs e)
        {
            Program.Data.slotnumber = 2;
            FillSlot(2, slot2);
        }

        private void Slot3_Click(object sender, EventArgs e)
        {
            Program.Data.slotnumber = 3;
            FillSlot(3, slot3);
        }

        private void Slot4_Click(object sender, EventArgs e)
        {
            Program.Data.slotnumber = 4;
            FillSlot(4, slot4);
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            Show sh = new Show();
            sh.Show();
            sh.Activate();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\HBMLauncher\saves"))
                { count = (int)key.GetValue("count") + 1; }
                if (cleop.Checked) cleopr = 1;
                else cleopr = 0;
                if (csoundsCB.Checked) csounds = 1;
                else csounds = 0;
                string pn = "";
                string name = CutName(saveFileDialog1.FileName, ref pn);
                Registry.CurrentUser.CreateSubKey(@"Software\HBMLauncher\saves").SetValue("count", count);
                Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("path", gtaPath);
                Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("cleop", cleopr);
                Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("csounds", csounds);
                Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("slot", Program.Data.slotnumber);
                Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("filepath", $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\{name}.exe");
                File.WriteAllBytes($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\{name}.exe", Resources.HBMLRunFile);
                ShortCut.Create($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\{name}.exe", $@"{pn}.lnk", "", "");
                if (MessageBox.Show("Вы хотите указать IP сервера и ник для запуска?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Enabled = false;
                    Run r = new Run();
                    r.Show();
                    r.Activate();
                    r.FormClosed += (obj1, args1) =>
                    {
                        if (Program.Data.isSave)
                        {
                            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("ip", Program.Data.ip);
                            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("nickname", Program.Data.nickname);
                        }
                        else
                        {
                            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("ip", "");
                            Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("nickname", "");
                        }
                        Enabled = true;
                    };
                }
                else
                {
                    Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("ip", "");
                    Registry.CurrentUser.CreateSubKey($@"Software\HBMLauncher\saves\save{count}").SetValue("nickname", "");
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите очистить слоты и удалить сохранения?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    for (int i = 1; i < 5; i++)
                    {
                        Registry.CurrentUser.DeleteSubKey($@"Software\HBMLauncher\slot{i}");
                        Directory.Delete($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\HBMLauncher\slot{i}", true);
                    }
                }
                catch (Exception) { }

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

                slot1.Text = "+";
                slot2.Text = "+";
                slot2.Visible = false;
                slot2.Enabled = false;
                slot3.Text = "+";
                slot3.Visible = false;
                slot3.Enabled = false;
                slot4.Text = "+";
                slot4.Visible = false;
                slot4.Enabled = false;
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