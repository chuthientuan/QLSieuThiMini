using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSieuThiMini.Classes;
using System.Windows.Forms;

namespace QLSieuThiMini
{
    public partial class frmHDB : Form
    {
        DataBaseProcess db = new DataBaseProcess();
        private int mhd = 1;
        public frmHDB()
        {
            InitializeComponent();
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
            txtMaNV.Text = null;
            txtTenNV.Text = null;
            cbMaKH.Text = null;
            txtTenKH.Text = null;
            txtSDT.Text = null;
            txtDiaChi.Text = null;
        }
        private void frmHDB_Load(object sender, EventArgs e)
        {
            readonlyText(true);
            enable(false);
            DataTable dtb = db.DataReader("select TenNV from NhanVien where MaNV = '" + txtMaNV.Text + "'");
            txtTenNV.Text = dtb.Rows[0]["TenNV"].ToString();

            loadCbbMHD();
        }
        void loadData()
        {
            DataTable dtb = db.DataReader("select s.TenSP, c.SLBan, s.DonGiaBan, c.ThanhTien, c.KhuyenMai, h.NgayBan " +
                "from SanPham s inner join ChiTietHDB c on s.MaSP = c.MaSP " +
                "inner join HoaDonBan h on h.MaHDB = c.MaHDB " +
                "where h.MaNV = '" + txtMaNV.Text +"' and h.MaHDB = '" + txtMaHD.Text + "'");
            dtMatHang.DataSource = dtb;
        }
        private void loadCbbMHD()
        {
            DataTable dt = db.DataReader("select MaHDB from HoaDonBan where MaNV = '" + txtMaNV + "'");
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
            while(check(maHDB))
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

            if(string.IsNullOrEmpty(cbMaHD.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sql = "select * from ChiTietHDB c inner join HoaDonBan h on c.MaHDB = h.MaHDB" +
                        "inner join KhachHang k on k.MaKH = h.MaKH" +
                        "inner join SanPham s on s.MaSP = c.MaSP" +
                        "where c.MaHDB = '" + cbMaHD.Text + "'" +
                        "and h.MaNV = '" + txtMaNV.Text + "'";
            DataTable dt = db.DataReader(sql);

            if(dt.Rows.Count > 0)
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
            if(!string.IsNullOrEmpty(txtSDT.Text))
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
            if(dt.Rows.Count > 0)
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
            if(dt.Rows.Count > 0)
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
            if(int.TryParse(txtSL.Text, out int quan))
            {
                if(quan <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSL.Focus();
                }
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {

        }
    }
}