using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08062025
{
    internal class KetNoi
    {
        public static SqlConnection Conn; //bín giữ kết nối sql dùng hết cả bài này

        // Hàm tạo và mở kết nối đến SQL Server
        public static void Connect()
        {
            string source = @"server=.\SQLEXPRESS;" + "database=QUAN LI TAI KHOAN NGAN HANG;" + "Integrated Security=true;";

            Conn = new SqlConnection(source); //khởi tạo kết nối với chuỗi trên kia
            Conn.Open();

            //Kiểm tra trạng thái kết nối
            if (Conn.State == ConnectionState.Open)
            {
                Console.WriteLine("Kết nối thành công");
            }
            else
            {
                Console.WriteLine("Kết nối thất bại");
            }
        }
        public static void Disconnect()
        {
            if (Conn != null && Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }
    }
}
