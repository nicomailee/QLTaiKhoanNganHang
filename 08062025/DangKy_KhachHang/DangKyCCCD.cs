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
    public partial class DangKyCCCD : UserControl
    {
        public String CCCD_ = "";
        private DangKyKhachHangorTaiKhoan formcha;
        public DangKyCCCD(DangKyKhachHangorTaiKhoan formcha)
        {
            InitializeComponent();
            this.formcha = formcha;
        }
        private bool KiemTraCCCD(string cccd)
        {
            return Regex.IsMatch(cccd, @"^\d{12}$");
        }
        private void setDeFault()
        {
            lblCCCDDaTonTai.Visible = false;
        }
        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            setDeFault();
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("KTRA_CCCD", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text);

                    int ketQua = (int)cmd.ExecuteScalar(); // Vì thủ tục trả về SELECT 1 hoặc 0

                    if (ketQua == 1)
                    {
                        lblCCCDDaTonTai.Visible = true;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { KetNoi.Disconnect(); }
        }

        private void lblHinhDong_Click(object sender, EventArgs e)
        {
            string CCCD = txtCCCD.Text; // textbox người dùng nhập sau +84

            if (KiemTraCCCD(CCCD))
            {
                CCCD_ = txtCCCD.Text;
                formcha.LoadUCNhapThemThongTin();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng 12 chữ số.");
            }
        }

        private void DangKyCCCD_Load(object sender, EventArgs e)
        {
            lblCCCDDaTonTai.Visible=false;
        }

        private void lblQuayLai_Click(object sender, EventArgs e)
        {
            formcha.LoadUCDangKySDT();
        }
    }
}
