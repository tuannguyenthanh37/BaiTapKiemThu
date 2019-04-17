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

        // Hàm thực thi câu lệnh sql
        public int ExecuteNonQuery(string strQuery)
        {
            int CS = -1;
            try
            {
                int result = 0;
                if (this.cnn.State == ConnectionState.Closed)
                {
                    this.cnn.Open();
                }
                result = new SqlCommand { Connection = this.cnn, CommandType = CommandType.Text, CommandText = strQuery }.ExecuteNonQuery();
                this.cnn.Close();
                CS = result;
            }
            catch
            {
                return -1;

            }
            return CS;
        }
        // Hàm thực thi sql trả về bảng dữ liêu
        public DataTable ExecuteData(string strQuery)
        {
            try
            {
                KetNoi();
                SqlDataAdapter adapter = new SqlDataAdapter(strQuery, cnn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                DongKetNoi();
                return dataSet.Tables[0];
            }
            catch { return null; }
        }
    }
}
