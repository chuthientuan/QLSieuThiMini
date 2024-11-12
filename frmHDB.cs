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
using static System.Collections.Specialized.BitVector32;

namespace QLSieuThiMini
{
    public partial class frmHDB : Form
    {
        DataBaseProcess db = new DataBaseProcess();
        private int mhd = 1;
        private DataTable invoiceProducts = new DataTable();
        private decimal totalPrice = 0;
        public frmHDB()
        {
            InitializeComponent();
            productTable();
        }
        private void readonlyText(bool hide)
        {
            txtSL.ReadOnly = hide;
            txtGiamGia.ReadOnly = hide;
            txtTenKH.ReadOnly = hide;
            txtSDT.ReadOnly = hide;
            txtDiaChi.ReadOnly = hide;
        }
        private void enable(bool enable)
        {
            cbTenSP.Enabled = enable;
            cbMaKH.Enabled = enable;
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
            cbMaKH.Text = null;
            txtTenKH.Text = null;
            txtSDT.Text = null;
            txtDiaChi.Text = null;
            lbTotalMoney.Text = "0";
            lbPay.Text = "0";
        }
        private void productTable()
        {
            invoiceProducts.Clear();
            invoiceProducts.Columns.Clear();
            invoiceProducts.Columns.Add("Mã hàng", typeof(int));
            invoiceProducts.Columns.Add("Tên hàng", typeof(string));
            invoiceProducts.Columns.Add("Số lượng", typeof(int));
            invoiceProducts.Columns.Add("Giá", typeof(decimal));
            invoiceProducts.Columns.Add("Giảm giá", typeof(int));
            invoiceProducts.Columns.Add("Thành tiền", typeof(decimal));

            dtMatHang.DataSource = invoiceProducts;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTimer.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
        private void frmHDB_Load(object sender, EventArgs e)
        {
            readonlyText(true);
            enable(false);
            DataTable dtb = db.DataReader("select TenNV from NhanVien where MaNV = N'NV01'");
            txtTenNV.Text = dtb.Rows[0]["TenNV"].ToString();
            txtMaNV.Text = "NV01";
            loadCbbMHD();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();

            dtpNgayBan.Value = DateTime.Now;
        }
        void loadData()
        {
            DataTable dtb = db.DataReader("select s.TenSP, c.SLBan, s.DonGiaBan, c.KhuyenMai, c.ThanhTien " +
                "from SanPham s inner join ChiTietHDB c on s.MaSP = c.MaSP " +
                "inner join HoaDonBan h on h.MaHDB = c.MaHDB " +
                "where h.MaNV = '" + txtMaNV.Text + "' and h.MaHDB = '" + txtMaHD.Text + "'");
            dtMatHang.DataSource = dtb;
            dtMatHang.Columns[0].HeaderText = "Tên Hàng";
            dtMatHang.Columns[1].HeaderText = "Số Lượng";
            dtMatHang.Columns[2].HeaderText = "Giá";
            dtMatHang.Columns[3].HeaderText = "Giảm Giá";
            dtMatHang.Columns[4].HeaderText = "Thành Tiền";
        }
        private void loadCbbMHD()
        {
            DataTable dt = db.DataReader("select MaHDB from HoaDonBan where MaNV = '" + txtMaNV.Text + "'");
            cbMaHD.DataSource = dt;
            cbMaHD.DisplayMember = "MaHDB";
            cbMaHD.ValueMember = "MaHDB";
            cbMaHD.SelectedIndex = -1;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            readonlyText(false);
            resetValue();
            enable(true);
            loadData();
            cbMaHD.Text = null;
            btnHuy.Enabled = false;
            btnIn.Enabled = false;
            invoiceProducts.Clear();

            DataTable dtSp = db.DataReader("select TenSP from SanPham");
            cbTenSP.DataSource = dtSp;
            cbTenSP.DisplayMember = "TenSP";
            cbTenSP.ValueMember = "TenSP";
            cbTenSP.SelectedIndex = -1;

            DataTable dtKh = db.DataReader("select MaKH from KhachHang");
            cbMaKH.DataSource = dtKh;
            cbMaKH.DisplayMember = "MaKH";
            cbMaKH.ValueMember = "MaKH";
            cbMaKH.SelectedIndex = -1;

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
             "where c.MaHDB = '" + cbMaHD.Text + "' " +
             "and h.MaNV = '" + txtMaNV.Text + "'";

            DataTable dt = db.DataReader(sql);

            if (dt.Rows.Count > 0)
            {
                txtMaHD.Text = cbMaHD.Text;
                dtpNgayBan.Value = Convert.ToDateTime(dt.Rows[0]["NgayBan"]);
                cbMaKH.Text = dt.Rows[0]["MaKH"].ToString();
                txtTenKH.Text = dt.Rows[0]["TenKH"].ToString();
                txtSDT.Text = dt.Rows[0]["DienThoai"].ToString();
                txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
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
                    cbMaKH.Text = dt.Rows[0]["MaKH"].ToString();
                    txtTenKH.Text = dt.Rows[0]["TenKH"].ToString();
                    txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                }
                else
                {
                    cbMaKH.Text = string.Empty;
                    txtTenKH.Text = string.Empty;
                    txtDiaChi.Text = string.Empty;
                }
            }
            else
            {
                cbMaKH.Text = string.Empty;
                txtTenKH.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
            }
        }
        private void cbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = db.DataReader("select * from KhachHang where MaKH = '" + cbMaKH.Text + "'");
            if (dt.Rows.Count > 0)
            {
                txtTenKH.Text = dt.Rows[0]["TenKH"].ToString();
                txtSDT.Text = dt.Rows[0]["DienThoai"].ToString();
                txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
            }
            else
            {
                txtTenKH.Text = string.Empty;
                txtSDT.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
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
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbTenSP.Text) || !int.TryParse(txtSL.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSL.Focus();
                return;
            }
            decimal price = Convert.ToDecimal(txtDonGia.Text);
            decimal discount = string.IsNullOrEmpty(txtGiamGia.Text) ? 0 : Convert.ToDecimal(txtGiamGia.Text);
            decimal total = quantity * price * (1 - discount / 100);
            totalPrice += total;
            lbTotalMoney.Text = totalPrice.ToString();
            lbPay.Text = totalPrice.ToString();
            DataTable dt = db.DataReader("select MaSP from SanPham where TenSP = N'" + cbTenSP.Text + "'");
            int maSP = int.Parse(dt.Rows[0]["MaSP"].ToString());
            try
            {
                DataRow row = invoiceProducts.NewRow();
                row["Mã hàng"] = maSP;
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
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKH.Focus();
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
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(!checkInformation())
            {
                return;
            }
            try
            {
                int customerId;
                string sqlCheckKH = "select count(*) from KhachHang where DienThoai = '" + txtSDT.Text + "'";
                int count = (int)db.ExecuteScalar(sqlCheckKH);
                if(count == 0 )
                {
                    string sqlInsertKH = "insert into KhachHang (TenKH, DiaChi, DienThoai) values" +
                        "('" + txtTenKH.Text + "', '" + txtDiaChi.Text + "', '" + txtSDT.Text + "')";
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
                string invoiceSql = "insert into HoaDonBan (MaHDB, MaNV, NgayBan, TongTien, MaKH) values" +
                    "('" + txtMaHD.Text + "', '" + txtMaNV.Text + "', '" + dtpNgayBan.Value.ToString("yyyy-MM-dd") + "', '" + lbTotalMoney.Text + "', '" + maKH + "')";
                db.DataChange(invoiceSql);
                foreach(DataRow row in invoiceProducts.Rows)
                {
                    int productId = Convert.ToInt32(row["Mã hàng"]);
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
                resetValue();
                loadCbbMHD();
                readonlyText(true);
                enable(false);
                invoiceProducts.Clear();
            } catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?",
                                          "Xác nhận",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnMoi_Click(object sender, EventArgs e)
        {
            readonlyText(true);
            loadCbbMHD();
            enable(false);
            resetValue();
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
        private void btnIn_Click(object sender, EventArgs e)
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
            worksheet.Cells[4, 2] = txtTenKH.Text;
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
            worksheet.Cells[row + 1, 5] = "Tổng Tiền:";
            worksheet.Cells[row + 1, 6] = dt.Rows[0]["TongTien"].ToString();
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
        
    }
}
