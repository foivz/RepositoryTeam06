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
    public partial class frmOdaberiRadnikeAzuriraj : Form
    {
        IPoslovnaLogika logika = new Logika();
        frmAzurirajPosao f;
        DataGridViewRow row;

        public frmOdaberiRadnikeAzuriraj()
        {
            InitializeComponent();
        }

        public frmOdaberiRadnikeAzuriraj(frmAzurirajPosao f, DataGridViewRow row)
        {
            this.f = f;
            this.row = row;
            InitializeComponent();
        }

        private void frmOdaberiRadnikeAzuriraj_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = logika.BindDgdRadnici();
            logika.PripremiDataGridOdaberiRadnikeZaAzuriranje(dataGridView1, f, row);
        }

        private void btnOdaberi_Click(object sender, EventArgs e)
        {
            f.listaRadnika = logika.DohvatiOdabraneRadnike(dataGridView1);
            if (f.listaRadnika.Count.Equals(0))
            {
                MessageBox.Show("Odaberite barem jednog radnika.");
            }
            else
            {
                this.Close();
            }
        }
    }
}
