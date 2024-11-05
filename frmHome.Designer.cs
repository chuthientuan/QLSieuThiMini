namespace QLSieuThiMini
{
    partial class frmHome
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sdfsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.st2tToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.st2tToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1153, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fdfToolStripMenuItem,
            this.sdfsToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(71, 29);
            this.toolStripMenuItem1.Text = "hgdg";
            // 
            // fdfToolStripMenuItem
            // 
            this.fdfToolStripMenuItem.Name = "fdfToolStripMenuItem";
            this.fdfToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.fdfToolStripMenuItem.Text = "fdf";
            // 
            // sdfsToolStripMenuItem
            // 
            this.sdfsToolStripMenuItem.Name = "sdfsToolStripMenuItem";
            this.sdfsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.sdfsToolStripMenuItem.Text = "sdfs";
            // 
            // st2tToolStripMenuItem
            // 
            this.st2tToolStripMenuItem.Name = "st2tToolStripMenuItem";
            this.st2tToolStripMenuItem.Size = new System.Drawing.Size(58, 29);
            this.st2tToolStripMenuItem.Text = "st2t";
            // 
            // frmHome
            // 
            this.ClientSize = new System.Drawing.Size(1153, 665);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chủ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sdfsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem st2tToolStripMenuItem;
    }
}