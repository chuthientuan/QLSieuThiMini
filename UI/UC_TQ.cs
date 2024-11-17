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

namespace QLSieuThiMini.UI
{
    public partial class UC_TQ : UserControl
    {
        DataBaseProcess db = new DataBaseProcess();
        public UC_TQ()
        {
            InitializeComponent();
        }
        private void UC_TQ_Load(object sender, EventArgs e)
        {
            string turnover = "select sum(TongTien) as DoanhThu from HoaDonBan";
            string invoice = "select count(*) as SHD from HoaDonBan";
            string stock = "select sum(SoLuong) as Kho, count(*) as SoSP from SanPham";

            DataTable dtTurnover = db.DataReader(turnover);
            lbDoanhThu.Text = String.Format("{0:N0} VNĐ", dtTurnover.Rows[0]["DoanhThu"]);

            DataTable dtInvoice = db.DataReader(invoice);
            lbInvoice.Text = dtInvoice.Rows[0]["SHD"].ToString();

            DataTable dtStock = db.DataReader(stock);
            lbTonKho.Text = dtStock.Rows[0]["Kho"].ToString();
            lbSoSPKho.Text = dtStock.Rows[0]["SoSP"].ToString() + " sản phẩm";
        }
    }
}
