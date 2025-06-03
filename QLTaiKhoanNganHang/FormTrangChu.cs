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
        string connectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=QUAN LI TAI KHOAN NGAN HANG;Integrated Security= True";

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
    }
}