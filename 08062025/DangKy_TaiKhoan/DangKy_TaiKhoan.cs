using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08062025.DangKy_TaiKhoan
{
    public partial class DangKy_TaiKhoan : UserControl

    {
        private string maNV = "";
        private DangKyKhachHangorTaiKhoan formcha;
        public DangKy_TaiKhoan(string cccd, DangKyKhachHangorTaiKhoan formcha)
        {
            InitializeComponent();
            HienThiThongTinKhachHang(cccd);
            this.formcha = formcha;
        }
        private void HienThiThongTinKhachHang(string cccd)
        {
            if (cccd != "")
            {
                try
                {
                    KetNoi.Connect(); // Mở kết nối
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM KHACHHANG WHERE CCCD = @cccd", KetNoi.Conn))
                    {
                        cmd.Parameters.AddWithValue("@cccd", cccd);
                        cmd.ExecuteNonQuery();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // Gán giá trị vào các label hiển thị
                            lblCCCD.Text = "CCCD: " + reader["CCCD"].ToString();
                            lblHoTen.Text = "Họ tên: " + reader["TenKH"].ToString();
                            lblNgaySinh.Text = "Ngày sinh: " + Convert.ToDateTime(reader["NgaySinh"]).ToShortDateString();
                            lblGioiTinh.Text = "Giới tính: " + reader["GioiTinh"].ToString();
                            lblNgheNghiep.Text = "Nghề nghiệp: " + reader["NgheNghiep"].ToString();
                            lblEmail.Text = "Email: " + reader["Email"].ToString();
                            lblSDT.Text = "SĐT: " + reader["SDT"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { KetNoi.Disconnect(); }
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienThiThongTinKhachHang(txtFindCCCD.Text);
            cmbMaNV.Text = maNV;
        }

        private void DangKy_TaiKhoan_Load(object sender, EventArgs e)
        {
        }

        private void ckcThanhToan_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("KTRA_TKTT", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", lblCCCD.Text.Split(':')[1].Trim());

                    int ketQua = (int)cmd.ExecuteScalar(); // Vì thủ tục trả về SELECT 1 hoặc 0

                    if (ketQua == 1)
                    {
                        MessageBox.Show("Đã có tài khoản thanh toán");
                        ckcThanhToan.Checked = false;
                    }
                    
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { KetNoi.Disconnect(); }
        }

        private void ckcboxTietKiem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("KTRA_TKTK", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", lblCCCD.Text.Split(':')[1].Trim());

                    int ketQua = (int)cmd.ExecuteScalar(); // Vì thủ tục trả về SELECT 1 hoặc 0

                    if (ketQua == 1)
                    {
                        MessageBox.Show("Đã có tài khoản tiết kiệm");
                        ckcboxTietKiem.Checked = false;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { KetNoi.Disconnect(); }
        }

        private void TaiKhoanSoDienThoai_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TaiKhanNgauNhien_CheckedChanged(object sender, EventArgs e)
        {

        }
        private string GenerateRandomSoTaiKhoan()
        {
            Random rnd = new Random();
            return "0" + rnd.Next(100000000, 999999999).ToString("D11");
        }
        private string GetSDTFromKhachHang(string maKH)
        {
            string sdt = "";
            try
            {
                KetNoi.Connect(); // Mở kết nối
                using (SqlCommand cmd = new SqlCommand("SELECT SDT FROM KHACHHANG WHERE CCCD = @CCCD", KetNoi.Conn))
                {
                    cmd.Parameters.AddWithValue("@CCCD", lblCCCD.Text.Split(':')[1].Trim());
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        sdt = result.ToString();
                }

            }
            catch (Exception EX) { MessageBox.Show(EX.Message); } finally { KetNoi.Disconnect(); }
            return sdt;
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            string loaiTaiKhoan = "";
            if (ckcThanhToan.Checked) loaiTaiKhoan = "Thanh toán";
            else if (ckcboxTietKiem.Checked) loaiTaiKhoan = "Tiết kiệm";

            string soTaiKhoan = "";
            if (TaiKhoanSoDienThoai.Checked)
                soTaiKhoan = GetSDTFromKhachHang(lblCCCD.Text.Split(':')[1].Trim());
            else
                soTaiKhoan = GenerateRandomSoTaiKhoan();

            
            DateTime ngayDangKy = dtpNgayDangKy.Value;

            // Gọi stored procedure để thêm tài khoản
            try
            {
                KetNoi.Connect(); // Mở kết nối
                using (SqlCommand cmd = new SqlCommand("sp_TaoTaiKhoan", KetNoi.Conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STK", soTaiKhoan);
                    cmd.Parameters.AddWithValue("@NgayDangKy", ngayDangKy);
                    cmd.Parameters.AddWithValue("@LoaiTk", loaiTaiKhoan);
                    cmd.Parameters.AddWithValue("@CCCD", lblCCCD.Text.Split(':')[1].Trim());
                    cmd.Parameters.AddWithValue("@MaNV", cmbMaNV.Text);

                    cmd.ExecuteNonQuery();

                    DialogResult result = MessageBox.Show
                    (
                         "Tạo tài khoản thành công!\nBạn có muốn xuất phiếu đăng ký tài khoản không?",
                         "Thông báo",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Information
                    );
                    

                    if (result == DialogResult.Yes)
                    {
                        // Gọi hàm Xuất dữ liệu

                    }
                    else
                    {
                        

                    }
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message); 
            }
            finally { KetNoi.Disconnect(); }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            

        }
    }
}
