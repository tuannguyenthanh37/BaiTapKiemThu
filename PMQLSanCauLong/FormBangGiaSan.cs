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
    public partial class FormBangGiaSan : Form
    {
        //ghi chu
        string strcon = @"server=desktop-jcsiium;database=DBSanCauLong;integrated security=true";
        SqlConnection conn;
        SqlDataAdapter dtpSCL;

        DataSet dts = new DataSet();
        BindingSource bdsCT = new BindingSource();

        public FormBangGiaSan()
        {
            InitializeComponent();
        }

        private void FormBangGiaSan_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strcon);
            dtpSCL = new SqlDataAdapter("select * from cathue", strcon);
            dtpSCL.FillSchema(dts, SchemaType.Source, "cathue");
            dtpSCL.Fill(dts, "cathue");
            bdsCT.DataSource = dts;
            bdsCT.DataMember = "cathue";
            dgvThogTinSan.DataSource = bdsCT;
            dgvThogTinSan.DataSource = bdsCT;
            dgvThogTinSan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThogTinSan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //thiết lập k cho phép ng` dùng thay đổi kích thước
            dgvThogTinSan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvThogTinSan.RowHeadersVisible = false;
            dgvThogTinSan.Rows[0].Selected = true;

            btnGhi.Visible = false;
            btnKhong.Visible = false;
            txtGiaSan.Enabled = false;
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            btnGhi.Visible = false;
            btnKhong.Visible = false;
            btnSua.Visible = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnGhi.Visible = true;
            btnKhong.Visible = true;
            btnSua.Visible = false;
            txtGiaSan.Enabled = true;
            txtGiaSan.Focus();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            txtGiaSan.Enabled = false;
            btnGhi.Visible = false;
            btnKhong.Visible = false;
            btnSua.Visible = true;
        }
    }
}
