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
    }
}
