using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SieuThiMini
{
    public partial class QLSANPHAM : Form
    {
        KetNoi ketNoi = new KetNoi();
        public QLSANPHAM()
        {
            InitializeComponent();
            LoadData();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            string query = "SELECT MaNCC, TenNCC FROM NHACC";
            DataTable data = ketNoi.ExecuteQuery(query);
            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "TenNCC";
            comboBox1.ValueMember = "MaNCC";
            // Đặt ComboBox không chọn item nào
            comboBox1.SelectedIndex = -1;
        }

        private void LoadData()
        {
            string query = "SELECT MaSP, TenSP, MaNCC, LoaiSP, Gia FROM SANPHAM";
            DataTable data = ketNoi.ExecuteQuery(query);
            dataGridView1.DataSource = data;
        }
    
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string maSP = textBox1.Text;
                string tenSP = textBox2.Text;
                string maNCC = comboBox1.SelectedValue.ToString();
                string loaiSP = textBox4.Text;
                decimal giaBan = decimal.Parse(textBox3.Text);

                string query = $"INSERT INTO SANPHAM (MaSP, TenSP, MaNCC, LoaiSP, Gia) " +
                               $"VALUES ('{maSP}', N'{tenSP}', '{maNCC}', N'{loaiSP}', {giaBan})";
                ketNoi.ExecuteNonQuery(query);
                LoadData();
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string maSP = textBox1.Text;
                string tenSP = textBox2.Text;
                string maNCC = comboBox1.SelectedValue.ToString();
                string loaiSP = textBox4.Text;
                decimal giaBan = decimal.Parse(textBox3.Text);

                string query = $"UPDATE SANPHAM SET TenSP = N'{tenSP}', MaNCC = '{maNCC}', LoaiSP = N'{loaiSP}', Gia = {giaBan} " +
                               $"WHERE MaSP = '{maSP}'";
                ketNoi.ExecuteNonQuery(query);
                LoadData();
                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                string maSP = textBox1.Text;
                string query = $"DELETE FROM SANPHAM WHERE MaSP = '{maSP}'";
                ketNoi.ExecuteNonQuery(query);
                LoadData();
                MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            LoadData();
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            metroTextBox1.Text = string.Empty;

            // Đặt giá trị mặc định cho ComboBox (hoặc làm trống)
            comboBox1.SelectedIndex = -1; // Không chọn mục nào
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = metroTextBox1.Text;
            string query = $"SELECT MaSP, TenSP, MaNCC, LoaiSP, Gia " +
                           $"FROM SANPHAM WHERE TenSP LIKE N'%{keyword}%'";
            DataTable data = ketNoi.ExecuteQuery(query);
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Hiển thị thông tin dòng được chọn lên các TextBox và ComboBox
                textBox1.Text = row.Cells["MaSP"].Value.ToString();
                textBox2.Text = row.Cells["TenSP"].Value.ToString();
                comboBox1.SelectedValue = row.Cells["MaNCC"].Value.ToString();
                textBox4.Text = row.Cells["LoaiSP"].Value.ToString();
                textBox3.Text = row.Cells["Gia"].Value.ToString();
            }
        }
    }
}