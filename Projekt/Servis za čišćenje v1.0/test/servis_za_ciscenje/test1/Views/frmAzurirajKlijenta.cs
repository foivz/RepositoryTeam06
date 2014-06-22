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
    public partial class frmAzurirajKlijenta : Form
    {
        private DataGridViewRow row;
        IPoslovnaLogika logika = new Logika();

        public frmAzurirajKlijenta()
        {
            InitializeComponent();
        }

        public frmAzurirajKlijenta(DataGridViewRow row)
        {
            this.row = row;
            InitializeComponent();
        }


        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            logika.azurirajKlijenta(row, tbxAdresa.Text, tbxKontakt.Text, tbxNaziv.Text, tbxEmail.Text, checkBox1.Checked);
        }

        private void frmAzurirajKlijenta_Load(object sender, EventArgs e)
        {
            if (row != null)
            {
                logika.getPodaciKlijent(row, this);
            }
        }



    }
}
