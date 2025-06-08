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
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using DocumentFormat.OpenXml.Office2010.Drawing;

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

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            lbKiemTra.Visible = false;
            btnTiepTuc.Enabled = false;
        }

        private void btnXacMinhCCCD_Click(object sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();
            if (string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Vui lòng nhập CCCD.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Gọi thủ tục lấy thông tin khách hàng
                using (SqlCommand cmd = new SqlCommand("ThongTinKhachHangTheoCCCD", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", cccd);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtTenKH.Text = reader["TenKH"].ToString();
                            txtDiaChi.Text = reader["DiaChi"].ToString();
                            txtSDT.Text = reader["SDT"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy khách hàng.");
                            txtTenKH.Clear(); txtDiaChi.Clear(); txtSDT.Clear();
                            return;
                        }
                    }
                }

                // 2. Gọi thủ tục tạo mã phiếu rút tiền
                using (SqlCommand cmdMaPhieu = new SqlCommand("TAO_MAPHIEURUT", conn))
                {
                    cmdMaPhieu.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmdMaPhieu.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtMaPhieuRutTien.Text = reader["MaPhieuRutTienMoi"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không thể tạo mã phiếu rút tiền.");
                        }
                    }
                }
            }

        }

        private void cboLoaiTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loaiTK = cboLoaiTaiKhoan.SelectedItem.ToString();
            string cccd = txtCCCD.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("TimTaiKhoanTheoLoaiTKVaCCCD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CCCD", cccd);
                cmd.Parameters.AddWithValue("@LoaiTK", loaiTK);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtSTK.Text = reader["STK"].ToString();
                    txtSoDu.Text = string.Format("{0:N0}", reader["SoDu"]); // Hiển thị định dạng tiền
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản theo loại đã chọn.");
                    txtSTK.Clear();
                    txtSoDu.Clear();
                }
                conn.Close();
            }
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            // Kiểm tra các textbox cần thiết đã nhập chưa
            if (string.IsNullOrWhiteSpace(txtTenKH.Text) ||
                string.IsNullOrWhiteSpace(txtSTK.Text) ||
                string.IsNullOrWhiteSpace(txtSoTienRut.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi tạo phiếu.");
                return;
            }

            lbKiemTra.Text = "✅ Vui lòng kiểm tra thông tin trước khi xuất phiếu!";
            lbKiemTra.Visible = true;
            btnTiepTuc.Enabled = true;
        }

        private void txtSoTienRut_TextChanged(object sender, EventArgs e)
        {
            // Đảm bảo chỉ xử lý khi nhập số
            if (decimal.TryParse(txtSoTienRut.Text.Trim(), out decimal soTienRut) &&
                decimal.TryParse(txtSoDu.Text.Trim().Replace(",", ""), out decimal soDuHienTai))
            {
                if (soTienRut <= 0)
                {
                    MessageBox.Show("Số tiền rút phải lớn hơn 0.");
                    txtSoDuSauKhiRut.Clear();
                    return;
                }

                if (soTienRut > soDuHienTai)
                {
                    MessageBox.Show("Số dư không đủ để rút.");
                    txtSoDuSauKhiRut.Clear();
                }
                else
                {
                    decimal soDuSauKhiRut = soDuHienTai - soTienRut;
                    txtSoDuSauKhiRut.Text = string.Format("{0:N0}", soDuSauKhiRut);
                }
            }
            else
            {
                txtSoDuSauKhiRut.Clear();
            }
        }        

        private void btnXuatPhieuRutTien_Click(object sender, EventArgs e)
        {
           
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            lbKiemTra.Visible = false;
            txtTenKH.ReadOnly = false;
            txtSTK.ReadOnly = false;
            txtSoTienRut.ReadOnly = false;
            txtSoDuSauKhiRut.ReadOnly = false;

            MessageBox.Show("Bạn có thể chỉnh sửa lại phiếu.");
        }
        private void btnLuuPhieuRutTien_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieuRutTien.Text) ||
                string.IsNullOrWhiteSpace(txtSTK.Text) ||
                string.IsNullOrWhiteSpace(cboLoaiTaiKhoan.Text) ||
                string.IsNullOrWhiteSpace(txtSoTienRut.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phiếu rút tiền.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Chỉ INSERT phiếu rút tiền thôi, trigger sẽ tự động cập nhật số dư
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO PHIEURUTTIEN
                (MaPhieuRutTien, STK, LoaiTaiKhoan, SoTienRut, NgayGiaoDich, MaNV)
                VALUES (@MaPhieuRutTien, @STK, @LoaiTaiKhoan, @SoTienRut, @NgayGiaoDich, @MaNV)", conn);

                    cmd.Parameters.AddWithValue("@MaPhieuRutTien", txtMaPhieuRutTien.Text.Trim());
                    cmd.Parameters.AddWithValue("@STK", txtSTK.Text.Trim());
                    cmd.Parameters.AddWithValue("@LoaiTaiKhoan", cboLoaiTaiKhoan.Text.Trim());
                    cmd.Parameters.AddWithValue("@SoTienRut", Convert.ToDecimal(txtSoTienRut.Text.Trim()));
                    cmd.Parameters.AddWithValue("@NgayGiaoDich", DateTime.Now);
                    cmd.Parameters.AddWithValue("@MaNV", FormDangNhap.MaNV_DangNhap);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Lưu phiếu rút tiền thành công và số dư đã được cập nhật tự động!");
                    }
                    else
                    {
                        MessageBox.Show("Lưu phiếu thất bại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu phiếu rút tiền: " + ex.Message);
                }
            }
        }


    }
}