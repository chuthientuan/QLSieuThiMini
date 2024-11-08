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
    public partial class frmHome : Form
    {
        public int MaNV = 0;
        public frmHome(int manv)
        {
            InitializeComponent();
            MaNV = manv;
            guna2HtmlLabel1.Text = "Welcome, " + MaNV.ToString();
        }

        private void frmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }
    }
}
