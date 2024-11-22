using QLSieuThiMini.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QLSieuThiMini.UI
{
    public partial class UC_SanPham : UserControl
    {
        DataBaseProcess dtBase = new DataBaseProcess();
        private string ImageName = null;
        private int maSp;
        public UC_SanPham()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            string sqlSelect = "SELECT sp.MaSP, sp.MaLH,lh.TenLH,sp.TenSP,sp.DonGiaNhap,sp.DonGiaBan,sp.SoLuong,sp.Anh,sp.HSD FROM SanPham sp INNER JOIN LoaiHang lh ON sp.MaLH = lh.MaLH";
            DataTable dtSP = dtBase.DataReader(sqlSelect);
            dgvSanPham.DataSource = dtSP;
            dgvSanPham.Refresh();
            dgvSanPham.BackgroundColor = Color.LightBlue;
            dgvSanPham.Columns["MaSP"].HeaderText = "Mã Sản Phẩm";
            dgvSanPham.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            dgvSanPham.Columns["DonGiaNhap"].HeaderText = "Đơn Giá Nhập";
            dgvSanPham.Columns["DonGiaBan"].HeaderText = "Đơn Giá Bán";
            dgvSanPham.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvSanPham.Columns["HSD"].HeaderText = "Hạn Sử Dụng";
            dgvSanPham.Columns["MaLH"].HeaderText = "Mã Loại Hàng";
            dgvSanPham.Columns["TenLH"].HeaderText = "Tên Loại Hàng";
            dgvSanPham.Columns["Anh"].HeaderText = "Ảnh";
            dgvSanPham.Columns["HSD"].DefaultCellStyle.Format = "dd/MM/yyyy";

            DataTable dtLoaiHang = dtBase.DataReader("SELECT MaLH, TenLH FROM LoaiHang");
            cbbLoaiHang.DataSource = dtLoaiHang;
            cbbLoaiHang.DisplayMember = "TenLH";
            cbbLoaiHang.ValueMember = "MaLH";

            cbbLoaiHang.SelectedIndex = -1;
            cbbLoaiHang.DropDownStyle = ComboBoxStyle.DropDownList;

            DataTable dtLoc = new DataTable();
            dtLoc.Columns.Add("DisplayName", typeof(string));
            dtLoc.Columns.Add("Value", typeof(string));

            dtLoc.Rows.Add("Tên sản phẩm", "TenSP");
            dtLoc.Rows.Add("Mã sản phẩm", "MaSP");
            dtLoc.Rows.Add("Loại sản phẩm", "TenLH");
            cbbLoc.DataSource = dtLoc;
            cbbLoc.DisplayMember = "DisplayName";
            cbbLoc.ValueMember = "Value";
            cbbLoc.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void reset()
        {
            txtTenHang.Text = string.Empty;
            txtSoLuong.Text = "0";
            txtDGB.Text = string.Empty;
            txtDGN.Text = string.Empty;
            cbbLoaiHang.SelectedIndex = -1;
            txtDGB.Enabled = false;
            txtDGN.Enabled = false;
            txtTenHang.Enabled = false;
            cbbLoaiHang.Enabled = false;
            dtpHSD.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnAnh.Enabled = false;
            btnIn.Enabled = true;
            pic.Image = null;
        }
        private void UC_SanPham_Load(object sender, EventArgs e)
        {
            LoadData();
            txtTenHang.Enabled = false;
            txtDGN.Enabled = false;
            txtSoLuong.Enabled = false;
            txtDGB.Enabled = false;
            cbbLoaiHang.Enabled = false;
            dtpHSD.Enabled = false;
            btnIn.Enabled = true;
            btnAnh.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenHang.Enabled = false;
            txtDGN.Enabled = false;
            txtSoLuong.Enabled = false;
            txtDGB.Enabled = false;
            cbbLoaiHang.Enabled = false;
            dtpHSD.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnIn.Enabled = true;
            btnAnh.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = false;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvSanPham.Rows[e.RowIndex];
                if (selectedRow.IsNewRow)
                {
                    return;
                }
                string imagelink = Path.Combine(Application.StartupPath, "Images", selectedRow.Cells["Anh"].Value.ToString());
                maSp = int.Parse(selectedRow.Cells["MaSP"].Value.ToString());
                txtTenHang.Text = selectedRow.Cells["TenSP"].Value.ToString();
                cbbLoaiHang.SelectedValue = selectedRow.Cells["MaLH"].Value;
                txtDGN.Text = Convert.ToDecimal(dgvSanPham.CurrentRow.Cells["DonGiaNhap"].Value).ToString("N0");
                txtDGB.Text = Convert.ToDecimal(dgvSanPham.CurrentRow.Cells["DonGiaBan"].Value).ToString("N0");
                txtSoLuong.Text = selectedRow.Cells["SoLuong"].Value.ToString();
                dtpHSD.Value = DateTime.Parse(selectedRow.Cells["HSD"].Value.ToString());
                pic.Image = Image.FromFile(imagelink);
            }
        }
        private bool Ktra()
        {
            if (cbbLoaiHang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtTenHang.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDGN.Text) || !double.TryParse(txtDGN.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập đúng đơn giá nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDGB.Text) || !double.TryParse(txtDGB.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập đúng đơn giá bán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dtpHSD.Value.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("Vui lòng chọn hạn sử dụng thích hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (ImageName == string.Empty)
            {
                MessageBox.Show("Vui lòng thêm ảnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (Ktra())
            {
                string TenSP = txtTenHang.Text;
                double DGN = Double.Parse(txtDGN.Text);
                double DGB = Double.Parse(txtDGB.Text);
                DateTime HSD = dtpHSD.Value;
                int MaLoai = Convert.ToInt32(cbbLoaiHang.SelectedValue);
                string sqlInsert = "INSERT INTO SanPham (TenSP, DonGiaNhap, DonGiaBan, SoLuong, Anh, HSD, MaLH) " +
                               $"VALUES ('{TenSP}',{DGN},{DGB},0,'{ImageName}','{HSD.ToString("yyyy-MM-dd")}',{MaLoai});";
                try
                {
                    dtBase.DataChange(sqlInsert);
                    LoadData();
                    reset();
                    MessageBox.Show("Thêm sản phẩm thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi thêm sản phẩm: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sqlUpdate = $"UPDATE SanPham SET TenSp =N'{txtTenHang.Text}',DonGiaNhap ={double.Parse(txtDGN.Text)},DonGiaBan ={double.Parse(txtDGB.Text)},Anh='{ImageName}',HSD='{dtpHSD.Text:yyyy-MM-dd}',MaLH={int.Parse(cbbLoaiHang.SelectedValue.ToString())} WHERE MaSp = {maSp}";
            try
            {
                dtBase.DataChange(sqlUpdate);
                MessageBox.Show("Sửa sản phẩm thành công.");
                LoadData();
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi sửa sản phẩm: " + ex.Message);
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtTenHang.Enabled = true;
            txtDGN.Enabled = true;
            txtSoLuong.Text = "0";
            txtSoLuong.Enabled = false;
            txtDGB.Enabled = true;
            cbbLoaiHang.Enabled = true;
            dtpHSD.Enabled = true;
            btnAnh.Enabled = true;
            btnIn.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            txtDGB.Text = string.Empty;
            txtDGN.Text = string.Empty;
            txtSoLuong.Text = "0";
            txtTenHang.Text = string.Empty;
            pic.Image = null;
            cbbLoaiHang.SelectedIndex = -1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtTenHang.Enabled = true;
            txtDGN.Enabled = true;
            txtSoLuong.Enabled = false;
            txtDGB.Enabled = true;
            cbbLoaiHang.Enabled = true;
            dtpHSD.Enabled = true;
            btnAnh.Enabled = true;
            btnIn.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtSoLuong.Text) > 0)
            {
                MessageBox.Show("Sản phẩm vẫn còn tồn kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string sqlDelete = $"DELETE FROM SanPham WHERE MaSP = {maSp}";
                    dtBase.DataChange(sqlDelete);

                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();

                    reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Danh sách sản phẩm";
                worksheet.Cells[1, 1] = "DANH SÁCH SẢN PHẨM";
                Excel.Range titleRange = worksheet.get_Range("A1", "H1");
                titleRange.Merge();
                titleRange.Font.Size = 16;
                titleRange.Font.Bold = true;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                if (txtTenHang.Text == string.Empty)
                {
                    int rowStart = 3;

                    worksheet.Cells[2, 1] = "Mã SP";
                    worksheet.Cells[2, 2] = "Tên SP";
                    worksheet.Cells[2, 3] = "Mã LH";
                    worksheet.Cells[2, 4] = "Tên LH";
                    worksheet.Cells[2, 5] = "Đơn Giá Nhập";
                    worksheet.Cells[2, 6] = "Đơn Giá Bán";
                    worksheet.Cells[2, 7] = "Số Lượng";
                    worksheet.Cells[2, 8] = "Hạn Sử Dụng";

                    for (int i = 0; i < dgvSanPham.Rows.Count; i++)
                    {
                        DataGridViewRow row = dgvSanPham.Rows[i];
                        for (int j = 0; j < dgvSanPham.Columns.Count; j++)
                        {
                            worksheet.Cells[rowStart + i, j + 1] = row.Cells[j].Value?.ToString();
                        }
                    }
                }
                else
                {
                    worksheet.Cells[2, 1] = "Thông tin sản phẩm";
                    worksheet.Cells[3, 1] = "Mã Sản Phẩm:";
                    worksheet.Cells[3, 2] = maSp.ToString();
                    worksheet.Cells[4, 1] = "Tên Sản Phẩm:";
                    worksheet.Cells[4, 2] = txtTenHang.Text;
                    worksheet.Cells[5, 1] = "Mã Loại Hàng:";
                    worksheet.Cells[5, 2] = cbbLoaiHang.SelectedValue?.ToString();
                    worksheet.Cells[6, 1] = "Tên Loại Hàng:";
                    worksheet.Cells[6, 2] = cbbLoaiHang.Text;
                    worksheet.Cells[7, 1] = "Đơn Giá Nhập:";
                    worksheet.Cells[7, 2] = txtDGN.Text;
                    worksheet.Cells[8, 1] = "Đơn Giá Bán:";
                    worksheet.Cells[8, 2] = txtDGB.Text;
                    worksheet.Cells[9, 1] = "Số Lượng:";
                    worksheet.Cells[9, 2] = txtSoLuong.Text;
                    worksheet.Cells[10, 1] = "Hạn Sử Dụng:";
                    worksheet.Cells[10, 2] = dtpHSD.Value.ToString("dd/MM/yyyy");
                }

                worksheet.Columns.AutoFit();

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files|*.xls;*.xlsx";
                saveDialog.Title = "Lưu file Excel";
                saveDialog.FileName = "DanhSachSanPham.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveDialog.FileName;
                    workbook.SaveAs(filePath);
                    workbook.Close(false);
                    excelApp.Quit();

                    MessageBox.Show("Xuất file Excel thành công tại: " + filePath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    workbook.Close(false);
                    excelApp.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search()
        {
            if (string.IsNullOrEmpty(txtTim.Text))
            {
                LoadData();
                return;
            }

            string sqlSearch = $"SELECT sp.MaSP, sp.MaLH, lh.TenLH, sp.TenSP, sp.DonGiaNhap, sp.DonGiaBan, sp.SoLuong, sp.Anh, sp.HSD " +
                               "FROM SanPham sp " +
                               "INNER JOIN LoaiHang lh ON sp.MaLH = lh.MaLH " +
                               $"WHERE {cbbLoc.SelectedValue.ToString()} LIKE N'%{txtTim.Text}%'";

            try
            {
                DataTable dtTim = dtBase.DataReader(sqlSearch);

                if (dtTim.Rows.Count == 0)
                {
                    DataTable dtNothing = new DataTable();
                    dtNothing.Columns.Add("Thông báo");
                    dtNothing.Rows.Add("Không có sản phẩm nào khớp với tìm kiếm");
                    dgvSanPham.DataSource = dtNothing;
                }
                else
                {
                    dgvSanPham.DataSource = dtTim;
                }

                dgvSanPham.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void cbbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
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

                    pic.Image = Image.FromFile(destFilePath);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi chọn ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
