using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PMQLSanCauLong
{
    public partial class FormDSKHang : Form
    {
        string strcon = @"server=DESKTOP-1HNEIAT\SQLEXPRESS;database=DBSanCauLong;integrated security=true";
        SqlDataAdapter dtpPTS;
        SqlDataAdapter dtpDV;
        SqlDataAdapter dtpCTDV;
        SqlDataAdapter dtpCTTS;
        SqlConnection conn;
        DataSet dts = new DataSet();
        BindingSource bdsPTS = new BindingSource();
        BindingSource bdsCTTS = new BindingSource();
        BindingSource bdsDV = new BindingSource();
        BindingSource bdsCTDV = new BindingSource();
        int co;

        public FormDSKHang()
        {
            InitializeComponent();
        }

        private void FormDSKHang_Load(object sender, EventArgs e)
        {
            
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            string laymaphPH = dgvKH.CurrentRow.Cells[0].Value.ToString();
            SqlCommand cmdb = new SqlCommand("delete PhieuThueSan where MaPhieuThue=" + laymaphPH, conn);
            int count1 = cmdb.ExecuteNonQuery();
            if (count1 > 0)
            {
                //int icountSelectedRow = dgvKH.SelectedRows.Count;
                //if (icountSelectedRow == 0)
                //    MessageBox.Show("Bạn hãy chọn dòng cần xoá!");
                //else
                //    foreach (DataGridViewRow row in dgvKH.SelectedRows)
                //        if (!row.IsNewRow) dgvKH.Rows.Remove(row);

                MessageBox.Show("Xóa thành công");
                dgvKH.Refresh();
            }
            else
            {
                MessageBox.Show("Không thể xóa");
            }
            conn.Close();
        }
        private void dateNgaySDSan_ValueChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string ngay_thue = dateNgaySDSan.Value.ToString("yyyy/MM/dd");

            string sql = "select phieuthuesan.maphieuthue as [Mã phiếu thuê],tenkh as [Tên KH],diachi as [Địa chỉ],sdt as [Số điện thoại],ngaythue as [Ngày thuê],tongtien as [Tổng tiền] from khachhang,phieuthuesan where khachhang.makh=phieuthuesan.makh and ngaythue='" + ngay_thue + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            List<object> lst = rd.Cast<object>().ToList();
            dgvKH.DataSource = lst;
            conn.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXoaSan_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {

        }      

        private void btnTrove_Click(object sender, EventArgs e)
        {
            
        }
    }
}
