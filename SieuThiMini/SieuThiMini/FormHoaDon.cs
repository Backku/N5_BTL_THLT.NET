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
            if (!dataGridView1.Columns.Contains("MaSP")) dataGridView1.Columns.Add("MaSP", "Mã Sản Phẩm");
            if (!dataGridView1.Columns.Contains("TenSP")) dataGridView1.Columns.Add("TenSP", "Tên Sản Phẩm");
            if (!dataGridView1.Columns.Contains("SoLuong")) dataGridView1.Columns.Add("SoLuong", "Số Lượng");
            if (!dataGridView1.Columns.Contains("Gia")) dataGridView1.Columns.Add("Gia", "Giá Bán");
            if (!dataGridView1.Columns.Contains("ThanhTien")) dataGridView1.Columns.Add("ThanhTien", "Thành Tiền");


            label1.Text = "Mã Đơn Hàng : " + maDH;  
            label2.Text = "Tên Khách Hàng : " + tenKH; 
            label3.Text = "Địa Chỉ : " + diaChi;  
            label4.Text = "Ngày Mua : " + ngayMua.ToString("dd/MM/yyyy"); 
            label5.Text = "Tổng Bill : " + tongHD.ToString("C", cultureInfo);  


            foreach (DataGridViewRow row in orderDetails)
            {
                if (row.Cells["MaSP"].Value != null)
                {
                    int maSP = Convert.ToInt32(row.Cells["MaSP"].Value);
                    string tenSP = row.Cells["TenSP"].Value.ToString();
                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    decimal giaBan = Convert.ToDecimal(row.Cells["Gia"].Value);  
                    decimal thanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value);


                    dataGridView1.Rows.Add(
                        maSP,
                        tenSP,
                        soLuong,
                        giaBan.ToString("C", cultureInfo), 
                        thanhTien.ToString("C", cultureInfo) 
                    );
                }
            }
        }
    }
}
