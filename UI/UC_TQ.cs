using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.Charts.Interfaces;
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
            profits();
            lineGraph();
            top5Product();
        }
        private void revenue()
        {
            try
            {
                string revenue = @"
                WITH ThisWeekRevenue AS (
                    SELECT 
                        SUM(TongTien) AS DoanhThuTuanNay
                    FROM 
                        HoaDonBan
                    WHERE 
                        NgayBan BETWEEN DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE)) 
                        AND DATEADD(DAY, 7 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))
                ),
                LastWeekRevenue AS (
                    SELECT 
                        SUM(TongTien) AS DoanhThuTuanTruoc
                    FROM 
                        HoaDonBan
                    WHERE 
                        NgayBan BETWEEN DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()) - 7, CAST(GETDATE() AS DATE)) 
                        AND DATEADD(DAY, 7 - DATEPART(WEEKDAY, GETDATE()) - 7, CAST(GETDATE() AS DATE))
                )
                SELECT 
                    ISNULL(ThisWeekRevenue.DoanhThuTuanNay, 0) AS DoanhThuTuanNay,
                    ISNULL(LastWeekRevenue.DoanhThuTuanTruoc, 0) AS DoanhThuTuanTruoc,
                    CASE 
                        WHEN ISNULL(LastWeekRevenue.DoanhThuTuanTruoc, 0) = 0 THEN 0
                        ELSE CAST(
                            ROUND(
                                ((ISNULL(ThisWeekRevenue.DoanhThuTuanNay, 0) - ISNULL(LastWeekRevenue.DoanhThuTuanTruoc, 0)) * 100.0) 
                                / ISNULL(LastWeekRevenue.DoanhThuTuanTruoc, 1),
                                0
                            ) AS INT
                        )
                    END AS PhanTramThayDoi
                FROM 
                    ThisWeekRevenue, LastWeekRevenue";

                DataTable dtTurnover = db.DataReader(revenue);

                if (dtTurnover.Rows.Count > 0)
                {
                    // Lấy và kiểm tra giá trị DoanhThuTuanNay
                    decimal doanhThuTuanNay = dtTurnover.Rows[0]["DoanhThuTuanNay"] != DBNull.Value
                        ? Convert.ToDecimal(dtTurnover.Rows[0]["DoanhThuTuanNay"])
                        : 0;

                    // Hiển thị DoanhThuTuanNay
                    lbDoanhThu.Text = $"{doanhThuTuanNay:N0} VNĐ";

                    // Lấy và kiểm tra giá trị PhanTramThayDoi
                    int phanTramThayDoi = dtTurnover.Rows[0]["PhanTramThayDoi"] != DBNull.Value
                        ? Convert.ToInt32(dtTurnover.Rows[0]["PhanTramThayDoi"])
                        : 0;

                    // Hiển thị PhanTramThayDoi
                    lbRevenue.Text = $"{phanTramThayDoi}%";
                }
                else
                {
                    lbDoanhThu.Text = "0 VNĐ";
                    lbRevenue.Text = "0%";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy doanh thu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void invoice()
        {
            string invoice = @"
                        WITH ThisWeek AS (
                        SELECT 
                            COUNT(MaHDB) AS SoHoaDon
                            FROM 
                            HoaDonBan
                        WHERE 
                            NgayBan BETWEEN DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE)) 
                                        AND DATEADD(DAY, 7 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))
                    ),
                    LastWeek AS (
                        SELECT 
                            COUNT(MaHDB) AS SoHoaDon
                        FROM 
                            HoaDonBan
                        WHERE 
                            NgayBan BETWEEN DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()) - 7, CAST(GETDATE() AS DATE)) 
                                        AND DATEADD(DAY, 7 - DATEPART(WEEKDAY, GETDATE()) - 7, CAST(GETDATE() AS DATE))
                    )
                        SELECT 
                        ThisWeek.SoHoaDon AS SoHoaDonTuanNay,
                        CASE 
                            WHEN LastWeek.SoHoaDon = 0 THEN 0
                            ELSE CAST(((ThisWeek.SoHoaDon * 1.0 - LastWeek.SoHoaDon) / LastWeek.SoHoaDon) * 100 AS INT)
                        END AS PhanTramThayDoi,
                        CASE 
                            WHEN LastWeek.SoHoaDon = 0 THEN '(0 hóa đơn)'
                            ELSE CONCAT('(', LastWeek.SoHoaDon, ' hóa đơn)')
                        END AS GhiChu
                        FROM 
                            ThisWeek, LastWeek";
            DataTable dtInvoice = db.DataReader(invoice);
            lbInvoice.Text = dtInvoice.Rows[0]["SoHoaDonTuanNay"].ToString();
            lbRateHD.Text = dtInvoice.Rows[0]["PhanTramThayDoi"].ToString() + "%" + " " + dtInvoice.Rows[0]["GhiChu"].ToString();
        }
        private void profits()
        {
            string sql = @"DECLARE @StartOfWeek DATE = DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE));
                    DECLARE @EndOfWeek DATE = DATEADD(DAY, 7 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE));
                    SELECT 
                        (ISNULL(SUM(HDB.TongTien), 0) - ISNULL(SUM(HDN.TongTien), 0)) AS LoiNhuanTrongTuan
                    FROM 
                        (SELECT TongTien 
                        FROM HoaDonBan 
                        WHERE NgayBan >= @StartOfWeek AND NgayBan <= @EndOfWeek) AS HDB
                    FULL OUTER JOIN 
                        (SELECT TongTien 
                        FROM HoaDonNhap 
                        WHERE NgayNhap >= @StartOfWeek AND NgayNhap <= @EndOfWeek) AS HDN
                    ON 1 = 1";
            DataTable dt = db.DataReader(sql);
            lbLoiNhuan.Text = String.Format("{0:N0} VNĐ", dt.Rows[0]["LoiNhuanTrongTuan"]);
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
            barChart.XAxes.Display = false;
            barChart.Update();
        }
    }
}
