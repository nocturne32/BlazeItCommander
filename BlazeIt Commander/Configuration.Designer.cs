namespace BlazeIt_Commander
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.checkBoxShowHidden = new System.Windows.Forms.CheckBox();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.leftLblDefaultDrive = new System.Windows.Forms.Label();
            this.leftCboxDefaultDrive = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rightLblDefaultDrive = new System.Windows.Forms.Label();
            this.rightCboxDefaultDrive = new System.Windows.Forms.ComboBox();
            this.lblDriveInfo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxShowHidden
            // 
            this.checkBoxShowHidden.AutoSize = true;
            this.checkBoxShowHidden.Location = new System.Drawing.Point(18, 40);
            this.checkBoxShowHidden.Name = "checkBoxShowHidden";
            this.checkBoxShowHidden.Size = new System.Drawing.Size(238, 21);
            this.checkBoxShowHidden.TabIndex = 0;
            this.checkBoxShowHidden.Text = "Show hidden directories and files";
            this.checkBoxShowHidden.UseVisualStyleBackColor = true;
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaveClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSaveClose.Location = new System.Drawing.Point(133, 422);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(122, 41);
            this.btnSaveClose.TabIndex = 8;
            this.btnSaveClose.Text = "Save and Close";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // leftLblDefaultDrive
            // 
            this.leftLblDefaultDrive.AutoSize = true;
            this.leftLblDefaultDrive.Location = new System.Drawing.Point(18, 35);
            this.leftLblDefaultDrive.Name = "leftLblDefaultDrive";
            this.leftLblDefaultDrive.Size = new System.Drawing.Size(73, 17);
            this.leftLblDefaultDrive.TabIndex = 3;
            this.leftLblDefaultDrive.Text = "Left Drive:";
            // 
            // leftCboxDefaultDrive
            // 
            this.leftCboxDefaultDrive.FormattingEnabled = true;
            this.leftCboxDefaultDrive.Location = new System.Drawing.Point(106, 32);
            this.leftCboxDefaultDrive.Name = "leftCboxDefaultDrive";
            this.leftCboxDefaultDrive.Size = new System.Drawing.Size(121, 24);
            this.leftCboxDefaultDrive.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rightLblDefaultDrive);
            this.groupBox1.Controls.Add(this.rightCboxDefaultDrive);
            this.groupBox1.Controls.Add(this.lblDriveInfo);
            this.groupBox1.Controls.Add(this.leftLblDefaultDrive);
            this.groupBox1.Controls.Add(this.leftCboxDefaultDrive);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 113);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Default";
            // 
            // rightLblDefaultDrive
            // 
            this.rightLblDefaultDrive.AutoSize = true;
            this.rightLblDefaultDrive.Location = new System.Drawing.Point(18, 65);
            this.rightLblDefaultDrive.Name = "rightLblDefaultDrive";
            this.rightLblDefaultDrive.Size = new System.Drawing.Size(82, 17);
            this.rightLblDefaultDrive.TabIndex = 6;
            this.rightLblDefaultDrive.Text = "Right Drive:";
            // 
            // rightCboxDefaultDrive
            // 
            this.rightCboxDefaultDrive.FormattingEnabled = true;
            this.rightCboxDefaultDrive.Location = new System.Drawing.Point(106, 62);
            this.rightCboxDefaultDrive.Name = "rightCboxDefaultDrive";
            this.rightCboxDefaultDrive.Size = new System.Drawing.Size(121, 24);
            this.rightCboxDefaultDrive.TabIndex = 5;
            // 
            // lblDriveInfo
            // 
            this.lblDriveInfo.AutoSize = true;
            this.lblDriveInfo.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblDriveInfo.Location = new System.Drawing.Point(233, 51);
            this.lblDriveInfo.Name = "lblDriveInfo";
            this.lblDriveInfo.Size = new System.Drawing.Size(125, 17);
            this.lblDriveInfo.TabIndex = 4;
            this.lblDriveInfo.Text = "Sets default drives";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(261, 422);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 41);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkBoxShowHidden);
            this.groupBox2.Location = new System.Drawing.Point(12, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 116);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Explorer";
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 475);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(413, 522);
            this.MinimumSize = new System.Drawing.Size(413, 522);
            this.Name = "Configuration";
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.Configuration_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Configuration_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckBox checkBoxShowHidden;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Label leftLblDefaultDrive;
        private System.Windows.Forms.ComboBox leftCboxDefaultDrive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDriveInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label rightLblDefaultDrive;
        private System.Windows.Forms.ComboBox rightCboxDefaultDrive;
    }
}