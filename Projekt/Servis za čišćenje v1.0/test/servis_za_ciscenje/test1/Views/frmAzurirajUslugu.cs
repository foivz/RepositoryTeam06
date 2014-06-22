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
    public partial class frmAzurirajUslugu : Form
    {
        IPoslovnaLogika logika = new Logika();
        private DataGridViewRow row;

        public frmAzurirajUslugu()
        {
            InitializeComponent();
        }

        public frmAzurirajUslugu(DataGridViewRow row)
        {
            this.row = row;
            InitializeComponent();
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            logika.azurirajUslugu(row, tbxNaziv.Text, tbxFaktor.Text);
        }

        private void frmAzurirajUslugu_Load(object sender, EventArgs e)
        {
            if (row!=null)
            {
                logika.getPodaciUsluga(row, this);
            }
        }
    }
}
