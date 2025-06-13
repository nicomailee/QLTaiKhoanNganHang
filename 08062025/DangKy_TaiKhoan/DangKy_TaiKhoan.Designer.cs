namespace _08062025.DangKy_TaiKhoan
{
    partial class DangKy_TaiKhoan
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbMaNV = new System.Windows.Forms.ComboBox();
            this.dtpNgayDangKy = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.TaiKhanNgauNhien = new System.Windows.Forms.CheckBox();
            this.TaiKhoanSoDienThoai = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHoanThanh = new System.Windows.Forms.Button();
            this.ckcboxTietKiem = new System.Windows.Forms.CheckBox();
            this.ckcThanhToan = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lblNgheNghiep = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtFindCCCD = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbMaNV
            // 
            this.cmbMaNV.FormattingEnabled = true;
            this.cmbMaNV.Location = new System.Drawing.Point(482, 578);
            this.cmbMaNV.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMaNV.Name = "cmbMaNV";
            this.cmbMaNV.Size = new System.Drawing.Size(105, 24);
            this.cmbMaNV.TabIndex = 105;
            // 
            // dtpNgayDangKy
            // 
            this.dtpNgayDangKy.Location = new System.Drawing.Point(469, 523);
            this.dtpNgayDangKy.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayDangKy.Name = "dtpNgayDangKy";
            this.dtpNgayDangKy.Size = new System.Drawing.Size(253, 22);
            this.dtpNgayDangKy.TabIndex = 104;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(360, 530);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(93, 16);
            this.label22.TabIndex = 103;
            this.label22.Text = "Ngày đăng kí :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(363, 587);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 16);
            this.label21.TabIndex = 102;
            this.label21.Text = "Mã nhân viên:";
            // 
            // TaiKhanNgauNhien
            // 
            this.TaiKhanNgauNhien.AutoSize = true;
            this.TaiKhanNgauNhien.Location = new System.Drawing.Point(391, 480);
            this.TaiKhanNgauNhien.Margin = new System.Windows.Forms.Padding(4);
            this.TaiKhanNgauNhien.Name = "TaiKhanNgauNhien";
            this.TaiKhanNgauNhien.Size = new System.Drawing.Size(171, 20);
            this.TaiKhanNgauNhien.TabIndex = 101;
            this.TaiKhanNgauNhien.Text = "Số tài khoản ngẫu nhiên";
            this.TaiKhanNgauNhien.UseVisualStyleBackColor = true;
            this.TaiKhanNgauNhien.CheckedChanged += new System.EventHandler(this.TaiKhanNgauNhien_CheckedChanged);
            // 
            // TaiKhoanSoDienThoai
            // 
            this.TaiKhoanSoDienThoai.AutoSize = true;
            this.TaiKhoanSoDienThoai.Location = new System.Drawing.Point(391, 452);
            this.TaiKhoanSoDienThoai.Margin = new System.Windows.Forms.Padding(4);
            this.TaiKhoanSoDienThoai.Name = "TaiKhoanSoDienThoai";
            this.TaiKhoanSoDienThoai.Size = new System.Drawing.Size(107, 20);
            this.TaiKhoanSoDienThoai.TabIndex = 100;
            this.TaiKhoanSoDienThoai.Text = "Số điện thoại";
            this.TaiKhoanSoDienThoai.UseVisualStyleBackColor = true;
            this.TaiKhoanSoDienThoai.CheckedChanged += new System.EventHandler(this.TaiKhoanSoDienThoai_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(350, 426);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 16);
            this.label7.TabIndex = 99;
            this.label7.Text = "Chọn số tài khoản theo:";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(444, 663);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 28);
            this.btnThoat.TabIndex = 98;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnHoanThanh
            // 
            this.btnHoanThanh.Location = new System.Drawing.Point(567, 663);
            this.btnHoanThanh.Margin = new System.Windows.Forms.Padding(4);
            this.btnHoanThanh.Name = "btnHoanThanh";
            this.btnHoanThanh.Size = new System.Drawing.Size(116, 28);
            this.btnHoanThanh.TabIndex = 97;
            this.btnHoanThanh.Text = "Đăng ký";
            this.btnHoanThanh.UseVisualStyleBackColor = true;
            this.btnHoanThanh.Click += new System.EventHandler(this.btnHoanThanh_Click);
            // 
            // ckcboxTietKiem
            // 
            this.ckcboxTietKiem.AutoSize = true;
            this.ckcboxTietKiem.Location = new System.Drawing.Point(391, 391);
            this.ckcboxTietKiem.Margin = new System.Windows.Forms.Padding(4);
            this.ckcboxTietKiem.Name = "ckcboxTietKiem";
            this.ckcboxTietKiem.Size = new System.Drawing.Size(141, 20);
            this.ckcboxTietKiem.TabIndex = 95;
            this.ckcboxTietKiem.Text = "Tài khoản tiết kiệm";
            this.ckcboxTietKiem.UseVisualStyleBackColor = true;
            this.ckcboxTietKiem.CheckedChanged += new System.EventHandler(this.ckcboxTietKiem_CheckedChanged);
            // 
            // ckcThanhToan
            // 
            this.ckcThanhToan.AutoSize = true;
            this.ckcThanhToan.Location = new System.Drawing.Point(391, 366);
            this.ckcThanhToan.Margin = new System.Windows.Forms.Padding(4);
            this.ckcThanhToan.Name = "ckcThanhToan";
            this.ckcThanhToan.Size = new System.Drawing.Size(153, 20);
            this.ckcThanhToan.TabIndex = 94;
            this.ckcThanhToan.Text = "Tài khoản thanh toán";
            this.ckcThanhToan.UseVisualStyleBackColor = true;
            this.ckcThanhToan.CheckedChanged += new System.EventHandler(this.ckcThanhToan_CheckedChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(350, 331);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(166, 16);
            this.label20.TabIndex = 93;
            this.label20.Text = "Loại tài khoản mong muốn:";
            // 
            // lblNgheNghiep
            // 
            this.lblNgheNghiep.AutoSize = true;
            this.lblNgheNghiep.Location = new System.Drawing.Point(752, 276);
            this.lblNgheNghiep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgheNghiep.Name = "lblNgheNghiep";
            this.lblNgheNghiep.Size = new System.Drawing.Size(90, 16);
            this.lblNgheNghiep.TabIndex = 91;
            this.lblNgheNghiep.Text = "Nghề nghiệp: ";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(350, 276);
            this.lblSDT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(40, 16);
            this.lblSDT.TabIndex = 90;
            this.lblSDT.Text = "SĐT: ";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(348, 211);
            this.lblHoTen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(52, 16);
            this.lblHoTen.TabIndex = 89;
            this.lblHoTen.Text = "Họ tên: ";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(348, 244);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(47, 16);
            this.lblEmail.TabIndex = 88;
            this.lblEmail.Text = "Email: ";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(752, 183);
            this.lblNgaySinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(73, 16);
            this.lblNgaySinh.TabIndex = 87;
            this.lblNgaySinh.Text = "Ngày sinh: ";
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(752, 226);
            this.lblGioiTinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(60, 16);
            this.lblGioiTinh.TabIndex = 86;
            this.lblGioiTinh.Text = "Giới tính: ";
            // 
            // lblCCCD
            // 
            this.lblCCCD.AutoSize = true;
            this.lblCCCD.Location = new System.Drawing.Point(345, 180);
            this.lblCCCD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.Size = new System.Drawing.Size(50, 16);
            this.lblCCCD.TabIndex = 85;
            this.lblCCCD.Text = "CCCD: ";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label32.Location = new System.Drawing.Point(530, 44);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(313, 35);
            this.label32.TabIndex = 84;
            this.label32.Text = "Phiếu đăng kí tài khoản";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(328, 137);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(125, 16);
            this.label18.TabIndex = 83;
            this.label18.Text = "1. Thông tin cá nhân";
            // 
            // txtFindCCCD
            // 
            this.txtFindCCCD.Location = new System.Drawing.Point(1146, 24);
            this.txtFindCCCD.Name = "txtFindCCCD";
            this.txtFindCCCD.Size = new System.Drawing.Size(100, 22);
            this.txtFindCCCD.TabIndex = 106;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(335, 302);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(122, 16);
            this.label19.TabIndex = 92;
            this.label19.Text = "2. Đăng kí tài khoản";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(1006, 24);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(119, 22);
            this.btnTimKiem.TabIndex = 107;
            this.btnTimKiem.Text = "Tìm kiếm CCCD";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // DangKy_TaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtFindCCCD);
            this.Controls.Add(this.cmbMaNV);
            this.Controls.Add(this.dtpNgayDangKy);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.TaiKhanNgauNhien);
            this.Controls.Add(this.TaiKhoanSoDienThoai);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHoanThanh);
            this.Controls.Add(this.ckcboxTietKiem);
            this.Controls.Add(this.ckcThanhToan);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblNgheNghiep);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.lblCCCD);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label18);
            this.Location = new System.Drawing.Point(0, 170);
            this.Name = "DangKy_TaiKhoan";
            this.Size = new System.Drawing.Size(1734, 935);
            this.Load += new System.EventHandler(this.DangKy_TaiKhoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMaNV;
        private System.Windows.Forms.DateTimePicker dtpNgayDangKy;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox TaiKhanNgauNhien;
        private System.Windows.Forms.CheckBox TaiKhoanSoDienThoai;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHoanThanh;
        private System.Windows.Forms.CheckBox ckcboxTietKiem;
        private System.Windows.Forms.CheckBox ckcThanhToan;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblNgheNghiep;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtFindCCCD;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnTimKiem;
    }
}
