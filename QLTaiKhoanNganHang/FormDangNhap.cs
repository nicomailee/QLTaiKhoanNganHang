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

namespace QLTaiKhoanNganHang
{
    public partial class FormDangNhap : Form
    {
        string ConnectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=QUAN LI TAI KHOAN NGAN HANG;Integrated Security= True";
         
        public FormDangNhap()
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
        
        public static string MaNV_DangNhap; // Biến toàn cục (hoặc đưa vào class CurrentUser)

        private void btn_Dangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("KTRADANGNHAP", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenDangNhap", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@MatKhau", txtPassword.Text.Trim());

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        MaNV_DangNhap = result.ToString(); // Lưu mã nhân viên
                        this.Hide();
                        FormTrangChu trangchu = new FormTrangChu();
                        trangchu.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
        }

        private void linkTerms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Chính sách và điều khoản đang được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}
