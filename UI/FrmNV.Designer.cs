namespace QLSieuThiMini.UI
{
    partial class FrmNV
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.imgSlide = new System.Windows.Forms.PictureBox();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlide)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 26;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.btnLogout);
            this.guna2Panel1.Controls.Add(this.guna2Button5);
            this.guna2Panel1.Controls.Add(this.guna2Button4);
            this.guna2Panel1.Controls.Add(this.guna2Button3);
            this.guna2Panel1.Controls.Add(this.guna2Button2);
            this.guna2Panel1.Controls.Add(this.imgSlide);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(180, 710);
            this.guna2Panel1.TabIndex = 1;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.guna2PictureBox2);
            this.guna2Panel2.Controls.Add(this.lbName);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(180, 163);
            this.guna2Panel2.TabIndex = 7;
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lbName.ForeColor = System.Drawing.Color.White;
            this.lbName.Location = new System.Drawing.Point(30, 129);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(113, 24);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Ten nhan vien";
            this.lbName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbName.UseSystemCursors = true;
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(180, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.pnlContent.Size = new System.Drawing.Size(1240, 710);
            this.pnlContent.TabIndex = 5;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Image = global::QLSieuThiMini.Properties.Resources.icons8_employee_100;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(35, 12);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(100, 100);
            this.guna2PictureBox2.TabIndex = 1;
            this.guna2PictureBox2.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BorderRadius = 6;
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = global::QLSieuThiMini.Properties.Resources.ic_exit;
            this.btnLogout.Location = new System.Drawing.Point(21, 632);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(142, 45);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // guna2Button5
            // 
            this.guna2Button5.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button5.BorderRadius = 22;
            this.guna2Button5.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button5.CheckedState.FillColor = System.Drawing.Color.White;
            this.guna2Button5.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.guna2Button5.CheckedState.Image = global::QLSieuThiMini.Properties.Resources.ic_product_blue;
            this.guna2Button5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.guna2Button5.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.guna2Button5.ForeColor = System.Drawing.Color.White;
            this.guna2Button5.Image = global::QLSieuThiMini.Properties.Resources.ic_product_white;
            this.guna2Button5.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button5.Location = new System.Drawing.Point(10, 390);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.Size = new System.Drawing.Size(163, 44);
            this.guna2Button5.TabIndex = 5;
            this.guna2Button5.Text = "Sản Phẩm";
            this.guna2Button5.UseTransparentBackground = true;
            this.guna2Button5.CheckedChanged += new System.EventHandler(this.guna2Button5_CheckedChanged);
            this.guna2Button5.Click += new System.EventHandler(this.guna2Button5_Click);
            // 
            // guna2Button4
            // 
            this.guna2Button4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button4.BorderRadius = 22;
            this.guna2Button4.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button4.CheckedState.FillColor = System.Drawing.Color.White;
            this.guna2Button4.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.guna2Button4.CheckedState.Image = global::QLSieuThiMini.Properties.Resources.ic_invoice_blue;
            this.guna2Button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.guna2Button4.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.guna2Button4.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.Image = global::QLSieuThiMini.Properties.Resources.ic_invoice_white;
            this.guna2Button4.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button4.Location = new System.Drawing.Point(10, 272);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.Size = new System.Drawing.Size(163, 44);
            this.guna2Button4.TabIndex = 4;
            this.guna2Button4.Text = "Hóa Đơn Nhập";
            this.guna2Button4.UseTransparentBackground = true;
            this.guna2Button4.CheckedChanged += new System.EventHandler(this.guna2Button5_CheckedChanged);
            this.guna2Button4.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // guna2Button3
            // 
            this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderRadius = 22;
            this.guna2Button3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button3.Checked = true;
            this.guna2Button3.CheckedState.FillColor = System.Drawing.Color.White;
            this.guna2Button3.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.guna2Button3.CheckedState.Image = global::QLSieuThiMini.Properties.Resources.ic_invoice_blue;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.guna2Button3.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.Image = global::QLSieuThiMini.Properties.Resources.ic_invoice_white;
            this.guna2Button3.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button3.Location = new System.Drawing.Point(10, 213);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(163, 44);
            this.guna2Button3.TabIndex = 3;
            this.guna2Button3.Text = "Hóa Đơn Bán";
            this.guna2Button3.UseTransparentBackground = true;
            this.guna2Button3.CheckedChanged += new System.EventHandler(this.guna2Button5_CheckedChanged);
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderRadius = 22;
            this.guna2Button2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button2.CheckedState.FillColor = System.Drawing.Color.White;
            this.guna2Button2.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.guna2Button2.CheckedState.Image = global::QLSieuThiMini.Properties.Resources.ic_customer_blue;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.guna2Button2.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Image = global::QLSieuThiMini.Properties.Resources.ic_customer_white;
            this.guna2Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button2.Location = new System.Drawing.Point(10, 331);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(163, 44);
            this.guna2Button2.TabIndex = 2;
            this.guna2Button2.Text = "Khách Hàng";
            this.guna2Button2.UseTransparentBackground = true;
            this.guna2Button2.CheckedChanged += new System.EventHandler(this.guna2Button5_CheckedChanged);
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // imgSlide
            // 
            this.imgSlide.Image = global::QLSieuThiMini.Properties.Resources.image_check;
            this.imgSlide.Location = new System.Drawing.Point(142, 183);
            this.imgSlide.Name = "imgSlide";
            this.imgSlide.Size = new System.Drawing.Size(39, 101);
            this.imgSlide.TabIndex = 1;
            this.imgSlide.TabStop = false;
            // 
            // FrmNV
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(1420, 710);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNV";
            this.Load += new System.EventHandler(this.FrmNV_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSlide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbName;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private System.Windows.Forms.PictureBox imgSlide;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
    }
}