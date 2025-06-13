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
    public partial class GuiTien : UserControl
    {
        public GuiTien()
        {
            InitializeComponent();
        }
        public void TaoMaPhieuNgauNhien()
        {
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("TAO_MAPHIEUGUITIEN", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string maMoi = reader["MaPhieuMoi"].ToString();
                        txtMaPhieuGui.Text = maMoi;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
            finally { KetNoi.Disconnect(); }

        }
        public void setDeFault()
        {
            txtLaiSuat.Text = ""; 
            txtMaPhieuGui.Text = "";
            txtSoTienDuKien.Text = "";
            txtSoTienGui.Text = "";
            txtSTKTietKiem.Text = "";
            txtThoiHan.Text = "";
            lblChuY2.Visible = false;
            lblSTKTT.Visible = false;
            txtSTKGuiTien.Visible = false;
            lblSoDu.Visible = false;
            txtSoDu.Visible = false;
        }
        public void LaySTK_TietKiem()
        {
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("STK_TIETKIEM", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", GiaoDich.CCCD);


                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader["SOTAIKHOAN"] == DBNull.Value)
                        {
                            MessageBox.Show("Bạn hãy đăng ký số tài khoản tiết kiệm");
                            setDeFault();

                        }
                        else
                        {
                            string stk = reader["SOTAIKHOAN"].ToString();
                            txtSTKTietKiem.Text = stk;
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
        
        private void GuiTien_Load(object sender, EventArgs e)
        {

        }

        private void txtSoTienGui_TextChanged(object sender, EventArgs e)
        {
            string input = txtSoTienGui.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Nếu ô trống thì không làm gì cả
                return;
            }

            if (decimal.TryParse(input, out decimal tiengui))
            {
                if (tiengui > 50000000)
                {
                    MessageBox.Show("Bạn chỉ có thể gửi dưới 50 triệu");
                }
            }
            else
            {
                MessageBox.Show("Số tiền gửi không hợp lệ");
            }
        }
        public void ThemPhieuGuiTien()
        {
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("THEM_PHIEUGUITIEN", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", GiaoDich.CCCD);
                    cmd.Parameters.AddWithValue("@MAPHIEUGUITIEN", txtMaPhieuGui.Text);
                    cmd.Parameters.AddWithValue("@SOTIENGUI", decimal.Parse(txtSoTienGui.Text));
                    cmd.Parameters.AddWithValue("@THOIHAN", int.Parse(txtThoiHan.Text));
                    cmd.Parameters.AddWithValue("@LAISUAT", float.Parse(txtLaiSuat.Text));
                    cmd.Parameters.AddWithValue("@SOTIENCUOIKY", decimal.Parse(txtSoTienDuKien.Text));
                    cmd.Parameters.AddWithValue("@STK", txtSTKTietKiem.Text);

                    cmd.Parameters.AddWithValue("@NGAYGIAODICH", GiaoDich.NgayGD.ToString());
                    cmd.Parameters.AddWithValue("@NGAYDENHAN", dtpNgayDenHan.Value.ToString());
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

        private void txtThoiHan_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtThoiHan.Text.Trim(), out int thoihan))
            {
                if (thoihan > 24)
                {
                    MessageBox.Show("Bạn chỉ có thể gửi tiền với thời hạn dưới 24 tháng");
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
                            }
                            dtpNgayDenHan.Value = GiaoDich.NgayGD.AddMonths(int.Parse(txtThoiHan.Text));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { KetNoi.Disconnect(); }
                }

            }
            else
            {
                txtLaiSuat.Text = "";
            }
            if (decimal.TryParse(txtSoTienGui.Text.Trim(), out decimal soTienGui) &&
            int.TryParse(txtThoiHan.Text.Trim(), out int thoiHan) && thoiHan > 0 && float.TryParse(txtLaiSuat.Text.Trim(), out float laisuat) && laisuat > 0)
            {
                decimal soTienCuoiKy = soTienGui + soTienGui * thoihan * (decimal)laisuat/100;
                txtSoTienDuKien.Text = soTienCuoiKy.ToString();
            }
            else
            {
                txtSoTienDuKien.Text = txtSoTienGui.Text;
            }
        }

        private void cmbHinhThucNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHinhThucGui.SelectedIndex == 1)
            {

                lblChuY2.Visible = true;
                lblSTKTT.Visible = true;
                txtSTKGuiTien.Visible = true;
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
                                MessageBox.Show("Không có tài khoản thanh toán để gửi tiền");
                                txtSTKGuiTien.Text = "";
                            }
                            else
                            {
                                string stk = reader["SOTAIKHOAN"].ToString();
                                txtSTKGuiTien.Text = stk;

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
                finally { KetNoi.Disconnect(); }
                if (txtSTKGuiTien.Text != "")
                {
                    try
                    {
                        KetNoi.Connect();
                        using (SqlCommand cmd = new SqlCommand("LAYSTK_KIEMTRASODUDEGUITIEN", KetNoi.Conn))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@SOTIENGUI", decimal.Parse(txtSoTienGui.Text));
                            cmd.Parameters.AddWithValue("@STK", decimal.Parse(txtSTKGuiTien.Text));
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                string ktra = reader["KIEMTRASODU"].ToString();
                                if (ktra == "1")
                                {
                                    MessageBox.Show("Tài khoản không đủ số dư để gửi tiền vào");

                                }
                                else
                                {
                                    txtSTKGuiTien.Text = reader["SOTAIKHOANGUITIEN"].ToString();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
            else
            {
                lblSoDu.Visible = false;
                txtSoDu.Visible = false;
                lblSTKTT.Visible = false;
                txtSTKGuiTien.Visible = false;
                lblChuY2.Visible = false;
            }
        }
    }
}
