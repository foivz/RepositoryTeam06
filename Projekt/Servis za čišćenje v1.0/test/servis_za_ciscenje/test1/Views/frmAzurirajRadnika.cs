using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using servis_za_ciscenje.Sloj_logike;

namespace servis_za_ciscenje.Views
{
    public partial class frmAzurirajRadnika : Form
    {
        private DataGridViewRow row;
        IPoslovnaLogika logika = new Logika();

        public frmAzurirajRadnika()
        {
            InitializeComponent();
        }

        public frmAzurirajRadnika(DataGridViewRow row) {
            InitializeComponent();
            this.row = row;
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            logika.azurirajRadnika(row, tbxIme.Text, tbxPrezime.Text, tbxBrojTelefona.Text);
        }

        private void frmAzurirajRadnika_Load(object sender, EventArgs e)
        {
            if (row!=null)
            {
                logika.getPodaciRadnik(row, this);
            }
        }
    }
}
