using Guna.UI2.WinForms;
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
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }
        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            imgSlide.Location = new Point(b.Location.X + 131, b.Location.Y - 30);
            imgSlide.SendToBack();
        }
        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }
        private void FrmHome_Load(object sender, EventArgs e)
        {
            ShowUserControl(new UC_NhanVien());
        }
        private void ShowUserControl(UserControl userControl)
        {
            pnlContent.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(userControl);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_NhanVien());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_KhachHang());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_HDB());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_HDN());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_SanPham());
        }
    }
}
