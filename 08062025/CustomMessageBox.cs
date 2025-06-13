using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08062025
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;
        }

        public static CustomMessageBox.MessageBoxResult ShowBox(string message)
        {
            using (var box = new CustomMessageBox(message))
            {
                box.ShowDialog();
                return box.Result;
            }
        }

        public enum MessageBoxResult
            {
                TiepTuc,
                Luu,
                Xuat,
                None
            }

            public MessageBoxResult Result { get; private set; } = MessageBoxResult.None;

            private void btnLuuPhieu_Click(object sender, EventArgs e)
            {
                Result = MessageBoxResult.Luu;
                this.Close();
            }

            private void btnTiepTuc_Click(object sender, EventArgs e)
            {
                Result = MessageBoxResult.TiepTuc;
                this.Close();
            }

            private void btnXuatPhieu_Click(object sender, EventArgs e)
            {
                Result = MessageBoxResult.Xuat;
                this.Close();
            }
        }
    }

