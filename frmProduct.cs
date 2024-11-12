using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;
using QLSieuThiMini.Classes;
using TheArtOfDevHtmlRenderer.Adapters;

namespace QLSieuThiMini
{
    public partial class frmProduct : Form
    {
        DataBaseProcess dtBase = new DataBaseProcess();
        private string ImageName = null;
        public frmProduct()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DataTable dtSP = dtBase.DataReader("Select TenSP, DonGiaNhap, DonGiaBan, SoLuong, HSD, MaLH from SanPham");
            dgvSanPham.DataSource = dtSP;
            dgvSanPham.BackgroundColor = Color.LightBlue;
        }
        private void LoadCbbLH()
        {
            DataTable dtLoaiHang = dtBase.DataReader("SELECT TenLH FROM LoaiHang");
            cbbLoaiHang.DataSource = dtLoaiHang;
            cbbLoaiHang.DisplayMember = "TenLH";
            cbbLoaiHang.ValueMember = "TenLH";

            cbbLoaiHang.SelectedIndex = -1;

            cbbLoaiHang.DropDownStyle = ComboBoxStyle.DropDown;
            cbbLoaiHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbLoaiHang.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
            }
        }
        



        private void ThemSanPham(string TenSP, double DGN, double DGB, string anh, DateTime HSD, string Loai)
        {
            int MaLoai = int.Parse(Loai);
            string sqlInsert = "INSERT INTO SanPham (TenSP, DGN, DGB, Anh, HSD, MaLH) " +
                               $"VALUES ('{TenSP}',{DGN},{DGB},'{anh}','{HSD.ToString("yyyy-MM-dd")}',{MaLoai});";
            try
            {
                dtBase.DataChange(sqlInsert);
                LoadData();

                MessageBox.Show("Thêm sản phẩm thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm sản phẩm: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ThemLoaiHang(string TenLH)
        {
            string sqlInsert = $"INSERT INTO LoaiHang (TenLH) VALUES ({TenLH});";
            try
            {
                dtBase.DataChange(sqlInsert);
                LoadData();

                MessageBox.Show("Thêm loại hàng thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm loại hàng: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = "Resources";
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFile.Title = "Chọn ảnh";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFile.FileName;

                pic.Image = Image.FromFile(imagePath);

                ImageName = System.IO.Path.GetFileName(imagePath);

            }
        }
    }
}
