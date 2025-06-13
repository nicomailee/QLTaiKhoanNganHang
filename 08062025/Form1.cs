using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _08062025.GiaoDich;

namespace _08062025
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
          panelMainBottom.BringToFront();
        }



        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelMainBottom.Controls.Clear();
            panelMainBottom.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void btnGiaoDich_Click(object sender, EventArgs e)
        {
            GiaoDich.GiaoDich giaoDichUC = new GiaoDich.GiaoDich(); // Tạo UC
            addUserControl(giaoDichUC);          // Hiển thị nó trong panelMain
        }
        private void btnQuanLi_Click(object sender, EventArgs e)
        {
            GiaoDich.QuanLiThongTinKhachHang quanliUC= new GiaoDich.QuanLiThongTinKhachHang(); // Tạo UC
            addUserControl(quanliUC);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            DangKyKhachHangorTaiKhoan dangKyKhachHangorTaiKhoanUC = new DangKyKhachHangorTaiKhoan();
            addUserControl(dangKyKhachHangorTaiKhoanUC);
        }
    }
}

