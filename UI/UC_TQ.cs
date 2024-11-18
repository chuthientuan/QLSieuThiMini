using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.Charts.WinForms;
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
            top5Product();
        }
        private void top5Product()
        {
            string sql = "select top 5 s.TenSP as ProductName, sum(c.SLBan) as TotalQuantity " +
                "from ChiTietHDB c inner join SanPham s on c.MaSP = s.MaSP " +
                "group by s.TenSP order by TotalQuantity DESC";
            DataTable dt = db.DataReader(sql);
            pd1.DataPoints.Clear();
            pd2.DataPoints.Clear();
            pd3.DataPoints.Clear();
            pd4.DataPoints.Clear();
            pd5.DataPoints.Clear();

            if (dt.Rows.Count >= 5)
            {
                pd1.DataPoints.Add(dt.Rows[0]["ProductName"].ToString(), int.Parse(dt.Rows[0]["TotalQuantity"].ToString()));
                pd1.Label = dt.Rows[0]["ProductName"].ToString();

                pd2.DataPoints.Add(dt.Rows[1]["ProductName"].ToString(), int.Parse(dt.Rows[1]["TotalQuantity"].ToString()));
                pd2.Label = dt.Rows[1]["ProductName"].ToString();

                pd3.DataPoints.Add(dt.Rows[2]["ProductName"].ToString(), int.Parse(dt.Rows[2]["TotalQuantity"].ToString()));
                pd3.Label = dt.Rows[2]["ProductName"].ToString();

                pd4.DataPoints.Add(dt.Rows[3]["ProductName"].ToString(), int.Parse(dt.Rows[3]["TotalQuantity"].ToString()));
                pd4.Label = dt.Rows[3]["ProductName"].ToString();

                pd5.DataPoints.Add(dt.Rows[4]["ProductName"].ToString(), int.Parse(dt.Rows[4]["TotalQuantity"].ToString()));
                pd5.Label = dt.Rows[4]["ProductName"].ToString();
            }
            barChart.Update();
        }
    }
}
