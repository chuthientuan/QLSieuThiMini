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
        public frmHDB()
        {
            InitializeComponent();
        }
        private void readonlyText(bool hide)
        {
            txtTenHang.ReadOnly = hide;
            txtDonGia.ReadOnly = hide;
            txtSL.ReadOnly = hide;
            txtGiamGia.ReadOnly = hide;
            txtMaHD.ReadOnly = hide;
            txtMaNV.ReadOnly = hide;
            txtTenNV.ReadOnly = hide;
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
        }
        void loadData()
        {
            DataTable dtb = db.DataReader("select s.TenSP, c.SLBan, s.DonGiaBan, c.ThanhTien, c.KhuyenMai, h.NgayBan " +
                "from SanPham s inner join ChiTietHDB c on s.MaSP = c.MaSP " +
                "inner join HoaDonBan h on h.MaHDB = c.MaHDB " +
                "where h.MaNV = '" + txtMaNV.Text +"' and h.MaHDB = '" + txtMaHD.Text + "'");
            dtMatHang.DataSource = dtb;
        }
    }
}
