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
            string stock = "select sum(SoLuong) as Kho, count(*) as SoSP from SanPham";
            DataTable dtStock = db.DataReader(stock);
            lbTonKho.Text = dtStock.Rows[0]["Kho"].ToString();
            lbSoSPKho.Text = dtStock.Rows[0]["SoSP"].ToString() + " sản phẩm";
            revenue();
            invoice();
            top5Product();
        }
        private void revenue()
        {
            string revenue = @"
                WITH TodayRevenue AS (
                    SELECT 
                        SUM(TongTien) AS DoanhThuHomNay
                    FROM 
                        HoaDonBan
                    WHERE 
                        CAST(NgayBan AS DATE) = CAST(GETDATE() AS DATE)
                ),
                YesterdayRevenue AS (
                    SELECT 
                        SUM(TongTien) AS DoanhThuHomQua
                    FROM 
                        HoaDonBan
                    WHERE 
                        CAST(NgayBan AS DATE) = CAST(DATEADD(DAY, -1, GETDATE()) AS DATE)
                )
                SELECT 
                    ISNULL(TodayRevenue.DoanhThuHomNay, 0) AS DoanhThuHomNay,
                    ISNULL(YesterdayRevenue.DoanhThuHomQua, 0) AS DoanhThuHomQua,
                    CASE 
                        WHEN ISNULL(YesterdayRevenue.DoanhThuHomQua, 0) = 0 THEN 0
                        ELSE CAST(
                            ROUND(
                                ((ISNULL(TodayRevenue.DoanhThuHomNay, 0) - ISNULL(YesterdayRevenue.DoanhThuHomQua, 0)) * 100.0) / ISNULL(YesterdayRevenue.DoanhThuHomQua, 1), 
                                0
                            ) AS INT    
                        )
                    END AS PhanTramThayDoi
                FROM 
                    TodayRevenue, YesterdayRevenue";
            DataTable dtTurnover = db.DataReader(revenue);
            lbDoanhThu.Text = String.Format("{0:N0} VNĐ", dtTurnover.Rows[0]["DoanhThuHomNay"]);
            lbRevenue.Text = dtTurnover.Rows[0]["PhanTramThayDoi"].ToString() + "%";
        }
        private void invoice()
        {
            string invoice = @"
                WITH Today AS (
                    SELECT 
                        COUNT(MaHDB) AS SoHoaDon
                    FROM 
                        HoaDonBan
                    WHERE 
                        CAST(NgayBan AS DATE) = CAST(GETDATE() AS DATE)
                ),
                Yesterday AS (
                    SELECT 
                        COUNT(MaHDB) AS SoHoaDon
                    FROM 
                        HoaDonBan
                    WHERE 
                        CAST(NgayBan AS DATE) = CAST(DATEADD(DAY, -1, GETDATE()) AS DATE)
                )
                SELECT 
                    Today.SoHoaDon AS SoHoaDonHomNay,
                    CASE 
                        WHEN Yesterday.SoHoaDon = 0 THEN 0
                        ELSE CAST(((Today.SoHoaDon * 1.0 - Yesterday.SoHoaDon) / Yesterday.SoHoaDon) * 100 as int)
                    END AS PhanTramThayDoi,
                    CASE 
                        WHEN Yesterday.SoHoaDon = 0 THEN '(0 hóa đơn)'
                        ELSE CONCAT('(', Yesterday.SoHoaDon, ' hóa đơn)')
                    END AS GhiChu
                FROM 
                    Today, Yesterday";
            DataTable dtInvoice = db.DataReader(invoice);
            lbInvoice.Text = dtInvoice.Rows[0]["SoHoaDonHomNay"].ToString();
            lbRateHD.Text = dtInvoice.Rows[0]["PhanTramThayDoi"].ToString() + "%" + " " + dtInvoice.Rows[0]["GhiChu"].ToString();
        }
        private void top5Product()
        {
            string sql = "select top 5 s.TenSP as ProductName, sum(c.SLBan) as TotalQuantity " +
                "from ChiTietHDB c inner join SanPham s on c.MaSP = s.MaSP " +
                "inner join HoaDonBan h on c.MaHDB = h.MaHDB " +
                "where month(h.NgayBan) = month(GETDATE()) and " +
                "year(h.NgayBan) = year(GETDATE()) " +
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
