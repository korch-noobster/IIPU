using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace USB
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            usbworker.RunWorkerAsync();
        }

        void Reading()
        {
            String boxstring="Tome\t\tSize(Mb)\t\tFreeSpace(Mb)\tLeft(Mb)",line,tomes=null;
            float temp;
            using (StreamReader sr = new StreamReader("UsbList.txt", System.Text.Encoding.UTF8))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    boxstring += Environment.NewLine;
                    line = line.Substring(line.IndexOf(";") + 1);
                    line = line.Remove(2);
                    tomes += line;
                    Process.Start("get_tome_size.bat", line);
                    boxstring += line + "\t\t";
                    using (StreamReader sr2 = new StreamReader("TomeSize.txt", System.Text.Encoding.UTF8))
                    {
                        float left;
                        sr2.ReadLine();
                        line = sr2.ReadLine();
                        temp = Convert.ToInt32(line);
                        temp /= 1048576;
                        left = temp;
                        boxstring += temp.ToString() + "\t\t";
                        sr2.ReadLine();
                        line = sr2.ReadLine();
                        temp = Convert.ToInt32(line);
                        temp /= 1048576;
                        boxstring += temp.ToString() + "\t\t";
                        left -= temp;
                        boxstring += left.ToString() + "\t\t";
                    }
                }
            }
            Usb_eject.DataSource = tomes;
            UsbBox.Invoke(new Action<string>((s) => UsbBox.Text = s), boxstring);
        }
        private void Usbworker_DoWork(object sender, DoWorkEventArgs e)
        {
          // string writePath = @"UsbList.txt";
            while (true)
            {
               /*foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.DriveType == DriveType.Removable)
                    {
                        using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                        
                            sw.WriteLine(string.Format("({0}) {1} {2} {3} {4}", drive.Name.Replace("\\", ""), drive.VolumeLabel,drive.TotalSize,drive.AvailableFreeSpace,drive.TotalFreeSpace));
                    }
                }
                */
                Process.Start("get-usblist.bat");
                Reading();

                // Process.Start("get_tome_size.bat");
                Thread.Sleep(5000);
            }
        }
        #region
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr CreateFile(
    string lpFileName,
    uint dwDesiredAccess,
    uint dwShareMode,
    IntPtr SecurityAttributes,
    uint dwCreationDisposition,
    uint dwFlagsAndAttributes,
    IntPtr hTemplateFile
        );

        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool DeviceIoControl(
            IntPtr hDevice,
            uint dwIoControlCode,
            IntPtr lpInBuffer,
            uint nInBufferSize,
            IntPtr lpOutBuffer,
            uint nOutBufferSize,
            out uint lpBytesReturned,
            IntPtr lpOverlapped
        );

        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool DeviceIoControl(
            IntPtr hDevice,
            uint dwIoControlCode,
            byte[] lpInBuffer,
            uint nInBufferSize,
            IntPtr lpOutBuffer,
            uint nOutBufferSize,
            out uint lpBytesReturned,
            IntPtr lpOverlapped
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);

        private IntPtr handle = IntPtr.Zero;

        const uint GENERIC_READ = 0x80000000;
        const uint GENERIC_WRITE = 0x40000000;
        const int FILE_SHARE_READ = 0x1;
        const int FILE_SHARE_WRITE = 0x2;
        const int FSCTL_LOCK_VOLUME = 0x00090018;
        const int FSCTL_DISMOUNT_VOLUME = 0x00090020;
        const int IOCTL_STORAGE_EJECT_MEDIA = 0x2D4808;
        const int IOCTL_STORAGE_MEDIA_REMOVAL = 0x002D4804;

        /// <summary>
        /// Constructor for the USBEject class
        /// </summary>
        /// <param name="driveLetter">This should be the drive letter. Format: F:/, C:/..</param>

        public IntPtr USBEject(string driveLetter)
        {
            string filename = @"\\.\" + driveLetter[0] + ":";
            return CreateFile(filename, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, 0x3, 0, IntPtr.Zero);
        }

        public bool Eject(IntPtr handle)
        {
            if (LockVolume(handle) && DismountVolume(handle))
            {
                PreventRemovalOfVolume(handle, false);
                return AutoEjectVolume(handle);
            }
            return false;
        }

        private bool LockVolume(IntPtr handle)
        {
            uint byteReturned;

            for (int i = 0; i < 10; i++)
            {
                if (DeviceIoControl(handle, FSCTL_LOCK_VOLUME, IntPtr.Zero, 0, IntPtr.Zero, 0, out byteReturned, IntPtr.Zero))
                {
                    System.Windows.Forms.MessageBox.Show("Lock success!");
                    return true;
                }
                Thread.Sleep(500);
            }
            return false;
        }

        private bool PreventRemovalOfVolume(IntPtr handle, bool prevent)
        {
            byte[] buf = new byte[1];
            uint retVal;

            buf[0] = (prevent) ? (byte)1 : (byte)0;
            return DeviceIoControl(handle, IOCTL_STORAGE_MEDIA_REMOVAL, buf, 1, IntPtr.Zero, 0, out retVal, IntPtr.Zero);
        }

        private bool DismountVolume(IntPtr handle)
        {
            uint byteReturned;
            return DeviceIoControl(handle, FSCTL_DISMOUNT_VOLUME, IntPtr.Zero, 0, IntPtr.Zero, 0, out byteReturned, IntPtr.Zero);
        }

        private bool AutoEjectVolume(IntPtr handle)
        {
            uint byteReturned;
            return DeviceIoControl(handle, IOCTL_STORAGE_EJECT_MEDIA, IntPtr.Zero, 0, IntPtr.Zero, 0, out byteReturned, IntPtr.Zero);
        }

        private bool CloseVolume(IntPtr handle)
        {
            return CloseHandle(handle);
        }




        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
          //  Eject(USBEject(Usb_eject.));
        }
    }
}

