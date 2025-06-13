namespace _08062025.DangKy_KhachHang
{
    partial class DangKySDT
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
            this.lblSDT = new System.Windows.Forms.Label();
            this.txt84 = new System.Windows.Forms.TextBox();
            this.lblHinhDong = new System.Windows.Forms.Label();
            this.lblSDTDaTonTai = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(323, 228);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(70, 16);
            this.lblSDT.TabIndex = 0;
            this.lblSDT.Text = "Nhập SĐT";
            // 
            // txt84
            // 
            this.txt84.Location = new System.Drawing.Point(477, 221);
            this.txt84.Name = "txt84";
            this.txt84.Size = new System.Drawing.Size(32, 22);
            this.txt84.TabIndex = 1;
            this.txt84.Text = "+84";
            // 
            // lblHinhDong
            // 
            this.lblHinhDong.AutoSize = true;
            this.lblHinhDong.Location = new System.Drawing.Point(1462, 360);
            this.lblHinhDong.Name = "lblHinhDong";
            this.lblHinhDong.Size = new System.Drawing.Size(221, 16);
            this.lblHinhDong.TabIndex = 2;
            this.lblHinhDong.Text = "Hình động ở đây để nhấn tiếp theo á";
            this.lblHinhDong.Click += new System.EventHandler(this.lblHinhDong_Click);
            // 
            // lblSDTDaTonTai
            // 
            this.lblSDTDaTonTai.AutoSize = true;
            this.lblSDTDaTonTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDTDaTonTai.Location = new System.Drawing.Point(351, 246);
            this.lblSDTDaTonTai.Name = "lblSDTDaTonTai";
            this.lblSDTDaTonTai.Size = new System.Drawing.Size(158, 18);
            this.lblSDTDaTonTai.TabIndex = 3;
            this.lblSDTDaTonTai.Text = "Số điện thoại đã tồn tại";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(505, 221);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(157, 22);
            this.txtSDT.TabIndex = 4;
            this.txtSDT.TextChanged += new System.EventHandler(this.txtSDT_TextChanged);
            // 
            // DangKySDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.lblSDTDaTonTai);
            this.Controls.Add(this.lblHinhDong);
            this.Controls.Add(this.txt84);
            this.Controls.Add(this.lblSDT);
            this.Location = new System.Drawing.Point(0, 117);
            this.Name = "DangKySDT";
            this.Size = new System.Drawing.Size(1734, 935);
            this.Load += new System.EventHandler(this.DangKySDT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txt84;
        private System.Windows.Forms.Label lblHinhDong;
        private System.Windows.Forms.Label lblSDTDaTonTai;
        private System.Windows.Forms.TextBox txtSDT;
    }
}
