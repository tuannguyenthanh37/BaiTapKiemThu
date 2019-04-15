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
    public partial class FormThongKe : Form
    {
        string strcon = @"server=desktop-jcsiium;database=DBSanCauLong;integrated security=true";
        SqlConnection conn;
        DataSet dts = null;
        SqlDataAdapter dtpCTDV;
        SqlDataAdapter dtpCTTS;
        BindingSource bdsDV = new BindingSource();
        BindingSource bdsS = new BindingSource();
        
        public FormThongKe()
        {
            InitializeComponent();
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strcon);
            DataSet dts = new DataSet("DBSanCauLong");
            dtpCTDV = new SqlDataAdapter("select tendv,soluong,dongia,soluong*dongia as[ThanhTien],ngaythue from dichvu,CTdichvu,Phieuthuesan where dichvu.Madv=CTdichvu.Madv and CTdichvu.MaPhieuthue=Phieuthuesan.MaPhieuthue", strcon);
            dtpCTDV.FillSchema(dts, SchemaType.Source, "ctdichvu");
            dtpCTDV.Fill(dts, "ctdichvu");
            bdsDV.DataSource = dts;
            bdsDV.DataMember = "ctdichvu";
            dgvDTDV.DataSource = bdsDV;
            dgvDTDV.AutoGenerateColumns = false;

            dtpCTTS = new SqlDataAdapter("select phieuthuesan.ngaythue,ctthuesan.masan,sancaulong.tensan,cathue.maca,cathue.giasan from ctthuesan inner join phieuthuesan on ctthuesan.maphieuthue=phieuthuesan.maphieuthue inner join cathue on ctthuesan.maca=cathue.maca inner join sancaulong on sancaulong.masan=ctthuesan.masan", strcon);
            dtpCTTS.FillSchema(dts, SchemaType.Source, "ctthuesan");
            dtpCTTS.Fill(dts, "ctthuesan");
            bdsS.DataSource = dts;
            bdsS.DataMember = "ctthuesan";
            dgvDTSan.DataSource = bdsS;
            dgvDTSan.AutoGenerateColumns = false;

            datengaythue.Value = DateTime.Today;
            datengaythue.Format = DateTimePickerFormat.Short;

            dgvDTSan.RowHeadersVisible = false;
            dgvDTDV.RowHeadersVisible = false;
            dgvDTDV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDTSan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Chế độ mờ txt
            txtDTDVu.Enabled = false;
            txtDTSan.Enabled = false;
            txtDTTP.Enabled = false;

            
        }
        private void tongSan()
        {
            
        }

        private void tongdv()
        {
           
        }

        private void TongDT()
        {
            
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void datengaythue_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
