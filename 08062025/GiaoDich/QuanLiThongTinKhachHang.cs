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

namespace _08062025.GiaoDich
{
    public partial class QuanLiThongTinKhachHang : UserControl
    {
        public QuanLiThongTinKhachHang()
        {
            InitializeComponent();
           
        }
        private void LamDamDongVuaSua(int i, string s)
        {

            foreach (DataGridViewRow row in dgvKHACHHANG.Rows)
            {
                if (i == 0)
                {
                    if (row.Cells["MaKH"].Value != null && row.Cells["MaKH"].Value.ToString() == s)
                    {
                        row.DefaultCellStyle.Font = new Font(dgvKHACHHANG.Font, FontStyle.Bold);
                        row.DefaultCellStyle.ForeColor = Color.Blue; // Tùy ý
                        row.DefaultCellStyle.BackColor = Color.LightYellow; // Tùy ý
                        break;
                    }
                }
                else if (i == 1)
                {
                    if (row.Cells["CCCD"].Value != null && row.Cells["CCCD"].Value.ToString() == s)
                    {
                        row.DefaultCellStyle.Font = new Font(dgvKHACHHANG.Font, FontStyle.Bold);
                        row.DefaultCellStyle.ForeColor = Color.Blue; // Tùy ý
                        row.DefaultCellStyle.BackColor = Color.LightYellow; // Tùy ý
                        break;
                    }
                }

            }
        }
        void LayDSKH()
        {
            try
            {
                KetNoi.Connect(); // Mở kết nối

                string query = "SELECT * FROM KHACHHANG";
                SqlDataAdapter da = new SqlDataAdapter(query, KetNoi.Conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKHACHHANG.DataSource = dt;

                dgvKHACHHANG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                // Đặt độ rộng cụ thể cho từng cột theo tên
                dgvKHACHHANG.Columns[0].Width = 60;
                dgvKHACHHANG.Columns[1].Width = 130;
                dgvKHACHHANG.Columns[2].Width = 40;
                dgvKHACHHANG.Columns[3].Width = 70;
                dgvKHACHHANG.Columns[4].Width = 180;
                dgvKHACHHANG.Columns[5].Width = 100;
                dgvKHACHHANG.Columns[6].Width = 100;
                dgvKHACHHANG.Columns[7].Width = 130;
                dgvKHACHHANG.Columns[8].Width = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không mở được file" + ex.Message);
            }
            finally { KetNoi.Disconnect(); }

        }
        void LayDSTK()
        {
            try
            {

                KetNoi.Connect();
                string query = "SELECT LoaiTK, STK, SoDu, NgayDangKy, HoTenNV FROM TAIKHOAN JOIN NHANVIEN ON TAIKHOAN.MaNV = NHANVIEN.MaNV";
                SqlDataAdapter da = new SqlDataAdapter(query, KetNoi.Conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSTK.DataSource = dt;

                dgvSTK.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                // Đặt độ rộng cụ thể cho từng cột theo tên
                dgvSTK.Columns[0].Width = 200;
                dgvSTK.Columns[1].Width = 200;
                dgvSTK.Columns[2].Width = 200;
                dgvSTK.Columns[3].Width = 200;
                dgvSTK.Columns[4].Width = 200;
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không mở được file" + ex.Message);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("SUA_KH", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MAKH", txtMaKH.Text);
                    cmd.Parameters.AddWithValue("@GIOITINH", cmbGioiTinh.Text);
                    cmd.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@NGHENGHIEP", txtNgheNghiep.Text);
                    cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@TENKH", txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@NGAYSINH", Convert.ToDateTime(dtpNgaySinh.Value));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LayDSKH();
                    LamDamDongVuaSua(0, txtMaKH.Text);
                    setDeFault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không sửa được: " + ex.Message);
            }
            finally { KetNoi.Disconnect(); }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            setDeFault();
            LayDSKH();
            LayDSTK();
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {

            if (txtCCCD.Text == "")
            {
                MessageBox.Show("Hãy điền CCCD", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCCCD.Focus(); // Đưa trỏ chuột về ô CCCD
                return; // Ngăn xử lý tiếp tục nếu CCCD trống
            }
            else
            {
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
                            MessageBox.Show("Tìm kiếm CCCD thành công", "Thông báo", MessageBoxButtons.OK);
                            LamDamDongVuaSua(1, txtCCCD.Text);
                        }
                        else if (ketQua == 0)
                        {
                            MessageBox.Show("Không tìm thấy CCCD", "Thông báo", MessageBoxButtons.OK);
                            LamDamDongVuaSua(1, txtCCCD.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally {KetNoi.Disconnect(); } 
            }
        }



        private void QuanLiThongTinKhachHang_Load(object sender, EventArgs e)
        {
            LayDSKH();
            LayDSTK();

        }
        public void setDeFault()
        {
            txtCCCD.Text = "";
            txtDiaChi.Text = "";
            txtHoTen.Text = "";
            txtMaKH.Text = "";
            txtNgheNghiep.Text = "";
            txtNVDK1.Text = "";
            txtSDT.Text = "";
            txtSodu1.Text = "";
            txtSTK1.Text = "";
            cmbGioiTinh.Text = "";
            cmbLoaiTK1.Text = "";
        }
        public void LayTaiKhoanKH(string maKH)
        {
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("LAY_TAIKHOAN", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MAKH", maKH);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvSTK.DataSource = dt; // Gán dữ liệu vào DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không mở được file" + ex.Message);
            }
        }




        private void dgvKHACHHANG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKHACHHANG.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                cmbGioiTinh.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value != DBNull.Value && row.Cells[3].Value != null)
                {
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells[3].Value);
                }
                else
                {
                    dtpNgaySinh.Value = DateTime.Today; // hoặc gán giá trị mặc định
                }
                txtDiaChi.Text = row.Cells[4].Value.ToString();
                txtNgheNghiep.Text = row.Cells[5].Value.ToString();
                txtCCCD.Text = row.Cells[6].Value.ToString();
                txtSDT.Text = row.Cells[8].Value.ToString();
                LayTaiKhoanKH(txtMaKH.Text);
            }
        }

        private void dgvSTK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSTK.Rows[e.RowIndex];
                cmbLoaiTK1.Text = row.Cells[0].Value.ToString();
                txtSTK1.Text = row.Cells[1].Value.ToString();
                txtSodu1.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value != DBNull.Value && row.Cells[3].Value != null)
                {
                    dtpDK1.Value = Convert.ToDateTime(row.Cells[3].Value);
                }
                else
                {
                    dtpDK1.Value = DateTime.Today; // hoặc gán giá trị mặc định
                }
                txtNVDK1.Text = row.Cells[4].Value.ToString();
                txtNVDK1.ReadOnly = true;
                txtSodu1.ReadOnly = true;
                txtSTK1.ReadOnly = true;
                cmbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        int kiemtra_xoa()
        {
            int ketQua1 = 0;
            int ketQua2 = 0;
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("KIEMTRA_CHOVAY", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ketQua1 = Convert.ToInt32(reader["KETQUA"]);
                        }
                        else
                        {
                            MessageBox.Show("Không có kết quả trả về từ thủ tục KIEMTRA_CHOVAY");
                        }
                    }
                }

                using (SqlCommand cmd = new SqlCommand("LAY_TAIKHOAN", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MAKH", txtMaKH.Text);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string sodu = reader["SoDu"].ToString();
                            if (sodu != "") ketQua2 = 2;
                        }
                        else
                        {
                            MessageBox.Show("Không có kết quả trả về từ thủ tục LAY_TAIKHOAN");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { KetNoi.Disconnect(); }
            return ketQua1 + ketQua2;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (kiemtra_xoa() == 1)
            {
                MessageBox.Show("Hãy thanh toán khoản vay trước khi xoá khách hàng");
                setDeFault();
            }
            else if (kiemtra_xoa() == 2)
            {
                MessageBox.Show("Hãy rút tiền trước khi xoá khách hàng");
                setDeFault();
            }
            else if (kiemtra_xoa() == 3)
            {
                MessageBox.Show("Hãy thanh toán khoản vay và rút tiền trước khi xoá khách hàng");
                setDeFault();
            }
            else
            {
                try
                {
                    KetNoi.Connect();
                    using (SqlCommand cmd = new SqlCommand("XOA_KH", KetNoi.Conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MAKH", txtMaKH.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setDeFault();
                    }
                }
               
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi không xoá được: " + ex.Message);
                }
                finally { KetNoi.Disconnect(); }
            }
        }

        private void btnGiaoDich_Click(object sender, EventArgs e)
        {

        }


    }
}
