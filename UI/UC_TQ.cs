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
            revenue();
            invoice();
            lineGraph();
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
        private void lineGraph()
        {
            try
            {
                string sql = @"SELECT 
                        FORMAT(NgayBan, 'dd-MM-yyyy') AS Date,
                        DATENAME(WEEKDAY, NgayBan) AS DayName,
                        SUM(TongTien) AS Revenue,
                        CASE 
                            WHEN DATEDIFF(WEEK, NgayBan, GETDATE()) = 1 THEN 'LastWeek'
                            WHEN DATEDIFF(WEEK, NgayBan, GETDATE()) = 0 THEN 'ThisWeek'
                        END AS WeekCategory
                    FROM 
                        HoaDonBan
                    WHERE 
                        DATEDIFF(WEEK, NgayBan, GETDATE()) IN (0, 1)
                    GROUP BY 
                        NgayBan, 
                        FORMAT(NgayBan, 'dd-MM-yyyy'), 
                        DATENAME(WEEKDAY, NgayBan),
                        CASE 
                            WHEN DATEDIFF(WEEK, NgayBan, GETDATE()) = 1 THEN 'LastWeek'
                            WHEN DATEDIFF(WEEK, NgayBan, GETDATE()) = 0 THEN 'ThisWeek'
                        END
                    ORDER BY 
                        WeekCategory, 
                        FORMAT(NgayBan, 'dd-MM-yyyy')";

                DataTable dt = db.DataReader(sql);

                lineLastWeek.DataPoints.Clear();
                lineThisWeek.DataPoints.Clear();

                // Danh sách ngày trong tuần
                List<string> daysOfWeek = new List<string>
                {
                    "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
                };

                // Khởi tạo doanh thu mặc định là 0 cho cả tuần trước và tuần này
                Dictionary<string, double> revenueLastWeek = daysOfWeek.ToDictionary(day => day, day => 0.0);
                Dictionary<string, double> revenueThisWeek = daysOfWeek.ToDictionary(day => day, day => 0.0);

                // Đọc dữ liệu từ cơ sở dữ liệu
                foreach (DataRow row in dt.Rows)
                {
                    string dayName = row["DayName"].ToString();
                    double revenue = double.Parse(row["Revenue"].ToString());
                    string weekCategory = row["WeekCategory"].ToString();

                    if (weekCategory == "LastWeek" && revenueLastWeek.ContainsKey(dayName))
                    {
                        revenueLastWeek[dayName] = revenue;
                    }
                    else if (weekCategory == "ThisWeek" && revenueThisWeek.ContainsKey(dayName))
                    {
                        revenueThisWeek[dayName] = revenue;
                    }
                }

                // Thêm dữ liệu vào biểu đồ
                foreach (var day in daysOfWeek)
                {
                    lineLastWeek.DataPoints.Add(day, revenueLastWeek[day]);
                    lineThisWeek.DataPoints.Add(day, revenueThisWeek[day]);
                }
                lineChart.Update();
            } catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi vẽ biểu đồ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
