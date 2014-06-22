using servis_za_ciscenje.Sloj_logike;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace servis_za_ciscenje.Views
{
    public partial class frmPDFforma : Form
    {
        IPoslovnaLogika logika = new Logika();

        public frmPDFforma()
        {
            InitializeComponent();
        }

        private void btnGenerirajPDF_Click(object sender, EventArgs e)
        {
            int id = (int)cmbRadnici.SelectedValue;

            frmRadnikReport frmRadnikReport = new frmRadnikReport(id);
            frmRadnikReport.ShowDialog();
           
        }

        private void frmPDFforma_Load(object sender, EventArgs e)
        {
            cmbRadnici.DataSource = logika.GetRadnici();
            cmbRadnici.DisplayMember = "ImePrezime";
            cmbRadnici.ValueMember = "ID";
        }
    }
}
