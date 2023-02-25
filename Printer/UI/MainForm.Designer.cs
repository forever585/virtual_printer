namespace Printer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelPrinters = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetPrinters = new DevExpress.XtraEditors.SimpleButton();
            this.btnBrowseFolder = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddPrinter = new DevExpress.XtraEditors.SimpleButton();
            this.labelFolerPath = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelPrinters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPrinters
            // 
            this.panelPrinters.AllowTouchScroll = true;
            this.panelPrinters.AutoSize = true;
            this.panelPrinters.Location = new System.Drawing.Point(8, 64);
            this.panelPrinters.Name = "panelPrinters";
            this.panelPrinters.Size = new System.Drawing.Size(496, 606);
            this.panelPrinters.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(8, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Printers";
            // 
            // btnGetPrinters
            // 
            this.btnGetPrinters.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGetPrinters.ImageOptions.SvgImage")));
            this.btnGetPrinters.Location = new System.Drawing.Point(463, 18);
            this.btnGetPrinters.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.btnGetPrinters.Name = "btnGetPrinters";
            this.btnGetPrinters.Size = new System.Drawing.Size(40, 40);
            this.btnGetPrinters.TabIndex = 1;
            this.btnGetPrinters.Click += new System.EventHandler(this.BtnGetPrinters_Click);
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Appearance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnBrowseFolder.Appearance.Options.UseFont = true;
            this.btnBrowseFolder.ImageOptions.Image = global::ExamApp.Properties.Resources.open2_32x32;
            this.btnBrowseFolder.Location = new System.Drawing.Point(416, 18);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(40, 40);
            this.btnBrowseFolder.TabIndex = 6;
            this.btnBrowseFolder.Click += new System.EventHandler(this.BtnBrowseFolder_Click);
            // 
            // btnAddPrinter
            // 
            this.btnAddPrinter.Appearance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAddPrinter.Appearance.Options.UseFont = true;
            this.btnAddPrinter.ImageOptions.Image = global::ExamApp.Properties.Resources.add_32x32;
            this.btnAddPrinter.Location = new System.Drawing.Point(370, 18);
            this.btnAddPrinter.Name = "btnAddPrinter";
            this.btnAddPrinter.Size = new System.Drawing.Size(40, 40);
            this.btnAddPrinter.TabIndex = 5;
            this.btnAddPrinter.Click += new System.EventHandler(this.BtnAddPrinter_Click);
            // 
            // labelFolerPath
            // 
            this.labelFolerPath.Appearance.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFolerPath.Appearance.Options.UseFont = true;
            this.labelFolerPath.Appearance.Options.UseTextOptions = true;
            this.labelFolerPath.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelFolerPath.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelFolerPath.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelFolerPath.Location = new System.Drawing.Point(5, 1);
            this.labelFolerPath.Name = "labelFolerPath";
            this.labelFolerPath.Size = new System.Drawing.Size(252, 20);
            this.labelFolerPath.TabIndex = 3;
            this.labelFolerPath.Text = "Please select folder to save test page file!";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.labelFolerPath);
            this.panelControl2.Location = new System.Drawing.Point(69, 34);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(295, 24);
            this.panelControl2.TabIndex = 4;
            // 
            // MainForm
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(510, 678);
            this.Controls.Add(this.btnAddPrinter);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.btnGetPrinters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelPrinters);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(512, 710);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(512, 710);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Examination App";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelPrinters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelPrinters;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnGetPrinters;
        private DevExpress.XtraEditors.SimpleButton btnSavePrinter;
        private DevExpress.XtraEditors.SimpleButton btnBrowseFolder;
        private DevExpress.XtraEditors.SimpleButton btnAddPrinter;
        private DevExpress.XtraEditors.LabelControl labelFolerPath;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}

