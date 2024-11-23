using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieuThiMini
{
    public partial class FormHoaDon : Form
    {
        public FormHoaDon(string maDH, string tenKH, string diaChi, DateTime ngayMua, decimal tongHD, DataGridViewRowCollection orderDetails)
        {
            InitializeComponent();
            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            // Khai báo các cột cho DataGridView nếu chưa có
            if (!dataGridView1.Columns.Contains("MaSP")) dataGridView1.Columns.Add("MaSP", "Mã Sản Phẩm");
            if (!dataGridView1.Columns.Contains("TenSP")) dataGridView1.Columns.Add("TenSP", "Tên Sản Phẩm");
            if (!dataGridView1.Columns.Contains("SoLuong")) dataGridView1.Columns.Add("SoLuong", "Số Lượng");
            if (!dataGridView1.Columns.Contains("Gia")) dataGridView1.Columns.Add("Gia", "Giá Bán");
            if (!dataGridView1.Columns.Contains("ThanhTien")) dataGridView1.Columns.Add("ThanhTien", "Thành Tiền");

            // Gán thông tin cho các Label
            label1.Text = "Mã Đơn Hàng: " + maDH;  // Label hiển thị mã đơn hàng
            label2.Text = "Tên Khách Hàng: " + tenKH;  // Label hiển thị tên khách hàng
            label3.Text = "Địa Chỉ: " + diaChi;  // Label hiển thị địa chỉ
            label4.Text = "Ngày Mua: " + ngayMua.ToString("dd/MM/yyyy");  // Label hiển thị ngày mua
            label5.Text = "Tổng Bill: " + tongHD.ToString("C", cultureInfo);  // Hiển thị tổng hóa đơn định dạng tiền tệ

            // Điền dữ liệu vào DataGridView
            foreach (DataGridViewRow row in orderDetails)
            {
                if (row.Cells["MaSP"].Value != null)
                {
                    int maSP = Convert.ToInt32(row.Cells["MaSP"].Value);
                    string tenSP = row.Cells["TenSP"].Value.ToString();
                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    decimal giaBan = Convert.ToDecimal(row.Cells["Gia"].Value);  // Lấy giá bán
                    decimal thanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value);

                    // Thêm dòng vào DataGridView
                    dataGridView1.Rows.Add(
                        maSP,
                        tenSP,
                        soLuong,
                        giaBan.ToString("C", cultureInfo), // Định dạng giá bán
                        thanhTien.ToString("C", cultureInfo) // Định dạng thành tiền
                    );
                }
            }
        }
    }
}
