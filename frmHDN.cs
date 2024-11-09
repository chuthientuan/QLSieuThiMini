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
        
    }
}
