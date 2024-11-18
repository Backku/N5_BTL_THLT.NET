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

namespace SieuThiMini
{
    public partial class QLKHO : Form
    {
        KetNoi ketNoi = new KetNoi();
        public QLKHO()
        {
            InitializeComponent();
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NHAPKHO nhapkho = new NHAPKHO();
            nhapkho.Show();
        }
        private void LoadData()
        {
            try
            {
                string query = @"
                    SELECT 
                    s.MaSP,
                    s.TenSP,
                    ISNULL(n.Soluongton, 0) AS Soluongton,
                    CASE 
                    WHEN n.NgayNhap IS NULL THEN N'Chưa nhập' 
                    ELSE FORMAT(n.NgayNhap, 'dd/MM/yyyy') 
                    END AS NgayNhap 
                    FROM SANPHAM s
                    LEFT JOIN NHAPKHO n ON s.MaSP = n.MaSP;";

                DataTable dt = ketNoi.ExecuteQuery(query); // Lấy dữ liệu bằng lớp KetNoi
                dataGridView1.DataSource = dt; // Gán dữ liệu cho DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadData();
            button7.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0) // Kiểm tra nếu có dòng được chọn
                {
                    // Lấy Mã SP từ dòng được chọn
                    int maSP = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MaSP"].Value);

                    // Xác nhận trước khi xóa
                    DialogResult dialogResult = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa sản phẩm này khỏi kho?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Xóa sản phẩm trong bảng NHAPKHO
                        string queryDelete = $"DELETE FROM NHAPKHO WHERE MaSP = {maSP}";
                        ketNoi.ExecuteNonQuery(queryDelete);

                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Làm mới dữ liệu hiển thị trong DataGridView
                        LoadData();

                        // Vô hiệu hóa nút "Xóa"
                        button7.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không phải tiêu đề
            {
                button7.Enabled = true; // Bật nút "Xóa"
            }
        }
    }
}
