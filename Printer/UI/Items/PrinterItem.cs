using System;
using DevExpress.XtraEditors;

namespace Printer
{
    class PrinterItem : PanelControl
    {
        PanelControl panelControl = new PanelControl();
        public PrinterItem( int i, string printerName)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            // 
            // picPrinter
            // 
            PictureEdit picPrinter = new PictureEdit();
            picPrinter.EditValue = global::ExamApp.Properties.Resources.printer_32x32;
            picPrinter.Location = new System.Drawing.Point(6, 6);
            picPrinter.Name = "picPrinter" + i;
            picPrinter.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            picPrinter.Properties.Appearance.Options.UseBackColor = true;
            picPrinter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            picPrinter.Properties.Caption.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            picPrinter.Properties.Caption.Appearance.Options.UseBackColor = true;
            picPrinter.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            picPrinter.Size = new System.Drawing.Size(42, 42);
            picPrinter.TabIndex = 0;
            // 
            // labelPrinter
            // 
            LabelControl labelPrinter = new LabelControl();
            labelPrinter.Appearance.Font = new System.Drawing.Font("Stencil Std", 13F);
            labelPrinter.Appearance.Options.UseFont = true;
            labelPrinter.Location = new System.Drawing.Point(54, 17);
            labelPrinter.Name = "labelPrinter" + i;
            labelPrinter.Size = new System.Drawing.Size(149, 22);
            labelPrinter.TabIndex = 1;
            labelPrinter.Text = printerName;
            // 
            // btnSettingPrinter
            // 
            SimpleButton btnSettingPrinter = new SimpleButton();
            btnSettingPrinter.ImageOptions.Image = global::ExamApp.Properties.Resources.technology_32x32;
            btnSettingPrinter.Location = new System.Drawing.Point(370, 8);
            btnSettingPrinter.Name = "btnSettingPrinter" + i;
            btnSettingPrinter.Size = new System.Drawing.Size(38, 38);
            btnSettingPrinter.TabIndex = 2;
            btnSettingPrinter.Tag = printerName;
            // 
            // btnDelPrinter
            // 
            SimpleButton btnDelPrinter = new SimpleButton();
            btnDelPrinter.ImageOptions.Image = global::ExamApp.Properties.Resources.cancel_32x321;
            btnDelPrinter.Location = new System.Drawing.Point(417, 8);
            btnDelPrinter.Name = "btnDelPrinter" + i;
            btnDelPrinter.Size = new System.Drawing.Size(38, 38);
            btnDelPrinter.TabIndex = 3;
            btnDelPrinter.Tag = printerName;

            panelControl.Controls.Add(btnSettingPrinter);
            panelControl.Controls.Add(btnDelPrinter);
            panelControl.Controls.Add(labelPrinter);
            panelControl.Controls.Add(picPrinter);
            panelControl.Location = new System.Drawing.Point(11, 11);
            panelControl.Name = "panelPrinter" + i;
            panelControl.Size = new System.Drawing.Size(462, 55);
            panelControl.Location = new System.Drawing.Point(10, 15 * (i + 1 ) + 48 * i);
            panelControl.TabIndex = 0;
        }

        public PanelControl getPrinterItem()
        {
            return this.panelControl;
        }

        
    }
}
