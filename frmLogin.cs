using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSieuThiMini.Classes;

namespace QLSieuThiMini
{
    public partial class frmLogin : Form
    {
        DataBaseProcess dtBase = new DataBaseProcess();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string MaNV = txtLogin.Text.Trim();
            string MatKhau = txtPassword.Text.Trim();

            DataTable dtNhanVien = dtBase.DataReader($"Select * from NhanVien where MaNV = '{MaNV}' and MatKhau = '{MatKhau}'");
            if (dtNhanVien.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                frmHome frm = new frmHome(MaNV);
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLogin.Clear();
                txtPassword.Clear();
                txtLogin.Focus();
            }
        }
    }
}
