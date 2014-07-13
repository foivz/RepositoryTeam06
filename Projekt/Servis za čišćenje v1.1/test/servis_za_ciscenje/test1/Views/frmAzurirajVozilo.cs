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
    public partial class frmAzurirajVozilo : Form
    {
        private DataGridViewRow row;
        IPoslovnaLogika logika = new Logika();

        public frmAzurirajVozilo()
        {
            InitializeComponent();
        }

        public frmAzurirajVozilo(DataGridViewRow row)
        {
            this.row = row;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            logika.azurirajVozilo(row, tbxRegOznaka.Text, tbxModel.Text);
        }

        private void frmAzurirajVozilo_Load(object sender, EventArgs e)
        {
            if (row != null)
            {
                logika.getPodaciVozilo(row, this);
            }
        }
    }
}
