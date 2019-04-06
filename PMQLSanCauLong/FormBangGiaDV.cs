using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace PMQLSanCauLong
{
    public partial class FormBangGiaDV : Form
    {
        

        public FormBangGiaDV()
        {
            InitializeComponent();
        }

        private void FormBangGiaDV_Load(object sender, EventArgs e)
        {
            
        }
        public void GanDK(DataGridViewRow r)
        {
            try
            {
                txtTenHH.Text = r.Cells[1].Value.ToString();
                txtDVT.Text = r.Cells[2].Value.ToString();
                txtDongia.Text = r.Cells[3].Value.ToString();
            }
            catch
            {
                return;
            }

        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            
        }

        private void btnKhongDV_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGhiDV_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            
        }


    }
}
