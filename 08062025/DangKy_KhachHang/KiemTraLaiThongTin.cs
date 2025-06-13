using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace _08062025.DangKy_KhachHang
{
    public partial class KiemTraLaiThongTin : UserControl
    {
        private DangKyKhachHangorTaiKhoan formcha;
        private DangKySDT formCha1;
        private DangKyCCCD formCha2;
        private NhapThemThongTin formCha3;
        public KiemTraLaiThongTin(DangKySDT form1, DangKyCCCD form2, NhapThemThongTin form3, DangKyKhachHangorTaiKhoan formcha)
        {
            InitializeComponent();
            formCha1 = form1; // lưu lại để dùng sau
            formCha2 = form2;
            formCha3 = form3;
            this.formcha = formcha;
        }
        

        private void btnTao_Click(object sender, EventArgs e)
        {
            KiemTraLaiThongTin_Load(sender, e);
            try
            {
                KetNoi.Connect();

                using (SqlCommand cmd = new SqlCommand("ThemKhachHang", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Truyền tham số vào stored procedure
                    cmd.Parameters.AddWithValue("@TenKH", txtHoTen.Text.Trim());
                    if (checkBoxNam.Checked)
                        cmd.Parameters.AddWithValue("@GioiTinh", "Nam");
                    else cmd.Parameters.AddWithValue("@GioiTinh", "Nữ");

                    string input = txtNgaySinh.Text.Trim();
                    DateTime ngaySinh;
                   
                        ngaySinh = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                   

                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@NgheNghiep", txtNgheNghiep.Text.Trim());
                    cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());

                    cmd.ExecuteNonQuery();

                    DialogResult result = MessageBox.Show
                    (
                         "Thêm khách hàng thành công!\nBạn có muốn xuất phiếu đăng ký khách hàng không?",
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
                        // Thoát hoặc đóng form
                                      
                    }
                    lblHinhDong.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { KetNoi.Disconnect(); }
            }
        
        private void KiemTraTT()
        {
            

        }

        private void KiemTraLaiThongTin_Load(object sender, EventArgs e)
        {
            lblHinhDong.Visible = false;
            txtCCCD.Text = formCha2.CCCD_;
            txtSDT.Text = formCha1.SDT;
            txtHoTen.Text = formCha3.HoTen;

            txtEmail.Text = formCha3.Email;
            string gioiTinh = formCha3.GioiTinh; // hoặc "Nữ", có thể lấy từ CSDL hoặc form khác

            if (gioiTinh == "Nam")
            {
                checkBoxNam.Checked = true;
                checkBoxNu.Checked = false;
            }
            else if (gioiTinh == "Nữ")
            {
                checkBoxNam.Checked = false;
                checkBoxNu.Checked = true;
            }
            txtNgaySinh.Text = formCha3.NgaySinh;
            txtDiaChi.Text = formCha3.DiaChi;
            txtNgheNghiep.Text = formCha3.NgheNghiep;
            txtNguoiGT.Text = formCha3.MaNGT;

            KiemTraTT();

        }

        private void lblHinhDong_Click(object sender, EventArgs e)
        {
            formcha.LoadUCDangKyTaiKhoan(txtCCCD.Text);
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            formcha.LoadUCNhapThemThongTin();
        }
    }
}
