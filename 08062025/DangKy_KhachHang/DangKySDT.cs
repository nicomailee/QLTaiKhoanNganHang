using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08062025.DangKy_KhachHang
{
    public partial class DangKySDT : UserControl
    {
        public String SDT = "";
        private DangKyKhachHangorTaiKhoan formcha;
        public DangKySDT(DangKyKhachHangorTaiKhoan formcha)
        {
            InitializeComponent();
            this.formcha = formcha;
        }

        public void HienThiUserControl(UserControl uc)
        {
            // Xóa tất cả controls hiện tại trên form
            this.Controls.Clear();

            // Thêm UserControl mới
            uc.Dock = DockStyle.Fill; // Cho chiếm toàn form
            this.Controls.Add(uc);
        }
        private void setDeFault()
        {
            lblSDTDaTonTai.Visible = false;
        }
        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            setDeFault();
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("KIEMTRA_SDT", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);

                    int ketQua = (int)cmd.ExecuteScalar(); // Vì thủ tục trả về SELECT 1 hoặc 0

                    if (ketQua == 1)
                    {
                        lblSDTDaTonTai.Visible = true;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { KetNoi.Disconnect(); }
        }
        private bool KiemTraSoDienThoai(string sdt)
        {
            return Regex.IsMatch(sdt, @"^\d{9}$"); // đúng 9 chữ số
        }
        //private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    // Chỉ cho phép số và phím điều hướng
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true; // chặn ký tự không hợp lệ
        //    }
        //}

        private void lblHinhDong_Click(object sender, EventArgs e)
        {
            string soDienThoai = txtSDT.Text; // textbox người dùng nhập sau +84

            if (KiemTraSoDienThoai(soDienThoai))
            {
                SDT = "0" + txtSDT.Text;

                formcha.LoadUCDangKyCCCD();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng 9 chữ số.");
            }
        }

        private void DangKySDT_Load(object sender, EventArgs e)
        {
            //this.txtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNumber_KeyPress);
            lblSDTDaTonTai.Visible=false;

        }
    }
}
