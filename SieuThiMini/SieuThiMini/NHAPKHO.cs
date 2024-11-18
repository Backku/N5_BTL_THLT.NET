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
    public partial class NHAPKHO : Form
    {
        KetNoi ketNoi = new KetNoi();
        public NHAPKHO()
        {
            InitializeComponent();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ giao diện
                int maSP = int.Parse(textBox2.Text.Trim()); // Mã SP nhập từ TextBox
                int soLuongNhap = int.Parse(domainUpDown1.Text.Trim()); // Số lượng nhập từ DomainUpDown

                // Kiểm tra xem Mã SP có tồn tại trong bảng SANPHAM hay không
                string queryCheck = $"SELECT COUNT(*) AS Total FROM SANPHAM WHERE MaSP = {maSP}";
                DataTable dtCheck = ketNoi.ExecuteQuery(queryCheck);

                if (dtCheck.Rows.Count == 0 || Convert.ToInt32(dtCheck.Rows[0]["Total"]) == 0)
                {
                    MessageBox.Show("Mã sản phẩm không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem sản phẩm đã có trong bảng NHAPKHO chưa
                string queryCheckKho = $"SELECT COUNT(*) AS Total FROM NHAPKHO WHERE MaSP = {maSP}";
                DataTable dtCheckKho = ketNoi.ExecuteQuery(queryCheckKho);

                bool isExistInKho = dtCheckKho.Rows.Count > 0 && Convert.ToInt32(dtCheckKho.Rows[0]["Total"]) > 0;

                if (isExistInKho)
                {
                    // Nếu đã tồn tại, cập nhật số lượng tồn
                    string queryUpdate = $@"
                        UPDATE NHAPKHO
                        SET Soluongton = Soluongton + {soLuongNhap}, Ngaynhap = GETDATE()
                        WHERE MaSP = {maSP}";
                    ketNoi.ExecuteNonQuery(queryUpdate);

                    MessageBox.Show("Cập nhật số lượng tồn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Nếu chưa tồn tại, thêm mới bản ghi vào NHAPKHO
                    string queryInsert = $@"
                        INSERT INTO NHAPKHO (Soluongton, Ngaynhap, MaSP)
                        VALUES ({soLuongNhap}, GETDATE(), {maSP})";
                    ketNoi.ExecuteNonQuery(queryInsert);

                    MessageBox.Show("Thêm mới sản phẩm vào kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Làm mới dữ liệu hiển thị trong DataGridView
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadData()
        {
            try
            {
                // Câu lệnh SQL kết hợp bảng SANPHAM, NHAPKHO và NHACC
                string query = @"
            SELECT 
                n.STT, 
                s.MaSP, 
                m.TenNCC, 
                s.TenSP, 
                s.LoaiSP, 
                s.Gia, 
                n.Soluongton, 
                n.Ngaynhap
            FROM 
                SANPHAM s
            INNER JOIN 
                NHAPKHO n 
            ON 
                s.MaSP = n.MaSP
            INNER JOIN 
                NHACC m 
            ON 
                s.MaNCC = m.MaNCC";

                // Lấy dữ liệu từ cơ sở dữ liệu
                DataTable data = ketNoi.ExecuteQuery(query);

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
