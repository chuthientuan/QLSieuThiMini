namespace QLSieuThiMini
{
    partial class frmNhanVien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanVien));
            this.tieude = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.grbchitiet = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtMatKhau = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSDT = new Guna.UI2.WinForms.Guna2TextBox();
            this.dagNgaySinh = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cbbGioiTinh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtTenNV = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaNV = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grbtimkiem = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtTimMaNV = new Guna.UI2.WinForms.Guna2TextBox();
            this.dvgNhanVien = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.label12 = new System.Windows.Forms.Label();
            this.guna2GroupBox3 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnsearch = new Guna.UI2.WinForms.Guna2Button();
            this.btnThoat = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaoMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnNhapLai = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.errChiTiet = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbchitiet.SuspendLayout();
            this.grbtimkiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgNhanVien)).BeginInit();
            this.guna2GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // tieude
            // 
            this.tieude.BackColor = System.Drawing.Color.Transparent;
            this.tieude.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tieude.Location = new System.Drawing.Point(443, 12);
            this.tieude.Name = "tieude";
            this.tieude.Size = new System.Drawing.Size(3, 2);
            this.tieude.TabIndex = 0;
            this.tieude.Text = null;
            this.tieude.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grbchitiet
            // 
            this.grbchitiet.BorderColor = System.Drawing.Color.White;
            this.grbchitiet.BorderRadius = 5;
            this.grbchitiet.Controls.Add(this.txtMatKhau);
            this.grbchitiet.Controls.Add(this.txtSDT);
            this.grbchitiet.Controls.Add(this.dagNgaySinh);
            this.grbchitiet.Controls.Add(this.cbbGioiTinh);
            this.grbchitiet.Controls.Add(this.txtTenNV);
            this.grbchitiet.Controls.Add(this.txtMaNV);
            this.grbchitiet.Controls.Add(this.label8);
            this.grbchitiet.Controls.Add(this.label6);
            this.grbchitiet.Controls.Add(this.label3);
            this.grbchitiet.Controls.Add(this.label2);
            this.grbchitiet.Controls.Add(this.label1);
            this.grbchitiet.Controls.Add(this.label4);
            this.grbchitiet.CustomBorderColor = System.Drawing.Color.LightGray;
            this.grbchitiet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbchitiet.ForeColor = System.Drawing.Color.Black;
            this.grbchitiet.Location = new System.Drawing.Point(12, 71);
            this.grbchitiet.Name = "grbchitiet";
            this.grbchitiet.Size = new System.Drawing.Size(624, 416);
            this.grbchitiet.TabIndex = 1;
            this.grbchitiet.Text = "Chi Tiết Nhân Viên";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BorderRadius = 5;
            this.txtMatKhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMatKhau.DefaultText = "";
            this.txtMatKhau.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMatKhau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMatKhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMatKhau.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMatKhau.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMatKhau.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMatKhau.Location = new System.Drawing.Point(286, 353);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '\0';
            this.txtMatKhau.PlaceholderText = "";
            this.txtMatKhau.SelectedText = "";
            this.txtMatKhau.Size = new System.Drawing.Size(290, 37);
            this.txtMatKhau.TabIndex = 21;
            this.txtMatKhau.TextChanged += new System.EventHandler(this.txtMatKhau_TextChanged);
            // 
            // txtSDT
            // 
            this.txtSDT.BorderRadius = 5;
            this.txtSDT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSDT.DefaultText = "";
            this.txtSDT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSDT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSDT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSDT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSDT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSDT.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSDT.Location = new System.Drawing.Point(286, 289);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.PasswordChar = '\0';
            this.txtSDT.PlaceholderText = "";
            this.txtSDT.SelectedText = "";
            this.txtSDT.Size = new System.Drawing.Size(290, 37);
            this.txtSDT.TabIndex = 20;
            this.txtSDT.TextChanged += new System.EventHandler(this.txtSDT_TextChanged);
            this.txtSDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDT_KeyPress);
            // 
            // dagNgaySinh
            // 
            this.dagNgaySinh.BorderRadius = 5;
            this.dagNgaySinh.Checked = true;
            this.dagNgaySinh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dagNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dagNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dagNgaySinh.Location = new System.Drawing.Point(286, 227);
            this.dagNgaySinh.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dagNgaySinh.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dagNgaySinh.Name = "dagNgaySinh";
            this.dagNgaySinh.Size = new System.Drawing.Size(140, 36);
            this.dagNgaySinh.TabIndex = 19;
            this.dagNgaySinh.Value = new System.DateTime(2024, 11, 7, 17, 28, 44, 811);
            this.dagNgaySinh.ValueChanged += new System.EventHandler(this.guna2DateTimePicker1_ValueChanged);
            // 
            // cbbGioiTinh
            // 
            this.cbbGioiTinh.BackColor = System.Drawing.Color.Transparent;
            this.cbbGioiTinh.BorderRadius = 5;
            this.cbbGioiTinh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbGioiTinh.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbGioiTinh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbGioiTinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbGioiTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbGioiTinh.ItemHeight = 30;
            this.cbbGioiTinh.Location = new System.Drawing.Point(286, 165);
            this.cbbGioiTinh.Name = "cbbGioiTinh";
            this.cbbGioiTinh.Size = new System.Drawing.Size(132, 36);
            this.cbbGioiTinh.TabIndex = 18;
            this.cbbGioiTinh.SelectedIndexChanged += new System.EventHandler(this.cbbGioiTinh_SelectedIndexChanged);
            // 
            // txtTenNV
            // 
            this.txtTenNV.BorderRadius = 5;
            this.txtTenNV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenNV.DefaultText = "";
            this.txtTenNV.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenNV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenNV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenNV.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenNV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenNV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenNV.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenNV.Location = new System.Drawing.Point(286, 113);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.PasswordChar = '\0';
            this.txtTenNV.PlaceholderText = "";
            this.txtTenNV.SelectedText = "";
            this.txtTenNV.Size = new System.Drawing.Size(290, 37);
            this.txtTenNV.TabIndex = 17;
            this.txtTenNV.TextChanged += new System.EventHandler(this.txtTenNV_TextChanged);
            // 
            // txtMaNV
            // 
            this.txtMaNV.BorderRadius = 5;
            this.txtMaNV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaNV.DefaultText = "";
            this.txtMaNV.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaNV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaNV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaNV.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaNV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaNV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaNV.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaNV.Location = new System.Drawing.Point(286, 59);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.PasswordChar = '\0';
            this.txtMaNV.PlaceholderText = "";
            this.txtMaNV.SelectedText = "";
            this.txtMaNV.Size = new System.Drawing.Size(290, 42);
            this.txtMaNV.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(55, 368);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 22);
            this.label8.TabIndex = 15;
            this.label8.Text = "Mật Khẩu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "Số Điện Thoại ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ngày Sinh ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "Giới Tính";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Họ và Tên :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mã Nhân Viên :";
            // 
            // grbtimkiem
            // 
            this.grbtimkiem.BorderRadius = 5;
            this.grbtimkiem.Controls.Add(this.txtTimMaNV);
            this.grbtimkiem.Controls.Add(this.btTimKiem);
            this.grbtimkiem.Controls.Add(this.label12);
            this.grbtimkiem.Enabled = false;
            this.grbtimkiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbtimkiem.ForeColor = System.Drawing.Color.Black;
            this.grbtimkiem.Location = new System.Drawing.Point(642, 71);
            this.grbtimkiem.Name = "grbtimkiem";
            this.grbtimkiem.Size = new System.Drawing.Size(609, 201);
            this.grbtimkiem.TabIndex = 2;
            this.grbtimkiem.Text = "Tìm Kiếm Nhân Viên";
            // 
            // txtTimMaNV
            // 
            this.txtTimMaNV.BorderRadius = 5;
            this.txtTimMaNV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimMaNV.DefaultText = "";
            this.txtTimMaNV.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimMaNV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimMaNV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimMaNV.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimMaNV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimMaNV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimMaNV.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimMaNV.Location = new System.Drawing.Point(239, 64);
            this.txtTimMaNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTimMaNV.Name = "txtTimMaNV";
            this.txtTimMaNV.PasswordChar = '\0';
            this.txtTimMaNV.PlaceholderText = "";
            this.txtTimMaNV.SelectedText = "";
            this.txtTimMaNV.Size = new System.Drawing.Size(287, 37);
            this.txtTimMaNV.TabIndex = 22;
            // 
            // dvgNhanVien
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dvgNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dvgNhanVien.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgNhanVien.DefaultCellStyle = dataGridViewCellStyle3;
            this.dvgNhanVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dvgNhanVien.Location = new System.Drawing.Point(642, 278);
            this.dvgNhanVien.Name = "dvgNhanVien";
            this.dvgNhanVien.RowHeadersVisible = false;
            this.dvgNhanVien.RowHeadersWidth = 51;
            this.dvgNhanVien.RowTemplate.Height = 24;
            this.dvgNhanVien.Size = new System.Drawing.Size(609, 209);
            this.dvgNhanVien.TabIndex = 3;
            this.dvgNhanVien.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dvgNhanVien.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dvgNhanVien.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dvgNhanVien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dvgNhanVien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dvgNhanVien.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dvgNhanVien.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dvgNhanVien.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dvgNhanVien.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dvgNhanVien.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgNhanVien.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dvgNhanVien.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dvgNhanVien.ThemeStyle.HeaderStyle.Height = 30;
            this.dvgNhanVien.ThemeStyle.ReadOnly = false;
            this.dvgNhanVien.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dvgNhanVien.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dvgNhanVien.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgNhanVien.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dvgNhanVien.ThemeStyle.RowsStyle.Height = 24;
            this.dvgNhanVien.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dvgNhanVien.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dvgNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgNhanVien_CellClick);
            // 
            // btTimKiem
            // 
            this.btTimKiem.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.btTimKiem.BorderRadius = 10;
            this.btTimKiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btTimKiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btTimKiem.ForeColor = System.Drawing.Color.White;
            this.btTimKiem.Location = new System.Drawing.Point(187, 128);
            this.btTimKiem.Name = "btTimKiem";
            this.btTimKiem.Size = new System.Drawing.Size(180, 45);
            this.btTimKiem.TabIndex = 2;
            this.btTimKiem.Text = "Tìm Kiếm ";
            this.btTimKiem.Click += new System.EventHandler(this.btTimKiem_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(69, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 22);
            this.label12.TabIndex = 1;
            this.label12.Text = "Mã Nhân Viên";
            // 
            // guna2GroupBox3
            // 
            this.guna2GroupBox3.BorderRadius = 5;
            this.guna2GroupBox3.Controls.Add(this.btnsearch);
            this.guna2GroupBox3.Controls.Add(this.btnThoat);
            this.guna2GroupBox3.Controls.Add(this.btnTaoMoi);
            this.guna2GroupBox3.Controls.Add(this.btnXoa);
            this.guna2GroupBox3.Controls.Add(this.btnLuu);
            this.guna2GroupBox3.Controls.Add(this.btnNhapLai);
            this.guna2GroupBox3.Controls.Add(this.btnSua);
            this.guna2GroupBox3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox3.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox3.Location = new System.Drawing.Point(12, 502);
            this.guna2GroupBox3.Name = "guna2GroupBox3";
            this.guna2GroupBox3.Size = new System.Drawing.Size(1238, 139);
            this.guna2GroupBox3.TabIndex = 4;
            this.guna2GroupBox3.Text = "Chức Năng";
            // 
            // btnsearch
            // 
            this.btnsearch.Animated = true;
            this.btnsearch.BorderRadius = 10;
            this.btnsearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnsearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnsearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnsearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnsearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnsearch.ForeColor = System.Drawing.Color.White;
            this.btnsearch.Image = ((System.Drawing.Image)(resources.GetObject("btnsearch.Image")));
            this.btnsearch.ImageSize = new System.Drawing.Size(25, 25);
            this.btnsearch.Location = new System.Drawing.Point(17, 60);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(153, 48);
            this.btnsearch.TabIndex = 2;
            this.btnsearch.Text = "Tìm Kiếm";
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BorderRadius = 10;
            this.btnThoat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThoat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThoat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThoat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThoat.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(1063, 63);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(162, 45);
            this.btnThoat.TabIndex = 17;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.BorderRadius = 10;
            this.btnTaoMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaoMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaoMoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.btnTaoMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTaoMoi.ForeColor = System.Drawing.Color.White;
            this.btnTaoMoi.Image = global::QLSieuThiMini.Properties.Resources.icons8_add_67;
            this.btnTaoMoi.ImageSize = new System.Drawing.Size(25, 25);
            this.btnTaoMoi.Location = new System.Drawing.Point(204, 63);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(152, 45);
            this.btnTaoMoi.TabIndex = 12;
            this.btnTaoMoi.Text = "Thêm Mới ";
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BorderRadius = 10;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(28)))), ((int)(((byte)(24)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(902, 63);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(145, 45);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "Xóa ";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 10;
            this.btnLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Image = global::QLSieuThiMini.Properties.Resources.icons8_save_50;
            this.btnLuu.Location = new System.Drawing.Point(380, 63);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 45);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "Lưu ";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnNhapLai
            // 
            this.btnNhapLai.BorderRadius = 10;
            this.btnNhapLai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNhapLai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNhapLai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNhapLai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNhapLai.FillColor = System.Drawing.Color.Teal;
            this.btnNhapLai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNhapLai.ForeColor = System.Drawing.Color.White;
            this.btnNhapLai.Image = global::QLSieuThiMini.Properties.Resources.icons8_reset_48;
            this.btnNhapLai.Location = new System.Drawing.Point(718, 63);
            this.btnNhapLai.Name = "btnNhapLai";
            this.btnNhapLai.Size = new System.Drawing.Size(153, 45);
            this.btnNhapLai.TabIndex = 14;
            this.btnNhapLai.Text = "Nhập Lại";
            this.btnNhapLai.Click += new System.EventHandler(this.btnNhapLai_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 10;
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.FillColor = System.Drawing.Color.Gold;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(547, 63);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(154, 45);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa ";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // errChiTiet
            // 
            this.errChiTiet.ContainerControl = this;
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 660);
            this.Controls.Add(this.guna2GroupBox3);
            this.Controls.Add(this.dvgNhanVien);
            this.Controls.Add(this.grbtimkiem);
            this.Controls.Add(this.grbchitiet);
            this.Controls.Add(this.tieude);
            this.Name = "frmNhanVien";
            this.Text = "FormNV";
            this.Load += new System.EventHandler(this.FormNV_Load);
            this.grbchitiet.ResumeLayout(false);
            this.grbchitiet.PerformLayout();
            this.grbtimkiem.ResumeLayout(false);
            this.grbtimkiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgNhanVien)).EndInit();
            this.guna2GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errChiTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel tieude;
        private Guna.UI2.WinForms.Guna2GroupBox grbchitiet;
        private Guna.UI2.WinForms.Guna2GroupBox grbtimkiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox txtMatKhau;
        private Guna.UI2.WinForms.Guna2TextBox txtSDT;
        private Guna.UI2.WinForms.Guna2DateTimePicker dagNgaySinh;
        private Guna.UI2.WinForms.Guna2ComboBox cbbGioiTinh;
        private Guna.UI2.WinForms.Guna2TextBox txtTenNV;
        private Guna.UI2.WinForms.Guna2TextBox txtMaNV;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2TextBox txtTimMaNV;
        private Guna.UI2.WinForms.Guna2Button btTimKiem;
        private Guna.UI2.WinForms.Guna2DataGridView dvgNhanVien;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox3;
        private Guna.UI2.WinForms.Guna2Button btnsearch;
        private Guna.UI2.WinForms.Guna2Button btnThoat;
        private Guna.UI2.WinForms.Guna2Button btnTaoMoi;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnNhapLai;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private System.Windows.Forms.ErrorProvider errChiTiet;
    }
}