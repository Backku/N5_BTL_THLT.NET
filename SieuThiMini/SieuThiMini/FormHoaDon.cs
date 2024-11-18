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
    public partial class FormHoaDon : Form
    {
        public FormHoaDon(string maDH, string tenKH, string diaChi, decimal tongHD, DataGridViewRowCollection orderDetails)
        {
            InitializeComponent();
            // Khai báo các cột cho DataGridView nếu chưa có
            dataGridView1.Columns.Add("MaSP", "Mã Sản Phẩm");
            dataGridView1.Columns.Add("TenSP", "Tên Sản Phẩm");
            dataGridView1.Columns.Add("SoLuong", "Số Lượng");
            dataGridView1.Columns.Add("ThanhTien", "Thành Tiền");

            // Set information to labels or textboxes (for example)
            label1.Text = maDH;
            label2.Text = tenKH;
            label3.Text = diaChi;
            label5.Text = tongHD.ToString("C");  // Display the total amount in currency format

            // Populate DataGridView with order details
            foreach (DataGridViewRow row in orderDetails)
            {
                if (row.Cells["MaSP"].Value != null)
                {
                    int maSP = Convert.ToInt32(row.Cells["MaSP"].Value);
                    string tenSP = row.Cells["TenSP"].Value.ToString();
                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    decimal thanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value);

                    // Add the row to the DataGridView in FormHoaDon
                    dataGridView1.Rows.Add(maSP, tenSP, soLuong, thanhTien);
                }
            }
        }
    }
}
