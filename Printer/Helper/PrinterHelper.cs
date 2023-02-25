using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.InteropServices;
using static System.Drawing.Printing.PrinterSettings;
using DevExpress.XtraEditors;

namespace Printer
{
    public static class PrinterClass // class which carries SetDefaultPrinter function
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);
    }

    class PrinterHelper
    {
       public static StringCollection getPrinterNames()
        {
            return InstalledPrinters;
        }           

        private static string comName = "tcp:";
        private static string connectionType = "Standard TCP/IP Port";
        public static void installPrinter(string printerName) //works on win 7,8,8.1,10 on both x84 and x64
        {
            Winspool.AddMonitorPrinterPort(comName, connectionType);

            string arg;
            arg = "printui.dll , PrintUIEntry /if /b " + "\"" + printerName + "\"" + @" /f C:\Windows\inf\ntprint.inf /r " + comName + " /m " + "\"" + "Generic / Text Only" + "\""; //initial arg
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = "rundll32.exe";
            p.Arguments = arg;
            p.WindowStyle = ProcessWindowStyle.Hidden;

            try
            {
                Process.Start(p);
                XtraMessageBox.Show(printerName + "installed successfully",
                        "Printer Installed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        public static void setPrinterSetting(string printerName) //works on win 7,8,8.1,10 on both x84 and x64
        {
            string arg;
            arg = string.Format("printui.dll , PrintUIEntry /p /n \"{0}\" /r \"{1}\"", printerName, " COM32"); //set port
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = "rundll32.exe";
            p.Arguments = arg;
            p.WindowStyle = ProcessWindowStyle.Hidden;
            try
            {
                Process.Start(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void printTestPage(string printerName, string fileName)
        {
            string arg;
            arg = string.Format("printui.dll , PrintUIEntry /Xg /n \"{0}\" /f \"{1}\" /q", printerName, fileName); //set port
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = "rundll32.exe";
            p.Arguments = arg;
            p.WindowStyle = ProcessWindowStyle.Hidden;
            try
            {
                Process.Start(p);
                XtraMessageBox.Show("Successfully Printed with " + printerName,
                       "Test Page Printed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    public static bool printerExists(string printerName)
        {
            bool res = false;
            foreach (string printer in InstalledPrinters)
            {
                if (printer == printerName)
                {
                    res = true;
                }
            }
            return res;
        }
        public static void uninstallPrinter(string printerName)
        {
            string arg;
            ProcessStartInfo p = new ProcessStartInfo();
            arg = "printui.dll, PrintUIEntry /dl /n " + "\"" + printerName + "\"";
            if (printerExists(printerName))
            {
                p.FileName = "rundll32.exe";
                p.Arguments = arg;
                p.WindowStyle = ProcessWindowStyle.Hidden;
                try
                {
                    Process.Start(p);
                    XtraMessageBox.Show(printerName + "unistalled successfully",
                        "Printer Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }
                p = null;
            }
        }
       
        public static string GetLocalIPAddress() //erxomeno feature
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

	   public static class Winspool
        {
            private const int MAX_PORTNAME_LEN = 64;
            private const int MAX_NETWORKNAME_LEN = 49;
            private const int MAX_SNMP_COMMUNITY_STR_LEN = 33;
            private const int MAX_QUEUENAME_LEN = 33;
            private const int MAX_IPADDR_STR_LEN = 16;
            private const int RESERVED_BYTE_ARRAY_SIZE = 540;

            private enum PrinterAccess
            {
                ServerAdmin = 0x01,
                ServerEnum = 0x02,
                PrinterAdmin = 0x04,
                PrinterUse = 0x08,
                JobAdmin = 0x10,
                JobRead = 0x20,
                StandardRightsRequired = 0x000f0000,
                PrinterAllAccess = (StandardRightsRequired | PrinterAdmin | PrinterUse)
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct PrinterDefaults
            {
                public IntPtr pDataType;
                public IntPtr pDevMode;
                public PrinterAccess DesiredAccess;
            }

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            private struct PortData
            {
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PORTNAME_LEN)]
                public string sztPortName;
                public UInt32 dwVersion;
                public UInt32 dwProtocol;
                public UInt32 cbSize;
                public UInt32 dwReserved;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NETWORKNAME_LEN)]
                public string sztHostAddress;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_SNMP_COMMUNITY_STR_LEN)]
                public string sztSNMPCommunity;
                public UInt32 dwDoubleSpool;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_QUEUENAME_LEN)]
                public string sztQueue;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_IPADDR_STR_LEN)]
                public string sztIPAddress;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = RESERVED_BYTE_ARRAY_SIZE)]
                public byte[] Reserved;
                public UInt32 dwPortNumber;
                public UInt32 dwSNMPEnabled;
                public UInt32 dwSNMPDevIndex;
            }

            [DllImport("winspool.drv")]
            private static extern bool OpenPrinter(string printerName, out IntPtr phPrinter, ref PrinterDefaults printerDefaults);

            [DllImport("winspool.drv")]
            private static extern bool ClosePrinter(IntPtr phPrinter);

            [DllImport("winspool.drv", CharSet = CharSet.Unicode)]
            private static extern bool XcvDataW(IntPtr hXcv, string pszDataName, IntPtr pInputData, UInt32 cbInputData, out IntPtr pOutputData, UInt32 cbOutputData, out UInt32 pcbOutputNeeded, out UInt32 pdwStatus);

            public static void AddMonitorPrinterPort(string portName, string portType)
            {
                IntPtr hPrinter = IntPtr.Zero; 

                PrinterDefaults defaults = new PrinterDefaults { pDataType = IntPtr.Zero, pDevMode = IntPtr.Zero, DesiredAccess = PrinterAccess.ServerAdmin };
                if (!OpenPrinter(",XcvMonitor " + portType, out hPrinter, ref defaults))
                    throw new Exception("Could not open printer for the monitor port " + portType + "!");
                try
                {
                    PortData portData = new PortData
                    {
                        dwVersion = 1,
                        dwProtocol = 1, // 1 = RAW, 2 = LPR
                        dwPortNumber = 9100, // 9100 = default port for RAW, 515 for LPR
                        dwReserved = 0,
                        sztPortName = portName,
                        sztIPAddress = "172.30.164.15",
                        sztSNMPCommunity = "public",
                        dwSNMPEnabled = 1,
                        dwSNMPDevIndex = 1
                    };
                    uint size = (uint)Marshal.SizeOf(portData);
                    portData.cbSize = size;
                    IntPtr pointer = Marshal.AllocHGlobal((int)size);
                    Marshal.StructureToPtr(portData, pointer, true);
                    IntPtr outputData;
                    UInt32 outputNeeded, status;
                    try
                    {
                        if (!XcvDataW(hPrinter, "AddPort", pointer, size, out outputData, 0, out outputNeeded, out status))
                            throw new Exception("Could not add port (error code " + status + ")!");
                    }
                    finally
                    {
                        Marshal.FreeHGlobal(pointer);
                    }
                }
                finally
                {
                    ClosePrinter(hPrinter);
                }
            }

        }


    }
}
