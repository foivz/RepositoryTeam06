using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using servis_za_ciscenje.Views;

namespace servis_za_ciscenje
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCloseMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSifrarnik_Click(object sender, EventArgs e)
        {
            // prikaži formu za šifarnik
            frmSifrarnik newSifrarnik = new frmSifrarnik();
            newSifrarnik.Show();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {            
            //Prosljedjivanje datuma formi za dnevni prikaz termina
            frmDayView prikazDana = new frmDayView(e.Start);
            prikazDana.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // onemogucavanje multiple selecta na kalendaru
            calKalendar.MaxSelectionCount = 1;

            //Preuzmi termine iz baze i oznaci dane s terminima

            //Test
            DateTime dt1 = new DateTime(2014, 4, 15);
            DateTime dt2 = new DateTime(2014, 4, 18);

            DateTime[] absentDates = { dt1, dt2};
            calKalendar.BoldedDates = absentDates;
        }

        private void btnRacuni_Click(object sender, EventArgs e)
        {
            frmRacuni rac = new frmRacuni();
            rac.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin newLogin = new frmLogin();
            newLogin.Show();
        }

        
    }
}
