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
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtTDN.Focus();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sql = "select MaNV, TenNV, MatKhau, ChucDanh from NhanVien" +
                " where MaNV = '" + txtTDN.Text + "' and MatKhau = '" + txtMK.Text + "'";
            DataTable dt = db.DataReader(sql);
            if(dt.Rows.Count > 0 )
            {
                Session.MaNhanVien = dt.Rows[0]["MaNV"].ToString();
                Session.TenNhanVien = dt.Rows[0]["TenNV"].ToString();
                int cd = int.Parse(dt.Rows[0]["ChucDanh"].ToString());
                
                if(cd == 0)
                {
                    FrmAdmin frmAdmin = new FrmAdmin();
                    frmAdmin.Show();
                }
                else
                {
                    FrmNV frmNV = new FrmNV();
                    frmNV.Show();
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtTDN.Text = null;
            txtMK.Text = null;
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
        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
