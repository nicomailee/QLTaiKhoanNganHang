using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTaiKhoanNganHang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Resize += Form1_Resize;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Mở full màn hình khi chạy
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Màu nền đồng nhất
            this.BackColor = Color.WhiteSmoke;
            panelRight.BackColor = this.BackColor;

            // Căn giữa panel đăng nhập
            CenterLoginPanel();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterLoginPanel();
        }

        private void CenterLoginPanel()
        {
            panelLogin.Left = (panelRight.ClientSize.Width - panelLogin.Width) / 2;
            panelLogin.Top = (panelRight.ClientSize.Height - panelLogin.Height) / 2;
        }

        private void chk_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chk_ShowPassword.Checked;
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Dangnhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "Lemai" && password == "123")
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkTerms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Chính sách và điều khoản đang được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
