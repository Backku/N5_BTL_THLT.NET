using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieuThiMini
{
    public partial class QLNHACUNGCAP : Form
    {
        KetNoi ketNoi = new KetNoi();
        public QLNHACUNGCAP()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string query = "SELECT MaNCC, TenNCC, SDT, Diachi FROM NHACC";
            DataTable data = ketNoi.ExecuteQuery(query);
            dataGridView1.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string maNCC = textBox1.Text;
                string tenNCC = textBox4.Text;
                string SDT = textBox2.Text;
                string Diachi = textBox3.Text;

                string query = $"INSERT INTO NHACC (MaNCC, TenNCC, SDT, DiaChi) " +
                               $"VALUES ('{maNCC}', N'{tenNCC}', '{SDT}', N'{Diachi}')";
                ketNoi.ExecuteNonQuery(query);
                LoadData();
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string maNCC = textBox1.Text;
                string tenNCC = textBox4.Text;
                string SDT = textBox2.Text;
                string Diachi = textBox3.Text;

                string query = $"UPDATE NHACC SET TenNCC = N'{tenNCC}', SDT = '{SDT}', Diachi = N'{Diachi}' " +
                               $"WHERE MaNCC = '{maNCC}'";
                ketNoi.ExecuteNonQuery(query);
                LoadData();
                MessageBox.Show("Cập nhật thông tin nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                string maNCC = textBox1.Text;
                string query = $"DELETE FROM NHACC WHERE MaNCC = '{maNCC}'";
                ketNoi.ExecuteNonQuery(query);
                LoadData();
                MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void metroTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            string keyword = metroTextBox1.Text;
            string query = $"SELECT MaNCC, TenNCC, SDT, Diachi " +
                           $"FROM NHACC WHERE TenNCC LIKE N'%{keyword}%'";
            DataTable data = ketNoi.ExecuteQuery(query);
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Hiển thị thông tin dòng được chọn lên các TextBox và ComboBox
                textBox1.Text = row.Cells["MaNCC"].Value.ToString();
                textBox4.Text = row.Cells["TenNCC"].Value.ToString();
                textBox2.Text = row.Cells["SDT"].Value.ToString();
                textBox3.Text = row.Cells["Diachi"].Value.ToString();
            }
        }
    }
}