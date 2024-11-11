using QLSieuThiMini.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSieuThiMini
{
    public partial class frmHDN : Form
    {
        DataBaseProcess db = new DataBaseProcess();
        private void LoadcbbNCC()
        {
            DataTable dt = db.DataReader("SELECT MaNCC, TenNCC FROM NhaCungCap");
            cbbTenNCC.DataSource = dt;
            cbbTenNCC.ValueMember = "MaNCC";
            cbbTenNCC.DisplayMember = "TenNCC";
            cbbTenNCC.SelectedIndex = -1;

            cbbTenNCC.DropDownStyle = ComboBoxStyle.DropDown;
            cbbTenNCC.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbTenNCC.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void HidebtnChucNang(bool hide)
        {
            btnThemHD.Enabled = hide;
            btnHuyHD.Enabled = hide;
            btnLuuHD.Enabled = hide;
            btnInHD.Enabled = hide;
            btnThemSP.Enabled = hide;
        }
        private void HideGrbTimKiem(bool hide)
        {
            cbbTKMHDN.Enabled = hide;
            btnTimKiem.Enabled = hide;
        }
        private void HideData(bool hide)
        {
            dtpNgayNhap.Enabled = hide;
            cbbTenNCC.Enabled = hide;
            cbbMaSP.Enabled = hide;
            txtTenSP.Enabled = hide;
            txtDonGiaNhap.Enabled = hide;
            txtSoLuongNhap.Enabled = hide;
        }
        //Hiện tiền bằng chữ
        private static string ConvertToText(decimal number)
        {
            if (number == 0) return "Không đồng.";
            string[] units = { "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] ranks = { "", "nghìn", "triệu", "tỷ" };
            string result = "";
            int rank = 0;
            while (number > 0)
            {
                int group = (int)(number % 1000);
                number /= 1000;
                if (group > 0)
                {
                    string groupText = ConvertGroupToText(group, units);
                    result = groupText + " " + ranks[rank] + " " + result;
                }
                rank++;
            }
            return result.Trim() + " đồng.";
        }
        private static string ConvertGroupToText(int group, string[] units)
        {
            int hundreds = group / 100;
            int tens = (group % 100) / 10;
            int ones = group % 10;
            string result = "";

            // Xử lý hàng trăm
            if (hundreds > 0)
            {
                result += units[hundreds] + " trăm ";
            }

            // Xử lý hàng chục
            if (tens > 1)
            {
                result += units[tens] + " mươi ";
                if (ones == 1) result += "mốt";
                else if (ones == 5) result += "lăm";
                else if (ones > 0) result += units[ones];
            }
            else if (tens == 1)
            {
                result += "mười ";
                if (ones == 5) result += "lăm";
                else if (ones > 0) result += units[ones];
            }
            else if (tens == 0 && ones > 0)
            {
                // Chỉ thêm "lẻ" khi hàng trăm khác 0 và hàng chục là 0
                if (hundreds > 0) result += "lẻ ";
                if (ones == 5) result += "lăm";
                else result += units[ones];
            }
            return result.Trim();
        }

        //reset dữ liệu
        private void ResetTTChung()
        {
            cbbTKMHDN.Text = string.Empty;
            txtMHDN.Text = string.Empty;
            dtpNgayNhap.Value = DateTime.Now;
            cbbTenNCC.Text = string.Empty;
            txtTongTien.Text = string.Empty;
            
            dgvHDN.DataSource = null;
        }
        private void ResetTTSP()
        {
            cbbMaSP.Text = string.Empty;
            txtTenSP.Text = string.Empty;
            txtDonGiaNhap.Text = string.Empty;
            txtSoLuongNhap.Text = string.Empty;
            txtThanhTien.Text = string.Empty;
        }
        //Load dgv
        private void LoadData()
        {
            DataTable dt = db.DataReader("SELECT SanPham.MaSP, TenSP, DonGiaNhap, SLNhap, ThanhTien " +
                                         "FROM ChiTietHDN INNER JOIN SanPham ON ChiTietHDN.MaSP = SanPham.MaSP " +
                                         "WHERE MaHDN = '"+ txtMHDN.Text +"'");
            dgvHDN.DataSource = dt;

            //Định dạng dgv
            dgvHDN.Columns[0].HeaderText = "Mã sản phẩm";
            dgvHDN.Columns[1].HeaderText = "Tên sản phẩm";
            dgvHDN.Columns[2].HeaderText = "Đơn giá nhập";
            dgvHDN.Columns[3].HeaderText = "Số lượng nhập";
            dgvHDN.Columns[4].HeaderText = "Thành tiền";

            dgvHDN.BackgroundColor = Color.LightBlue;
        }
        //LoadCBB tìm kiếm hóa đơn
        private void LoadCbbMHD()
        {
            DataTable dt = db.DataReader("SELECT MaHDN FROM HoaDonNhap WHERE MaNV = '" + lblMaNV.Text + "'");
            cbbTKMHDN.DataSource = dt;
            cbbTKMHDN.DisplayMember = "MaHDN";
            cbbTKMHDN.ValueMember = "MaHDN";
            cbbTKMHDN.SelectedIndex = -1;

            // Đặt DropDownStyle là DropDown để cho phép nhập văn bản
            cbbTKMHDN.DropDownStyle = ComboBoxStyle.DropDown;

            // Thiết lập AutoCompleteMode và AutoCompleteSource
            cbbTKMHDN.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbTKMHDN.AutoCompleteSource = AutoCompleteSource.ListItems;
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
            txtMHDN.Enabled = false;
            txtTongTien.Enabled = false;
            txtThanhTien.Enabled = false;

            HidebtnChucNang(false);
            btnThemHD.Enabled = true;

            HideData(false);
            //Lấy thông tin nhân viên 
            DataTable dtNV = db.DataReader("SELECT TenNV FROM NhanVien WHERE MaNV = 'NV02'");
            lblTenNV.Text = dtNV.Rows[0]["TenNV"].ToString();
            lblMaNV.Text = "NV02";

            //Lấy thời gian hiện tại 
            timer1.Interval = 1000; // 1 giây
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

            dtpNgayNhap.Value = DateTime.Now;

            //Load cbb tìm kiếm mã hóa đơn
            LoadCbbMHD();

            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ResetTTSP();
            if (String.IsNullOrEmpty(cbbTKMHDN.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            HidebtnChucNang(true);
            btnThemSP.Enabled = false;
            btnLuuHD.Enabled = false;
            DataTable dt = db.DataReader("SELECT * " +
                                         "FROM HoaDonNhap " +
                                         "INNER JOIN NhaCungCap ON HoaDonNhap.MaNCC = NhaCungCap.MaNCC " +
                                         "WHERE HoaDonNhap.MaHDN = '"+cbbTKMHDN.Text+"' " +
                                         "AND HoaDonNhap.MaNV = '"+ lblMaNV.Text +"'");
            if (dt.Rows.Count > 0)
            {
                txtMHDN.Text = cbbTKMHDN.Text;
                dtpNgayNhap.Value = Convert.ToDateTime(dt.Rows[0]["NgayNhap"]);
                cbbTenNCC.Text = dt.Rows[0]["TenNCC"].ToString();
                txtTongTien.Text = dt.Rows[0]["TongTien"].ToString();
                LoadData();
            }
            else
            {
                MessageBox.Show("Không có mã hóa đơn'" + cbbTKMHDN.Text + "'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbTKMHDN.Text = txtMHDN.Text;
            }
        }

        private void dgvHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbMaSP.Text = dgvHDN.CurrentRow.Cells[0].Value.ToString();
            txtTenSP.Text = dgvHDN.CurrentRow.Cells[1].Value.ToString();
            txtDonGiaNhap.Text = dgvHDN.CurrentRow.Cells[2].Value.ToString();
            txtSoLuongNhap.Text = dgvHDN.CurrentRow.Cells[3].Value.ToString();
            txtThanhTien.Text = dgvHDN.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            HideData(false);
            ResetTTChung();
            ResetTTSP();
            LoadCbbMHD();

            HideGrbTimKiem(true);

            HidebtnChucNang(false);
            btnThemHD.Enabled = true;

            LoadData();

        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTongTien.Text, out decimal tongTien))
            {
                lblTongTienBangChu.Text = ConvertToText(tongTien);
            }
            else
            {
                lblTongTienBangChu.Text = ""; // Xóa nội dung nếu không phải số hợp lệ
            }
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            //reset data
            HideData(true);
            ResetTTChung();
            dtpNgayNhap.Enabled = false;
            ResetTTSP();
            HideGrbTimKiem(false);

            HidebtnChucNang(false);

            btnThemSP.Enabled = true;
            btnLuuHD.Enabled = true;


            //Sinh mã hóa đơn nhập
            string newMaHD = "HDN_" + DateTime.Now.ToString("ddMMyyyyHHmmss");
            txtMHDN.Text = newMaHD;

            LoadData();

            //Load cbbNCC
            LoadcbbNCC();

        }
    }
}
