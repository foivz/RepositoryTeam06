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
    public partial class frmOdaberiUslugeAzuriraj : Form
    {
        IPoslovnaLogika logika = new Logika();
        frmAzurirajPosao f;
        DataGridViewRow row;

        public frmOdaberiUslugeAzuriraj()
        {
            InitializeComponent();
        }

        public frmOdaberiUslugeAzuriraj(frmAzurirajPosao f, DataGridViewRow row)
        {
            this.row = row;
            this.f = f;
            InitializeComponent();
        }

        private void frmOdaberiUslugeAzuriraj_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = logika.BindDgdUsluga();
            logika.PripremiDataGridOdaberiUslugeZaAzuriranje(dataGridView1, f, row);
        }

        private void btnOdaberi_Click(object sender, EventArgs e)
        {
            f.listaUsluga = logika.DohvatiOdabraneUsluge(dataGridView1);
            if (f.listaUsluga.Count.Equals(0))
            {
                MessageBox.Show("Odaberite barem jednu uslugu.");
            }
            else
            {
                logika.IzracunCijeneKodAzuriranja(f);
                this.Close();
            }
        }
    }
}
