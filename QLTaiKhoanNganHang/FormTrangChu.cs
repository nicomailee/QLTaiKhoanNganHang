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
            panelRutTienTietKiem.Visible = false;
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

                // 1. Lấy thông tin khách hàng + STK + Số dư từ thủ tục 
                using (SqlCommand cmd = new SqlCommand("ThongTinKhachHangTheoCCCD", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", cccd);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string tenKH = reader["TenKH"].ToString();
                            string diaChi = reader["DiaChi"].ToString();
                            string sdt = reader["SDT"].ToString();
                            string stk = reader["STK"]?.ToString();     // Dùng ?. để tránh lỗi null
                            string soDu = reader["SoDu"]?.ToString();

                            // Tab phiếu rút
                            txtTenKH.Text = tenKH;
                            txtDiaChi.Text = diaChi;
                            txtSDT.Text = sdt;

                            // Tab phiếu chuyển
                            txtTenKHNG.Text = tenKH;
                            txtDiaChiNG.Text = diaChi;
                            txtSDTNG.Text = sdt;
                            txtSTK_NG.Text = stk;
                            txtSoDu_NG.Text = soDu;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy khách hàng.");
                            return;
                        }
                    }
                }

                // 2. Luôn tạo mã phiếu rút tiền
                using (SqlCommand cmd = new SqlCommand("TAO_MAPHIEURUT", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            txtMaPhieuRutTien.Text = reader["MaPhieuRutTienMoi"].ToString();
                    }
                }

                // 3. Luôn tạo mã phiếu chuyển tiền
                using (SqlCommand cmd = new SqlCommand("TAO_MAPHIEUCHUYENTIEN", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            txtMaPhieuChuyenTien.Text = reader["MaPhieuChuyenTienMoi"].ToString();
                    }
                }
            }
        }


        private void cboLoaiTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiTaiKhoan.SelectedItem == null)
                return;

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
                    txtSoDu.Text = string.Format("{0:N0}", reader["SoDu"]);

                    // 👉 Cập nhật comboBox Hình thức rút tiền theo loại tài khoản
                    cboHinhThucRutTien.Items.Clear();

                    if (loaiTK == "Tiết kiệm")
                    {
                        cboHinhThucRutTien.Items.Add("Hình thức rút");
                        cboHinhThucRutTien.Items.Add("Tiền mặt");
                        cboHinhThucRutTien.Items.Add("Tài khoản thanh toán");
                        cboHinhThucRutTien.SelectedIndex = 0;
                        cboHinhThucRutTien.Enabled = true;

                        // 👉 Nếu là tài khoản tiết kiệm thì hiển thị panel và load dữ liệu
                        panelRutTienTietKiem.Visible = true;
                        LoadPhieuGuiTietKiem(); // Hàm bạn đã viết từ trước
                    }
                    else if (loaiTK == "Thanh toán")
                    {
                        // 👉 Chỉ được rút tiền mặt, không cho chọn hình thức khác
                        cboHinhThucRutTien.Items.Add("Tiền mặt");
                        cboHinhThucRutTien.SelectedIndex = 0;
                        cboHinhThucRutTien.Enabled = false; // Không cho chọn lại

                        panelRutTienTietKiem.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản theo loại đã chọn.");
                    txtSTK.Clear();
                    txtSoDu.Clear();
                    panelRutTienTietKiem.Visible = false;
                    cboHinhThucRutTien.Items.Clear();
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
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtMaPhieuRutTien.Text) ||
                string.IsNullOrWhiteSpace(txtSTK.Text) ||
                string.IsNullOrWhiteSpace(cboLoaiTaiKhoan.Text) ||
                string.IsNullOrWhiteSpace(txtSoTienRut.Text) ||
                string.IsNullOrWhiteSpace(cboHinhThucRutTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phiếu rút tiền.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        decimal soTienRut = Convert.ToDecimal(txtSoTienRut.Text.Trim());
                        string loaiTK = cboLoaiTaiKhoan.Text.Trim();
                        string hinhThuc = cboHinhThucRutTien.Text.Trim();

                        // Ghi phiếu rút tiền – Trigger sẽ xử lý số dư tự động
                        SqlCommand insertCmd = new SqlCommand(@"
                    INSERT INTO PhieuRutTien (MaPhieuRutTien, STK, LoaiTaiKhoan, HinhThucRut, SoTienRut, NgayGiaoDich, MaNV)
                    VALUES (@MaPhieuRutTien, @STK, @LoaiTaiKhoan, @HinhThucRut, @SoTienRut, @NgayGiaoDich, @MaNV)", conn, transaction);
                        insertCmd.Parameters.AddWithValue("@MaPhieuRutTien", txtMaPhieuRutTien.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@STK", txtSTK.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@LoaiTaiKhoan", loaiTK);
                        insertCmd.Parameters.AddWithValue("@HinhThucRut", hinhThuc);
                        insertCmd.Parameters.AddWithValue("@SoTienRut", soTienRut);
                        insertCmd.Parameters.AddWithValue("@NgayGiaoDich", DateTime.Now);
                        insertCmd.Parameters.AddWithValue("@MaNV", FormDangNhap.MaNV_DangNhap);
                        int rowsInsert = insertCmd.ExecuteNonQuery();

                        int rowsUpdate = 1;
                        // Cập nhật trạng thái PGT nếu là tiết kiệm
                        if (loaiTK == "Tiết kiệm")
                        {
                            SqlCommand updatePGT = new SqlCommand(@"
                        UPDATE PhieuGuiTien
                        SET TrangThaiPGT = N'Đã tất toán'
                        WHERE MaPhieuGuiTien = @MaPGT", conn, transaction);
                            updatePGT.Parameters.AddWithValue("@MaPGT", txtMaPGT.Text.Trim());
                            rowsUpdate = updatePGT.ExecuteNonQuery();
                        }

                        if (rowsInsert > 0 && rowsUpdate > 0)
                        {
                            transaction.Commit();
                            MessageBox.Show("Rút tiền thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            XoaTextBox();
                        }
                        else
                        {
                            transaction.Rollback();
                            MessageBox.Show("Lưu phiếu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi xử lý giao dịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadPhieuGuiTietKiem()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=QUAN LI TAI KHOAN NGAN HANG;Integrated Security=True";
            string cccd = txtCCCD.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("LayDanhSachPhieuGuiTien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", cccd); // Truyền CCCD vào thủ tục

                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    dgvPhieuRutTienTietKiem.DataSource = dt;

                    dgvPhieuRutTienTietKiem.EnableHeadersVisualStyles = false;
                    dgvPhieuRutTienTietKiem.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    dgvPhieuRutTienTietKiem.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

                    foreach (DataGridViewRow row in dgvPhieuRutTienTietKiem.Rows)
                    {
                        if (row.Cells["TrangThaiPGT"].Value != null)
                        {
                            string trangThai = row.Cells["TrangThaiPGT"].Value.ToString();

                            if (trangThai == "Đã đến hạn" || trangThai == "Đã tất toán")
                            {
                                row.Cells["TrangThaiPGT"].Style.ForeColor = Color.Red;
                            }
                            else if (trangThai == "Chưa đến hạn" || trangThai == "Chưa tất toán")
                            {
                                row.Cells["TrangThaiPGT"].Style.ForeColor = Color.Green;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void dgvPhieuRutTienTietKiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvPhieuRutTienTietKiem.Rows[e.RowIndex];

            string trangThai = row.Cells["TrangThaiPGT"].Value?.ToString().Trim();

            // Nếu đã tất toán
            if (trangThai == "Đã tất toán")
            {
                MessageBox.Show("Phiếu này đã tất toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Xóa nội dung các TextBox
                txtMaPGT.Clear();
                txtSoTienGui.Clear();
                txtNgayGuiTien.Clear();
                txtThoiHan.Clear();
                txtLaiSuat.Clear();
                txtNgayDenHan.Clear();
                txtTrangThaiPGT.Clear();
                txtSoTienDuKienCuoiKy.Clear();
                txtSoTienRut.Clear();
                return;
            }

            // Hiển thị dữ liệu
            txtMaPGT.Text = row.Cells["MaPhieuGuiTien"].Value?.ToString();
            txtSoTienGui.Text = row.Cells["SoTienGui"].Value?.ToString();
            txtNgayGuiTien.Text = Convert.ToDateTime(row.Cells["NgayGiaoDich"].Value).ToString("dd/MM/yyyy");
            txtThoiHan.Text = row.Cells["ThoiHan"].Value?.ToString();
            txtLaiSuat.Text = row.Cells["LaiSuat"].Value?.ToString();
            txtNgayDenHan.Text = Convert.ToDateTime(row.Cells["NgayDenHan"].Value).ToString("dd/MM/yyyy");
            txtTrangThaiPGT.Text = trangThai;

            // Tính số tiền dự kiến cuối kỳ
            decimal soTienGui = Convert.ToDecimal(row.Cells["SoTienGui"].Value);
            float laiSuat = Convert.ToSingle(row.Cells["LaiSuat"].Value) / 100;
            int kyHan = Convert.ToInt32(row.Cells["ThoiHan"].Value);

            decimal soTienDuKien = soTienGui + (soTienGui * (decimal)laiSuat * kyHan);
            txtSoTienDuKienCuoiKy.Text = soTienDuKien.ToString("N0");

            // Kiểm tra ngày đáo hạn
            DateTime ngayDenHan = Convert.ToDateTime(row.Cells["NgayDenHan"].Value);
            DateTime ngayHienTai = DateTime.Now.Date;

            // So sánh và gán số tiền rút
            if (ngayHienTai >= ngayDenHan)
            {
                MessageBox.Show("Bạn được rút đúng số tiền dự kiến cuối kỳ: " + soTienDuKien.ToString("N0"),
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoTienRut.Text = soTienDuKien.ToString("N0");
            }
            else
            {
                MessageBox.Show("Chưa đến hạn, bạn chỉ được rút số tiền gốc: " + soTienGui.ToString("N0"),
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTienRut.Text = soTienGui.ToString("N0");
            }
        }
        private void XoaTextBox()
        {
            txtMaPhieuRutTien.Clear();
            txtSTK.Clear();
            cboLoaiTaiKhoan.Text = "-- Chọn loại tài khoản --";  // Thay vì SelectedIndex = -1
            cboHinhThucRutTien.Text = "-- Chọn hình thức rút --";    // Giả sử bạn có ComboBox này
            txtSoTienRut.Clear();
            txtMaPGT.Clear();
            txtSoTienGui.Clear();
            txtNgayGuiTien.Clear();
            txtThoiHan.Clear();
            txtLaiSuat.Clear();
            txtNgayDenHan.Clear();
            txtTrangThaiPGT.Clear();
            txtSoTienDuKienCuoiKy.Clear();
        }

        private void cboNganHangNN_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nganHang = cboNganHangNN.SelectedItem.ToString();

            if (nganHang == "3CE")
            {
                txtPhiChuyenTien.Text = "0";
            }
            else
            {
                txtPhiChuyenTien.Text = "10000";
            }
        }

        private void txtSoTienChuyen_TextChanged(object sender, EventArgs e)
        {
            // Xóa định dạng cũ (nếu có dấu phẩy), sau đó kiểm tra
            if (decimal.TryParse(txtSoTienChuyen.Text.Replace(",", ""), out decimal soTienChuyen) &&
                decimal.TryParse(txtPhiChuyenTien.Text.Replace(",", ""), out decimal phiChuyen) &&
                decimal.TryParse(txtSoDu_NG.Text.Replace(",", ""), out decimal soDuNGHienTai))
            {
                decimal tongTru = soTienChuyen + phiChuyen;
                if (soTienChuyen <= 0)
                {
                    MessageBox.Show("Số tiền chuyển phải lớn hơn 0.");
                    txtSoDuSauKhiRut.Clear();
                    return;
                }

                if (tongTru > soDuNGHienTai)
                {
                    MessageBox.Show("Số dư không đủ để chuyển tiền.");
                    txtSoDuSauKhiRut.Clear();
                }
                else
                {
                    decimal soDuSauChuyen = soDuNGHienTai - tongTru;
                    txtSoDuSauChuyen.Text = string.Format("{0:N0}", soDuSauChuyen);
                    txtNoiDungChuyenTien.Text = $"Chuyển {soTienChuyen:N0} VND tới {txtSTK_NN.Text}";
                }
            }
            else
            {
                txtSoDuSauChuyen.Clear();
            }
        }
        private void btn_ChuyenTien_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtSoTienChuyen.Text, out decimal soTienChuyen) ||
                !decimal.TryParse(txtPhiChuyenTien.Text, out decimal phiChuyen) ||
                !decimal.TryParse(txtSoDu_NG.Text, out decimal soDuNGHienTai))
            {
                MessageBox.Show("Vui lòng nhập đúng số tiền và phí.");
                return;
            }

            decimal tongTru = soTienChuyen + phiChuyen;

            if (tongTru > soDuNGHienTai)
            {
                MessageBox.Show("Số dư không đủ để chuyển tiền.");
                return;
            }

            string maPhieu = txtMaPhieuChuyenTien.Text.Trim();
            string stkNguoiGui = txtSTK.Text.Trim();
            string stkNguoiNhan = txtSTK_NN.Text.Trim();
            string noiDung = txtNoiDungChuyenTien.Text.Trim();
            DateTime ngayChuyen = DateTime.Now;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // 1. Lưu phiếu chuyển tiền
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO PHIEUCHUYENTIEN(MaPhieuChuyenTien, STK, STKNguoiNhan, SoTienChuyen, PhiChuyenTien, NgayChuyenTien, NoiDungCT) " +
                                                                               "VALUES (@MaPhieu, @STKGui, @STKNhan, @SoTien, @Phi, @Ngay, @NoiDung)", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                        cmd.Parameters.AddWithValue("@STKGui", stkNguoiGui);
                        cmd.Parameters.AddWithValue("@STKNhan", stkNguoiNhan);
                        cmd.Parameters.AddWithValue("@SoTien", soTienChuyen);
                        cmd.Parameters.AddWithValue("@Phi", phiChuyen);
                        cmd.Parameters.AddWithValue("@Ngay", ngayChuyen);
                        cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Trừ tiền người gửi
                    using (SqlCommand cmd = new SqlCommand("UPDATE TAIKHOAN SET SoDu = SoDu - @TongTru WHERE STK = @STKGui", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@TongTru", tongTru);
                        cmd.Parameters.AddWithValue("@STKGui", stkNguoiGui);
                        cmd.ExecuteNonQuery();
                    }

                    // 3. Cộng tiền người nhận (nếu cùng ngân hàng)
                    if (!string.IsNullOrEmpty(stkNguoiNhan))
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE TAIKHOAN SET SoDu = SoDu + @SoTien WHERE STK = @STKNhan", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@SoTien", soTienChuyen);
                            cmd.Parameters.AddWithValue("@STKNhan", stkNguoiNhan);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    MessageBox.Show("Chuyển tiền thành công.");

                    // Cập nhật lại số dư
                    txtSoDu_NG.Text = (soDuNGHienTai - tongTru).ToString("N0");
                    txtSoDuSauChuyen.Text = txtSoDu_NG.Text;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi khi chuyển tiền: " + ex.Message);
                }
            }
        }
    }
}  
