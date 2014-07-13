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
    public partial class frmOdaberiUsluge : Form
    {
        IPoslovnaLogika logika = new Logika();
        frmDodajPosao f;

        public frmOdaberiUsluge()
        {
            InitializeComponent();
        }

        public frmOdaberiUsluge(frmDodajPosao f)
        {
            this.f = f;
            InitializeComponent();
        }

        private void frmOdaberiUsluge_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = logika.BindDgdUsluga();
            logika.PripremiDataGridOdaberiUsluge(dataGridView1, f);
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
                logika.IzracunCijene(f);
                this.Close();
            }
        }
    }
}
