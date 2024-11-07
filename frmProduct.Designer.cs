namespace QLSieuThiMini
{
    partial class frmProduct
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtDGN = new System.Windows.Forms.TextBox();
            this.txtDGB = new System.Windows.Forms.TextBox();
            this.dtpHSD = new System.Windows.Forms.DateTimePicker();
            this.cbbLoaiHang = new System.Windows.Forms.ComboBox();
            this.boxAnh = new System.Windows.Forms.GroupBox();
            this.groupChiTiet = new System.Windows.Forms.GroupBox();
            this.groupChiTiet.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên sản phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đơn giá nhập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đơn giá bán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hạn sử dụng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Loại hàng";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(130, 32);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(118, 22);
            this.txtTenSP.TabIndex = 5;
            // 
            // txtDGN
            // 
            this.txtDGN.Location = new System.Drawing.Point(386, 35);
            this.txtDGN.Name = "txtDGN";
            this.txtDGN.Size = new System.Drawing.Size(118, 22);
            this.txtDGN.TabIndex = 6;
            // 
            // txtDGB
            // 
            this.txtDGB.Location = new System.Drawing.Point(386, 77);
            this.txtDGB.Name = "txtDGB";
            this.txtDGB.Size = new System.Drawing.Size(118, 22);
            this.txtDGB.TabIndex = 7;
            // 
            // dtpHSD
            // 
            this.dtpHSD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHSD.Location = new System.Drawing.Point(160, 147);
            this.dtpHSD.Name = "dtpHSD";
            this.dtpHSD.Size = new System.Drawing.Size(118, 22);
            this.dtpHSD.TabIndex = 8;
            // 
            // cbbLoaiHang
            // 
            this.cbbLoaiHang.FormattingEnabled = true;
            this.cbbLoaiHang.Location = new System.Drawing.Point(130, 77);
            this.cbbLoaiHang.Name = "cbbLoaiHang";
            this.cbbLoaiHang.Size = new System.Drawing.Size(118, 24);
            this.cbbLoaiHang.TabIndex = 9;
            // 
            // boxAnh
            // 
            this.boxAnh.Dock = System.Windows.Forms.DockStyle.Right;
            this.boxAnh.Location = new System.Drawing.Point(690, 23);
            this.boxAnh.Name = "boxAnh";
            this.boxAnh.Size = new System.Drawing.Size(336, 139);
            this.boxAnh.TabIndex = 10;
            this.boxAnh.TabStop = false;
            this.boxAnh.Text = "Ảnh";
            // 
            // groupChiTiet
            // 
            this.groupChiTiet.Controls.Add(this.boxAnh);
            this.groupChiTiet.Controls.Add(this.cbbLoaiHang);
            this.groupChiTiet.Controls.Add(this.label1);
            this.groupChiTiet.Controls.Add(this.txtDGB);
            this.groupChiTiet.Controls.Add(this.label2);
            this.groupChiTiet.Controls.Add(this.txtDGN);
            this.groupChiTiet.Controls.Add(this.label3);
            this.groupChiTiet.Controls.Add(this.txtTenSP);
            this.groupChiTiet.Controls.Add(this.label5);
            this.groupChiTiet.Location = new System.Drawing.Point(12, 193);
            this.groupChiTiet.Name = "groupChiTiet";
            this.groupChiTiet.Size = new System.Drawing.Size(824, 132);
            this.groupChiTiet.TabIndex = 11;
            this.groupChiTiet.TabStop = false;
            this.groupChiTiet.Text = "Thông tin sản phẩm";
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 531);
            this.Controls.Add(this.groupChiTiet);
            this.Controls.Add(this.dtpHSD);
            this.Controls.Add(this.label4);
            this.Name = "frmProduct";
            this.Text = "frmProduct";
            this.groupChiTiet.ResumeLayout(false);
            this.groupChiTiet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtDGN;
        private System.Windows.Forms.TextBox txtDGB;
        private System.Windows.Forms.DateTimePicker dtpHSD;
        private System.Windows.Forms.ComboBox cbbLoaiHang;
        private System.Windows.Forms.GroupBox boxAnh;
        private System.Windows.Forms.GroupBox groupChiTiet;
    }
}