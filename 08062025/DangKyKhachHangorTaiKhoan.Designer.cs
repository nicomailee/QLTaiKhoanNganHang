namespace _08062025
{
    partial class DangKyKhachHangorTaiKhoan
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
            this.panelDangKy = new System.Windows.Forms.Panel();
            this.btnDangKyTK = new Guna.UI2.WinForms.Guna2Button();
            this.btnDangKyKH = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // panelDangKy
            // 
            this.panelDangKy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelDangKy.Location = new System.Drawing.Point(0, 126);
            this.panelDangKy.Name = "panelDangKy";
            this.panelDangKy.Size = new System.Drawing.Size(1734, 926);
            this.panelDangKy.TabIndex = 1;
            // 
            // btnDangKyTK
            // 
            this.btnDangKyTK.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangKyTK.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangKyTK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangKyTK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangKyTK.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDangKyTK.ForeColor = System.Drawing.Color.White;
            this.btnDangKyTK.Location = new System.Drawing.Point(468, 43);
            this.btnDangKyTK.Name = "btnDangKyTK";
            this.btnDangKyTK.Size = new System.Drawing.Size(180, 45);
            this.btnDangKyTK.TabIndex = 4;
            this.btnDangKyTK.Text = "Đăng ký tài khoản";
            this.btnDangKyTK.Click += new System.EventHandler(this.btnDangKyTK_Click);
            // 
            // btnDangKyKH
            // 
            this.btnDangKyKH.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangKyKH.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangKyKH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangKyKH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangKyKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDangKyKH.ForeColor = System.Drawing.Color.White;
            this.btnDangKyKH.Location = new System.Drawing.Point(171, 44);
            this.btnDangKyKH.Name = "btnDangKyKH";
            this.btnDangKyKH.Size = new System.Drawing.Size(180, 45);
            this.btnDangKyKH.TabIndex = 3;
            this.btnDangKyKH.Text = "Đăng ký khách hàng";
            this.btnDangKyKH.Click += new System.EventHandler(this.btnDangKyKH_Click);
            // 
            // DangKyKhachHangorTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDangKyTK);
            this.Controls.Add(this.btnDangKyKH);
            this.Controls.Add(this.panelDangKy);
            this.Location = new System.Drawing.Point(352, 0);
            this.Name = "DangKyKhachHangorTaiKhoan";
            this.Size = new System.Drawing.Size(1572, 1055);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDangKy;
        private Guna.UI2.WinForms.Guna2Button btnDangKyTK;
        private Guna.UI2.WinForms.Guna2Button btnDangKyKH;
    }
}
