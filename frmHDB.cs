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
            cbMaHang.Enabled = enable;
            cbMaKH.Enabled = enable;
            btnHuy.Enabled = enable;
            btnLuu.Enabled = enable;
            btnIn.Enabled = enable;
            btnThemSP.Enabled = enable;
        }
        private void resetValue()
        {
            cbMaHang.Text = null;
            txtTenHang.Text = null;
            txtDonGia.Text = null;
            txtSL.Text = null;
            cbMaHD.Text = null;
            txtGiamGia.Text = null;
            txtMaHD.Text = null;
            cbMaKH.Text = null;
            txtTenKH.Text = null;
            txtSDT.Text = null;
            txtDiaChi.Text = null;
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
            DataTable dtb = db.DataReader("select TenNV from NhanVien where MaNV = 1");
            txtTenNV.Text = dtb.Rows[0]["TenNV"].ToString();
            txtMaNV.Text = "1";
            loadCbbMHD();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();

            dtpNgayBan.Value = DateTime.Now;
        }
        void loadData()
        {
            DataTable dtb = db.DataReader("select s.TenSP, c.SLBan, s.DonGiaBan, c.KhuyenMai, c.ThanhTien, h.NgayBan " +
                "from SanPham s inner join ChiTietHDB c on s.MaSP = c.MaSP " +
                "inner join HoaDonBan h on h.MaHDB = c.MaHDB " +
                "where h.MaNV = '" + txtMaNV.Text + "' and h.MaHDB = '" + txtMaHD.Text + "'");
            dtMatHang.DataSource = dtb;
            dtMatHang.Columns[0].HeaderText = "Tên hàng";
            dtMatHang.Columns[1].HeaderText = "Số lượng";
            dtMatHang.Columns[2].HeaderText = "Giá";
            dtMatHang.Columns[3].HeaderText = "Giảm giá";
            dtMatHang.Columns[4].HeaderText = "Thành Tiền";
            dtMatHang.Columns[5].HeaderText = "Ngày bán";
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
            btnHuy.Enabled = false;
            btnIn.Enabled = false;
            invoiceProducts.Clear();

            DataTable dtSp = db.DataReader("select MaSP from SanPham");
            cbMaHang.DataSource = dtSp;
            cbMaHang.DisplayMember = "MaSP";
            cbMaHang.ValueMember = "MaSP";
            cbMaHang.SelectedIndex = -1;

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
                dtMatHang.DataSource = dt;
                dtMatHang.Columns[0].HeaderText = "Tên hàng";
                dtMatHang.Columns[1].HeaderText = "Số lượng";
                dtMatHang.Columns[2].HeaderText = "Giá";
                dtMatHang.Columns[3].HeaderText = "Giảm giá";
                dtMatHang.Columns[4].HeaderText = "Thành Tiền";
                dtMatHang.Columns[5].HeaderText = "Ngày bán";
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
        private void cbMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = db.DataReader("select TenSP, DonGiaBan from SanPham where MaSP = '" + cbMaHang.Text + "'");
            if (dt.Rows.Count > 0)
            {
                txtTenHang.Text = dt.Rows[0]["TenSP"].ToString();
                txtDonGia.Text = dt.Rows[0]["DonGiaBan"].ToString();
            }
            else
            {
                txtTenHang.Text = string.Empty;
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
            if (string.IsNullOrEmpty(cbMaHang.Text) || !int.TryParse(txtSL.Text, out int quantity) || quantity <= 0)
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
            try
            {
                DataRow row = invoiceProducts.NewRow();
                row["Mã hàng"] = cbMaHang.Text;
                row["Tên hàng"] = txtTenHang.Text;
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
            if(string.IsNullOrWhiteSpace(cbMaKH.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbMaKH.Focus();
                return false;
            }
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
                string sqlCheckKH = "select count(*) from KhachHang where DienThoai = '" + txtSDT.Text + "'";
                int count = (int)db.ExecuteScalar(sqlCheckKH);
                if(count == 0 )
                {
                    string sqlInsertKH = "insert into KhachHang (MaKH, TenKH, DiaChi, DienThoai) values" +
                        "('" + cbMaKH.Text + "', '" + txtTenKH.Text + "', '" + txtDiaChi.Text + "', '" + txtSDT.Text + "')";
                    db.DataChange(sqlInsertKH);
                }
                string invoiceSql = "insert into HoaDonBan (MaHDB, MaNV, NgayBan, TongTien, MaKH) values" +
                    "('" + txtMaHD.Text + "', '" + txtMaNV.Text + "', '" + dtpNgayBan.Value.ToString("yyyy-MM-dd") + "', '" + lbTotalMoney.Text + "', '" + cbMaKH.Text + "')";
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
    }
}
