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
    public partial class frmDodajRadnika : Form
    {
        IPoslovnaLogika logika = new Logika();

        public frmDodajRadnika()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            logika.dodajRadnika(tbxIme.Text, tbxPrezime.Text, tbxBrojTelefona.Text);
        }
    }
}
