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
