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
    public partial class BAOCAOTHONGKE : Form
    {
        KetNoi ketNoi = new KetNoi();
        public BAOCAOTHONGKE()
        {
            InitializeComponent();
            LoadData();
            TinhTongDoanhThu();
        }
        private void LoadData()
        {
            string query = "SELECT * FROM THONGKE";
            DataTable data = ketNoi.ExecuteQuery(query);
            dataGridView1.DataSource = data;
        }
        private void TinhTongDoanhThu()
        {
            try
            {
                // Truy vấn tổng doanh thu từ bảng THONGKE và chuyển đổi cột TongHD thành kiểu decimal
                string queryTongDoanhThu = "SELECT SUM(CAST(TongHD AS DECIMAL(10, 2))) AS TongDoanhThu FROM THONGKE";

                // Gọi phương thức ExecuteQuery để thực thi câu lệnh SQL
                DataTable dtTongDoanhThu = ketNoi.ExecuteQuery(queryTongDoanhThu);

                // Kiểm tra và hiển thị tổng doanh thu
                if (dtTongDoanhThu.Rows.Count > 0)
                {
                    // Lấy giá trị tổng doanh thu từ DataTable và chuyển sang kiểu decimal
                    decimal tongDoanhThu = Convert.ToDecimal(dtTongDoanhThu.Rows[0]["TongDoanhThu"]);

                    // Hiển thị tổng doanh thu trong label1, định dạng tiền tệ VND
                    label1.Text = "Tổng Doanh Thu: " + tongDoanhThu.ToString("C0", new System.Globalization.CultureInfo("vi-VN"));
                }
                else
                {
                    label1.Text = "Tổng Doanh Thu: 0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tính tổng doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = metroTextBox1.Text;
            string query = $"SELECT MaDH, TenKH, Diachi , Ngaymua , TongHD " +
                           $"FROM THONGKE WHERE MaDH LIKE N'%{keyword}%'";
            DataTable data = ketNoi.ExecuteQuery(query);
            dataGridView1.DataSource = data;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadData();
            metroTextBox1.Text = string.Empty;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                button7.Enabled = true; // Bật nút "Xem chi tiết HĐ"
            }
            else
            {
                button7.Enabled = false; // Tắt nút nếu không chọn dòng
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy thông tin từ dòng được chọn
                string maDH = dataGridView1.SelectedRows[0].Cells["MaDH"].Value.ToString();
                string tenKH = dataGridView1.SelectedRows[0].Cells["TenKH"].Value.ToString();
                string diaChi = dataGridView1.SelectedRows[0].Cells["DiaChi"].Value.ToString();
                DateTime ngayMua = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["NgayMua"].Value);
                decimal tongHD = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["TongHD"].Value);

                // Truy vấn dữ liệu chi tiết hóa đơn
                string query = @"
            SELECT 
                DONHANG.MaSP, 
                SANPHAM.TenSP, 
                SANPHAM.Gia, 
                DONHANG.SoLuong, 
                DONHANG.ThanhTien
            FROM 
                DONHANG
            INNER JOIN 
                SANPHAM 
            ON 
                DONHANG.MaSP = SANPHAM.MaSP
            WHERE 
                DONHANG.MaDH = '" + maDH + "'";

                DataTable orderDetails = ketNoi.ExecuteQuery(query);

                // Tạo danh sách các dòng DataGridViewRow từ DataTable
                DataGridView dgvTemp = new DataGridView(); // Tạo DataGridView tạm
                dgvTemp.Columns.Add("MaSP", "Mã Sản Phẩm");
                dgvTemp.Columns.Add("TenSP", "Tên Sản Phẩm");
                dgvTemp.Columns.Add("SoLuong", "Số Lượng");
                dgvTemp.Columns.Add("Gia", "Giá Bán");
                dgvTemp.Columns.Add("ThanhTien", "Thành Tiền");

                foreach (DataRow row in orderDetails.Rows)
                {
                    dgvTemp.Rows.Add(
                        row["MaSP"],
                        row["TenSP"],
                        row["SoLuong"],
                        row["Gia"],
                        row["ThanhTien"]
                    );
                }

                // Truyền dữ liệu sang FormHoaDon
                FormHoaDon formHoaDon = new FormHoaDon(maDH, tenKH, diaChi,ngayMua, tongHD, dgvTemp.Rows);
                formHoaDon.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
