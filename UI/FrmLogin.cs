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
    public partial class FrmLogin : Form
    {
        DataBaseProcess db = new DataBaseProcess();
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sql = "select MaNV, TenNV, MatKhau from NhanVien" +
                " where MaNV = '" + txtTDN.Text + "' and MatKhau = '" + txtMK.Text + "'";
            DataTable dt = db.DataReader(sql);
            if(dt.Rows.Count > 0 )
            {
                Session.MaNhanVien = dt.Rows[0]["MaNV"].ToString();
                Session.TenNhanVien = dt.Rows[0]["TenNV"].ToString();
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FrmHome frmHome = new FrmHome();
                frmHome.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(guna2CheckBox1.Checked)
            {
                txtMK.PasswordChar = (char)0;
            }
            else
            {
                txtMK.PasswordChar = '*';
            }
        }
    }
}
