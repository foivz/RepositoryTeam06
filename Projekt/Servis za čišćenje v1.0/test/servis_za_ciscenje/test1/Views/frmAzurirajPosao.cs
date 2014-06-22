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
    public partial class frmAzurirajPosao : Form
    {
        IPoslovnaLogika logika = new Logika();
        PomocnaKlasa pomocna = new PomocnaKlasa();
        DataGridViewRow row;
        public List<int> listaRadnika = new List<int>();
        public List<int> listaUsluga = new List<int>();
        public List<int> listaVozila = new List<int>();

        public frmAzurirajPosao()
        {
            InitializeComponent();
        }

        public frmAzurirajPosao(DataGridViewRow row)
        {
            this.row = row;
            InitializeComponent();
        }

        //propertyi za pristup kontrolama
        public string Datum 
        {
            set { tbxDate.Text = value; }    
        }
        public string Vrijeme 
        {
            set { cmbTermini.SelectedItem = value; }
        }
        public string Adresa
        {
            set { tbxAdresa.Text = value; }
        }
        public string Kvadratura 
        {
            set { tbxKvadratura.Text = value; }
        }
        public string TipPosla
        {
            set { cmbTip.SelectedItem = value;  }
        }
        public string Klijent
        {
            set { cmbKlijent.SelectedItem = value; }
        }
        public string TrajanjePosla
        {
            set { cmbTrajanje.SelectedItem = value; }
        }
        public string Cijena
        {
            set { tbxCijena.Text = value; }
        }
        //**********************************************************

 
        public string TipGet
        {
            get { return cmbTip.Text; }
        }

        public string KvadraturaGet
        {
            get { return tbxKvadratura.Text; }
        }

        private void frmAzurirajPosao_Load(object sender, EventArgs e)
        {
            //Bind comboboxa za klijenta
            cmbKlijent.DataSource = logika.DohvatiKlijente();

            //Bind comboboxa za tip usluge
            cmbTip.DataSource = pomocna.DohvatiTipPosla();

            //Bind comboboxa za trajanje
            cmbTrajanje.DataSource = pomocna.DohvatiTrajanje();

            //Bind comboboxa za termine
            cmbTermini.DataSource = pomocna.DohvatiTermineZaAzuriranje();

            logika.PreuzmiPodatkeOPoslu(row, this);

            logika.PreuzmiListuRadnika(row, this);
            logika.PreuzmiListuUsluga(row, this);
            logika.PreuzmiListuVozila(row, this);

            logika.OsvjeziDataGridOusluzi(dataGridView1, listaUsluga);

        }

        private void btnOdabirUsluga_Click(object sender, EventArgs e)
        {
            frmOdaberiUslugeAzuriraj frmOdaberiUslugeAzuriraj = new frmOdaberiUslugeAzuriraj(this, row);
            frmOdaberiUslugeAzuriraj.ShowDialog();

            logika.OsvjeziDataGridOusluzi(dataGridView1, listaUsluga);
        }

        private void btnOdabirRadnika_Click(object sender, EventArgs e)
        {
            frmOdaberiRadnikeAzuriraj frmOdaberiRadnikeAzuriraj = new frmOdaberiRadnikeAzuriraj(this, row);
            frmOdaberiRadnikeAzuriraj.ShowDialog();
        }

        private void btnOdabirVozila_Click(object sender, EventArgs e)
        {
            frmOdaberiVozilaAzuriraj frmOdaberiVozilaAzuriraj = new frmOdaberiVozilaAzuriraj(this, row);
            frmOdaberiVozilaAzuriraj.ShowDialog();
        }

        private void tbxKvadratura_TextChanged(object sender, EventArgs e)
        {
            if (listaUsluga.Count != 0)
            {
                logika.IzracunCijeneKodAzuriranja(this);
            }
        }

        private void cmbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaUsluga.Count != 0)
            {
                logika.IzracunCijeneKodAzuriranja(this);
            }
        }

        private void btnAzurirajPosao_Click(object sender, EventArgs e)
        {
            object test = row.Cells[5].Value;
            if (test != null)
            {
                logika.azurirajPosao(row, tbxDate.Text, cmbTermini.Text, tbxAdresa.Text, tbxKvadratura.Text, cmbTip.Text, tbxCijena.Text, cmbKlijent.Text, listaUsluga, listaRadnika, listaVozila, cmbTrajanje.Text);
            }
        }

        private void cmbKlijent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKlijent.Text != "")
            {
                logika.dajAdresuAzuriranje(this, cmbKlijent.Text);
            }
        }
    }
}
