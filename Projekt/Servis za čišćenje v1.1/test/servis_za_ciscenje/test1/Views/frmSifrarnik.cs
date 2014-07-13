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
    public partial class frmSifrarnik : Form
    {
        IPoslovnaLogika logika = new Logika();

        public frmSifrarnik()
        {
            InitializeComponent();
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (tctSifarnik.SelectedTab.Name.Equals("tabVozila"))
            {
                frmDodajVozilo frmDodajVozilo = new frmDodajVozilo();
                frmDodajVozilo.ShowDialog();

                dgdVozila.DataSource = logika.BindDgdVozila();
                RepairDgdVozila();
                
            }
            else if (tctSifarnik.SelectedTab.Name.Equals("tabKlijenti"))
            {
                frmDodajKlijenta frmDodajKlijenta = new frmDodajKlijenta();
                frmDodajKlijenta.ShowDialog();

                dgdKlijenti.DataSource = logika.BindDgdKlijenti();
                RepairDgdKlijenit();
            }
            else if (tctSifarnik.SelectedTab.Name.Equals("tabUsluge"))
            {
                frmDodajUslugu frmDodajUslugu = new frmDodajUslugu();
                frmDodajUslugu.ShowDialog();

                dgdUsluge.DataSource = logika.BindDgdUsluga();
                RepairDgdUsluge();

            }
            else if (tctSifarnik.SelectedTab.Name.Equals("tabRadnici"))
            {
                frmDodajRadnika frmDodajRadnika = new frmDodajRadnika();
                frmDodajRadnika.ShowDialog();

                dgdRadnici.DataSource = logika.BindDgdRadnici();
                RepairDgdRadnici();
            }
        }

        private void frmSifrarnik_Load(object sender, EventArgs e)
        {
            //bind datagrid vozila
            dgdVozila.DataSource = logika.BindDgdVozila();
            RepairDgdVozila();

            //bind datagrid klijenata
            dgdKlijenti.DataSource = logika.BindDgdKlijenti();
            RepairDgdKlijenit();

            //bind datagrid usluga
            dgdUsluge.DataSource = logika.BindDgdUsluga();
            RepairDgdUsluge();

            //bind datagrid radnika
            dgdRadnici.DataSource = logika.BindDgdRadnici();
            RepairDgdRadnici();


        }

        private void btnBrisi_Click(object sender, EventArgs e)
        {
            if (tctSifarnik.SelectedTab.Name.Equals("tabVozila"))
            {
                var odabraniRed = dgdVozila.SelectedRows;

                DataGridViewRow row = null;
                foreach (var item in odabraniRed)
                {
                    row = (DataGridViewRow)item;
                }
                logika.brisiVozilo(row);

                dgdVozila.DataSource = logika.BindDgdVozila();
                RepairDgdVozila();
            }
            else if (tctSifarnik.SelectedTab.Name.Equals("tabKlijenti"))
            {
                var odabraniRed = dgdKlijenti.SelectedRows;

                DataGridViewRow row = null;
                foreach (var item in odabraniRed)
                {
                    row = (DataGridViewRow)item;
                }
                logika.brisiKlijenta(row);

                dgdKlijenti.DataSource = logika.BindDgdKlijenti();
                RepairDgdKlijenit();

            }
            else if (tctSifarnik.SelectedTab.Name.Equals("tabUsluge"))
            {
                var odabraniRed = dgdUsluge.SelectedRows;

                DataGridViewRow row = null;
                foreach (var item in odabraniRed)
                {
                    row = (DataGridViewRow)item;
                }
                logika.brisiUslugu(row);

                dgdUsluge.DataSource = logika.BindDgdUsluga();
                RepairDgdUsluge();
            }
            else if (tctSifarnik.SelectedTab.Name.Equals("tabRadnici"))
            {
                var odabraniRed = dgdRadnici.SelectedRows;

                DataGridViewRow row = null;
                foreach (var item in odabraniRed)
                {
                    row = (DataGridViewRow)item;
                }
                logika.brisiRadnika(row);

                dgdRadnici.DataSource = logika.BindDgdRadnici();
                RepairDgdRadnici();
            }

           

        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            if (tctSifarnik.SelectedTab.Name.Equals("tabVozila"))
            {
                var odabraniRed = dgdVozila.SelectedRows;

                DataGridViewRow row = null;
                foreach (var item in odabraniRed)
                {
                    row = (DataGridViewRow)item;
                }

                if (row!=null)
                {
                    frmAzurirajVozilo frmAzurirajVozilo = new frmAzurirajVozilo(row);
                    frmAzurirajVozilo.ShowDialog();

                    dgdVozila.DataSource = logika.BindDgdVozila();
                   
                    RepairDgdVozila();
                }
            }
            else if (tctSifarnik.SelectedTab.Name.Equals("tabKlijenti"))
            {
                var odabraniRed = dgdKlijenti.SelectedRows;

                DataGridViewRow row = null;
                foreach (var item in odabraniRed)
                {
                    row = (DataGridViewRow)item;
                }

                if (row != null)
                {
                    frmAzurirajKlijenta frmAzurirajKlijenta = new frmAzurirajKlijenta(row);
                    frmAzurirajKlijenta.ShowDialog();

                    dgdKlijenti.DataSource = logika.BindDgdKlijenti();
                    RepairDgdKlijenit();


                }
          
            }
            else if (tctSifarnik.SelectedTab.Name.Equals("tabUsluge"))
            {
                var odabraniRed = dgdUsluge.SelectedRows;

                DataGridViewRow row = null;
                foreach (var item in odabraniRed)
                {
                    row = (DataGridViewRow)item;
                }

                if (row != null)
                {
                    frmAzurirajUslugu frmAzurirajUslugu = new frmAzurirajUslugu(row);
                    frmAzurirajUslugu.ShowDialog();

                    dgdUsluge.DataSource = logika.BindDgdUsluga();
                    RepairDgdUsluge();
                }

                
            }
            else if (tctSifarnik.SelectedTab.Name.Equals("tabRadnici"))
            {
                var odabraniRed = dgdRadnici.SelectedRows;

                DataGridViewRow row = null;
                foreach (var item in odabraniRed)
                {
                    row = (DataGridViewRow)item;
                }

                if (row != null)
                {
                    frmAzurirajRadnika frmAzurirajRadnika= new frmAzurirajRadnika(row);
                    frmAzurirajRadnika.ShowDialog();

                    dgdRadnici.DataSource = logika.BindDgdRadnici();
                    RepairDgdRadnici();
                }
            }
        }


        private void RepairDgdVozila() {
            dgdVozila.Columns[0].Visible = false;
            dgdVozila.Columns[1].HeaderText = "Registracijska oznaka";
            dgdVozila.Columns[2].HeaderText = "Model";
            dgdVozila.Columns[3].Visible = false;
        }

        private void RepairDgdKlijenit() {
            dgdKlijenti.Columns[0].Visible = false;
            dgdKlijenti.Columns[1].HeaderText = "Adresa";
            dgdKlijenti.Columns[2].HeaderText = "Kontakt";
            dgdKlijenti.Columns[3].HeaderText = "Naziv";
            dgdKlijenti.Columns[4].HeaderText = "Email";
            dgdKlijenti.Columns[5].Visible = false;
            dgdKlijenti.Columns[6].Visible = false;
            dgdKlijenti.Columns[7].HeaderText = "Primanje obavijesti";
            dgdKlijenti.Columns[8].Visible = false;
        }

        private void RepairDgdUsluge() {
            dgdUsluge.Columns[0].Visible = false;
            dgdUsluge.Columns[1].HeaderText = "Naziv";
            dgdUsluge.Columns[2].HeaderText = "Cijena/m2";
            dgdUsluge.Columns[3].Visible = false;
        }

        private void RepairDgdRadnici() {
            dgdRadnici.Columns[0].Visible = false;
            dgdRadnici.Columns[1].HeaderText = "Ime";
            dgdRadnici.Columns[2].HeaderText = "Prezime";
            dgdRadnici.Columns[3].HeaderText = "Broj telefona";
            dgdRadnici.Columns[4].Visible = false;
        }

    }
}
