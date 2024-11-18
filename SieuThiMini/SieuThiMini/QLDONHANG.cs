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
    public partial class QLDONHANG : Form
    {
        KetNoi ketNoi = new KetNoi();
        public QLDONHANG()
        {
            InitializeComponent();
            LoadComboBox();
        }
        private void LoadComboBox()
        {
            try
            {
                // Truy vấn dữ liệu từ bảng NHAPKHO và SANPHAM
                string query = @"
                                SELECT 
                                    n.MaSP, 
                                    s.TenSP, 
                                    n.Soluongton 
                                FROM NHAPKHO n
                                INNER JOIN SANPHAM s ON n.MaSP = s.MaSP";

                DataTable data = ketNoi.ExecuteQuery(query);

                // Thêm cột "Display" để kết hợp TenSP và Soluongton
                data.Columns.Add("Display", typeof(string), "MaSP + ' | ' + TenSP + ' | ' + Soluongton");

                // Gán dữ liệu vào ComboBox
                comboBox2.DataSource = data;

                // Hiển thị giá trị kết hợp của TenSP và Soluongton trong ComboBox
                comboBox2.DisplayMember = "Display";  // Hiển thị tên sản phẩm và số lượng tồn

                // Đặt ComboBox không chọn mục nào
                comboBox2.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu vào ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu người dùng đã chọn sản phẩm và nhập số lượng hợp lệ
                if (comboBox2.SelectedIndex != -1 && int.TryParse(textBox4.Text.Trim(), out int soLuong))
                {
                    // Lấy MaSP và TenSP từ ComboBox
                    DataRowView selectedItem = (DataRowView)comboBox2.SelectedItem;
                    int maSP = (int)selectedItem["MaSP"];  // Lấy MaSP từ ComboBox (giả sử là kiểu int)
                    string tenSP = selectedItem["TenSP"].ToString().Trim();  // Lấy TenSP từ ComboBox

                    // Lấy GiaBan từ bảng SANPHAM
                    string queryGiaBan = $"SELECT Gia FROM SANPHAM WHERE MaSP = {maSP}";
                    DataTable dtGiaBan = ketNoi.ExecuteQuery(queryGiaBan); // Gọi ExecuteQuery với câu lệnh SQL

                    if (dtGiaBan.Rows.Count > 0)
                    {
                        decimal giaBan = Convert.ToDecimal(dtGiaBan.Rows[0]["Gia"]);

                        // Tính ThanhTien
                        decimal thanhTien = giaBan * soLuong;

                        // Thêm vào DataGridView
                        dataGridView1.Rows.Add(maSP, tenSP, soLuong, giaBan, thanhTien);

                        MessageBox.Show("Thêm sản phẩm vào giỏ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy giá sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm và nhập số lượng hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có hàng nào được chọn trong DataGridView không
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Lấy chỉ mục của hàng được chọn
                    int rowIndex = dataGridView1.SelectedRows[0].Index;

                    // Xóa hàng trong DataGridView
                    dataGridView1.Rows.RemoveAt(rowIndex);

                    MessageBox.Show("Đã xóa sản phẩm khỏi giỏ hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có hàng nào trong DataGridView không
                if (dataGridView1.Rows.Count > 0)
                {
                    // Xóa tất cả các hàng trong DataGridView
                    dataGridView1.Rows.Clear();

                    MessageBox.Show("Đã hủy tất cả sản phẩm trong giỏ hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Giỏ hàng đã trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi hủy giỏ hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa tất cả giá trị trong các TextBox
                textBox1.Clear();  // Ví dụ: Clear textBox1
                textBox2.Clear();  // Ví dụ: Clear textBox2
                textBox3.Clear();  // Ví dụ: Clear textBox3
                textBox4.Clear();  // Ví dụ: Clear textBox4
                textBox5.Clear();  // Ví dụ: Clear textBox5

                // Xóa tất cả giá trị trong ComboBox
                comboBox2.SelectedIndex = -1;  // Đặt ComboBox không chọn mục nào

                // Đặt lại giá trị DateTimePicker về giá trị mặc định (ngày hiện tại)
                dateTimePicker1.Value = DateTime.Now;
                dataGridView1.Rows.Clear();

                // Hiển thị thông báo tải lại thành công
                MessageBox.Show("Đã tải lại tất cả các thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải lại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các TextBox và DateTimePicker
                string maDH = textBox1.Text.Trim();
                string tenKhachHang = textBox5.Text.Trim();
                string diaChi = textBox3.Text.Trim();
                DateTime thoiGian = dateTimePicker1.Value;

                // Kiểm tra xem các thông tin có đầy đủ hay không
                if (string.IsNullOrEmpty(maDH) || string.IsNullOrEmpty(tenKhachHang) || string.IsNullOrEmpty(diaChi))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tính tổng thành tiền từ DataGridView
                decimal tongHD = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["ThanhTien"].Value != null)
                    {
                        tongHD += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                    }
                }

                // Tạo câu lệnh SQL để lưu vào bảng THONGKE
                string queryThongKe = @"
                                INSERT INTO THONGKE (MaDH, TenKH, Diachi, Ngaymua, TongHD)
                                VALUES ('" + maDH + "', N'" + tenKhachHang + "', N'" + diaChi + "', '" + thoiGian.ToString("yyyy-MM-dd HH:mm:ss") + "', " + tongHD + ")";

                // Thực thi câu lệnh SQL
                ketNoi.ExecuteQuery(queryThongKe);

                // Lưu thông tin chi tiết đơn hàng vào bảng DONHANG
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["MaSP"].Value != null && row.Cells["SoLuong"].Value != null && row.Cells["ThanhTien"].Value != null)
                    {
                        int maSP = Convert.ToInt32(row.Cells["MaSP"].Value);
                        int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                        decimal thanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value);

                        // Tạo câu lệnh SQL để lưu vào bảng DONHANG
                        string queryDonHang = @"
            INSERT INTO DONHANG (MaSP, SoLuong, Thanhtien)
            VALUES (" + maSP + ", " + soLuong + ", " + thanhTien + ")";

                        // Thực thi câu lệnh SQL
                        ketNoi.ExecuteQuery(queryDonHang);

                        // Cập nhật Số lượng tồn trong bảng NHAPKHO
                        string queryUpdateSoluong = @"
                    UPDATE NHAPKHO 
                    SET Soluongton = Soluongton - " + soLuong + @"
                    WHERE MaSP = " + maSP;

                        // Thực thi câu lệnh SQL để cập nhật kho
                        ketNoi.ExecuteQuery(queryUpdateSoluong);
                    }
                }

                // Hiển thị thông báo thành công
                MessageBox.Show("Tạo hóa đơn và cập nhật kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tạo hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the values from TextBoxes and DataGridView
                string maDH = textBox1.Text.Trim();  // Order ID from TextBox
                string tenKhachHang = textBox5.Text.Trim();  // Customer Name from TextBox
                string diaChi = textBox3.Text.Trim();  // Address from TextBox

                // Calculate the total amount from DataGridView
                decimal tongHD = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["ThanhTien"].Value != null)
                    {
                        tongHD += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                    }
                }

                // Open FormHoaDon and pass the required data
                FormHoaDon formHoaDon = new FormHoaDon(maDH, tenKhachHang, diaChi, tongHD, dataGridView1.Rows);
                formHoaDon.ShowDialog(); // Show FormHoaDon as a modal dialog
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xuất hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
