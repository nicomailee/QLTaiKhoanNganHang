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

namespace QLTaiKhoanNganHang
{
    public partial class FormTrangChu : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=QUAN LI TAI KHOAN NGAN HANG;Integrated Security=True";

        public FormTrangChu()
        {
            InitializeComponent();
            Load += FormTrangChu_Load;
        }

        private void SetDefaultButtonColors()
        {
            btnTrangChu.BackColor = Color.LightGreen;
            btnQuanLi.BackColor = Color.LightBlue;
            btnDangKyTaiKhoan.BackColor = Color.LightBlue;
            btnThongTinKhachHang.BackColor = Color.LightBlue;
            btnGiaoDich.BackColor = Color.LightBlue;
            btnRutTien.BackColor = Color.LightBlue;
            btnChuyenTien.BackColor = Color.LightBlue;
            btnGuiTien.BackColor = Color.LightBlue;
            btnVayTien.BackColor = Color.LightBlue;
        }

        private void BtnTrangChu_Click(object sender, EventArgs e)
        {
            SetDefaultButtonColors();
            btnTrangChu.BackColor = Color.LightGreen;

            btnDangKyTaiKhoan.Visible = false;
            btnThongTinKhachHang.Visible = false;
            btnRutTien.Visible = false;
            btnChuyenTien.Visible = false;
            btnGuiTien.Visible = false;
            btnVayTien.Visible = false;
        }

        private void BtnQuanLi_Click(object sender, EventArgs e)
        {
            SetDefaultButtonColors();
            btnQuanLi.BackColor = Color.LightGreen;

            btnDangKyTaiKhoan.Visible = true;
            btnThongTinKhachHang.Visible = true;
            btnRutTien.Visible = false;
            btnChuyenTien.Visible = false;
            btnGuiTien.Visible = false;
            btnVayTien.Visible = false;
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

            btnDangKyTaiKhoan.Visible = false;
            btnThongTinKhachHang.Visible = false;
            btnRutTien.Visible = true;
            btnChuyenTien.Visible = true;
            btnGuiTien.Visible = true;
            btnVayTien.Visible = true;
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
            // Tạo nút Rút tiền
            Button btnRutTien = new Button
            {
                Text = "Rút Tiền",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };
            btnRutTien.Click += BtnRutTien_Click;
            this.Controls.Add(btnRutTien);

            // Tạo ComboBox LoaiTaiKhoan (nếu chưa có trong designer)
            cboLoaiTaiKhoan = new ComboBox
            {
                Location = new System.Drawing.Point(20, 60),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Enabled = true
            };
            cboLoaiTaiKhoan.SelectedIndexChanged += cboLoaiTaiKhoan_SelectedIndexChanged;
            this.Controls.Add(cboLoaiTaiKhoan);

            // Vô hiệu hóa các ô nhập thông tin KH ban đầu
            txtHoTen.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;

            // Đảm bảo txtSTK và txtSoDu được khởi tạo
            txtSTK = new TextBox
            {
                Location = new System.Drawing.Point(20, 90),
                Width = 200,
                Enabled = false
            };
            this.Controls.Add(txtSTK);

            txtSoDu = new TextBox
            {
                Location = new System.Drawing.Point(20, 120),
                Width = 200,
                Enabled = false
            };
            this.Controls.Add(txtSoDu);

            // Không gọi LoadDanhSachLoaiTaiKhoan ở đây để đảm bảo cần CCCD trước
        }

        private void btnXacMinhCCCD_Click(object sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();

            if (string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Vui lòng nhập CCCD.");
                return;
            }

            LoadTaiKhoanTheoCCCD(cccd);

            // Xóa các thông tin giao dịch hiện tại
            txtSTK.Text = "";
            txtSoDu.Text = "";
            txtSoTienRut.Text = "";
            cboLoaiTaiKhoan.DataSource = null;
            cboLoaiTaiKhoan.Items.Clear();
            LoadDanhSachLoaiTaiKhoan(cccd); // Tải danh sách loại tài khoản dựa trên CCCD
        }

