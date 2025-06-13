using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _08062025.DangKy_KhachHang;
using _08062025.DangKy_TaiKhoan;

namespace _08062025
{
    public partial class DangKyKhachHangorTaiKhoan : UserControl
    {
        public DangKyKhachHangorTaiKhoan()
        {
            InitializeComponent();
            NhapThemThongTin nhapThemThongTin_UC = new NhapThemThongTin(this);
            DangKyCCCD dangKyCCCD_UC = new DangKyCCCD(this);
            DangKySDT dangKySDT_UC = new DangKySDT(this);
            KiemTraLaiThongTin kiemTraLaiThongTin_UC = new KiemTraLaiThongTin(dangKySDT_UC, dangKyCCCD_UC, nhapThemThongTin_UC, this);
           


        }
        private DangKyCCCD dangKyCCCD_UC;
        private DangKySDT dangKySDT_UC;
        private NhapThemThongTin nhapThemThongTin_UC;
        private KiemTraLaiThongTin kiemTraLaiThongTin_UC;


        private DangKy_TaiKhoan.DangKy_TaiKhoan dangKy_TK_UC;
        
        private void addUserControl(UserControl userControl)
        {
           ;
            panelDangKy.Controls.Clear();
            panelDangKy.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();
        }
        public void LoadUCDangKySDT()
        {
            if (dangKySDT_UC == null)
            {
                dangKySDT_UC = new DangKySDT(this); // truyền form cha nếu cần
            }
            addUserControl(dangKySDT_UC);
            
        }
        public void LoadUCNhapThemThongTin()
        {
            if (nhapThemThongTin_UC == null)
            {
                nhapThemThongTin_UC= new NhapThemThongTin(this); // truyền form cha nếu cần
            }

            addUserControl(nhapThemThongTin_UC);
        }
        public void LoadUCDangKyCCCD()
        {
            if (dangKyCCCD_UC == null)
            {
                dangKyCCCD_UC = new DangKyCCCD(this); // truyền form cha nếu cần
            }
            addUserControl(dangKyCCCD_UC);
        }
        public void LoadUCKiemTraThongTin()
        {
            if (kiemTraLaiThongTin_UC == null)
            {
                kiemTraLaiThongTin_UC = new KiemTraLaiThongTin(dangKySDT_UC, dangKyCCCD_UC, nhapThemThongTin_UC, this); // truyền form cha nếu cần
            }
            addUserControl (kiemTraLaiThongTin_UC );
        }
        public void LoadUCDangKyTaiKhoan(string cccd)
        {
            if (dangKy_TK_UC == null)
            {
                dangKy_TK_UC = new DangKy_TaiKhoan.DangKy_TaiKhoan(cccd, this); // truyền form cha nếu cần
            }
            addUserControl(dangKy_TK_UC);
        }
        private void btnDangKyKH_Click(object sender, EventArgs e)
        {
            LoadUCDangKySDT ();
        }

        private void btnDangKyTK_Click(object sender, EventArgs e)
        {
            
            LoadUCDangKyTaiKhoan("");

        }
    }
}
