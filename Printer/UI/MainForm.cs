using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevExpress.XtraEditors;

namespace Printer
{
    public partial class MainForm : XtraForm
    {
        private static configuration _conf;

        public string path;
        public string installPath;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            initDb();
            initUI();
            initLanguage();
        }

        private void initDb()
        {
            DbProviderManager.Instance.createDbProvider();
            DbProviderManager.Instance.DbProvider.openDb();
        }

        private void initUI()
        {
            setPrinters();
        }

        public void setPrinters()
        {
            int i = 0;
            panelPrinters.Controls.Clear();
            foreach (string printer in PrinterHelper.getPrinterNames())
            {
                PanelControl printerItem = new PrinterItem(i, printer).getPrinterItem();
                SimpleButton btnDelete = (SimpleButton) printerItem.Controls.Find("btnDelPrinter" + i, true)[0];
                SimpleButton btnSettingPrinter = (SimpleButton)printerItem.Controls.Find("btnSettingPrinter" + i, true)[0];
                btnDelete.Click += new System.EventHandler(this.btnDeleteClicked);
                btnSettingPrinter.Click += new System.EventHandler(this.btnSettingPrinterClicked);
                panelPrinters.Controls.Add(printerItem);
                i++;
            }
        }

        private void initLanguage()
        {
            this.Text = LocRm.GetString("AppName");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveConfig();
        }


        public static configuration Conf
        {
            get
            {
                if (_conf != null)
                    return _conf;
                var s = new XmlSerializer(typeof(configuration));
                bool loaded = false;
                using (var fs = new FileStream(Program.AppDataPath + @"\config\XML\config.xml", FileMode.Open))
                {
                    try
                    {
                        using (TextReader reader = new StreamReader(fs))
                        {
                            fs.Position = 0;
                            _conf = (configuration)s.Deserialize(reader);
                            loaded = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.Message);
                    }
                }

                if (!loaded)
                {
                    //copy over new config file
                    try
                    {
                        var didest = new DirectoryInfo(Program.AppDataPath + @"\config\XML\");
                        var disource = new DirectoryInfo(Program.AppPath + @"XML\");
                        File.Copy(disource + @"config.xml", didest + @"config.xml", true);

                        using (var fs = new FileStream(Program.AppDataPath + @"\config\XML\config.xml", FileMode.Open))
                        {
                            fs.Position = 0;
                            using (TextReader reader = new StreamReader(fs))
                            {
                                _conf = (configuration)s.Deserialize(reader);
                                reader.Close();
                            }
                            fs.Close();
                        }
                    }
                    catch (Exception ex2)
                    {
                        string m = LocRm.GetString("CouldNotLoadRestore") + Environment.NewLine + ex2.Message;
                        MessageBox.Show(m);
                        Trace.WriteLine(m);
                        throw;
                    }
                }
                return _conf;
            }
        }

        public static void SaveConfig()
        {
            string fileName = Program.AppDataPath + @"\config\XML\config.xml";
            //save configuration

            var s = new XmlSerializer(typeof(configuration));
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                try
                {
                    s.Serialize(writer, Conf);
                    File.WriteAllText(fileName, sb.ToString(), Encoding.UTF8);
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                }
            }
        }

        private void BtnGetPrinters_Click(object sender, EventArgs e)
        {
            setPrinters();
        }

        private void BtnAddPrinter_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show(this, "Do you want add priter?",
                        "Printer Add", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;
            try
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    PrinterHelper.installPrinter("dokimastikos32aris");
                }
                else
                {
                    PrinterHelper.installPrinter("dokimastikos32aris");
                }
                setPrinters();
            }
            catch (Exception ex)
            {

            }
            
        }

        private void btnSettingPrinterClicked(object sender, EventArgs e)
        {

            try
            {
                SimpleButton button = (SimpleButton)sender;
                string printerName = button.Tag.ToString();
                PrinterHelper.setPrinterSetting(printerName);
            }
            catch (Exception ex)
            {

            }

        }

        private void btnDeleteClicked(object sender, EventArgs e)
        {
            
            try
            {
                SimpleButton button = (SimpleButton)sender;
                string printerName = button.Tag.ToString();
                DialogResult result = XtraMessageBox.Show(this, "Are you sure delete priter:" + printerName,
                        "Printer Deleted", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;
                PrinterHelper.uninstallPrinter(printerName);
                setPrinters();
            }
            catch (Exception ex)
            {

            }

        }

        private void BtnBrowseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            DialogResult result = dialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                labelFolerPath.Text = dialog.SelectedPath;
                Environment.SpecialFolder root = dialog.RootFolder;
                path = labelFolerPath.Text.Replace(@"\", @"\\");
                installPath = "\"" + path + "\"";
            }
        }
    }
}
