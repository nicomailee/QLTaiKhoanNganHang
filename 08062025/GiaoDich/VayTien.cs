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
    public partial class VayTien : UserControl
    {

        public VayTien()
        {
            InitializeComponent();
         
        }
        public void setDefault()
        {
            lblChuY.Visible = false;
            lblSTKNhanTien.Visible = false;
            txtSTKNhanTien.Visible=false;
            txtLaiSuat.Text = "";
            txtLaiSuatPhat.Text = "";
            txtMaPhieuVay.Text = "";
            txtSoTienTraMoiThang.Text = "";
            txtSoTienVay.Text = "";
            txtSTKNhanTien.Text = "";
            txtThoiHan.Text = "";
            cmbHinhThucNhanTien.Text = "";
            
        }
        public void TaoMaPhieuNgauNhien()
        {
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("TAO_MAPHIEUVAY", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string maMoi = reader["MaPhieuMoi"].ToString();
                        txtMaPhieuVay.Text = maMoi;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
            finally { KetNoi.Disconnect(); };

        }

        public void ThemPhieuVayTien()
        {
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("THEM_PHIEUVAYTIEN", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", GiaoDich.CCCD);
                    cmd.Parameters.AddWithValue("@MAPHIEUVAYTIEN", txtMaPhieuVay.Text);
                    cmd.Parameters.AddWithValue("@SOTIENVAY", decimal.Parse(txtSoTienVay.Text));
                    cmd.Parameters.AddWithValue("@THOIHAN", int.Parse(txtThoiHan.Text));
                    cmd.Parameters.AddWithValue("@LAISUAT", float.Parse(txtLaiSuat.Text));
                    cmd.Parameters.AddWithValue("@LAISUATPHAT", float.Parse(txtLaiSuatPhat.Text));
                    cmd.Parameters.AddWithValue("@SOTIENTRAMOITHANG", decimal.Parse(txtSoTienTraMoiThang.Text));
                    cmd.Parameters.AddWithValue("@HINHTHUCNHAN", cmbHinhThucNhanTien.Text);
                    string stk = txtSTKNhanTien.Text.Trim();
                    if (stk == "")
                        cmd.Parameters.AddWithValue("@STK", DBNull.Value); // Nếu trống, gán NULL vào SQL
                    else
                        cmd.Parameters.AddWithValue("@STK", stk);          // Nếu có giá trị, thêm vào như thường

                    cmd.Parameters.AddWithValue("@NGAYGIAODICH", GiaoDich.NgayGD.ToString());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã lưu phiếu thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
            finally { KetNoi.Disconnect(); }
        }
        private void txtThoiHan_TextChanged_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtThoiHan.Text.Trim(), out int thoihan))
            {
                if (thoihan > 24)
                {
                    MessageBox.Show("Bạn chỉ có thể vay với thời hạn dưới 24 tháng");
                }
                else
                {
                    try
                    {
                        KetNoi.Connect();
                        using (SqlCommand cmd = new SqlCommand("LAISUAT_THEOTHOIHAN", KetNoi.Conn))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@THOIHAN", int.Parse(txtThoiHan.Text));

                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                txtLaiSuat.Text = reader["LAISUAT"].ToString();
                                txtLaiSuatPhat.Text = reader["LAISUATPHAT"].ToString();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally {  KetNoi.Disconnect(); }
                }

            }
            else
            {
                txtLaiSuat.Text = "";
                txtLaiSuatPhat.Text = "";
            }
            if (decimal.TryParse(txtSoTienVay.Text.Trim(), out decimal soTienVay) &&
            int.TryParse(txtThoiHan.Text.Trim(), out int thoiHan) && thoiHan > 0)
            {
                decimal soTienTraMoiThang = soTienVay / thoiHan;
                txtSoTienTraMoiThang.Text = soTienTraMoiThang.ToString(); // Hiển thị với dấu phân cách ngàn
            }
            else
            {
                txtSoTienTraMoiThang.Text = ""; // Hoặc gán thông báo lỗi nếu cần
            }

        }

        private void VayTien_Load(object sender, EventArgs e)
        {
            setDefault();
            
        }

        private void txtSoTienVay_TextChanged(object sender, EventArgs e)
        {
            string input = txtSoTienVay.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Nếu ô trống thì không làm gì cả
                return;
            }

            if (decimal.TryParse(input, out decimal tienvay))
            {
                if (tienvay > 50000000)
                {
                    MessageBox.Show("Bạn chỉ có thể vay dưới 50 triệu");
                }
            }
            else
            {
                MessageBox.Show("Số tiền vay không hợp lệ");
            }
        }

        private void cmbHinhThucNhanTien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHinhThucNhanTien.SelectedIndex == 1)
            {
                lblChuY.Visible = true;
                lblSTKNhanTien.Visible = true;
                txtSTKNhanTien.Visible = true;
                try
                {
                    KetNoi.Connect();
                    using (SqlCommand cmd = new SqlCommand("STK_NHANTIENVAY_THANHTOANTIENVAY_GUITIENTIETKIEM", KetNoi.Conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CCCD", GiaoDich.CCCD);
                    

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            if (reader["SOTAIKHOAN"] == DBNull.Value)
                            {
                                MessageBox.Show("Bạn hãy đăng ký số tài khoản thanh toán để nhận tiền vay");

                            }
                            else
                            {
                                string stk = reader["SOTAIKHOAN"].ToString();
                                txtSTKNhanTien.Text = stk;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
                finally { KetNoi.Disconnect(); }

            }
            else
            {
                lblSTKNhanTien.Visible = false;
                txtSTKNhanTien.Visible = false;
                lblChuY.Visible = false;
            }
        }
    }
}
