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
    public partial class frmNhanVien : Form
    {
        DataBaseProcess dtBase = new DataBaseProcess();
        public frmNhanVien()
        {
            InitializeComponent();
            txtMatKhau.PasswordChar = '*';
            //thêm giới tính 
            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");
        }

        

        private void FormNV_Load(object sender, EventArgs e)
        {
            tieude.Text = "QUẢN LÝ NHÂN VIÊN";
            DataTable dtNhanVien = dtBase.DataReader("Select * from NhanVien");
            dvgNhanVien.DataSource = dtNhanVien;

            dvgNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dvgNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dvgNhanVien.Columns[2].HeaderText = "Mật Khẩu ";
            dvgNhanVien.Columns[3].HeaderText = "Chức Danh";
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
            btnThoat.Enabled = true;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

            grbtimkiem.Enabled = true;
            grbchitiet.Enabled = false;
            dvgNhanVien.Enabled = false;
            btnsearch.Enabled = false;
            btnNhapLai.Enabled = true;
            tieude.Text = "TÌM KIẾM NHÂN VIÊN"; 
        }

        private void dvgNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dvgNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtTenNV.Text = dvgNhanVien.CurrentRow.Cells[1].Value.ToString();
            txtMatKhau.Text = dvgNhanVien.CurrentRow.Cells[2].Value.ToString();
            cbbGioiTinh.Text = dvgNhanVien.CurrentRow.Cells[4].Value.ToString();
            dagNgaySinh.Text = dvgNhanVien.CurrentRow.Cells[5].Value.ToString();
            txtSDT.Text = dvgNhanVien.CurrentRow.Cells[6].Value.ToString();
            btnTaoMoi.Enabled = false;
            btnLuu.Enabled = false;
            btnNhapLai.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;
            btnsearch.Enabled = false;
        }
        void Reset()
        {
            txtTenNV.Text = "";
            txtMatKhau.Text = "";
            cbbGioiTinh.Text = "";
            txtSDT.Text = "";
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            tieude.Text = "THÊM MỚI NHÂN VIÊN ";
            Reset();
            grbtimkiem.Enabled = false;
            grbchitiet.Enabled = true;
            txtMaNV.Enabled = false;
            // Đếm số lượng mã KH hiện có
            string sqlCheckKhach = $"SELECT COUNT(*) FROM NhanVien WHERE DienThoai = N'{txtSDT.Text}'";

            int countKhach = Convert.ToInt32(dtBase.DataReader(sqlCheckKhach).Rows[0][0]);
            if (countKhach == 0)
            {
                string sqlThemKhach = $"SELECT COUNT(*) FROM NhanVien";
                int count = Convert.ToInt32(dtBase.DataReader(sqlThemKhach).Rows[0][0]) + 1;
                string maNV = count.ToString("");


                // Gán mã mới vào txtMaKH
                txtMaNV.Text = maNV;
                btnsearch.Enabled = false;
                btnTaoMoi.Enabled = false;
                btnLuu.Enabled = true;
                btnNhapLai.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnThoat.Enabled = true;
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            Reset();
            txtTimMaNV.Text = "";
            DataTable dtNhanVien = dtBase.DataReader("Select * from NhanVien");
            dvgNhanVien.DataSource = dtNhanVien;

            dvgNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dvgNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dvgNhanVien.Columns[2].HeaderText = "Mật Khẩu ";
            dvgNhanVien.Columns[3].HeaderText = "Chức Danh";
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
                    string query = "INSERT INTO NhanVien ( TenNV, MatKhau, ChucDanh, GioiTinh, NgaySinh, DienThoai) " +
                    "VALUES ( N'" + txtTenNV.Text + "', N'" + txtMatKhau.Text + "', 1, N'" + cbbGioiTinh.Text + "', N'" + dagNgaySinh.Value.ToString("yyyy-MM-dd") + "', N'" + txtSDT.Text + "')";
                    dtBase.DataChange(query);


                    MessageBox.Show("Bạn đã thêm mới Nhân Viên thành công");

                    // Cập nhật lại DataGridView để hiển thị thông tin mới
                    dvgNhanVien.DataSource = dtBase.DataReader("select * from NhanVien");
                    // Reset giá trị các ô nhập liệu sau khi lưu thành công
                    Reset();
                    btnTaoMoi.Enabled = true;
                    btnLuu.Enabled = false;
                    btnNhapLai.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThoat.Enabled = true;
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
        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
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
                dvgNhanVien.DataSource = dtBase.DataReader("select * from NhanVien");
                MessageBox.Show("Bạn đã sửa Nhân Viên thành công");
                // Cập nhật lại DataGridView để hiển thị thông tin mới
                dvgNhanVien.DataSource = dtBase.DataReader("select * from NhanVien");
                // Reset giá trị các ô nhập liệu sau khi lưu thành công
                Reset();
                btnTaoMoi.Enabled = true;
                btnLuu.Enabled = false;
                btnNhapLai.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnThoat.Enabled = true;
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
                btnTaoMoi.Enabled = true;
                btnLuu.Enabled = false;
                btnNhapLai.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnThoat.Enabled = true;
                tieude.Text = "QUẢN LÝ NHÂN VIÊN";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (btnLuu.Enabled == true)
                {
                    if (MessageBox.Show("Bạn có muốn Lưu lại Nhân Viên   không ? ", "Thông báo",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question)
                   == System.Windows.Forms.DialogResult.Yes)
                        btnLuu_Click(sender, e);
                    else
                        this.Close();

                }
                else
                    this.Close();
            }
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            dvgNhanVien.Enabled = false;

            string sql = "SELECT * FROM NhanVien WHERE MaNV is not null";

            // Tìm theo mã nhân viên nếu có
            if (txtTimMaNV.Text.Trim() != "")
            {
                sql += " AND MaNV LIKE '%" + txtTimMaNV.Text + "%'";
            }

            // Hiển thị kết quả tìm kiếm
            dvgNhanVien.DataSource = dtBase.DataReader(sql);

        }
    }
}
