using QLSieuThiMini.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSieuThiMini.UI
{
    public partial class UC_NhanVien : UserControl
    {
        DataBaseProcess dtBase = new DataBaseProcess();
        private string ImageName = null;
        public UC_NhanVien()
        {
            InitializeComponent();
            //thêm giới tính 
            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");
        }
        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            tieude.Text = "QUẢN LÝ NHÂN VIÊN";
            DataTable dtNhanVien = dtBase.DataReader("Select t.MaNV,t.TenNV, t.MatKhau,t.Anh, t.GioiTinh, t.NgaySinh, t.DienThoai from NhanVien t Where ChucDanh = 1");
            dvgNhanVien.DataSource = dtNhanVien;

            dvgNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dvgNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dvgNhanVien.Columns[2].HeaderText = "Mật Khẩu ";
            dvgNhanVien.Columns[3].HeaderText = "Anh";
            dvgNhanVien.Columns[4].HeaderText = "Giới Tính ";
            dvgNhanVien.Columns[5].HeaderText = "Ngày Sinh";
            dvgNhanVien.Columns[6].HeaderText = "Điện Thoại";

            dvgNhanVien.BackgroundColor = Color.LightBlue;
            dtNhanVien.Dispose();//Giải phóng bộ nhớ cho DataTable
            btnTaoMoi.Enabled = true;
            btnLuu.Enabled = false;
            btnNhapLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void btnsearch_Click(object sender, EventArgs e)
        {

            grbchitiet.Enabled = false;
            dvgNhanVien.Enabled = false;
            btnsearch.Enabled = false;
            btnNhapLai.Enabled = true;
            txtTimKiem.Enabled = true;
            tieude.Text = "TÌM KIẾM NHÂN VIÊN";
        }
        private void dvgNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dvgNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtTenNV.Text = dvgNhanVien.CurrentRow.Cells[1].Value.ToString();
            txtMatKhau.Text = dvgNhanVien.CurrentRow.Cells[2].Value.ToString();
            string imageName = dvgNhanVien.CurrentRow.Cells[3].Value?.ToString();
            if (imageName != "")
            {
                Anh.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + imageName);
            }
            else
            {
                Anh.Image = null;
            }
            cbbGioiTinh.Text = dvgNhanVien.CurrentRow.Cells[4].Value.ToString();
            dagNgaySinh.Text = dvgNhanVien.CurrentRow.Cells[5].Value.ToString();
            txtSDT.Text = dvgNhanVien.CurrentRow.Cells[6].Value.ToString();
            btnAnh.Enabled = true;
            btnTaoMoi.Enabled = true;
            btnLuu.Enabled = false;
            btnNhapLai.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnsearch.Enabled = false;
        }
        void Reset()
        {
            txtTenNV.Text = "";
            txtMatKhau.Text = "";
            cbbGioiTinh.Text = "";
            txtSDT.Text = "";
            cbbGioiTinh.SelectedIndex = -1;
            Anh.Image = null;
        }
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            tieude.Text = "THÊM MỚI NHÂN VIÊN ";
            Reset();
            grbchitiet.Enabled = true;
            txtMaNV.Enabled = false;
            // Đếm số lượng mã KH hiện có
            string sqlCheckKhach = $"SELECT COUNT(*) FROM NhanVien WHERE DienThoai = N'{txtSDT.Text}'";

            int countKhach = Convert.ToInt32(dtBase.DataReader(sqlCheckKhach).Rows[0][0]);
            if (countKhach == 0)
            {
                string sqlThemKhach = $"SELECT COUNT(*) FROM NhanVien";
                int count = Convert.ToInt32(dtBase.DataReader(sqlThemKhach).Rows[0][0]) + 1;
                string maNV = "NV_" + count.ToString("D3");


                // Gán mã mới vào txtMaKH
                btnAnh.Enabled = true;
                txtMaNV.Text = maNV;
                btnsearch.Enabled = false;
                btnTaoMoi.Enabled = false;
                btnLuu.Enabled = true;
                btnNhapLai.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }
        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            Reset();
            txtTimKiem.Text = "";
            DataTable dtNhanVien = dtBase.DataReader("Select t.MaNV,t.TenNV, t.MatKhau,t.Anh, t.GioiTinh, t.NgaySinh, t.DienThoai from NhanVien t Where ChucDanh = 1");
            dvgNhanVien.DataSource = dtNhanVien;
            

            dvgNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dvgNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dvgNhanVien.Columns[2].HeaderText = "Mật Khẩu ";
            dvgNhanVien.Columns[3].HeaderText = "Ảnh";
            dvgNhanVien.Columns[4].HeaderText = "Giới Tính ";
            dvgNhanVien.Columns[5].HeaderText = "Ngày Sinh";
            dvgNhanVien.Columns[6].HeaderText = "Điện Thoại";

            dvgNhanVien.BackgroundColor = Color.LightBlue;
            dtNhanVien.Dispose();//Giải phóng bộ nhớ cho DataTable
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text.Trim() == "")
            {
                errChiTiet.SetError(txtTenNV, "Bạn không để trống tên Tên Nhân Viên!");
                return;
            }
            else if (cbbGioiTinh.SelectedIndex == -1)
            {
                errChiTiet.SetError(cbbGioiTinh, "Bạn không để trống tên Giới Tính NHân Viên!");
                return;
            }
            else if (dagNgaySinh.Value > DateTime.Now || dagNgaySinh.Value < new DateTime(1900, 1, 1))
            {
                errChiTiet.SetError(dagNgaySinh, "Bạn phải chọn ngày sinh hợp lệ (trước ngày hiện tại và sau năm 1900).");
                dagNgaySinh.Focus();
                return;
            }
            else if (txtSDT.Text.Trim() == "")
            {
                errChiTiet.SetError(txtSDT, "Bạn không để trống tên Số Điện Thoại Nhân Viên!");
                return;
            }
            else if (txtMatKhau.Text.Trim() == "")
            {
                errChiTiet.SetError(txtMatKhau, "Bạn không để trống tên Số Điện Thoại NHân Viên!");
                return;
            }
            else if (Anh.Image == null) // Kiểm tra nếu chưa chọn ảnh
            {
                errChiTiet.SetError(Anh, "Bạn chưa chọn ảnh cho Nhân Viên!");
                Anh.Focus();
                return;
            }
            else
            {
                // Kiểm tra SĐT của  khách hàng đã tồn tại hay chưa
                DataTable dtKhachHang = dtBase.DataReader("Select * from NhanVien where DienThoai = '" + txtSDT.Text.Trim() + "'");

                if (dtKhachHang.Rows.Count > 0)
                {
                    MessageBox.Show("Số Điện Thoại của  bạn đã được sử dụng , Vui  lòng hãy nhập Số Điện THoại  khác!");
                    txtSDT.Focus();
                }
                else
                {
                    // Lệnh INSERT để thêm khách hàng mới
                    string query = "INSERT INTO NhanVien (MaNV, TenNV, MatKhau, ChucDanh,Anh, GioiTinh, NgaySinh, DienThoai) " +
                    "VALUES (N'" + txtMaNV.Text + "', N'" + txtTenNV.Text + "', N'" + txtMatKhau.Text + "', 1,N'" + ImageName + "' , N'" + cbbGioiTinh.Text + "', N'" + dagNgaySinh.Value.ToString("yyyy-MM-dd") + "', N'" + txtSDT.Text + "')";
                    dtBase.DataChange(query);


                    MessageBox.Show("Bạn đã thêm mới Nhân Viên thành công");

                    // Cập nhật lại DataGridView để hiển thị thông tin mới
                    dvgNhanVien.DataSource = dtBase.DataReader("select * from NhanVien Where ChucDanh = 1");
                    // Reset giá trị các ô nhập liệu sau khi lưu thành công
                    Reset();
                    btnAnh.Enabled = false;
                    btnTaoMoi.Enabled = true;
                    btnLuu.Enabled = false;
                    btnNhapLai.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnsearch.Enabled = true;
                    dvgNhanVien.Enabled = true;
                }

            }
        }
        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {
            if (txtTenNV.Text.Trim() != "")
            {
                errChiTiet.SetError(txtTenNV, string.Empty); // Xóa lỗi
            }
        }
        private void cbbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbGioiTinh.SelectedIndex != -1) // Kiểm tra xem đã chọn một mục hợp lệ hay chưa
            {
                errChiTiet.SetError(cbbGioiTinh, string.Empty); // Xóa lỗi
            }
        }
        private void dagNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            if (dagNgaySinh.Value <= DateTime.Now)
            {
                errChiTiet.SetError(dagNgaySinh, string.Empty); // Xóa lỗi nếu ngày hợp lệ
            }
        }
        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSDT.Text.Trim() != "")
            {
                errChiTiet.SetError(txtSDT, string.Empty); // Xóa lỗi
            }
        }
        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Trim() != "")
            {
                errChiTiet.SetError(txtMatKhau, string.Empty); // Xóa lỗi
            }
        }
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Ngăn không cho nhập nếu không phải là số
                e.Handled = true;
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text.Trim() == "")
            {
                errChiTiet.SetError(txtTenNV, "Bạn không để trống tên Tên Nhân Viên!");
                return;
            }
            else if (cbbGioiTinh.SelectedIndex == -1)
            {
                errChiTiet.SetError(cbbGioiTinh, "Bạn không để trống tên Giới Tính NHân Viên!");
                return;
            }
            else if (dagNgaySinh.Value > DateTime.Now || dagNgaySinh.Value < new DateTime(1900, 1, 1))
            {
                errChiTiet.SetError(dagNgaySinh, "Bạn phải chọn ngày sinh hợp lệ (trước ngày hiện tại và sau năm 1900).");
                dagNgaySinh.Focus();
                return;
            }
            else if (txtSDT.Text.Trim() == "")
            {
                errChiTiet.SetError(txtSDT, "Bạn không để trống tên Số Điện Thoại Khách Hàng!");
                return;
            }
            else if (txtMatKhau.Text.Trim() == "")
            {
                errChiTiet.SetError(txtMatKhau, "Bạn không để trống tên Số Điện Thoại Khách Hàng!");
                return;
            }
            else
            {
                // Lệnh UPDATE khách hàng 
                dtBase.DataChange("UPDATE NhanVien SET TenNV = N'" + txtTenNV.Text +
                    "', MatKhau = N'" + txtMatKhau.Text +
                  "', GioiTinh = N'" + cbbGioiTinh.Text +
                  "', NgaySinh = N'" + dagNgaySinh.Text +
                  "', DienThoai = N'" + txtSDT.Text +
                  "' WHERE MaNV = '" + txtMaNV.Text + "'");
                //Sau khi update cần lấy lại dữ liệu để hiển thị lên lưới
                dvgNhanVien.DataSource = dtBase.DataReader("select * from NhanVien where ChucDanh = 1");
                MessageBox.Show("Bạn đã sửa Nhân Viên thành công");
                // Cập nhật lại DataGridView để hiển thị thông tin mới
                dvgNhanVien.DataSource = dtBase.DataReader("select * from NhanVien Where ChucDanh = 1");
                // Reset giá trị các ô nhập liệu sau khi lưu thành công
                Reset();
                btnsearch.Enabled = true;
                btnAnh.Enabled = false;
                btnTaoMoi.Enabled = true;
                btnLuu.Enabled = false;
                btnNhapLai.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                tieude.Text = "QUẢN LÝ NHÂN VIÊN";
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa Nhân Viên có mã là:" + txtMaNV.Text + " không?", "Thông báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                dtBase.DataChange("delete NhanVien where MaNV='" + txtMaNV.Text + "'");
                dvgNhanVien.DataSource = dtBase.DataReader("Select * from NhanVien");

                Reset();
                btnAnh.Enabled = false;
                btnTaoMoi.Enabled = true;
                btnLuu.Enabled = false;
                btnNhapLai.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                tieude.Text = "QUẢN LÝ NHÂN VIÊN";
                btnsearch.Enabled = true;
            }
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog
                {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                    Title = "Chọn ảnh"
                };
                Anh.Image = null;
                errChiTiet.SetError(Anh, string.Empty);
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string sourceFilePath = openFile.FileName;
                    string imageFolderPath = Path.Combine(Application.StartupPath, "Images");

                    if (!Directory.Exists(imageFolderPath))
                    {
                        Directory.CreateDirectory(imageFolderPath);
                    }

                    ImageName = Path.GetFileName(sourceFilePath);
                    string destFilePath = Path.Combine(imageFolderPath, ImageName);

                    File.Copy(sourceFilePath, destFilePath, true);

                    Anh.Image = Image.FromFile(destFilePath);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi chọn ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (keyword != "")
            {
                SearchEmployee(keyword);
            }
        }
        private void SearchEmployee(string keyword)
        {
            try
            {
                string query = $@"
            SELECT MaNV, TenNV, MatKhau, ChucDanh, Anh, GioiTinh, NgaySinh, DienThoai
            FROM NhanVien
            WHERE MaNV LIKE N'%{keyword}%'
            OR TenNV LIKE N'%{keyword}%'";

                // Sử dụng phương thức DataReader của DataBaseProcess
                DataTable data = dtBase.DataReader(query);

                dvgNhanVien.DataSource = data;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm nhân viên: " + ex.Message);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            tieude.Text = "QUẢN LÝ NHÂN VIÊN";
            btnTaoMoi.Enabled = true;
            btnsearch.Enabled = true;
            btnLuu.Enabled = false;
            btnQuayLai.Enabled = true;
            btnSua.Enabled = false;
            btnNhapLai.Enabled = false;
            btnXoa.Enabled = false;
            Reset();
            txtMaNV.Text = "";
            txtTimKiem.Text = "";
            DataTable dtNhanVien = dtBase.DataReader("Select t.MaNV,t.TenNV, t.MatKhau,t.Anh, t.GioiTinh, t.NgaySinh, t.DienThoai from NhanVien t Where ChucDanh = 1");
            dvgNhanVien.DataSource = dtNhanVien;


            dvgNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dvgNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dvgNhanVien.Columns[2].HeaderText = "Mật Khẩu ";
            dvgNhanVien.Columns[3].HeaderText = "Ảnh";
            dvgNhanVien.Columns[4].HeaderText = "Giới Tính ";
            dvgNhanVien.Columns[5].HeaderText = "Ngày Sinh";
            dvgNhanVien.Columns[6].HeaderText = "Điện Thoại";

            dvgNhanVien.BackgroundColor = Color.LightBlue;
            dtNhanVien.Dispose();//Giải phóng bộ nhớ cho DataTable
        }
    }
 }
