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
    public partial class frmOdaberiRadnike : Form
    {
        IPoslovnaLogika logika = new Logika();
        frmDodajPosao f;

        public frmOdaberiRadnike()
        {
            InitializeComponent();
        }
        public frmOdaberiRadnike(frmDodajPosao f)
        {
            this.f = f;
            InitializeComponent();
        }

        private void frmOdaberiRadnike_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = logika.BindDgdRadnici();
            logika.PripremiDataGridOdaberiRadnike(dataGridView1, f);
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
