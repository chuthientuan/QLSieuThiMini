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

namespace QLSieuThiMini
{
    public partial class frmHDN : Form
    {
        DataBaseProcess db = new DataBaseProcess();
        private void LoadData()
        {
            DataTable dt = db.DataReader("SELECT SanPham.MaSP, TenSP, DonGiaNhap, SLNhap, ThanhTien " +
                                         "FROM ChiTietHDN INNER JOIN SanPham ON ChiTietHDN.MaSP = SanPham.MaSP " +
                                         "WHERE MaHDN = '"+ txtMHD.Text +"'");
            dgvHDN.DataSource = dt;

            //Định dạng dgv
            dgvHDN.Columns[0].HeaderText = "Mã sản phẩm";
            dgvHDN.Columns[1].HeaderText = "Tên sản phẩm";
            dgvHDN.Columns[2].HeaderText = "Đơn giá nhập";
            dgvHDN.Columns[3].HeaderText = "Số lượng nhập";
            dgvHDN.Columns[4].HeaderText = "Thành tiền";
            dgvHDN.BackgroundColor = Color.LightBlue;
        }
        private void LoadCbbMHD()
        {
            DataTable dt = db.DataReader("SELECT MaHDN FROM HoaDonNhap WHERE MaNV = '" + lblMaNV.Text + "'");
            cbbTKMHD.DataSource = dt;
            cbbTKMHD.DisplayMember = "MaHDN";
            cbbTKMHD.ValueMember = "MaHDN";
            cbbTKMHD.SelectedIndex = -1;

            //// Đặt DropDownStyle là DropDown để cho phép nhập văn bản
            //cbbTKMHD.DropDownStyle = ComboBoxStyle.DropDown;

            //// Thiết lập AutoCompleteMode và AutoCompleteSource
            //cbbTKMHD.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbbTKMHD.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void timer1_Tick(object sender, EventArgs e)
        { // Cập nhật Label với thời gian hiện tại
            lbldtnow.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
        public frmHDN()
        {
            InitializeComponent();
        }

        private void frmHDN_Load(object sender, EventArgs e)
        {
            //Lấy thông tin nhân viên 
            DataTable dtNV = db.DataReader("SELECT TenNV FROM NhanVien WHERE MaNV = 1");
            lblTenNV.Text = dtNV.Rows[0]["TenNV"].ToString();
            lblMaNV.Text = "1";

            //Lấy thời gian hiện tại 
            timer1.Interval = 1000; // 1 giây
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

            dtpNgayNhap.Value = DateTime.Now;

            //Load cbb tìm kiếm mã hóa đơn
            LoadCbbMHD();

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cbbTKMHD.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            DataTable dt = db.DataReader("SELECT * " +
                                         "FROM HoaDonNhap " +
                                         "INNER JOIN NhaCungCap ON HoaDonNhap.MaNCC = NhaCungCap.MaNCC " +
                                         "WHERE HoaDonNhap.MaHDN = '"+cbbTKMHD.Text+"' " +
                                         "AND HoaDonNhap.MaNV = '"+ lblMaNV.Text +"'");
            if (dt.Rows.Count > 0)
            {
                txtMHD.Text = cbbTKMHD.Text;
                dtpNgayNhap.Value = Convert.ToDateTime(dt.Rows[0]["NgayNhap"]);
                cbbMaNCC.Text = dt.Rows[0]["MaNCC"].ToString();
                txtTenNCC.Text = dt.Rows[0]["TenNCC"].ToString();
                txtTongTien.Text = dt.Rows[0]["TongTien"].ToString();
                LoadData();
            }
            else
            {
                MessageBox.Show("Không có mã hóa đơn'" + cbbTKMHD.Text + "'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbTKMHD.Text = txtMHD.Text;
            }
        }
    }
}
