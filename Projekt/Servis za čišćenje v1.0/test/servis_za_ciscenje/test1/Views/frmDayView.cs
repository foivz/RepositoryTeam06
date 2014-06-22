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
    public partial class frmDayView : Form
    {
        private DateTime dan;
        MonthCalendar cal;
        PomocnaKlasa pomocna = new PomocnaKlasa();
        IPoslovnaLogika logika = new Logika();

        public frmDayView()
        {
            InitializeComponent();
        }

        public frmDayView(DateTime dan, MonthCalendar cal)
        {
            this.dan = dan;
            this.cal = cal;
            InitializeComponent();
        }

        /*Propertyi za bindanje comboboxa*/
        public BindingSource Cmb0
        {
            set { cmb0.DataSource = value; }
        }
        public BindingSource Cmb1
        {
            set { cmb1.DataSource = value; }
        }
        public BindingSource Cmb2
        {
            set { cmb2.DataSource = value; }
        }
        public BindingSource Cmb3
        {
            set { cmb3.DataSource = value; }
        }
        public BindingSource Cmb4
        {
            set { cmb4.DataSource = value; }
        }
        public BindingSource Cmb5
        {
            set { cmb5.DataSource = value; }
        }
        public BindingSource Cmb6
        {
            set { cmb6.DataSource = value; }
        }
        public BindingSource Cmb7
        {
            set { cmb7.DataSource = value; }
        }
        public BindingSource Cmb8
        {
            set { cmb8.DataSource = value; }
        }
        public BindingSource Cmb9
        {
            set { cmb9.DataSource = value; }
        }
        public BindingSource Cmb10
        {
            set { cmb10.DataSource = value; }
        }
        public BindingSource Cmb11
        {
            set { cmb11.DataSource = value; }
        }

        /*Propertyi za dobivanje cmb vrijednosti*/
        public object Cmb0Text
        {
            get { return cmb0.SelectedValue; }
        }
        public object Cmb1Text
        {

            get { return cmb1.SelectedValue; }
        }
        public object Cmb2Text
        {
            get { return cmb2.SelectedValue; }
        }
        public object Cmb3Text
        {
            get { return cmb3.SelectedValue; }
        }
        public object Cmb4Text
        {
            get { return cmb4.SelectedValue; }
        }
        public object Cmb5Text
        {
            get { return cmb5.SelectedValue; }
        }
        public object Cmb6Text
        {
            get { return cmb6.SelectedValue; }
        }
        public object Cmb7Text
        {
            get { return cmb7.SelectedValue; }
        }
        public object Cmb8Text
        {
            get { return cmb8.SelectedValue; }
        }
        public object Cmb9Text
        {
            get { return cmb9.SelectedValue; }
        }
        public object Cmb10Text
        {
            get { return cmb10.SelectedValue; }
        }
        public object Cmb11Text
        {
            get { return cmb11.SelectedValue; }
        }

        public string Datum
        {
            get { return tbxDatum.Text; }
        }

        private void frmDayView_Load(object sender, EventArgs e)
        {
            //zapisivanje odabranog datuma na vrhu forme
            tbxDatum.Text = dan.Date.ToShortDateString();
            //BindDataGrida
            BindingSource bs = new BindingSource();
            bs.DataSource = pomocna.DohvatiTermine();

            dataGridView1.DataSource = bs;

            logika.PripremiDataGridPopisPoslova(dataGridView1, this, tbxDatum.Text);

            foreach (Control x in this.Controls)
            {
                if (x is ComboBox)
                {
                    ((ComboBox)x).DisplayMember = "Adresa";
                    ((ComboBox)x).ValueMember = "ID";
                }
            }


            // logika.PoveziCmbxSaDataGridom(dataGridView1, this);

        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var odabraniRed = dataGridView1.SelectedRows;

            DataGridViewRow row = null;
            foreach (var item in odabraniRed)
            {
                row = (DataGridViewRow)item;
            }

            frmDodajPosao frmDodajPosao = new frmDodajPosao(row, dan);
            frmDodajPosao.ShowDialog();

            BindingSource bs = new BindingSource();
            bs.DataSource = pomocna.DohvatiTermine();

            dataGridView1.DataSource = bs;

            foreach (Control x in this.Controls)
            {
                if (x is ComboBox)
                {
                    ((ComboBox)x).DataSource = null;
                }
            }

            logika.PripremiDataGridPopisPoslova(dataGridView1, this, tbxDatum.Text);

            foreach (Control x in this.Controls)
            {
                if (x is ComboBox)
                {
                    ((ComboBox)x).DisplayMember = "Adresa";
                    ((ComboBox)x).ValueMember = "ID";
                }
            }

            logika.PoveziCmbxSaDataGridom(dataGridView1, this);

            logika.OsvjeziKalendar(cal);

        }

        private void cmb0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb0Text != null)
            {
                logika.PoveziCmbxSaDataGridom(dataGridView1, this);
            }

        }

        private void cmb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb2Text != null)
            {
                logika.PoveziCmbxSaDataGridom(dataGridView1, this);
            }

        }

        private void cmb3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb3Text != null)
            {
                logika.PoveziCmbxSaDataGridom(dataGridView1, this);
            }

        }

        private void cmb4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb4Text != null)
            {
                logika.PoveziCmbxSaDataGridom(dataGridView1, this);
            }

        }

        private void cmb5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb5Text != null)
            {
                logika.PoveziCmbxSaDataGridom(dataGridView1, this);
            }

        }

        private void cmb6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb6Text != null)
            {
                logika.PoveziCmbxSaDataGridom(dataGridView1, this);
            }

        }

        private void cmb7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb7Text != null)
            {
                logika.PoveziCmbxSaDataGridom(dataGridView1, this);
            }
            // 
        }

        private void cmb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb1Text != null)
            {
                logika.PoveziCmbxSaDataGridom(dataGridView1, this);
            }
            // 
        }

        private void cmb8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb8Text != null)
            {
                logika.PoveziCmbxSaDataGridom(dataGridView1, this);
            }
            // 
        }

        private void cmb9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb9Text != null)
            {
                logika.PoveziCmbxSaDataGridom(dataGridView1, this);
            }

        }

        private void cmb11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb11Text != null)
            {
                logika.PoveziCmbxSaDataGridom(dataGridView1, this);
            }

        }

        private void cmb10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb10Text != null)
            {
                logika.PoveziCmbxSaDataGridom(dataGridView1, this);
            }

        }

        private void btnIzbrisi_Click(object sender, EventArgs e)
        {
            var odabraniRed = dataGridView1.SelectedRows;

            DataGridViewRow row = null;
            foreach (var item in odabraniRed)
            {
                row = (DataGridViewRow)item;
            }

            object test = row.Cells[1].Value;
            if (test != null)
            {
                logika.brisiPosao(row);

                BindingSource bs = new BindingSource();
                bs.DataSource = pomocna.DohvatiTermine();

                dataGridView1.DataSource = bs;


                foreach (Control x in this.Controls)
                {
                    if (x is ComboBox)
                    {
                        ((ComboBox)x).DataSource = null;
                    }
                }


                logika.PripremiDataGridPopisPoslova(dataGridView1, this, tbxDatum.Text);

                foreach (Control x in this.Controls)
                {
                    if (x is ComboBox)
                    {
                        ((ComboBox)x).DisplayMember = "Adresa";
                        ((ComboBox)x).ValueMember = "ID";
                    }
                }

                logika.PoveziCmbxSaDataGridom(dataGridView1, this);
                logika.OsvjeziKalendar(cal);
            }



        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            var odabraniRed = dataGridView1.SelectedRows;

            DataGridViewRow row = null;
            foreach (var item in odabraniRed)
            {
                row = (DataGridViewRow)item;
            }

            object test = row.Cells[1].Value;
            if (test != null)
            {

                frmAzurirajPosao frmAzurirajPosao = new Views.frmAzurirajPosao(row);
                frmAzurirajPosao.ShowDialog();

                BindingSource bs = new BindingSource();
                bs.DataSource = pomocna.DohvatiTermine();

                dataGridView1.DataSource = bs;

                foreach (Control x in this.Controls)
                {
                    if (x is ComboBox)
                    {
                        ((ComboBox)x).DataSource = null;
                    }
                }


                logika.PripremiDataGridPopisPoslova(dataGridView1, this, tbxDatum.Text);

                foreach (Control x in this.Controls)
                {
                    if (x is ComboBox)
                    {
                        ((ComboBox)x).DisplayMember = "Adresa";
                        ((ComboBox)x).ValueMember = "ID";
                    }
                }

                logika.PoveziCmbxSaDataGridom(dataGridView1, this);
                logika.OsvjeziKalendar(cal);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var odabraniRed = dataGridView1.SelectedRows;

            DataGridViewRow row = null;
            foreach (var item in odabraniRed)
            {
                row = (DataGridViewRow)item;
            }

            string id = row.Cells[5].Value.ToString();
            int idPosla = Convert.ToInt32(id);
            if (!idPosla.Equals(0))
            {
                string naziv = row.Cells[4].Value.ToString();

                frmRacun frmRacun = new frmRacun(idPosla, naziv);
                frmRacun.ShowDialog();
            }





        }
    }
}
