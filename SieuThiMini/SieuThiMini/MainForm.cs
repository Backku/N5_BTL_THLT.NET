using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SieuThiMini
{
    public partial class MainForm : Form
    {
        KetNoi kn = new KetNoi();
        public MainForm()
        {
            InitializeComponent();
        }
        private Form activeform = null;
        public void openChildform(Form childform)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            label2.Text = childform.Text;
            panelMain.Controls.Add(childform);
            panelMain.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void btnQLSP_Click(object sender, EventArgs e)
        {
            openChildform(new QLSANPHAM());
        }
        private void btnQLKH_Click(object sender, EventArgs e)
        {
            openChildform(new QLDONHANG());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildform(new QLNHACUNGCAP());
        }

        private void btnQLKH_Click_1(object sender, EventArgs e)
        {
            openChildform(new QLKHO());
        }

        private void btnBCTK_Click(object sender, EventArgs e)
        {
            openChildform(new BAOCAOTHONGKE());
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (activeform != null)
            {
                activeform.Close(); // Đóng form con hiện tại
            }
            label2.Text = "TIỆM TẠP HÓA NHỎ";
        }
    }
}
