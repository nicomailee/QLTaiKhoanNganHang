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
using System.Windows.Forms.DataVisualization.Charting;
using System.Configuration;
using System.Text.RegularExpressions;


namespace QLTaiKhoanNganHang
{
    public partial class FormTrangChu : Form
    {
        string connectionString = @"Data Source=LYNKDEN ; Initial Catalog=QUAN LI TAI KHOAN NGAN HANG;Integrated Security= True";
        private int currentMaKH;

        public FormTrangChu()
        {
            InitializeComponent();

           

            // Đặt màu mặc định cho các nút
            SetDefaultButtonColors();

            // Gán sự kiện Click cho các nút
            btnTrangChu.Click += BtnTrangChu_Click;
            btnQuanLi.Click += BtnQuanLi_Click;
            btnDangKyTaiKhoan.Click += BtnDangKyTaiKhoan_Click;
            btnThongTinKhachHang.Click += BtnThongTinKhachHang_Click;
            btnGiaoDich.Click += BtnGiaoDich_Click;
            btnRutTien.Click += BtnRutTien_Click;
            btnChuyenTien.Click += BtnChuyenTien_Click;
            btnGuiTien.Click += BtnGuiTienTietKiem_Click;
            btnVayTien.Click += BtnVayTien_Click;
        }

        // Hàm đặt màu mặc định cho các nút
        private void SetDefaultButtonColors()
        {
            btnTrangChu.BackColor = Color.LightBlue;
            btnQuanLi.BackColor = Color.LightBlue;
            btnDangKyTaiKhoan.BackColor = Color.LightBlue;
            btnThongTinKhachHang.BackColor = Color.LightBlue;
            btnGiaoDich.BackColor = Color.LightBlue;
            btnRutTien.BackColor = Color.LightBlue;
            btnChuyenTien.BackColor = Color.LightBlue;
            btnGuiTien.BackColor = Color.LightBlue;
            btnVayTien.BackColor = Color.LightBlue;
        }

        // Sự kiện Click cho btnTrangChu
        private void BtnTrangChu_Click(object sender, EventArgs e)
        {
            SetDefaultButtonColors();
            btnTrangChu.BackColor = Color.LightGreen;
        }

        private void BtnQuanLi_Click(object sender, EventArgs e)
        {
            SetDefaultButtonColors();
            btnQuanLi.BackColor = Color.LightGreen;
        }

        private void BtnDangKyTaiKhoan_Click(object sender, EventArgs e)
        {
            SetDefaultButtonColors();
            btnDangKyTaiKhoan.BackColor = Color.LightGreen;
        }

        private void BtnThongTinKhachHang_Click(object sender, EventArgs e)
        {
            SetDefaultButtonColors();
            btnThongTinKhachHang.BackColor = Color.LightGreen;
        }

        private void BtnGiaoDich_Click(object sender, EventArgs e)
        {
            SetDefaultButtonColors();
            btnGiaoDich.BackColor = Color.LightGreen;
        }

        private void BtnRutTien_Click(object sender, EventArgs e)
        {
            SetDefaultButtonColors();
            btnRutTien.BackColor = Color.LightGreen;
        }

        private void BtnChuyenTien_Click(object sender, EventArgs e)
        {
            SetDefaultButtonColors();
            btnChuyenTien.BackColor = Color.LightGreen;
        }

        private void BtnGuiTienTietKiem_Click(object sender, EventArgs e)
        {
            SetDefaultButtonColors();
            btnGuiTien.BackColor = Color.LightGreen;
        }

        private void BtnVayTien_Click(object sender, EventArgs e)
        {
            SetDefaultButtonColors();
            btnVayTien.BackColor = Color.LightGreen;
        }

        private void HienThiBieuDoTheoNam(int nam)
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add($"Biểu đồ khách hàng đăng ký năm {nam}");


            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("THONGKE_NAM", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nam", nam);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            Series series = new Series($"Năm {nam}");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.Blue;

            foreach (DataRow row in dt.Rows)
            {
                string thangNam = row["ThangNam"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                series.Points.AddXY(thangNam, soLuong);
            }

            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Title = "Tháng";
            chart1.ChartAreas[0].AxisY.Title = "Số lượng khách hàng";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nam = Convert.ToInt32(((ComboBox)sender).SelectedItem);
            HienThiBieuDoTheoNam(nam);
           
        }

        private void panelNotification_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            panelNotification.Visible = true;
            DKTaiKhoan.Visible = false;
            panelDangKiTaiKhoan.Visible = false;

            LoadMaNhanVien();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DKTaiKhoan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTrangChu_Click_1(object sender, EventArgs e)
        {
            DKTaiKhoan.Visible = false;
        }

        private void btnDangKyTaiKhoan_Click_1(object sender, EventArgs e)
        {
            DKTaiKhoan.Visible= true;
        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void KiemTraCCCD()
        {
            string connectionString = "Data Source=LYNKDEN ; Initial Catalog=QUAN LI TAI KHOAN NGAN HANG;Integrated Security= True"; // sửa "TenCSDL"
            string cccd = txtCCCD.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM KHACHHANG WHERE CCCD = @cccd";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cccd", cccd);
                    int count = (int)cmd.ExecuteScalar();


                    if (count > 0)
                    {
                        MessageBox.Show("CCCD này đã được đăng ký tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCCCD.Focus();
                    }
                    else
                    {
                        MessageBox.Show("CCCD hợp lệ. Tiếp tục đăng ký...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cho phép người dùng nhập tiếp
                    }
                }
            }
        }

        private void txtCCCD_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                KiemTraCCCD();
                e.SuppressKeyPress = true;
            }
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra hợp lệ dữ liệu đầu vào

