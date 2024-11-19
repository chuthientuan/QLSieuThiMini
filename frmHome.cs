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
        public string MaNV = "";
        public frmHome(string manv)
        {
            InitializeComponent();
            MaNV = manv;
            guna2HtmlLabel1.Text = "Welcome, " + MaNV;
        }

        private void frmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct frm = new frmProduct();
            frm.Show();
        }
    }
}
