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
    public partial class Form1 : Form
    {
        UC_Login uc_Login = new UC_Login();
        UC_Home uc_Home = new UC_Home();
        public Form1()
        {
            InitializeComponent();
            uc_Login.Dock = DockStyle.Fill;
            uc_Home.Dock = DockStyle.Fill;
            uc_Login.OnSwitchToHome += uc_Login_OnSwitchToHome;
            this.Controls.Add(uc_Login);
        }
        private void uc_Login_OnSwitchToHome(object sender, EventArgs e)
        {
            // Chuyển sang trang Home
            this.Controls.Clear();
            this.Controls.Add(uc_Home);
        }
    }
}
