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
    public partial class frmKhachHang : Form
    {
        DataBaseProcess dtBase = new DataBaseProcess();
        public frmKhachHang()
        {
            InitializeComponent();
            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");
            cbbThanThiet.Items.Add("Thân thiết");
            cbbThanThiet.Items.Add("Khách hàng mới");
            cbbThanThiet.Items.Add("VIP");
            cbbThanThiet.Items.Add("Đăc Biệt");
            tieude.Text = "QUẢN LÝ KHÁCH HÀNG";
        }

        private void FormKH_Load(object sender, EventArgs e)
        {
            DataTable dtKhachHang = dtBase.DataReader("Select * from KhachHang");
            dvgKhachHang.DataSource = dtKhachHang;

            dvgKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            dvgKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
            dvgKhachHang.Columns[2].HeaderText = "Giới Tính ";
            dvgKhachHang.Columns[3].HeaderText = "Địa chỉ";
            dvgKhachHang.Columns[4].HeaderText = "Điện Thoại";
            dvgKhachHang.BackgroundColor = Color.LightBlue;
            dtKhachHang.Dispose();//Giải phóng bộ nhớ cho DataTable
            btnThemMoi.Enabled = true;
            btnLuu.Enabled = false;
            btnNhapLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;
        }

        private void dvgKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dvgKhachHang.CurrentRow.Cells[0].Value.ToString();
            txtTenKH.Text = dvgKhachHang.CurrentRow.Cells[1].Value.ToString();
            cbbGioiTinh.Text = dvgKhachHang.CurrentRow.Cells[2].Value.ToString();
            txtDiaChi.Text = dvgKhachHang.CurrentRow.Cells[3].Value.ToString();
            txtDienThoai.Text = dvgKhachHang.CurrentRow.Cells[4].Value.ToString();
            btnThemMoi.Enabled = true;
            btnLuu.Enabled = false;
            btnNhapLai.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;
            grbTimKiem.Enabled = false;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            grbTimKiem.Enabled = true;
            grbChiTiet.Enabled = false ;
            dvgKhachHang.Enabled = false;
            btnsearch.Enabled = false;
            btnNhapLai.Enabled=true;
            tieude.Text = "TÌM KIẾM KHÁCH HÀNG";
            
        }
        void Reset()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            cbbGioiTinh.Text = "";
            txtDienThoai.Text = "";
            cbbThanThiet.Text = "";
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            tieude.Text = "THÊM MỚI KHÁCH HÀNG ";
            Reset();
            grbTimKiem.Enabled= false;
            grbChiTiet.Enabled = true;
            txtMaKH.Enabled = false;
            // Đếm số lượng mã KH hiện có
            string sqlCheckKhach = $"SELECT COUNT(*) FROM KhachHang WHERE DienThoai = N'{txtDienThoai.Text}'";

            int countKhach = Convert.ToInt32(dtBase.DataReader(sqlCheckKhach).Rows[0][0]);
            if (countKhach == 0)
            {
                string sqlThemKhach = $"SELECT COUNT(*) FROM KhachHang";
                int count = Convert.ToInt32(dtBase.DataReader(sqlThemKhach).Rows[0][0]) + 1;
                string maKH = "KH_" + count.ToString("D3");


                // Gán mã mới vào txtMaKH
                txtMaKH.Text = maKH;
            }
            btnsearch.Enabled = false;
            btnThemMoi.Enabled = false;
            btnLuu.Enabled = true;
            btnNhapLai.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            cbbGioiTinh.Text = "";
            txtDienThoai.Text = "";
            cbbThanThiet.Text = "";
            txtTimKiem.Text = "";
            dvgKhachHang.Enabled = true;
            DataTable dtKhachHang = dtBase.DataReader("Select * from KhachHang");
            dvgKhachHang.DataSource = dtKhachHang;

            dvgKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            dvgKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
            dvgKhachHang.Columns[2].HeaderText = "Giới Tính ";
            dvgKhachHang.Columns[3].HeaderText = "Địa chỉ";
            dvgKhachHang.Columns[4].HeaderText = "Điện Thoại";
            dvgKhachHang.BackgroundColor = Color.LightBlue;
            dtKhachHang.Dispose();//Giải phóng bộ nhớ cho DataTable
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Trim() == "")
            {
                errChiTiet.SetError(txtTenKH, "Bạn không để trống tên Tên Khách Hàng!");
                return;
            }
            else if (cbbGioiTinh.SelectedIndex == -1)
            {
                errChiTiet.SetError(cbbGioiTinh, "Bạn không để trống tên Giới Tính Khách Hàng!");
                return;
            }
            else if (txtDiaChi.Text.Trim() == "")
            {
                errChiTiet.SetError(txtDiaChi, "Bạn không để trống tên Địa CHỉ  Khách Hàng!");
                return;
            }
            else if (txtDienThoai.Text.Trim() == "")
            {
                errChiTiet.SetError(txtDienThoai, "Bạn không để trống tên Số Điện Thoại Khách Hàng!");
                return;
            }
            else if (cbbThanThiet.SelectedIndex == -1)
            {
                errChiTiet.SetError(cbbThanThiet, "Bạn không để trống tên mức thân thiết của  Khách Hàng!");
                return;
            }
            else
            {
                // Kiểm tra SĐT của  khách hàng đã tồn tại hay chưa
                DataTable dtKhachHang = dtBase.DataReader("Select * from KhachHang where DienThoai = '" + txtDienThoai.Text.Trim() + "'");

                if (dtKhachHang.Rows.Count > 0)
                {
                    MessageBox.Show("Số Điện Thoại của  khách hàng này đã có, hãy nhập Số Điện THoại  khác!");
                    txtDienThoai.Focus();
                }
                else
                {
                    // Lệnh INSERT để thêm khách hàng mới
                    string query = "INSERT INTO KhachHang(MaKH, TenKH,GioiTinh, DiaChi, DienThoai) " +
                                   "VALUES (N'" + txtMaKH.Text + "', N'" + txtTenKH.Text + "', N'" + cbbGioiTinh.Text + "', N'" + txtDiaChi.Text + "', N'" + txtDienThoai.Text + "')";
                    dtBase.DataChange(query);

                    MessageBox.Show("Bạn đã thêm mới khách hàng thành công");

                    // Cập nhật lại DataGridView để hiển thị thông tin mới
                    dvgKhachHang.DataSource = dtBase.DataReader("select * from KhachHang");
                    // Reset giá trị các ô nhập liệu sau khi lưu thành công
                    Reset();
                    btnThemMoi.Enabled = true;
                    btnLuu.Enabled = false;
                    btnNhapLai.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThoat.Enabled = true;
                    dvgKhachHang.Enabled = true;
                    tieude.Text = "QUẢN LÝ KHÁCH HÀNG";
                }
            }
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Trim() != "")
            {
                errChiTiet.SetError(txtTenKH, string.Empty); // Xóa lỗi
            }
        }

        private void cbbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbGioiTinh.SelectedIndex != -1) // Kiểm tra xem đã chọn một mục hợp lệ hay chưa
            {
                errChiTiet.SetError(cbbGioiTinh, string.Empty); // Xóa lỗi
            }
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            if (txtDiaChi.Text.Trim() != "")
            {
                errChiTiet.SetError(txtDiaChi, string.Empty); // Xóa lỗi
            }
        }

        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {
            if (txtDienThoai.Text.Trim() != "")
            {
                errChiTiet.SetError(txtDienThoai, string.Empty); // Xóa lỗi
            }
        }

        private void cbbThanThiet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbThanThiet.SelectedIndex != -1) // Kiểm tra xem đã chọn một mục hợp lệ hay chưa
            {
                errChiTiet.SetError(cbbThanThiet, string.Empty); // Xóa lỗi
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaKH.Enabled = false;
            if (txtTenKH.Text.Trim() == "")
            {
                errChiTiet.SetError(txtTenKH, "Bạn không để trống tên Tên Khách Hàng!");
                return;
            }
            else if (cbbGioiTinh.SelectedIndex == -1)
            {
                errChiTiet.SetError(cbbGioiTinh, "Bạn không để trống tên Giới Tính Khách Hàng!");
                return;
            }
            else if (txtDiaChi.Text.Trim() == "")
            {
                errChiTiet.SetError(txtDiaChi, "Bạn không để trống tên Địa CHỉ  Khách Hàng!");
                return;
            }
            else if (txtDienThoai.Text.Trim() == "")
            {
                errChiTiet.SetError(txtDienThoai, "Bạn không để trống tên Số Điện Thoại Khách Hàng!");
                return;
            }
            else
            {

                // Lệnh UPDATE khách hàng 
                dtBase.DataChange("UPDATE KhachHang SET TenKH = N'" + txtTenKH.Text +
                  "', GioiTinh = N'" + cbbGioiTinh.Text +
                  "', DiaChi = N'" + txtDiaChi.Text +
                  "', DienThoai = N'" + txtDienThoai.Text +
                  "' WHERE MaKH = '" + txtMaKH.Text + "'");
                //Sau khi update cần lấy lại dữ liệu để hiển thị lên lưới
                dvgKhachHang.DataSource = dtBase.DataReader("select * from KhachHang");
                MessageBox.Show("Bạn đã sửa khách hàng thành công");
                // Cập nhật lại DataGridView để hiển thị thông tin mới
                dvgKhachHang.DataSource = dtBase.DataReader("select * from KhachHang");
                // Reset giá trị các ô nhập liệu sau khi lưu thành công
                Reset();
                btnsearch.Enabled = true;
                btnThemMoi.Enabled = true;
                btnLuu.Enabled = false;
                btnNhapLai.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnThoat.Enabled = true;
                tieude.Text = "QUẢN LÝ KHÁCH HÀNG";
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa Khách Hàng có mã là:" + txtMaKH.Text + " không?", "Thông báo",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                dtBase.DataChange("delete KhachHang where MaKH='" + txtMaKH.Text + "'");
                dvgKhachHang.DataSource = dtBase.DataReader("Select * from KhachHang");

                Reset();
                btnsearch.Enabled=true;
                btnThemMoi.Enabled = true;
                btnLuu.Enabled = false;
                btnNhapLai.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnThoat.Enabled = true;
                tieude.Text = "QUẢN LÝ KHÁCH HÀNG";
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dvgKhachHang.Enabled = false;

            // Khởi tạo câu truy vấn ban đầu
            string sql = "SELECT * FROM KhachHang WHERE MaKH IS NOT NULL";

            // Kiểm tra nếu có dữ liệu trong txtTimKiem
            if (txtTimKiem.Text.Trim() != "")
            {
                sql += " AND (MaKH LIKE '%" + txtTimKiem.Text.Trim() + "%' OR TenKH LIKE '%" + txtTimKiem.Text.Trim() + "%')";
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng hoặc tên khách hàng để tìm kiếm.", "Thông báo");
                return;
            }

            // Thực hiện truy vấn và lấy kết quả
            DataTable result = dtBase.DataReader(sql);

            // Kiểm tra nếu có kết quả
            if (result.Rows.Count > 0)
            {
                // Hiển thị kết quả tìm kiếm
                dvgKhachHang.DataSource = result;
            }
            else
            {
                // Thông báo nếu không tìm thấy khách hàng nào
                MessageBox.Show("Không tìm thấy khách hàng nào với thông tin đã nhập.", "Thông báo");
            }

        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Ngăn không cho nhập nếu không phải là số
                e.Handled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (btnLuu.Enabled == true)
                {
                    if (MessageBox.Show("Bạn có muốn Lưu lại Khách hàng   không ? ", "Thông báo",
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
    }
}
