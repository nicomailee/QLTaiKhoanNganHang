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
    public partial class GiaoDich : UserControl
    {
        public static string PhieuHienTai = "";
        private VayTien vayTienControl;
        private ThanhToanTienVay thanhToanTienVayControl;
        private GuiTien guiTienConTrol;
        public static string CCCD = "";
        public static DateTime NgayGD = DateTime.Today;
        public GiaoDich()
        {
            InitializeComponent();
            VayTien vaytien = new VayTien(); // Tạo UC
            this.Controls.Add(vaytien);
        }




        private void GiaoDich_Load(object sender, EventArgs e)
        {
            setDeFault();
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelDienPhieu.Controls.Clear();
            panelDienPhieu.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void btnVayTien_Click(object sender, EventArgs e)
        {
            setDeFault();
            PhieuHienTai = "Vay tiền";
            vayTienControl = new VayTien(); // Gán vào biến toàn cục
            addUserControl(vayTienControl);
        }
        private void btnPhieuGuiTienTK_Click(object sender, EventArgs e)
        {

            setDeFault();
            PhieuHienTai = "Gửi tiền";
            guiTienConTrol = new GuiTien(); // Gán vào biến toàn cục
            addUserControl(guiTienConTrol);
        }
        public void layTTTuCCCD()
        {
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("LAYTTKH_THEOCCCD", KetNoi.Conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", txtNhapCCCD.Text);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtCCCD.Text = txtNhapCCCD.Text;

                        txtHoten.Text = reader["TenKH"].ToString();
                        txtSDT.Text = reader["SDT"].ToString();
                        txtDiaChi.Text = reader["DiaChi"].ToString();



                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng với CCCD này.");
                    }
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:  " + ex.Message);
            }
            finally { KetNoi.Disconnect(); }
        }
        public void setDeFault()                        // default cho các trường hợp phiếu trừ phiếu vay tiền
        {

            btnTatToan.Visible = false;
            panelTaoThoat.Show();
            panelKiemTraPhieu.Hide();
        }
        public void setDeFault_1()              // default cho tất cả sau khi reset
        {
            txtCCCD.Text = "";
            txtDiaChi.Text = "";
            txtHoten.Text = "";
            txtSDT.Text = "";
            txtSoDu.Text = "";
            cmbLoaiTK.Text = "";
            txtSTK.Text = "";
            btnTatToan.Visible = false;
        }
        private void btnTao_Click(object sender, EventArgs e)
        {
            panelTaoThoat.Hide();
            panelKiemTraPhieu.Show();


        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (PhieuHienTai == "Vay tiền")
            {
                vayTienControl.ThemPhieuVayTien();
                setDeFault_1();
                vayTienControl.setDefault();
            }
            if (PhieuHienTai == "Gửi tiền")
            {
                guiTienConTrol.ThemPhieuGuiTien();
                setDeFault_1();
                guiTienConTrol.setDeFault();
            }
               
        }

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            panelKiemTraPhieu.Hide();
        }
        public int kiemtraCCCD()
        {
            int KQ = 0;
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("KTRA_CCCD", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", txtNhapCCCD.Text);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            KQ = Convert.ToInt32(reader["KetQua"]);
                        }
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { KetNoi.Disconnect(); }
            return KQ;
        }
        private void btnXacMinhCCCD_Click(object sender, EventArgs e)
        {

            if (PhieuHienTai == "Vay tiền")
            {
                if (kiemtraCCCD() == 1)
                {
                    try
                    {
                        KetNoi.Connect();
                        using (SqlCommand cmd = new SqlCommand("KIEMTRA_CHOVAY", KetNoi.Conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@CCCD", txtNhapCCCD.Text);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int ketQua = Convert.ToInt32(reader["KETQUA"]);
                                    if (ketQua == 0)
                                    {
                                        CCCD = txtNhapCCCD.Text;
                                        layTTTuCCCD();
                                        if (!string.IsNullOrWhiteSpace(txtCCCD.Text))
                                        {

                                            vayTienControl.TaoMaPhieuNgauNhien();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Hãy thanh toán phiếu vay cũ trước khi tạo khi vay mới");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Không có kết quả trả về từ thủ tục KIEMTRA_CHOVAY");
                                }
                            }
                        }
                        }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                        
                    }
                    finally
                    {
                        KetNoi.Disconnect();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy CCCD của khách hàng này");
                }
            }



            if (PhieuHienTai == "Thanh toán tiền vay")
            {
                CCCD = txtNhapCCCD.Text;
                layTTTuCCCD();
                thanhToanTienVayControl.LayMaPhieuVay();
            }
            if (PhieuHienTai == "Gửi tiền")
            {
                CCCD = txtNhapCCCD.Text;
                layTTTuCCCD();
                guiTienConTrol.TaoMaPhieuNgauNhien();
                guiTienConTrol.LaySTK_TietKiem();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            setDeFault_1();
            panelDienPhieu.Controls.Clear();
        }

        private void btnThanhToanTienVay_Click(object sender, EventArgs e)
        {
            btnTao.Hide();
            btnTatToan.Show();
            panelKiemTraPhieu.Hide();
            PhieuHienTai = "Thanh toán tiền vay";
            thanhToanTienVayControl = new ThanhToanTienVay(); // Gán vào biến toàn cục
            addUserControl(thanhToanTienVayControl);
            btnTatToan.Visible = true;

        }

        private void btnTatToan_Click(object sender, EventArgs e)
        {
           
            thanhToanTienVayControl.CapNhatPhieuThanhToan();
        }

        private void dtpNgayGD_ValueChanged(object sender, EventArgs e)
        {
            NgayGD = dtpNgayGD.Value;

        }

        private void lblHayChonPhieu_Click(object sender, EventArgs e)
        {

        }

        private void panelGiaoDich_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNhapCCCD_TextChanged(object sender, EventArgs e)
        {
            setDeFault_1();
            if (PhieuHienTai == "Vay tiền") vayTienControl.setDefault();
            if (PhieuHienTai == "Thanh toán tiền vay")
            {
                btnTatToan.Show();
                thanhToanTienVayControl.setDefault();
            }
            if (PhieuHienTai == "Gửi tiền") guiTienConTrol.setDeFault();
        }

        private void cmbLoaiTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                KetNoi.Connect();
                using (SqlCommand cmd = new SqlCommand("LAYSTK_THEOCCCD_LOAITAIKHOAN", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", txtNhapCCCD.Text);
                    if (cmbLoaiTK.Text != "")
                    {
                        cmd.Parameters.AddWithValue("@LOAITK", cmbLoaiTK.Text);
                    }
                    else cmd.Parameters.AddWithValue("@LOAITK", DBNull.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtSTK.Text = reader["STK"].ToString();
                            txtSoDu.Text = reader["SoDu"].ToString();
                        }
                        else
                        {
                            txtSTK.Text = "";
                            txtSoDu.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally { KetNoi.Disconnect(); }


        }
    }
}
