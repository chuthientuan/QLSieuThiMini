using QLSieuThiMini.Classes;
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
    public partial class UC_HDB : UserControl
    {
        DataBaseProcess db = new DataBaseProcess();
        private int mhd = 1;
        private DataTable invoiceProducts = new DataTable();
        private double totalPrice = 0;
        public UC_HDB()
        {
            InitializeComponent();
            productTable();
        }
        private void readonlyText(bool hide)
        {
            txtSL.ReadOnly = hide;
            txtGiamGia.ReadOnly = hide;
            txtSDT.ReadOnly = hide;
            txtDiaChi.ReadOnly = hide;
        }
        private void enable(bool enable)
        {
            cbTenSP.Enabled = enable;
            cbTenKH.Enabled = enable;
            btnHuy.Enabled = enable;
            btnLuu.Enabled = enable;
            btnIn.Enabled = enable;
            btnThemSP.Enabled = enable;
        }
        private void resetValue()
        {
            cbTenSP.Text = null;
            txtDonGia.Text = null;
            txtSL.Text = null;
            cbMaHD.Text = null;
            txtGiamGia.Text = null;
            txtMaHD.Text = null;
            cbTenKH.Text = null;
            txtSDT.Text = null;
            txtDiaChi.Text = null;
            lbTotalMoney.Text = "0";
            lbPay.Text = "0";
            lbTien.Text = "";
        }
        private void productTable()
        {
            invoiceProducts.Clear();
            invoiceProducts.Columns.Clear();
            invoiceProducts.Columns.Add("Tên hàng", typeof(string));
            invoiceProducts.Columns.Add("Số lượng", typeof(int));
            invoiceProducts.Columns.Add("Giá", typeof(decimal));
            invoiceProducts.Columns.Add("Giảm giá", typeof(int));
            invoiceProducts.Columns.Add("Thành tiền", typeof(decimal));

            dtMatHang.DataSource = invoiceProducts;
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lbTimer.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
        private void UC_HDB_Load(object sender, EventArgs e)
        {
            readonlyText(true);
            enable(false);
            btnHuySP.Enabled = false;
            DataTable dtb = db.DataReader("select TenNV from NhanVien where MaNV = '" + Session.MaNhanVien + "'");
            lblTenNV.Text = dtb.Rows[0]["TenNV"].ToString();
            lblMaNV.Text = Session.MaNhanVien;
            loadCbbMHD();
            timer1.Tick += new EventHandler(timer1_Tick_1);
            timer1.Interval = 1000;
            timer1.Start();
            dtpNgayBan.Value = DateTime.Now;
        }
        void loadData()
        {
            DataTable dtb = db.DataReader("select s.TenSP, c.SLBan, s.DonGiaBan, c.KhuyenMai, c.ThanhTien " +
                "from SanPham s inner join ChiTietHDB c on s.MaSP = c.MaSP " +
                "inner join HoaDonBan h on h.MaHDB = c.MaHDB " +
                "where h.MaNV = '" + lblMaNV.Text + "' and h.MaHDB = '" + txtMaHD.Text + "'");
            dtMatHang.DataSource = dtb;
            dtMatHang.Columns[0].HeaderText = "Tên Hàng";
            dtMatHang.Columns[1].HeaderText = "Số Lượng";
            dtMatHang.Columns[2].HeaderText = "Giá";
            dtMatHang.Columns[3].HeaderText = "Giảm Giá";
            dtMatHang.Columns[4].HeaderText = "Thành Tiền";
        }
        private void loadCbbMHD()
        {
            DataTable dt = db.DataReader("select MaHDB from HoaDonBan");
            cbMaHD.DataSource = dt;
            cbMaHD.DisplayMember = "MaHDB";
            cbMaHD.ValueMember = "MaHDB";
            cbMaHD.SelectedIndex = -1;
        }
        private void resetNV()
        {
            lblMaNV.Text = Session.MaNhanVien;
            lblTenNV.Text = Session.TenNhanVien;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            readonlyText(false);
            resetValue();
            enable(true);
            loadData();
            resetNV();
            cbMaHD.Text = null;
            btnHuy.Enabled = false;
            btnIn.Enabled = false;
            invoiceProducts.Clear();
            dtpNgayBan.Value = DateTime.Now;

            DataTable dtSp = db.DataReader("select TenSP from SanPham");
            cbTenSP.DataSource = dtSp;
            cbTenSP.DisplayMember = "TenSP";
            cbTenSP.ValueMember = "TenSP";
            cbTenSP.SelectedIndex = -1;

            DataTable dtKh = db.DataReader("select TenKH from KhachHang");
            cbTenKH.DataSource = dtKh;
            cbTenKH.DisplayMember = "TenKH";
            cbTenKH.ValueMember = "TenKH";
            cbTenKH.SelectedIndex = -1;
            cbTenKH.DropDownStyle = ComboBoxStyle.DropDown;
            cbTenKH.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTenKH.AutoCompleteSource = AutoCompleteSource.ListItems;

            DateTime currentDate = DateTime.Now;
            string formatDate = currentDate.ToString("ddMMyyyy");
            string formatNumber = mhd.ToString("D3");
            string maHDB = $"HDB_{formatDate}0{formatNumber}";
            while (check(maHDB))
            {
                mhd++;
                formatNumber = mhd.ToString("D3");
                maHDB = $"HDB_{formatDate}0{formatNumber}";
            }
            txtMaHD.Text = maHDB;
        }
        public bool check(string maHDB)
        {
            DataTable dt = db.DataReader("select * from HoaDonBan where MaHDB = '" + maHDB + "'");
            return dt.Rows.Count > 0;
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            readonlyText(true);
            enable(false);
            btnHuySP.Enabled = false;
            btnHuy.Enabled = true;
            btnIn.Enabled = true;

            if (string.IsNullOrEmpty(cbMaHD.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sql = "select * from ChiTietHDB c inner join HoaDonBan h on c.MaHDB = h.MaHDB " +
             "inner join KhachHang k on k.MaKH = h.MaKH " +
             "inner join SanPham s on s.MaSP = c.MaSP " +
             "where c.MaHDB = '" + cbMaHD.Text + "' ";

            DataTable dt = db.DataReader(sql);
            string maNV = dt.Rows[0]["MaNV"].ToString();
            DataTable dtMNV = db.DataReader("select TenNV from NhanVien where MaNV = N'" + maNV + "'");
            lblTenNV.Text = dtMNV.Rows[0]["TenNV"].ToString();
            if (dt.Rows.Count > 0)
            {
                txtMaHD.Text = cbMaHD.Text;
                dtpNgayBan.Value = Convert.ToDateTime(dt.Rows[0]["NgayBan"]);
                lblMaNV.Text = dt.Rows[0]["MaNV"].ToString();
                cbTenKH.Text = dt.Rows[0]["TenKH"].ToString();
                txtSDT.Text = dt.Rows[0]["DienThoai"].ToString();
                txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                lbTotalMoney.Text = String.Format("{0:N0} VND", dt.Rows[0]["TongTien"]);
                lbPay.Text = String.Format("{0:N0} VND", dt.Rows[0]["TongTien"]);
                lbTien.Text = ConvertToWords((decimal)dt.Rows[0]["TongTien"]);
                loadData();
            }
            else
            {
                MessageBox.Show("Không có mã hóa đơn'" + cbMaHD.Text + "'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbMaHD.Text = txtMaHD.Text;
            }
        }
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSDT.Text))
            {
                DataTable dt = db.DataReader("select * from KhachHang where DienThoai = '" + txtSDT.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    cbTenKH.Text = dt.Rows[0]["TenKH"].ToString();
                    txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                }
                else
                {
                    cbTenKH.Text = cbTenKH.Text;
                    txtDiaChi.Text = txtDiaChi.Text;
                }
            }
            else
            {
                cbTenKH.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
            }
        }
        private void cbTenKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = db.DataReader("select * from KhachHang where TenKH = N'" + cbTenKH.Text + "'");
            if (dt.Rows.Count > 0)
            {
                txtSDT.Text = dt.Rows[0]["DienThoai"].ToString();
                txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
            }
            else
            {
                txtSDT.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
            }
        }
        private void cbTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void cbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = db.DataReader("select DonGiaBan from SanPham where TenSP = N'" + cbTenSP.Text + "'");
            if (dt.Rows.Count > 0)
            {
                txtDonGia.Text = dt.Rows[0]["DonGiaBan"].ToString();
            }
            else
            {
                txtDonGia.Text = string.Empty;
            }
        }
        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtSL.Text, out int quan))
            {
                if (quan <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSL.Focus();
                }
            }
        }
        //Tien bang chu
        private string ConvertToWords(decimal number)
        {
            string[] units = { "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] places = { "", "nghìn", "triệu", "tỷ" };

            if (number == 0) return "không đồng";

            string words = "";
            int placeIndex = 0;

            while (number > 0)
            {
                int group = (int)(number % 1000);
                if (group > 0)
                {
                    string groupWords = ConvertGroupToWords(group, units);
                    words = groupWords + " " + places[placeIndex] + " " + words;
                }

                number /= 1000;
                placeIndex++;
            }

            words = words.Trim() + " đồng";
            words = char.ToUpper(words[0]) + words.Substring(1); // Viết hoa chữ cái đầu.
            return words;
        }
        private string ConvertGroupToWords(int group, string[] units)
        {
            string result = "";
            int hundred = group / 100;
            int ten = (group % 100) / 10;
            int one = group % 10;

            if (hundred > 0) result += units[hundred] + " trăm ";

            if (ten > 0)
            {
                if (ten == 1) result += "mười ";
                else result += units[ten] + " mươi ";
            }

            if (one > 0)
            {
                if (ten > 1 && one == 1) result += "mốt ";
                else if (one == 5) result += "lăm ";
                else result += units[one] + " ";
            }

            return result.Trim();
        }
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            btnHuySP.Enabled = true;
            if (string.IsNullOrEmpty(cbTenSP.Text) || !int.TryParse(txtSL.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSL.Focus();
                return;
            }
            DataTable dtSP = db.DataReader("select SoLuong from SanPham where TenSP = N'" + cbTenSP.Text + "'");
            int sl = int.Parse(dtSP.Rows[0]["SoLuong"].ToString());
            if (sl < quantity)
            {
                MessageBox.Show("Số lượng sản phẩm không đủ. Hiện có " + sl + " sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double price = Convert.ToDouble(txtDonGia.Text);
            double discount = string.IsNullOrEmpty(txtGiamGia.Text) ? 0 : Convert.ToDouble(txtGiamGia.Text);
            double total = quantity * price * (1 - discount / 100);
            totalPrice += total;
            lbTotalMoney.Text = String.Format("{0:N0} VND", totalPrice);
            lbPay.Text = String.Format("{0:N0} VNĐ", totalPrice);
            lbTien.Text = ConvertToWords((decimal)totalPrice);
            try
            {
                DataRow row = invoiceProducts.NewRow();
                row["Tên hàng"] = cbTenSP.Text;
                row["Số lượng"] = quantity;
                row["Giá"] = price;
                row["Giảm giá"] = discount;
                row["Thành tiền"] = total;

                invoiceProducts.Rows.Add(row);
                dtMatHang.DataSource = invoiceProducts;
                dtMatHang.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool checkInformation()
        {
            if (string.IsNullOrWhiteSpace(cbTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTenKH.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }
            return true;
        }
        private bool checkProduct()
        {
            if (invoiceProducts.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!checkInformation() || !checkProduct())
            {
                return;
            }
            try
            {
                int customerId;
                string sqlCheckKH = "select count(*) from KhachHang where DienThoai = '" + txtSDT.Text + "'";
                int count = (int)db.ExecuteScalar(sqlCheckKH);
                if (count == 0)
                {
                    string sqlInsertKH = "insert into KhachHang (TenKH, DiaChi, DienThoai) values" +
                        "('" + cbTenKH.Text + "', '" + txtDiaChi.Text + "', '" + txtSDT.Text + "')";
                    db.DataChange(sqlInsertKH);
                    string sqlGetNewKH = "select MaKH from KhachHang where DienThoai = '" + txtSDT.Text + "'";
                    customerId = (int)db.ExecuteScalar(sqlGetNewKH);
                }
                else
                {
                    string sqlGetExistingKH = "select MaKH from KhachHang where DienThoai = '" + txtSDT.Text + "'";
                    customerId = (int)db.ExecuteScalar(sqlGetExistingKH);
                }
                DataTable dt = db.DataReader("select MaKH from KhachHang where DienThoai = '" + txtSDT.Text + "'");
                int maKH = int.Parse(dt.Rows[0]["MaKH"].ToString());
                decimal totalMoney = decimal.Parse(lbTotalMoney.Text.Replace(" VND", "").Replace(",", ""));
                string invoiceSql = "insert into HoaDonBan (MaHDB, MaNV, NgayBan, TongTien, MaKH) values" +
                    "('" + txtMaHD.Text + "', '" + lblMaNV.Text + "', '" + dtpNgayBan.Value.ToString("yyyy-MM-dd") + "', '" + totalMoney + "', '" + maKH + "')";
                db.DataChange(invoiceSql);
                foreach (DataRow row in invoiceProducts.Rows)
                {
                    string productName = row["Tên hàng"].ToString();
                    DataTable dataTable = db.DataReader("select MaSP from SanPham where TenSP = N'" + productName + "'");
                    int productId = Convert.ToInt32(dataTable.Rows[0]["MaSP"].ToString());
                    int quantity = Convert.ToInt32(row["Số lượng"]);
                    decimal discount = Convert.ToDecimal(row["Giảm giá"]);
                    decimal total = Convert.ToDecimal(row["Thành tiền"]);

                    string detailSql = "insert into ChiTietHDB (MaHDB, MaSP, SLBan, ThanhTien, KhuyenMai) values" +
                        "('" + txtMaHD.Text + "', '" + productId + "', '" + quantity + "', '" + total + "', '" + discount + "')";
                    db.DataChange(detailSql);

                    string updateQuantitySql = "update SanPham set SoLuong = SoLuong - '" + quantity + "' where MaSP = '" + productId + "'";
                    db.DataChange(updateQuantitySql);
                }
                MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Bạn có muốn in hóa đơn không?",
                                          "Xác nhận",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    print1();
                }
                resetValue();
                loadCbbMHD();
                readonlyText(true);
                enable(false);
                invoiceProducts.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnMoi_Click(object sender, EventArgs e)
        {
            readonlyText(true);
            loadCbbMHD();
            enable(false);
            resetValue();
            resetNV();
            btnHuySP.Enabled = false;
            cbTenSP.SelectedIndex = -1;
            loadData();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn mã hóa đơn để hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy hóa đơn này không?", "Xác nhận hủy hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string maHDB = txtMaHD.Text;
                    DataTable dtDetails = db.DataReader($"SELECT MaSP, SLBan FROM ChiTietHDB WHERE MaHDB = '{maHDB}'");
                    foreach (DataRow row in dtDetails.Rows)
                    {
                        int productId = Convert.ToInt32(row["MaSP"]);
                        int quantity = Convert.ToInt32(row["SLBan"]);

                        string updateProductSql = $"UPDATE SanPham SET SoLuong = SoLuong + {quantity} WHERE MaSP = {productId}";
                        db.DataChange(updateProductSql);
                    }
                    string deleteDetailsSql = $"DELETE FROM ChiTietHDB WHERE MaHDB = '{maHDB}'";
                    db.DataChange(deleteDetailsSql);
                    string deleteInvoiceSql = $"DELETE FROM HoaDonBan WHERE MaHDB = '{maHDB}'";
                    db.DataChange(deleteInvoiceSql);

                    MessageBox.Show("Hóa đơn đã được hủy thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    resetValue();
                    loadCbbMHD();
                    invoiceProducts.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hủy hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            loadData();
        }
        private void print1()
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

            worksheet.Cells[1, 1] = "Hóa Đơn Bán";
            worksheet.Cells[2, 1] = "Mã Hóa Đơn:";
            worksheet.Cells[2, 2] = txtMaHD.Text;
            worksheet.Cells[3, 1] = "Ngày:";
            worksheet.Cells[3, 2] = dtpNgayBan.Value.ToString("dd/MM/yyyy");
            worksheet.Cells[4, 1] = "Tên Khách Hàng:";
            worksheet.Cells[4, 2] = cbTenKH.Text;
            worksheet.Cells[5, 1] = "Số Điện Thoại:";
            worksheet.Cells[5, 2].NumberFormat = "@";
            worksheet.Cells[5, 2] = txtSDT.Text;
            worksheet.Cells[6, 1] = "Địa Chỉ:";
            worksheet.Cells[6, 2] = txtDiaChi.Text;

            worksheet.Cells[8, 1] = "Tên Hàng";
            worksheet.Cells[8, 2] = "Số Lượng";
            worksheet.Cells[8, 3] = "Giá";
            worksheet.Cells[8, 4] = "Giảm giá";
            worksheet.Cells[8, 5] = "Thành Tiền";

            int row = 9;
            foreach (DataRow dgvRow in invoiceProducts.Rows)
            {
                worksheet.Cells[row, 1] = dgvRow["Tên hàng"].ToString();
                worksheet.Cells[row, 2] = dgvRow["Số lượng"].ToString();
                worksheet.Cells[row, 3] = dgvRow["Giá"].ToString();
                worksheet.Cells[row, 4] = dgvRow["Giảm giá"].ToString();
                worksheet.Cells[row, 5] = dgvRow["Thành tiền"].ToString();
                row++;
            }
            worksheet.Cells[row + 1, 4] = "Tổng Tiền:";
            worksheet.Cells[row + 1, 5] = lbTotalMoney.Text;
            worksheet.Cells[row + 2, 4] = "Tiền bằng chữ:";
            worksheet.Cells[row + 2, 5] = ConvertToWords((decimal)totalPrice);
            worksheet.Range["A1", "F1"].Font.Bold = true;
            worksheet.Range["A8", "F8"].Font.Bold = true;
            worksheet.Columns.AutoFit();
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Save Invoice"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Hóa đơn đã được xuất ra file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            workbook.Close(false);
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }
        private void print()
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

            worksheet.Cells[1, 1] = "Hóa Đơn Bán";
            worksheet.Cells[2, 1] = "Mã Hóa Đơn:";
            worksheet.Cells[2, 2] = txtMaHD.Text;
            worksheet.Cells[3, 1] = "Ngày:";
            worksheet.Cells[3, 2] = dtpNgayBan.Value.ToString("dd/MM/yyyy");
            worksheet.Cells[4, 1] = "Tên Khách Hàng:";
            worksheet.Cells[4, 2] = cbTenKH.Text;
            worksheet.Cells[5, 1] = "Số Điện Thoại:";
            worksheet.Cells[5, 2].NumberFormat = "@";
            worksheet.Cells[5, 2] = txtSDT.Text;
            worksheet.Cells[6, 1] = "Địa Chỉ:";
            worksheet.Cells[6, 2] = txtDiaChi.Text;

            worksheet.Cells[8, 1] = "Tên Hàng";
            worksheet.Cells[8, 2] = "Số Lượng";
            worksheet.Cells[8, 3] = "Giá";
            worksheet.Cells[8, 4] = "Giảm giá";
            worksheet.Cells[8, 5] = "Thành Tiền";

            int row = 9;
            foreach (DataGridViewRow dgvRow in dtMatHang.Rows)
            {
                if (dgvRow.IsNewRow) continue;
                worksheet.Cells[row, 1] = dgvRow.Cells["TenSP"].Value;
                worksheet.Cells[row, 2] = dgvRow.Cells["SLBan"].Value;
                worksheet.Cells[row, 3] = dgvRow.Cells["DonGiaBan"].Value;
                worksheet.Cells[row, 4] = dgvRow.Cells["KhuyenMai"].Value;
                worksheet.Cells[row, 5] = dgvRow.Cells["ThanhTien"].Value;
                row++;
            }
            string sql = "select TongTien from HoaDonBan where MaHDB = '" + cbMaHD.Text + "'";
            DataTable dt = db.DataReader(sql);
            worksheet.Cells[row + 1, 4] = "Tổng Tiền:";
            worksheet.Cells[row + 1, 5] = String.Format("{0:N0} VND", dt.Rows[0]["TongTien"]);
            worksheet.Cells[row + 2, 4] = "Tiền bằng chữ:";
            worksheet.Cells[row + 2, 5] = ConvertToWords((decimal)dt.Rows[0]["TongTien"]);
            worksheet.Range["A1", "F1"].Font.Bold = true;
            worksheet.Range["A8", "F8"].Font.Bold = true;
            worksheet.Columns.AutoFit();
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Save Invoice"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Hóa đơn đã được xuất ra file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            workbook.Close(false);
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            print();
        }
        private void btnHuySP_Click(object sender, EventArgs e)
        {
            if (dtMatHang.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn hủy các sản phẩm đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    for (int i = dtMatHang.SelectedRows.Count - 1; i >= 0; i--)
                    {
                        int rowIndex = dtMatHang.SelectedRows[i].Index;
                        double total = Convert.ToDouble(invoiceProducts.Rows[rowIndex]["Thành Tiền"]);
                        totalPrice -= total;
                        invoiceProducts.Rows.RemoveAt(rowIndex);
                    }
                    lbTotalMoney.Text = totalPrice.ToString();
                    lbPay.Text = totalPrice.ToString();
                    lbTien.Text = ConvertToWords((decimal)totalPrice);
                    dtMatHang.DataSource = invoiceProducts;
                    dtMatHang.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Chọn ít nhất một sản phẩm để hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
