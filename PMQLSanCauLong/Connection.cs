using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PMQLSanCauLong
{
    public class Connection
    {
        public SqlConnection cnn;
        string connectionStr = @"server=desktop-jcsiium;database=DBSanCauLong;integrated security=true";
        public Connection()
        {
            cnn = new SqlConnection(connectionStr);
        }
        public Connection(string s)
        {
            cnn = new SqlConnection(s);
        }
        // hàm mở kết nối
        public void KetNoi()
        {
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
        }
        // Hàm đóng kết nối
        public void DongKetNoi()
        {
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
        }
    }
}
