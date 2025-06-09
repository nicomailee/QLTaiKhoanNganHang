namespace QLTaiKhoanNganHang
{
    partial class FormDangNhap
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDangNhap));
            this.panelLeft = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxBank = new System.Windows.Forms.PictureBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.linkTerms = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Dangnhap = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.chk_ShowPassword = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBank)).BeginInit();
            this.panelRight.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.LightBlue;
            this.panelLeft.Controls.Add(this.label1);
            this.panelLeft.Controls.Add(this.pictureBoxBank);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(303, 494);
            this.panelLeft.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(84, 332);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "NGÂN HÀNG 3CE";
            // 
            // pictureBoxBank
            // 
            this.pictureBoxBank.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBank.Image")));
            this.pictureBoxBank.Location = new System.Drawing.Point(2, 98);
            this.pictureBoxBank.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxBank.Name = "pictureBoxBank";
            this.pictureBoxBank.Size = new System.Drawing.Size(302, 219);
            this.pictureBoxBank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBank.TabIndex = 0;
            this.pictureBoxBank.TabStop = false;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.LightBlue;
            this.panelRight.Controls.Add(this.panelLogin);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(303, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(473, 494);
            this.panelRight.TabIndex = 1;
            this.panelRight.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRight_Paint);
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.linkTerms);
            this.panelLogin.Controls.Add(this.label4);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.label3);
            this.panelLogin.Controls.Add(this.btn_Thoat);
            this.panelLogin.Controls.Add(this.label5);
            this.panelLogin.Controls.Add(this.btn_Dangnhap);
            this.panelLogin.Controls.Add(this.txtUsername);
            this.panelLogin.Controls.Add(this.chk_ShowPassword);
            this.panelLogin.Controls.Add(this.txtPassword);
            this.panelLogin.Location = new System.Drawing.Point(2, 98);
            this.panelLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(262, 285);
            this.panelLogin.TabIndex = 10;
            // 
            // linkTerms
            // 
            this.linkTerms.AutoSize = true;
            this.linkTerms.Location = new System.Drawing.Point(77, 182);
            this.linkTerms.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkTerms.Name = "linkTerms";
            this.linkTerms.Size = new System.Drawing.Size(118, 13);
            this.linkTerms.TabIndex = 9;
            this.linkTerms.TabStop = true;
            this.linkTerms.Text = "Điều khoản và bảo mật";
            this.linkTerms.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTerms_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Project";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(2, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "QUẢN LÍ TÀI KHOẢN NGÂN HÀNG";
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(175, 138);
            this.btn_Thoat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(56, 19);
            this.btn_Thoat.TabIndex = 8;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 77);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Nhập mật khẩu";
            // 
            // btn_Dangnhap
            // 
            this.btn_Dangnhap.Location = new System.Drawing.Point(15, 138);
            this.btn_Dangnhap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Dangnhap.Name = "btn_Dangnhap";
            this.btn_Dangnhap.Size = new System.Drawing.Size(83, 19);
            this.btn_Dangnhap.TabIndex = 7;
            this.btn_Dangnhap.Text = "Đăng nhập";
            this.btn_Dangnhap.UseVisualStyleBackColor = true;
            this.btn_Dangnhap.Click += new System.EventHandler(this.btn_Dangnhap_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(90, 52);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(142, 20);
            this.txtUsername.TabIndex = 4;
            // 
            // chk_ShowPassword
            // 
            this.chk_ShowPassword.AutoSize = true;
            this.chk_ShowPassword.Location = new System.Drawing.Point(90, 107);
            this.chk_ShowPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chk_ShowPassword.Name = "chk_ShowPassword";
            this.chk_ShowPassword.Size = new System.Drawing.Size(95, 17);
            this.chk_ShowPassword.TabIndex = 6;
            this.chk_ShowPassword.Text = "Hiện mật khẩu";
            this.chk_ShowPassword.UseVisualStyleBackColor = true;
            this.chk_ShowPassword.CheckedChanged += new System.EventHandler(this.chk_ShowPassword_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(90, 77);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(142, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // FormDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(776, 494);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FormDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBank)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxBank;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btn_Dangnhap;
        private System.Windows.Forms.CheckBox chk_ShowPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkTerms;
        private System.Windows.Forms.Panel panelLogin;
    }
}

