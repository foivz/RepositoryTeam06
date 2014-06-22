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
    public partial class frmRadnikReport : Form
    {
        int idRadnika;

        public frmRadnikReport()
        {
            InitializeComponent();
        }

        public frmRadnikReport(int idRadnika)
        {
            this.idRadnika = idRadnika;
            InitializeComponent();
        }
      
        private void frmRadnikReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'servisCiscenjeDBDataSet.klijent' table. You can move, or remove it, as needed.
            this.klijentTableAdapter.Fill(this.servisCiscenjeDBDataSet.klijent);
            // TODO: This line of code loads data into the 'servisCiscenjeDBDataSetRadnik.radnici' table. You can move, or remove it, as needed.
            this.radniciTableAdapter.FillByRadnikID(this.servisCiscenjeDBDataSetRadnik.radnici, idRadnika);
            // TODO: This line of code loads data into the 'servisCiscenjeDBDataSetRadnik.posao' table. You can move, or remove it, as needed.
            this.posaoTableAdapter.FillByRadnikID(this.servisCiscenjeDBDataSetRadnik.posao, idRadnika);

            this.reportViewer1.RefreshReport();
        }
    }
}
