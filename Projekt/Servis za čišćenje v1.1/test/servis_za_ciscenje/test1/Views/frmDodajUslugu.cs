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
    public partial class frmDodajUslugu : Form
    {
        IPoslovnaLogika logika = new Logika();

        public frmDodajUslugu()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            logika.dodajUslugu(tbxNaziv.Text, tbxCijena.Text);
        }
    }
}
