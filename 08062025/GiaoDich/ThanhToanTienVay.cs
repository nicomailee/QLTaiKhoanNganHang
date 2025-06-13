using System;
using System.Collections;
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
    public partial class ThanhToanTienVay : UserControl
    {
        public ThanhToanTienVay()
        {
            InitializeComponent();
        }
        public void HienThiDanhSachPhieuThanhToan()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DS_PHIEUTHANHTOAN", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", GiaoDich.CCCD);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPhieuTT.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
            finally { KetNoi.Disconnect(); }
        }

        public void CapNhatPhieuThanhToan()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("CAPNHAT_THANHTOANTIENVAY", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PHIEUTTTIENVAY", txtMaPhieuTT.Text);
                    cmd.Parameters.AddWithValue("@NGAYTRA", dtpNgayTra.Value.ToString());
                    if (txtTienPhat.Text == "")
                        cmd.Parameters.AddWithValue("@TIENPHAT", DBNull.Value);
                    else cmd.Parameters.AddWithValue("@TIENPHAT", decimal.Parse(txtTienPhat.Text));
                    if (txtQuaHan.Text == "")
                        cmd.Parameters.AddWithValue("@QUAHAN", DBNull.Value);
                    else cmd.Parameters.AddWithValue("@QUAHAN", int.Parse(txtQuaHan.Text));
                    cmd.Parameters.AddWithValue("@STK", txtSTKTT.Text);
                    cmd.Parameters.AddWithValue("@HINHTHUCTRA", cmbHinhThucTra.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Đã cập nhật thành công");
                    HienThiDanhSachPhieuThanhToan();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
            finally { KetNoi.Disconnect(); }
        }
        public void setDefault()
        {
            txtSTKTT.Text = "";
            txtMaPhieuTT.Text = "";
            txtMaPhieuVay.Text = "";
            txtQuaHan.Text = "";
            txtSoTienTra.Text = "";
            txtTienPhat.Text = "";
            cmbHinhThucTra.Text = "";
            cmbTrangThai.Text = "";
        }
        private void cmbHinhThucTra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHinhThucTra.Text == "Tài khoản thanh toán")
            {
                txtSTKTT.Enabled = true;
                lblSTKTT.ForeColor = Color.Black;
                txtSTKTT.ForeColor = Color.Black;
                try
                {
                    using (SqlCommand cmd = new SqlCommand("STK_NHANTIENVAY_THANHTOANTIENVAY_GUITIENTIETKIEM", KetNoi.Conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CCCD", GiaoDich.CCCD);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            String stk = "";
                            if (reader["SOTAIKHOAN"] != DBNull.Value)
                            {
                                stk = reader["SOTAIKHOAN"].ToString();
                            }
                            if (stk == "")
                            {
                                MessageBox.Show("Hãy đăng ký tài khoản thanh toán để thanh toán tiền vay");
                                txtSTKTT.Text = "";
                            }
                            else
                            {
                                txtSTKTT.Text = stk;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { KetNoi.Disconnect(); }
                if (txtSTKTT.Text != "")
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("LAYSTK_KIEMTRASODUTHANHTOANVAY", KetNoi.Conn))
                        {


                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@SOTIENTRA", decimal.Parse(txtSoTienTra.Text));
                            cmd.Parameters.AddWithValue("@TIENPHAT", decimal.Parse(txtTienPhat.Text));
                            cmd.Parameters.AddWithValue("@MAPHIEUVAYTIEN", txtMaPhieuVay.Text);
                            cmd.Parameters.AddWithValue("@MAPHIEUTT", txtMaPhieuTT.Text);

                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                string ktra = reader["KIEMTRASODU"].ToString();
                                if (ktra == "1")
                                {
                                    MessageBox.Show("Tài khoản không đủ số dư để trả");
                                    txtSTKTT.Text = "";
                                }
                                else
                                {
                                    txtSTKTT.Text = reader["SOTAIKHOANTRATIEN"].ToString();
                                }
                            }
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
                lblSTKTT.ForeColor = Color.Gray;
                txtSTKTT.ForeColor = Color.Gray;
                txtSTKTT.Enabled = false;
            }
        }
        

        public void LayMaPhieuVay()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("LAY_MAPHIEUVAYTIEN", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CCCD", GiaoDich.CCCD);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {

                        txtMaPhieuVay.Text = reader["MAPHIEUVAYTIEN"].ToString();

                    }
                    reader.Close();
                    if (txtMaPhieuVay.Text != "")
                        HienThiDanhSachPhieuThanhToan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
            finally { KetNoi.Disconnect(); }
        }
        private void ThanhToanTienVay_Load(object sender, EventArgs e)
        {


        }

        private void dgvPhieuTT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dgvPhieuTT.Rows[e.RowIndex];
                cmbTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
                txtMaPhieuTT.Text = row.Cells["MaTT"].Value.ToString();
                txtSoTienTra.Text = row.Cells["SoTienTra"].Value.ToString();
                cmbHinhThucTra.Text = row.Cells["HinhThucTra"].Value.ToString();
                if (row.Cells["NgayTra"].Value != DBNull.Value && row.Cells["NgayTra"].Value != null)
                {
                    dtpNgayTra.Value = Convert.ToDateTime(row.Cells["NgayTra"].Value);
                }

                if (row.Cells["NgayDenHan"].Value != null && row.Cells["NgayDenHan"].Value != DBNull.Value)
                {
                    DateTime ngayDenHan;
                    if (DateTime.TryParse(row.Cells["NgayDenHan"].Value.ToString(), out ngayDenHan))
                    {
                        dtpNgayDenHan.Value = ngayDenHan;
                    }
                    else
                    {
                        // Nếu không phân tích được ngày => dùng ngày hiện tại
                        dtpNgayDenHan.Value = DateTime.Today;
                    }
                }
                else
                {
                    dtpNgayDenHan.Value = DateTime.Today;
                }
                if (cmbTrangThai.Text == "Hoàn thành")
                {
                    txtQuaHan.Text = row.Cells["QuaHan"].Value.ToString();
                    txtSTKTT.Text = row.Cells["STK"].Value.ToString();
                }
                else
                { 
                    
                    }
                }
            }

        private void dtpNgayTra_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("TinhNgayQuaHan", KetNoi.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaPhieuTT", txtMaPhieuTT.Text);
                    cmd.Parameters.AddWithValue("@MaPhieuVayTien", txtMaPhieuVay.Text);
                    cmd.Parameters.AddWithValue("@NgayThanhToanMoi", dtpNgayTra.Value);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        txtQuaHan.Text = reader["SONGAYQUAHAN"].ToString();
                        txtTienPhat.Text = reader["TIENPHAT"].ToString();
                    }
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
    }