            // Họ tên không được trống
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return;
            }

            // Giới tính không được trống
            if (string.IsNullOrWhiteSpace(txtGioiTinh.Text))
            {
                MessageBox.Show("Giới tính không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGioiTinh.Focus();
                return;
            }

            // Ngày sinh hợp lệ
            DateTime ngaySinh;
            if (!DateTime.TryParse(txtNgaySinh.Text.Trim(), out ngaySinh) || ngaySinh > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgaySinh.Focus();
                return;
            }

            // Địa chỉ không để trống
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return;
            }

            // Nghề nghiệp không để trống
            if (string.IsNullOrWhiteSpace(txtNgheNghiep.Text))
            {
                MessageBox.Show("Nghề nghiệp không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgheNghiep.Focus();
                return;
            }

            // CCCD: 12 chữ số
            if (!Regex.IsMatch(txtCCCD.Text.Trim(), @"^\d{12}$"))
            {
                MessageBox.Show("CCCD phải gồm đúng 12 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCCCD.Focus();
                return;
            }

            // Email hợp lệ
            if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            // SDT: 10 chữ số
            if (!Regex.IsMatch(txtSDT.Text.Trim(), @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return;
            }

            // 2. Chuỗi kết nối SQL Server
            string connStr = "Server=localhost;Database=QUAN LI TAI KHOAN NGAN HANG;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("ThemKhachHang", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Truyền tham số vào stored procedure
                    cmd.Parameters.AddWithValue("@TenKH", txtHoTen.Text.Trim());
                    cmd.Parameters.AddWithValue("@GioiTinh", txtGioiTinh.Text.Trim());
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@NgheNghiep", txtNgheNghiep.Text.Trim());
                    cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo");
                    HienThiThongTinKhachHang(txtCCCD.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HienThiThongTinKhachHang(string cccd)
        {
            string query = "SELECT * FROM KHACHHANG WHERE CCCD = @cccd";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cccd", cccd);

                try
                {
                    conn.Open();
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
                       

                        panelDangKiTaiKhoan.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void LoadMaNhanVien()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaNV FROM NHANVIEN";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                cmbMaNV.Items.Clear(); // Xóa các item cũ nếu có

                while (reader.Read())
                {
                    cmbMaNV.Items.Add(reader["MaNV"].ToString());
                }

                conn.Close();
            }
        }


        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            string maKH = "";

            // Gọi stored procedure để lấy mã KH mới nhất
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_LayMaKHMoiNhat", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    maKH = reader.GetString(0); // MaKH là varchar
                }
                conn.Close();
            }

            string loaiTaiKhoan = "";
            if (ckcThanhToan.Checked) loaiTaiKhoan = "Thanh toán";
            else if (ckcboxTietKiem.Checked) loaiTaiKhoan = "Tiết kiệm";

            string soTaiKhoan = "";
            if (TaiKhoanSoDienThoai.Checked)
                soTaiKhoan = GetSDTFromKhachHang(maKH);
            else
                soTaiKhoan = GenerateRandomSoTaiKhoan();

            string maNV = cmbMaNV.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên.");
                return;
            }
            DateTime ngayDangKy = dtpNgayDangKy.Value;

            // Gọi stored procedure để thêm tài khoản
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_TaoTaiKhoan", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@STK", soTaiKhoan);
                cmd.Parameters.AddWithValue("@NgayDangKy", ngayDangKy);
                cmd.Parameters.AddWithValue("@LoaiTk", loaiTaiKhoan);
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Tạo tài khoản thành công!");
            }
        }

        private string GenerateRandomSoTaiKhoan()
        {
            Random rnd = new Random();
            return "0" + rnd.Next(100000000, 999999999).ToString("D11"); 
        }

        private string GetSDTFromKhachHang(string maKH)
        {
            string sdt = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT SDT FROM KHACHHANG WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                    sdt = result.ToString();
                conn.Close();
            }
            return sdt;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            panelNotification.Visible = true;
            DKTaiKhoan.Visible = false;
            panelDangKiTaiKhoan.Visible = false;

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {

        }
    }
}