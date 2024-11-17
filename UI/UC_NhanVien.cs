using QLSieuThiMini.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSieuThiMini.UI
{
    public partial class UC_NhanVien : UserControl
    {
        DataBaseProcess dtBase = new DataBaseProcess();
        private string ImageName = null;
        public UC_NhanVien()
        {
            InitializeComponent();
            txtMatKhau.PasswordChar = '*';
            //thêm giới tính 
            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");
        }
        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            DataTable dtNhanVien = dtBase.DataReader("Select * from NhanVien");
            dvgNhanVien.DataSource = dtNhanVien;

            dvgNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dvgNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dvgNhanVien.Columns[2].HeaderText = "Mật Khẩu ";
            dvgNhanVien.Columns[3].HeaderText = "Chức Danh";
            dvgNhanVien.Columns[4].HeaderText = "Anh";
            dvgNhanVien.Columns[5].HeaderText = "Giới Tính ";
            dvgNhanVien.Columns[6].HeaderText = "Ngày Sinh";
            dvgNhanVien.Columns[7].HeaderText = "Điện Thoại";

            dvgNhanVien.BackgroundColor = Color.LightBlue;
            dtNhanVien.Dispose();//Giải phóng bộ nhớ cho DataTable
            btnTaoMoi.Enabled = true;
            btnLuu.Enabled = false;
            btnNhapLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;
        }
    }
}
