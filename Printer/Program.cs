using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.IO;

namespace Printer
{
    static class Program
    {
        private static string _apppath = "", _appdatapath = "";

        public static string AppPath
        {
            get
            {
                if (_apppath != "")
                    return _apppath;
                _apppath = (Application.StartupPath.ToLower());
                _apppath = _apppath.Replace(@"\bin\debug", @"\").Replace(@"\bin\release", @"\");
                _apppath = _apppath.Replace(@"\bin\x86\debug", @"\").Replace(@"\bin\x86\release", @"\");
                _apppath = _apppath.Replace(@"\bin\x64\debug", @"\").Replace(@"\bin\x64\release", @"\");

                _apppath = _apppath.Replace(@"\\", @"\");

                if (!_apppath.EndsWith(@"\"))
                    _apppath += @"\";

                return _apppath;
            }
        }

        public static string AppDataPath
        {
            get
            {
                if (_appdatapath != "")
                    return _appdatapath;

                string executableName = Application.ExecutablePath;
                var executableFileInfo = new FileInfo(executableName);

                _appdatapath = executableFileInfo.DirectoryName;
                return _appdatapath;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool ei = (!Directory.Exists(AppDataPath + @"\config\") || !Directory.Exists(AppDataPath + @"\config\XML\") || !File.Exists(AppDataPath + @"\config\XML\config.xml"));
            if (ei) EnsureInstall(true);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static void EnsureInstall(bool reset)
        {

            if (!Directory.Exists(AppDataPath + @"\config\")) Directory.CreateDirectory(AppDataPath + @"\config\");
            if (!Directory.Exists(AppDataPath + @"\config\XML")) Directory.CreateDirectory(AppDataPath + @"\config\XML");

            var didest = new DirectoryInfo(AppDataPath + @"\config\XML\");
            var disource = new DirectoryInfo(AppPath + @"Misc\");

            TryCopy(disource + @"Translations.xml", didest + @"Translations.xml", true);

            if (reset || !File.Exists(didest + @"config.xml")) TryCopy(disource + @"config.xml", didest + @"config.xml", reset);
        }

        private static void TryCopy(string source, string target, bool overwrite)
        {
            try
            {
                File.Copy(source, target, overwrite);
            }
            catch
            {

            }
        }
    }
}
