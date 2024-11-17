﻿using QLSieuThiMini.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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
        private void LoadcbbLoaiHang()
        {
            DataTable dt = db.DataReader("SELECT MaLH, TenLH FROM LoaiHang");
            cbbLoaiHang.DataSource = dt;
            cbbLoaiHang.ValueMember = "MaLH";
            cbbLoaiHang.DisplayMember = "TenLH";
            cbbLoaiHang.SelectedIndex = -1;

            cbbLoaiHang.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void LoadcbbNCC()
        {
            DataTable dt = db.DataReader("SELECT MaNCC, TenNCC FROM NhaCungCap");
            cbbTenNCC.DataSource = dt;
            cbbTenNCC.ValueMember = "MaNCC";
            cbbTenNCC.DisplayMember = "TenNCC";
            cbbTenNCC.SelectedIndex = -1;

            cbbTenNCC.DropDownHeight = 200;
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
            cbbLoaiHang.Enabled = hide;
            cbbTenSP.Enabled = hide;
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
            cbbLoaiHang.Text = string.Empty;
            cbbTenSP.Text = string.Empty;
            txtDonGiaNhap.Text = string.Empty;
            txtSoLuongNhap.Text = string.Empty;
            txtThanhTien.Text = string.Empty;
        }
        //Load dgv
        private void LoadData()
        {
            DataTable dt = db.DataReader("SELECT TenLH, TenSP, DonGiaNhap, SLNhap, ThanhTien " +
                                         "FROM ChiTietHDN INNER JOIN SanPham ON ChiTietHDN.MaSP = SanPham.MaSP " +
                                         "INNER JOIN LoaiHang ON SanPham.MaLH = LoaiHang.MaLH " +
                                         "WHERE MaHDN = '"+ txtMHDN.Text +"'");
            dgvHDN.DataSource = dt;

            //Định dạng dgv
            dgvHDN.Columns[0].HeaderText = "Loại hàng";
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

            cbbTKMHDN.DropDownHeight = 200;
            cbbTKMHDN.DropDownStyle = ComboBoxStyle.DropDown;
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
            lblThemHD.Visible = false;
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
                //txtTongTien.Text = dt.Rows[0]["TongTien"].ToString();
                decimal tongTien = Convert.ToDecimal(dt.Rows[0]["TongTien"]);
                txtTongTien.Text = tongTien.ToString("N0");
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
            // Kiểm tra xem ô trong cột Mã Hóa Đơn (hoặc bất kỳ ô nào trong hàng) có giá trị hợp lệ không
            if (dgvHDN.CurrentRow.Cells[0].Value == DBNull.Value ||
                dgvHDN.CurrentRow.Cells[1].Value == DBNull.Value ||
                dgvHDN.CurrentRow.Cells[2].Value == DBNull.Value ||
                dgvHDN.CurrentRow.Cells[3].Value == DBNull.Value ||
                dgvHDN.CurrentRow.Cells[4].Value == DBNull.Value)
            {
                // Nếu có bất kỳ ô nào trong hàng là DBNull, thì tất cả các ô nhập liệu sẽ được để trống
                cbbLoaiHang.Text = "";
                cbbTenSP.Text = "";
                txtDonGiaNhap.Text = "";
                txtSoLuongNhap.Text = "";
                txtThanhTien.Text = "";
            }
            else
            {
                // Nếu không có giá trị DBNull, gán dữ liệu vào các TextBox
                cbbLoaiHang.Text = dgvHDN.CurrentRow.Cells[0].Value.ToString();
                cbbTenSP.Text = dgvHDN.CurrentRow.Cells[1].Value.ToString();
                txtDonGiaNhap.Text = Convert.ToDecimal(dgvHDN.CurrentRow.Cells[2].Value).ToString("N0");
                txtSoLuongNhap.Text = dgvHDN.CurrentRow.Cells[3].Value.ToString();
                txtThanhTien.Text = Convert.ToDecimal(dgvHDN.CurrentRow.Cells[4].Value).ToString("N0");
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            lblThemHD.Visible = false;
            lblMain.Visible = true;

            HideData(false);
            ResetTTChung();
            ResetTTSP();
            LoadCbbMHD();

            HideGrbTimKiem(true);

            HidebtnChucNang(false);
            btnThemHD.Enabled = true;

            LoadData();
            cbbLoaiHang.SelectedIndex = -1;
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
            lblMain.Visible = false;
            lblThemHD.Visible = true;

            //Load cbbNCC
            LoadcbbNCC();

            //Load cbb loại hàng
            LoadcbbLoaiHang();
            //reset data
            HideData(false);
            ResetTTChung();
            cbbTenNCC.Enabled = true;
            cbbLoaiHang.Enabled = true;
            ResetTTSP();
            HideGrbTimKiem(false);

            HidebtnChucNang(false);

            btnThemSP.Enabled = true;

            //Sinh mã hóa đơn nhập
            string newMaHD = "HDN_" + DateTime.Now.ToString("ddMMyyyyHHmmss");
            txtMHDN.Text = newMaHD;

            LoadData(); //hiển thị bảng trống
        }
        private void cbbLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbTenSP.SelectedIndex = -1;
            if (btnThemHD.Enabled == false && cbbLoaiHang.SelectedIndex != -1)
            {
                cbbTenSP.Enabled = true;
                DataTable dt = db.DataReader("SELECT MaSP, TenSP FROM SanPham " +
                                             "INNER JOIN LoaiHang ON SanPham.MaLH = LoaiHang.MaLH " +
                                             "WHERE SanPham.MaLH = '"+ cbbLoaiHang.SelectedValue.ToString() +"'");
                cbbTenSP.DataSource = dt;
                cbbTenSP.ValueMember = "MaSP";
                cbbTenSP.DisplayMember = "TenSP";
                cbbTenSP.SelectedIndex = -1;

                //cbbTenSP.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        private void cbbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbTenSP.SelectedIndex != -1 && int.TryParse(cbbTenSP.SelectedValue.ToString(), out int maSP))
            {
                if(btnTimKiem.Enabled == false) txtSoLuongNhap.Enabled = true;
                DataTable dt = db.DataReader("SELECT DonGiaNhap FROM SanPham WHERE MaSP = '" + maSP + "'");
                if (dt.Rows.Count > 0)
                {
                    // Truy xuất giá trị của cột "DonGiaNhap" từ dòng đầu tiên
                    decimal donGiaNhap = Convert.ToDecimal(dt.Rows[0]["DonGiaNhap"]);

                    // Gán giá trị vào TextBox với định dạng số
                    txtDonGiaNhap.Text = donGiaNhap.ToString("N0");
                }
                else
                {
                    // Nếu không có dữ liệu, có thể hiển thị thông báo hoặc để trống
                    txtDonGiaNhap.Text = "0"; // Hoặc một giá trị mặc định
                }
            }
            else
            {
                txtSoLuongNhap.Enabled = false;
                txtSoLuongNhap.Text = string.Empty;
                txtDonGiaNhap.Text = string.Empty;
            }
        }
        private void txtSoLuongNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) 
            { 
                e.Handled = true; 
            }
            if (txtSoLuongNhap.Text.Length == 0 && e.KeyChar == '0')
            {
                e.Handled = true; // Ngừng nhập "0" đầu tiên
            }
        }
        private void txtSoLuongNhap_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtSoLuongNhap.Text, out int soLuong) && decimal.TryParse(txtDonGiaNhap.Text, out decimal donGia))
            {
                // Tính toán thành tiền
                decimal thanhTien = soLuong * donGia;

                // Hiển thị kết quả vào txtThanhTien
                txtThanhTien.Text = thanhTien.ToString("N0"); // Định dạng số nguyên
            }
            else
            {
                // Nếu không có đủ dữ liệu hợp lệ, đặt giá trị txtThanhTien là "0"
                txtThanhTien.Text = "";
            }
        }
        private void cbbTenNCC_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cbbTenNCC.Text)) 
            {
                string tenNCC = cbbTenNCC.Text.Trim();
                DataTable dt = db.DataReader("SELECT COUNT(*) FROM NhaCungCap WHERE TenNCC = N'"+ tenNCC +"'");
                int count = Convert.ToInt32(dt.Rows[0][0]);
                if (count == 0)
                {
                    // Hiển thị thông báo nếu nhà cung cấp này không có trong hệ thống
                    DialogResult result = MessageBox.Show("Nhà cung cấp này chưa có trong hệ thống. Bạn có muốn thêm không?",
                                                          "Xác nhận thêm nhà cung cấp",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        db.DataChange("INSERT INTO NhaCungCap (TenNCC) VALUES (N'"+ tenNCC +"')");
                        LoadcbbNCC();
                        MessageBox.Show("Nhà cung cấp đã được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbbTenNCC.SelectedValue = db.DataReader("SELECT MaNCC FROM NhaCungCap WHERE TenNCC = N'"+ tenNCC + "'").Rows[0]["MaNCC"];
                    }
                    else
                    {
                        // Nếu người dùng chọn "Không", xóa nội dung của ComboBox
                        cbbTenNCC.Text = string.Empty;
                    }
                }
            }
        }
        private bool KiemTraThongTin()
        {
            if (string.IsNullOrWhiteSpace(cbbTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbTenNCC.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbbLoaiHang.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbLoaiHang.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbbTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbTenSP.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSoLuongNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuongNhap.Focus();
                return false;
            }
            return true;
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (!KiemTraThongTin())
            {
                return;
            }
            DataTable dt = (DataTable)dgvHDN.DataSource;
            string loaiHang = cbbLoaiHang.Text;
            string tenSP = cbbTenSP.Text;
            decimal donGiaNhap = Convert.ToDecimal(txtDonGiaNhap.Text);
            int soLuongNhap = Convert.ToInt32(txtSoLuongNhap.Text);
            decimal thanhTien = Convert.ToDecimal(txtThanhTien.Text);

            // Biến kiểm tra sản phẩm đã tồn tại
            bool daTonTai = false;

            // Duyệt qua các dòng trong DataTable
            foreach (DataRow row in dt.Rows)
            {
                // Kiểm tra nếu trùng loại hàng và tên sản phẩm
                if (row["TenLH"].ToString() == loaiHang && row["TenSP"].ToString() == tenSP)
                {
                    row["SLNhap"] = soLuongNhap;         // Cập nhật số lượng
                    row["ThanhTien"] = thanhTien;        // Cập nhật thành tiền từ input
                    daTonTai = true;
                    break; // Dừng kiểm tra vì đã cập nhật
                }
            }
            // Nếu chưa tồn tại, thêm dòng mới
            if (!daTonTai)
            {
                dt.Rows.Add(loaiHang, tenSP, donGiaNhap, soLuongNhap, thanhTien);
            }
            // Gán lại DataTable vào DataGridView
            dgvHDN.DataSource = dt;

            // Tính tổng thành tiền và cập nhật vào txtTongTien
            decimal tongTien = 0;
            foreach (DataRow row in dt.Rows)
            {
                tongTien += Convert.ToDecimal(row["ThanhTien"]);
            }

            txtTongTien.Text = tongTien.ToString("N0");

            if (dt.Rows.Count > 0)
            {
                btnLuuHD.Enabled = true; // Hiển thị nút Lưu nếu có dữ liệu
            }
            else
            {
                btnLuuHD.Enabled = false; // Ẩn nút Lưu nếu bảng trống
            }

            ResetTTSP();
            cbbLoaiHang.SelectedIndex = -1;
            cbbTenSP.SelectedIndex = -1;
        }

        private void dgvHDN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThemSP.Enabled)
            {
                // Kiểm tra nếu dòng được chọn hợp lệ (không phải header hoặc ngoài phạm vi)
                if (e.RowIndex >= 0)
                {
                    // Lấy dòng đang được chọn
                    DataGridViewRow selectedRow = dgvHDN.Rows[e.RowIndex];

                    // Kiểm tra nếu dòng này không phải là dòng mới
                    if (!selectedRow.IsNewRow)
                    {
                        // Nếu dòng có dữ liệu hợp lệ, thực hiện xóa
                        dgvHDN.Rows.RemoveAt(e.RowIndex);

                        // Tính lại tổng thành tiền
                        decimal tongTien = 0;
                        foreach (DataGridViewRow row in dgvHDN.Rows)
                        {
                            // Cộng dồn giá trị cột "ThanhTien" vào tổng
                            tongTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                        }

                        // Kiểm tra nếu bảng trống, đặt tổng tiền bằng 0
                        if (dgvHDN.Rows.Count == 1)
                        {
                            tongTien = 0;
                            btnLuuHD.Enabled = false;
                        }

                        // Cập nhật lại tổng tiền vào txtTongTien
                        txtTongTien.Text = tongTien.ToString("N0"); // Định dạng hiển thị số

                        ResetTTSP();
                        cbbLoaiHang.SelectedIndex = -1;
                        cbbTenSP.SelectedIndex = -1;
                    }
                }
            }
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn lưu hóa đơn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            string maHDN = txtMHDN.Text.Trim();
            string maNV = lblMaNV.Text.Trim();
            string ngayNhap = dtpNgayNhap.Value.ToString("yyyy-MM-dd");
            string tongTien = txtTongTien.Text.Replace(",", "").Trim();
            string maNCC = cbbTenNCC.SelectedValue.ToString();

            db.DataChange($"INSERT INTO HoaDonNhap (MaHDN, MaNV, NgayNhap, TongTien, MaNCC) " +
                          $"VALUES ('{maHDN}', '{maNV}', '{ngayNhap}', {tongTien}, '{maNCC}')");

            //lưu từng dòng
            foreach (DataGridViewRow row in dgvHDN.Rows)
            {
                if (!row.IsNewRow) // Bỏ qua dòng mới chưa được điền
                {
                    // Lấy Tên sản phẩm từ DataGridView
                    string tenSP = row.Cells["TenSP"].Value.ToString();

                    string maSP = db.ExecuteScalar($"SELECT MaSP FROM SanPham WHERE TenSP = N'{tenSP}'")?.ToString();
                    string thanhTien = row.Cells["ThanhTien"].Value.ToString().Replace(",", "").Trim();
                    string soLuongNhap = row.Cells["SLNhap"].Value.ToString();

                    db.DataChange($"INSERT INTO ChiTietHDN (MaHDN, MaSP, ThanhTien, SLNhap) " +
                                  $"VALUES ('{maHDN}', '{maSP}', {thanhTien}, {soLuongNhap})");
                }
            }
            MessageBox.Show("Hóa đơn nhập đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetTTChung();
            string newMaHD = "HDN_" + DateTime.Now.ToString("ddMMyyyyHHmmss");
            txtMHDN.Text = newMaHD;
            LoadData();

        }
    }
}