        private void LoadTaiKhoanTheoCCCD(string cccd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetThongTinKhachHangTheoCCCD", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", cccd);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtHoTen.Text = reader["TenKH"].ToString();
                        txtSDT.Text = reader["SDT"].ToString();
                        txtDiaChi.Text = reader["DiaChi"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng với CCCD này.");
                        txtHoTen.Text = "";
                        txtSDT.Text = "";
                        txtDiaChi.Text = "";
                        cboLoaiTaiKhoan.DataSource = null;
                        cboLoaiTaiKhoan.Items.Clear();
                        txtSTK.Text = "";
                        txtSoDu.Text = "";
                        return;
                    }

                    reader.Close();
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Lỗi khi tải thông tin khách hàng: {ex.Message}");
                }
            }

            LoadDanhSachTaiKhoanTheoCCCD(cccd);
        }

        private void LoadDanhSachTaiKhoanTheoCCCD(string cccd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetTaiKhoanTheoCCCD", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", cccd);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtSTK.Text = reader["STK"].ToString();
                        txtSoDu.Text = Convert.ToDecimal(reader["SoDu"]).ToString("N0");
                    }
                    else
                    {
                        txtSTK.Text = "";
                        txtSoDu.Text = "";
                    }

                    reader.Close();
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Lỗi khi tải danh sách tài khoản: {ex.Message}");
                }
            }
        }

        private void cboLoaiTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiTaiKhoan.SelectedItem == null || string.IsNullOrEmpty(txtCCCD.Text))
                return;

            string loaiTK = cboLoaiTaiKhoan.SelectedValue.ToString();
            string cccd = txtCCCD.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetTaiKhoanTheoCCCDvaLoaiTK", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", cccd);
                    cmd.Parameters.AddWithValue("@LoaiTK", loaiTK);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtSTK.Text = reader["STK"].ToString();
                        txtSoDu.Text = Convert.ToDecimal(reader["SoDu"]).ToString("N0");
                    }
                    else
                    {
                        txtSTK.Text = "";
                        txtSoDu.Text = "";
                        MessageBox.Show("Không tìm thấy tài khoản phù hợp cho loại tài khoản này.");
                    }

                    reader.Close();
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Lỗi khi truy vấn thông tin tài khoản: {ex.Message}");
                }
            }
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            string stk = txtSTK.Text;
            string cccd = txtCCCD.Text;
            decimal soTienRut;

            if (string.IsNullOrEmpty(stk))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản.");
                return;
            }

            if (!decimal.TryParse(txtSoTienRut.Text, out soTienRut))
            {
                MessageBox.Show("Vui lòng nhập số tiền rút hợp lệ.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_TaoPhieuRutTien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@STK", stk);
                    cmd.Parameters.AddWithValue("@CCCD", cccd);
                    cmd.Parameters.AddWithValue("@SoTienRut", soTienRut);
                    cmd.Parameters.AddWithValue("@NgayRut", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                LoadDanhSachTaiKhoanTheoCCCD(cccd);
                MessageBox.Show("Rút tiền thành công. Số dư mới đã được cập nhật.");
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Số dư không đủ"))
                {
                    MessageBox.Show("Số dư không đủ để rút tiền.");
                }
                else
                {
                    MessageBox.Show($"Lỗi khi thực hiện rút tiền: {ex.Message}");
                }
            }
        }

        private void LoadDanhSachLoaiTaiKhoan(string cccd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetLoaiTaiKhoanTheoCCCD", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", cccd);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboLoaiTaiKhoan.DataSource = dt;
                    cboLoaiTaiKhoan.DisplayMember = "LoaiTK";
                    cboLoaiTaiKhoan.ValueMember = "LoaiTK";

                    if (dt.Rows.Count == 0)
                    {
                        cboLoaiTaiKhoan.DataSource = null;
                        cboLoaiTaiKhoan.Items.Clear();
                        txtSTK.Text = "";
                        txtSoDu.Text = "";
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Lỗi khi tải danh sách loại tài khoản: {ex.Message}");
                }
            }
        }
    }
}