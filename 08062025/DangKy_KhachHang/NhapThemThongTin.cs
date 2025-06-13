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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace _08062025.DangKy_KhachHang
{
    public partial class NhapThemThongTin : UserControl
    {
        private DangKyKhachHangorTaiKhoan formcha;
        public string HoTen = "";
        public string NgaySinh = "";
        public string GioiTinh = "";
        public string DiaChi = "";
        public string Email = "";
        public string NgheNghiep = "";
        public string MaNGT = "";
        public NhapThemThongTin(DangKyKhachHangorTaiKhoan formcha)
        {
            InitializeComponent();
            this.txtHoTen.Leave += new System.EventHandler(this.txtHoTen_Leave);
            this.formcha = formcha;
        }
        // xử lý tên
        private string ChuanHoaHoTen(string hoTen)
        {
            hoTen = hoTen.ToLower().Trim();
            string[] tu = hoTen.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tu.Length; i++)
            {
                tu[i] = char.ToUpper(tu[i][0]) + tu[i].Substring(1);
            }
            return string.Join(" ", tu);
        }
        private void txtHoTen_Leave(object sender, EventArgs e)
        {
            txtHoTen.Text = ChuanHoaHoTen(txtHoTen.Text);
        }
        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            int viTri = txtHoTen.SelectionStart;
            txtHoTen.Text = ChuanHoaHoTen(txtHoTen.Text);
            txtHoTen.SelectionStart = viTri;
        }




        private void cmbHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbXa.Items.Clear();
            string tenHuyen = cmbHuyen.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(tenHuyen)) return;

            cmbXa.Items.Clear(); // xóa dữ liệu cũ
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("LAY_XA", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TENHUYEN", tenHuyen);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            cmbXa.Items.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception EX) { MessageBox.Show(EX.Message); }
            finally { KetNoi.Disconnect(); }
        }

        


        private void cmbXa_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbHuyen.Items.Clear();
            cmbXa.Items.Clear(); // Xóa luôn xã khi tỉnh thay đổi
            string tenTinh = cmbTinh.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(tenTinh)) return;

            cmbHuyen.Items.Clear(); // xóa dữ liệu cũ
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("LAY_HUYEN", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TENTINH", tenTinh);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            cmbHuyen.Items.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { KetNoi.Disconnect(); }
        }

        private bool KiemTraTT()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }

            // Giới tính không được trống
            if (!checkBoxNam.Checked && !checkBoxNu.Checked)
            {
                MessageBox.Show("Giới tính không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Địa chỉ không để trống
            if (string.IsNullOrWhiteSpace(cmbTinh.Text))
            {
                MessageBox.Show("Tỉnh không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTinh.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbHuyen.Text))
            {
                MessageBox.Show("Huyện không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTinh.Focus();
                return false;
            }

            // Nghề nghiệp không để trống
            if (string.IsNullOrWhiteSpace(txtNgheNghiep.Text))
            {
                MessageBox.Show("Nghề nghiệp không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgheNghiep.Focus();
                return false;
            }


            // Email hợp lệ
            if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }



            // Bước 1: Lấy ngày sinh từ dtpNgaySinh
            DateTime ngaySinh = dtpNgaySinh.Value;

            // Bước 2: Kiểm tra nếu ngày sinh lớn hơn hiện tại
            if (ngaySinh > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgaySinh.Focus();
                return false;
            }

            // Bước 3: Tính tuổi
            int tuoi = DateTime.Now.Year - ngaySinh.Year;
            if (ngaySinh > DateTime.Now.AddYears(-tuoi)) tuoi--; // nếu chưa đến sinh nhật năm nay thì trừ 1

            // Bước 4: Kiểm tra điều kiện tuổi
            if (tuoi < 18)
            {
                MessageBox.Show("Người dùng phải đủ 18 tuổi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgaySinh.Focus();
                return false;
            }
            return true;
        }
            
                


        private void lblHinhDong_Click(object sender, EventArgs e)
        {

            


            HoTen = txtHoTen.Text;
            NgaySinh = dtpNgaySinh.Value.ToString("dd-MM-yyyy");
            DiaChi = cmbXa.SelectedItem?.ToString() + " - " + cmbHuyen.SelectedItem?.ToString()
                + " - " + cmbTinh.SelectedItem?.ToString();
            Email = txtEmail.Text + "@gmail.com";

            if (checkBoxNam.Checked)
                GioiTinh = "Nam";
            else if (checkBoxNu.Checked)
                GioiTinh = "Nữ";
            NgheNghiep = txtNgheNghiep.Text;
            MaNGT = txtNguoiGT.Text;

            if(KiemTraTT()==true)
                formcha.LoadUCKiemTraThongTin();




            

        }

        private void NhapThemThongTin_Load(object sender, EventArgs e)
        {
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT TenTinh FROM Huyen", KetNoi.Conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbTinh.Items.Add(reader.GetString(0));
                    }
                    reader.Close();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { KetNoi.Disconnect(); }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            formcha.LoadUCDangKyCCCD();
        }




        //
    }
}
