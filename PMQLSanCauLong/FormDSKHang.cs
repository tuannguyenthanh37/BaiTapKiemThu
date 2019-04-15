﻿using System;
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
            SqlDataAdapter dtpTimKH;
            BindingSource bdsTimKH = new BindingSource();
            co = 0;
            string ngay_thue = dateNgaySDSan.Value.ToString("yyyy/MM/dd");
            if (rdiTenKH.Checked)
            {
                dtpTimKH = new SqlDataAdapter("select phieuthuesan.maphieuthue as [Mã phiếu thuê],tenkh as [Tên KH],diachi as [Địa chỉ],sdt as [Số điện thoại],ngaythue as [Ngày thuê],tongtien as [Tổng tiền] from khachhang,phieuthuesan where khachhang.makh=phieuthuesan.makh and tenkh like N'%" + txtTimKiem.Text + "%' and ngaythue='" + ngay_thue + "'", strcon);
                DataTable dt = new DataTable();
                dtpTimKH.Fill(dt);
                dgvKH.DataSource = dt;
            }

            if (rdiSDT.Checked)
            {
                dtpTimKH = new SqlDataAdapter("select phieuthuesan.maphieuthue as [Mã phiếu thuê],tenkh as [Tên KH],diachi as [Địa chỉ],sdt as [Số điện thoại],ngaythue as [Ngày thuê],tongtien as [Tổng tiền] from khachhang,phieuthuesan where khachhang.makh=phieuthuesan.makh and sdt like '%" + txtTimKiem.Text + "%' and ngaythue='" + ngay_thue + "'", strcon);
                DataTable dt = new DataTable();
                dtpTimKH.Fill(dt);
                dgvKH.DataSource = dt;
            }
        }

        private void btnXoaSan_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string laymaphPH = dgvCTTS.CurrentRow.Cells[0].Value.ToString();
            string laymasan = dgvCTTS.CurrentRow.Cells[1].Value.ToString();
            string laymaca = dgvCTTS.CurrentRow.Cells[2].Value.ToString();



            SqlCommand cmdb = new SqlCommand("delete CTThueSan where MaPhieuThue='" + laymaphPH + "' and MaSan='" + laymasan + "' and MaCa='" + laymaca + "'", conn);
            int count1 = cmdb.ExecuteNonQuery();
            if (count1 > 0)
            {
                int icountSelectedRow = dgvCTTS.SelectedRows.Count;
                if (icountSelectedRow == 0)
                    MessageBox.Show("Bạn hãy chọn dòng cần xoá!");
                else
                    foreach (DataGridViewRow row in dgvCTTS.SelectedRows)
                        if (!row.IsNewRow) dgvCTTS.Rows.Remove(row);
                dgvCTTS.Refresh();
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Không thể xóa");
            }
            conn.Close();
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string laymaphPH3 = dgvCTDV.CurrentRow.Cells[0].Value.ToString();
            string laymadv = dgvCTDV.CurrentRow.Cells[1].Value.ToString();

            SqlCommand cmdb = new SqlCommand("delete CTDichVu where MaPhieuThue='" + laymaphPH3 + "' and MaDV='" + laymadv + "'", conn);
            int count1 = cmdb.ExecuteNonQuery();
            if (count1 > 0)
            {
                int icountSelectedRow = dgvCTTS.SelectedRows.Count;
                if (icountSelectedRow == 0)
                    MessageBox.Show("Bạn hãy chọn dòng cần xoá!");
                else
                    foreach (DataGridViewRow row in dgvCTDV.SelectedRows)
                        if (!row.IsNewRow) dgvCTDV.Rows.Remove(row);
                dgvCTDV.Refresh();
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Không thể xóa");
            }
            conn.Close();
        }
        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string laymp = dgvKH.SelectedRows[0].Cells[0].Value.ToString();
            SqlDataAdapter da1 = new SqlDataAdapter("select PhieuThueSan.MaPhieuThue as [Mã Phiếu Thuê], CTThueSan.MaSan as [Mã sân],CTThueSan.MaCa as [Mã ca],cathue.giasan as [Giá Sân],CTThueSan.NgaySDSan as [Ngày SD],CTThueSan.GhiChu as [Ghi chú] from Cathue,PhieuThueSan,CTThueSan where CTThueSan.MaPhieuThue=PhieuThueSan.MaPhieuThue and cathue.maca=ctthuesan.maca and CTThueSan.MaPhieuThue='" + laymp + "'", conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dgvCTTS.DataSource = dt1;
            SqlDataAdapter da = new SqlDataAdapter("select PhieuThueSan.MaPhieuThue as [Mã Phiếu Thuê],ctdichvu.madv as [Mã DV],tendv as [Tên DV],dongia as [Đơn giá],soluong as [Số lượng] from PhieuThueSan,CTDichVu,DichVu where DichVu.MaDV=CTDichVu.MaDV and PhieuThueSan.MaPhieuThue=CTDichVu.MaPhieuThue and PhieuThueSan.MaPhieuThue='" + laymp + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvCTDV.DataSource = dt;
            conn.Close();
        }


        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
