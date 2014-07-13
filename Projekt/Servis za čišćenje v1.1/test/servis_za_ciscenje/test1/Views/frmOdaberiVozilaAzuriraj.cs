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
    public partial class frmOdaberiVozilaAzuriraj : Form
    {
        IPoslovnaLogika logika = new Logika();
        frmAzurirajPosao f;
        DataGridViewRow row;

        public frmOdaberiVozilaAzuriraj()
        {
            InitializeComponent();
        }

        public frmOdaberiVozilaAzuriraj(frmAzurirajPosao f, DataGridViewRow row)
        {
            this.f = f;
            this.row = row;
            InitializeComponent();
        }

        private void frmOdaberiVozilaAzuriraj_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = logika.BindDgdVozila();
            logika.PripremiDataGridOdaberiVozilaZaAzuriranje(dataGridView1, f, row);
        }

        private void btnOdabir_Click(object sender, EventArgs e)
        {
            f.listaVozila = logika.DohvatiOdabranaVozila(dataGridView1);
            if (f.listaVozila.Count.Equals(0))
            {
                MessageBox.Show("Odaberite barem jedno vozilo.");
            }
            else
            {
                this.Close();
            }
        }
    }
}
