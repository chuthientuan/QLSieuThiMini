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
    public partial class frmProduct : Form
    {
        
        public frmProduct()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            DataTable dtTT = dtBase.DataReader("Select tblHang.Mahang, Tenhang, tblChitietHDBan.Soluong, Dongiaban, Giamgia, Thanhtien " +
                "from tblHang inner join tblChitietHDBan on tblHang.Mahang = tblChitietHDBan.Mahang " +
                "inner join tblHDBan on tblHDBan.MaHDBan = tblChitietHDBan.MaHDBan where Manhanvien = '" + maNhanVien + "' and tblHDBan.MaHDBan = '" + txtMaHD.Text + "'");
            dgvThongTin.DataSource = dtTT;
            dgvThongTin.BackgroundColor = Color.LightBlue;
        }

    }
}
