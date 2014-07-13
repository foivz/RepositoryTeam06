using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using servis_za_ciscenje.SlojPodataka;


namespace servis_za_ciscenje.Views
{
    public partial class frmRacun : Form
    {
        int idPosla;
        string naziv;
        private ServisCiscenjeDBEntities db = new ServisCiscenjeDBEntities();

        public frmRacun()
        {
            InitializeComponent();
        }

        public frmRacun(int idPosla, string naziv)
        {
            this.idPosla = idPosla;
            this.naziv = naziv;
            InitializeComponent();
        }

        private void frmRacun_Load(object sender, EventArgs e)
        {
            this.uslugaTableAdapter.FillByUslugaID(this.servisCiscenjeDBDataSet.usluga, idPosla);
            
            this.posaoTableAdapter.FillBy(this.servisCiscenjeDBDataSet.posao, idPosla);
         
            this.klijentTableAdapter.FillByNaziv(this.servisCiscenjeDBDataSet.klijent, naziv);
            
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
