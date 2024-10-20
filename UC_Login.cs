using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSieuThiMini
{
    public partial class UC_Login : UserControl
    {
        public event EventHandler OnSwitchToHome;
        private string us_Name = "manhanvien";
        private string password = "sodienthoai";
        public UC_Login()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string inputUserName = txtUserName.Text;
            string inputPassword = txtPassword.Text;

            if (inputUserName == us_Name && inputPassword == password)
            {
                if (OnSwitchToHome != null)
                {
                    OnSwitchToHome(this, EventArgs.Empty);
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
