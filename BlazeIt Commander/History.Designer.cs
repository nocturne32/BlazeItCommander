namespace BlazeIt_Commander
{
    partial class History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.leftListBox = new System.Windows.Forms.ListBox();
            this.rightListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.leftListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rightListBox);
            this.splitContainer1.Size = new System.Drawing.Size(910, 693);
            this.splitContainer1.SplitterDistance = 453;
            this.splitContainer1.TabIndex = 0;
            // 
            // leftListBox
            // 
            this.leftListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftListBox.FormattingEnabled = true;
            this.leftListBox.ItemHeight = 16;
            this.leftListBox.Location = new System.Drawing.Point(0, 0);
            this.leftListBox.Name = "leftListBox";
            this.leftListBox.Size = new System.Drawing.Size(453, 693);
            this.leftListBox.TabIndex = 4;
            this.leftListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.leftListBox_MouseDoubleClick);
            // 
            // rightListBox
            // 
            this.rightListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightListBox.FormattingEnabled = true;
            this.rightListBox.ItemHeight = 16;
            this.rightListBox.Location = new System.Drawing.Point(0, 0);
            this.rightListBox.Name = "rightListBox";
            this.rightListBox.Size = new System.Drawing.Size(453, 693);
            this.rightListBox.TabIndex = 5;
            this.rightListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.rightListBox_MouseDoubleClick);
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 693);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(594, 622);
            this.Name = "History";
            this.Text = "History";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox rightListBox;
        private System.Windows.Forms.ListBox leftListBox;
    }
}