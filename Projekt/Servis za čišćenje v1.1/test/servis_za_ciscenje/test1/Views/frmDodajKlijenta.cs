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
    public partial class frmDodajKlijenta : Form
    {
        IPoslovnaLogika logika = new Logika();

        public frmDodajKlijenta()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            logika.dodajKlijenta(tbxAdresa.Text, tbxKontakt.Text, tbxNaziv.Text, tbxEmail.Text, checkBox1.Checked);
        }
    }
}
