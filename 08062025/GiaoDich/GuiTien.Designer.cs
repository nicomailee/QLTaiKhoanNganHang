namespace _08062025.GiaoDich
{
    partial class GuiTien
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
            this.txtThoiHan = new System.Windows.Forms.TextBox();
            this.txtLaiSuat = new System.Windows.Forms.TextBox();
            this.txtSoTienGui = new System.Windows.Forms.TextBox();
            this.lblLaiSuat = new System.Windows.Forms.Label();
            this.lblThoiHan = new System.Windows.Forms.Label();
            this.lblSoTienGui = new System.Windows.Forms.Label();
            this.lblPhieuGuiTien = new System.Windows.Forms.Label();
            this.txtMaPhieuGui = new System.Windows.Forms.TextBox();
            this.lblChuY = new System.Windows.Forms.Label();
            this.txtSTKTietKiem = new System.Windows.Forms.TextBox();
            this.lblSTKNhanTien = new System.Windows.Forms.Label();
            this.txtSoTienDuKien = new System.Windows.Forms.TextBox();
            this.lblSoTienDuKien = new System.Windows.Forms.Label();
            this.lblNgayDenHan = new System.Windows.Forms.Label();
            this.dtpNgayDenHan = new System.Windows.Forms.DateTimePicker();
            this.lblHinhThucNhan = new System.Windows.Forms.Label();
            this.cmbHinhThucGui = new System.Windows.Forms.ComboBox();
            this.lblChuY2 = new System.Windows.Forms.Label();
            this.txtSTKGuiTien = new System.Windows.Forms.TextBox();
            this.lblSTKTT = new System.Windows.Forms.Label();
            this.lblSoDu = new System.Windows.Forms.Label();
            this.txtSoDu = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtThoiHan
            // 
            this.txtThoiHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThoiHan.Location = new System.Drawing.Point(351, 164);
            this.txtThoiHan.Name = "txtThoiHan";
            this.txtThoiHan.Size = new System.Drawing.Size(216, 27);
            this.txtThoiHan.TabIndex = 82;
            this.txtThoiHan.TextChanged += new System.EventHandler(this.txtThoiHan_TextChanged);
            // 
            // txtLaiSuat
            // 
            this.txtLaiSuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLaiSuat.Location = new System.Drawing.Point(351, 238);
            this.txtLaiSuat.Name = "txtLaiSuat";
            this.txtLaiSuat.Size = new System.Drawing.Size(216, 27);
            this.txtLaiSuat.TabIndex = 81;
            // 
            // txtSoTienGui
            // 
            this.txtSoTienGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTienGui.Location = new System.Drawing.Point(351, 93);
            this.txtSoTienGui.Name = "txtSoTienGui";
            this.txtSoTienGui.Size = new System.Drawing.Size(216, 27);
            this.txtSoTienGui.TabIndex = 80;
            this.txtSoTienGui.TextChanged += new System.EventHandler(this.txtSoTienGui_TextChanged);
            // 
            // lblLaiSuat
            // 
            this.lblLaiSuat.AutoSize = true;
            this.lblLaiSuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaiSuat.Location = new System.Drawing.Point(133, 238);
            this.lblLaiSuat.Name = "lblLaiSuat";
            this.lblLaiSuat.Size = new System.Drawing.Size(127, 20);
            this.lblLaiSuat.TabIndex = 79;
            this.lblLaiSuat.Text = "Lãi suất (tháng)";
            // 
            // lblThoiHan
            // 
            this.lblThoiHan.AutoSize = true;
            this.lblThoiHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiHan.Location = new System.Drawing.Point(129, 164);
            this.lblThoiHan.Name = "lblThoiHan";
            this.lblThoiHan.Size = new System.Drawing.Size(131, 20);
            this.lblThoiHan.TabIndex = 78;
            this.lblThoiHan.Text = "Thời hạn (tháng)";
            // 
            // lblSoTienGui
            // 
            this.lblSoTienGui.AutoSize = true;
            this.lblSoTienGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTienGui.Location = new System.Drawing.Point(133, 100);
            this.lblSoTienGui.Name = "lblSoTienGui";
            this.lblSoTienGui.Size = new System.Drawing.Size(141, 20);
            this.lblSoTienGui.TabIndex = 77;
            this.lblSoTienGui.Text = "Số tiền gửi (đồng)";
            // 
            // lblPhieuGuiTien
            // 
            this.lblPhieuGuiTien.AutoSize = true;
            this.lblPhieuGuiTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhieuGuiTien.Location = new System.Drawing.Point(130, 27);
            this.lblPhieuGuiTien.Name = "lblPhieuGuiTien";
            this.lblPhieuGuiTien.Size = new System.Drawing.Size(136, 20);
            this.lblPhieuGuiTien.TabIndex = 76;
            this.lblPhieuGuiTien.Text = "Mã phiếu gửi tiền";
            // 
            // txtMaPhieuGui
            // 
            this.txtMaPhieuGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhieuGui.Location = new System.Drawing.Point(351, 20);
            this.txtMaPhieuGui.Name = "txtMaPhieuGui";
            this.txtMaPhieuGui.Size = new System.Drawing.Size(216, 27);
            this.txtMaPhieuGui.TabIndex = 75;
            // 
            // lblChuY
            // 
            this.lblChuY.AutoSize = true;
            this.lblChuY.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChuY.Location = new System.Drawing.Point(180, 312);
            this.lblChuY.Name = "lblChuY";
            this.lblChuY.Size = new System.Drawing.Size(119, 16);
            this.lblChuY.TabIndex = 85;
            this.lblChuY.Text = "Tài khoản tiết kiệm";
            // 
            // txtSTKTietKiem
            // 
            this.txtSTKTietKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTKTietKiem.Location = new System.Drawing.Point(351, 292);
            this.txtSTKTietKiem.Name = "txtSTKTietKiem";
            this.txtSTKTietKiem.Size = new System.Drawing.Size(216, 27);
            this.txtSTKTietKiem.TabIndex = 84;
            // 
            // lblSTKNhanTien
            // 
            this.lblSTKNhanTien.AutoSize = true;
            this.lblSTKNhanTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTKNhanTien.Location = new System.Drawing.Point(129, 292);
            this.lblSTKNhanTien.Name = "lblSTKNhanTien";
            this.lblSTKNhanTien.Size = new System.Drawing.Size(101, 20);
            this.lblSTKNhanTien.TabIndex = 83;
            this.lblSTKNhanTien.Text = "Số tài khoản";
            // 
            // txtSoTienDuKien
            // 
            this.txtSoTienDuKien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTienDuKien.Location = new System.Drawing.Point(952, 11);
            this.txtSoTienDuKien.Name = "txtSoTienDuKien";
            this.txtSoTienDuKien.Size = new System.Drawing.Size(214, 27);
            this.txtSoTienDuKien.TabIndex = 87;
            // 
            // lblSoTienDuKien
            // 
            this.lblSoTienDuKien.AutoSize = true;
            this.lblSoTienDuKien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTienDuKien.Location = new System.Drawing.Point(717, 18);
            this.lblSoTienDuKien.Name = "lblSoTienDuKien";
            this.lblSoTienDuKien.Size = new System.Drawing.Size(176, 20);
            this.lblSoTienDuKien.TabIndex = 86;
            this.lblSoTienDuKien.Text = "Số tiền dự kiến cuối kỳ";
            // 
            // lblNgayDenHan
            // 
            this.lblNgayDenHan.AutoSize = true;
            this.lblNgayDenHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayDenHan.Location = new System.Drawing.Point(717, 85);
            this.lblNgayDenHan.Name = "lblNgayDenHan";
            this.lblNgayDenHan.Size = new System.Drawing.Size(111, 20);
            this.lblNgayDenHan.TabIndex = 88;
            this.lblNgayDenHan.Text = "Ngày đến hạn";
            // 
            // dtpNgayDenHan
            // 
            this.dtpNgayDenHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayDenHan.Location = new System.Drawing.Point(952, 80);
            this.dtpNgayDenHan.Name = "dtpNgayDenHan";
            this.dtpNgayDenHan.Size = new System.Drawing.Size(214, 27);
            this.dtpNgayDenHan.TabIndex = 90;
            // 
            // lblHinhThucNhan
            // 
            this.lblHinhThucNhan.AutoSize = true;
            this.lblHinhThucNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhThucNhan.Location = new System.Drawing.Point(721, 159);
            this.lblHinhThucNhan.Name = "lblHinhThucNhan";
            this.lblHinhThucNhan.Size = new System.Drawing.Size(122, 20);
            this.lblHinhThucNhan.TabIndex = 91;
            this.lblHinhThucNhan.Text = "Hình thức nhận";
            // 
            // cmbHinhThucGui
            // 
            this.cmbHinhThucGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHinhThucGui.FormattingEnabled = true;
            this.cmbHinhThucGui.Items.AddRange(new object[] {
            "Tiền mặt",
            "Tài khoản thanh toán"});
            this.cmbHinhThucGui.Location = new System.Drawing.Point(952, 156);
            this.cmbHinhThucGui.Name = "cmbHinhThucGui";
            this.cmbHinhThucGui.Size = new System.Drawing.Size(214, 28);
            this.cmbHinhThucGui.TabIndex = 92;
            this.cmbHinhThucGui.SelectedIndexChanged += new System.EventHandler(this.cmbHinhThucNhan_SelectedIndexChanged);
            // 
            // lblChuY2
            // 
            this.lblChuY2.AutoSize = true;
            this.lblChuY2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChuY2.Location = new System.Drawing.Point(777, 251);
            this.lblChuY2.Name = "lblChuY2";
            this.lblChuY2.Size = new System.Drawing.Size(134, 16);
            this.lblChuY2.TabIndex = 95;
            this.lblChuY2.Text = "Tài khoản thanh toán ";
            // 
            // txtSTKGuiTien
            // 
            this.txtSTKGuiTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTKGuiTien.Location = new System.Drawing.Point(952, 231);
            this.txtSTKGuiTien.Name = "txtSTKGuiTien";
            this.txtSTKGuiTien.Size = new System.Drawing.Size(216, 27);
            this.txtSTKGuiTien.TabIndex = 94;
            // 
            // lblSTKTT
            // 
            this.lblSTKTT.AutoSize = true;
            this.lblSTKTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTKTT.Location = new System.Drawing.Point(727, 231);
            this.lblSTKTT.Name = "lblSTKTT";
            this.lblSTKTT.Size = new System.Drawing.Size(101, 20);
            this.lblSTKTT.TabIndex = 93;
            this.lblSTKTT.Text = "Số tài khoản";
            // 
            // lblSoDu
            // 
            this.lblSoDu.AutoSize = true;
            this.lblSoDu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDu.Location = new System.Drawing.Point(731, 295);
            this.lblSoDu.Name = "lblSoDu";
            this.lblSoDu.Size = new System.Drawing.Size(52, 20);
            this.lblSoDu.TabIndex = 96;
            this.lblSoDu.Text = "Số dư";
            // 
            // txtSoDu
            // 
            this.txtSoDu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDu.Location = new System.Drawing.Point(952, 289);
            this.txtSoDu.Name = "txtSoDu";
            this.txtSoDu.Size = new System.Drawing.Size(216, 27);
            this.txtSoDu.TabIndex = 97;
            // 
            // GuiTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.txtSoDu);
            this.Controls.Add(this.lblSoDu);
            this.Controls.Add(this.lblChuY2);
            this.Controls.Add(this.txtSTKGuiTien);
            this.Controls.Add(this.lblSTKTT);
            this.Controls.Add(this.cmbHinhThucGui);
            this.Controls.Add(this.lblHinhThucNhan);
            this.Controls.Add(this.dtpNgayDenHan);
            this.Controls.Add(this.lblNgayDenHan);
            this.Controls.Add(this.txtSoTienDuKien);
            this.Controls.Add(this.lblSoTienDuKien);
            this.Controls.Add(this.lblChuY);
            this.Controls.Add(this.txtSTKTietKiem);
            this.Controls.Add(this.lblSTKNhanTien);
            this.Controls.Add(this.txtThoiHan);
            this.Controls.Add(this.txtLaiSuat);
            this.Controls.Add(this.txtSoTienGui);
            this.Controls.Add(this.lblLaiSuat);
            this.Controls.Add(this.lblThoiHan);
            this.Controls.Add(this.lblSoTienGui);
            this.Controls.Add(this.lblPhieuGuiTien);
            this.Controls.Add(this.txtMaPhieuGui);
            this.Location = new System.Drawing.Point(54, 210);
            this.Name = "GuiTien";
            this.Size = new System.Drawing.Size(1461, 354);
            this.Load += new System.EventHandler(this.GuiTien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtThoiHan;
        private System.Windows.Forms.TextBox txtLaiSuat;
        private System.Windows.Forms.TextBox txtSoTienGui;
        private System.Windows.Forms.Label lblLaiSuat;
        private System.Windows.Forms.Label lblThoiHan;
        private System.Windows.Forms.Label lblSoTienGui;
        private System.Windows.Forms.Label lblPhieuGuiTien;
        private System.Windows.Forms.TextBox txtMaPhieuGui;
        private System.Windows.Forms.Label lblChuY;
        private System.Windows.Forms.TextBox txtSTKTietKiem;
        private System.Windows.Forms.Label lblSTKNhanTien;
        private System.Windows.Forms.TextBox txtSoTienDuKien;
        private System.Windows.Forms.Label lblSoTienDuKien;
        private System.Windows.Forms.Label lblNgayDenHan;
        private System.Windows.Forms.DateTimePicker dtpNgayDenHan;
        private System.Windows.Forms.Label lblHinhThucNhan;
        private System.Windows.Forms.ComboBox cmbHinhThucGui;
        private System.Windows.Forms.Label lblChuY2;
        private System.Windows.Forms.TextBox txtSTKGuiTien;
        private System.Windows.Forms.Label lblSTKTT;
        private System.Windows.Forms.Label lblSoDu;
        private System.Windows.Forms.TextBox txtSoDu;
    }
}
