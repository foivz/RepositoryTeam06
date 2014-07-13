using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using servis_za_ciscenje.Views;
using servis_za_ciscenje.Sloj_logike;
using System.Diagnostics;

namespace servis_za_ciscenje
{
    public partial class frmMain : Form
    {
        IPoslovnaLogika logika = new Logika();

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
            frmDayView prikazDana = new frmDayView(e.Start, calKalendar);
            prikazDana.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // onemogucavanje multiple selecta na kalendaru
            calKalendar.MaxSelectionCount = 1;

            calKalendar.BoldedDates = logika.VratiZauzeteDatume();
        }

        private void btnRacuni_Click(object sender, EventArgs e)
        {
            //frmRacuni rac = new frmRacuni();
            //rac.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin newLogin = new frmLogin();
            newLogin.Show();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {

            frmPDFforma frmPdfForma = new frmPDFforma();
            frmPdfForma.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            Process.Start(path+@"\"+ "Help.html");
            
        }

        
    }
}
