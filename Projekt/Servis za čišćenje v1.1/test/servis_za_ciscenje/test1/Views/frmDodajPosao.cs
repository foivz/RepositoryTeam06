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
    public partial class frmDodajPosao : Form
    {
        IPoslovnaLogika logika = new Logika();
        PomocnaKlasa pomocna = new PomocnaKlasa();
        DataGridViewRow row;
        DateTime date;
        public List<int> listaRadnika = new List<int>();
        public List<int> listaUsluga = new List<int>();
        public List<int> listaVozila = new List<int>();

        public frmDodajPosao()
        {
            InitializeComponent();
        }

        public frmDodajPosao(DataGridViewRow row, DateTime date)
        {
            this.row = row;
            this.date = date;
            InitializeComponent();
        }

        public string Cijena
        {
            set { tbxCijena.Text = value; }
        }

        public string Tip
        {
            get { return cmbTip.Text; }
        }

        public string Kvadratura 
        {
            get { return tbxKvadratura.Text; }
        }

        public string Adresa 
        {
            set { tbxAdresa.Text = value; }
        }

        private void frmDodajPosao_Load(object sender, EventArgs e)
        {
            //Upis textboxa za datum
            tbxDate.Text = date.ToShortDateString();

            //Upis textboxa za vrijeme
            tbxVrijeme.Text =  row.Cells[0].Value.ToString();

            //Bind comboboxa za klijenta
            cmbKlijent.DataSource = logika.DohvatiKlijente();

            //Bind comboboxa za tip usluge
            cmbTip.DataSource = pomocna.DohvatiTipPosla();

            //Bind comboboxa za trajanje
            cmbTrajanje.DataSource = pomocna.DohvatiTrajanje();

            //Bind comboboxa za zakazivanje termina unaprijed
            cmbZakazi.DataSource = pomocna.DohvatiUnaprijed();
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logika.dodajPosao(tbxDate.Text, tbxVrijeme.Text, tbxAdresa.Text, tbxKvadratura.Text, cmbTip.Text, tbxCijena.Text, cmbKlijent.Text, listaUsluga, listaRadnika, listaVozila, cmbTrajanje.Text, cmbZakazi.Text);
        }

        private void btnOdabirUsluga_Click(object sender, EventArgs e)
        {
            frmOdaberiUsluge frmOdaberiUsluge = new frmOdaberiUsluge(this);
            frmOdaberiUsluge.ShowDialog();

            logika.OsvjeziDataGridOusluzi(dataGridView1, listaUsluga);
        }

        private void btnOdabirRadnika_Click(object sender, EventArgs e)
        {
            frmOdaberiRadnike frmOdaberiRadnike = new frmOdaberiRadnike(this);
            frmOdaberiRadnike.ShowDialog();
        }

        private void btnOdabirVozila_Click(object sender, EventArgs e)
        {
            frmOdaberiVozila frmOdaberiVozila = new frmOdaberiVozila(this);
            frmOdaberiVozila.ShowDialog();
        }

        private void tbxKvadratura_TextChanged(object sender, EventArgs e)
        {
            if (listaUsluga.Count != 0)
            {
                logika.IzracunCijene(this);
            }
            
        }

        private void cmbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaUsluga.Count != 0)
            {
                logika.IzracunCijene(this);
            }
        }

        private void cmbKlijent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKlijent.Text != "")
            {
                logika.dajAdresu(this, cmbKlijent.Text);
            }
           
        }
    }
}
