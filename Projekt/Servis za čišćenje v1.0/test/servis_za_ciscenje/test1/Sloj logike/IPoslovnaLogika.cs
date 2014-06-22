using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using servis_za_ciscenje.SlojPodataka;
using servis_za_ciscenje.Views;

namespace servis_za_ciscenje.Sloj_logike
{
    interface IPoslovnaLogika
    {
        void provjeriKorisnika(String username, String password);

        //CRUD vozila
        void dodajVozilo(string regOznaka, string model);
        void brisiVozilo(DataGridViewRow row);
        void azurirajVozilo(DataGridViewRow row, string registracija, string model);
        void getPodaciVozilo(DataGridViewRow row, Form f);

        //CRUD klijenti
        void dodajKlijenta(string adresa, string kontakt, string naziv, string email, bool obavijesti);
        void brisiKlijenta(DataGridViewRow row);
        void azurirajKlijenta(DataGridViewRow row, string adresa, string kontakt, string naziv, string email, bool obavijesti);
        void getPodaciKlijent(DataGridViewRow row, Form f);

        //CRUD usluge
        void dodajUslugu(string naziv, string faktor);
        void brisiUslugu(DataGridViewRow row);
        void azurirajUslugu(DataGridViewRow row, string naziv, string faktor);
        void getPodaciUsluga(DataGridViewRow row, Form f);

        //CRUD radnici
        void dodajRadnika(string ime, string prezime, string brojTelefona);
        void brisiRadnika(DataGridViewRow row);
        void azurirajRadnika(DataGridViewRow row, string ime, string prezime, string brojTelefona);
        void getPodaciRadnik(DataGridViewRow row, Form f);

        //posao
        List<string> DohvatiKlijente();
        List<int> DohvatiOdabraneUsluge(DataGridView d);
        List<int> DohvatiOdabraneRadnike(DataGridView d);
        List<int> DohvatiOdabranaVozila(DataGridView d);
        void PreuzmiListuRadnika(DataGridViewRow row, frmAzurirajPosao f);
        void PreuzmiListuUsluga(DataGridViewRow row, frmAzurirajPosao f);
        void PreuzmiListuVozila(DataGridViewRow row, frmAzurirajPosao f);
        void PripremiDataGridOdaberiUsluge(DataGridView d, frmDodajPosao f);
        void PripremiDataGridOdaberiRadnike(DataGridView d, frmDodajPosao f);
        void PripremiDataGridOdaberiVozila(DataGridView d, frmDodajPosao f);
        void PripremiDataGridOdaberiUslugeZaAzuriranje(DataGridView d, frmAzurirajPosao f, DataGridViewRow row);
        void PripremiDataGridOdaberiRadnikeZaAzuriranje(DataGridView d, frmAzurirajPosao f, DataGridViewRow row);
        void PripremiDataGridOdaberiVozilaZaAzuriranje(DataGridView d, frmAzurirajPosao f, DataGridViewRow row);
        void PripremiDataGridPopisPoslova(DataGridView d, frmDayView f, string datum);
        void PoveziCmbxSaDataGridom(DataGridView d, frmDayView f);
        void IzracunCijene(frmDodajPosao f);
        void IzracunCijeneKodAzuriranja(frmAzurirajPosao f);
        void dodajPosao(string datum, string vrijeme, string adresa, string kvadratura, string tipPosla, string cijena, string klijent, List<int> usluga, List<int> radnik, List<int> vozilo, string trajanjePosla, string unaprijed);
        void azurirajPosao(DataGridViewRow row, string datum, string vrijeme, string adresa, string kvadratura, string tipPosla, string cijena, string klijent, List<int> usluga, List<int> radnik, List<int> vozilo, string trajanjePosla);
        void brisiPosao(DataGridViewRow row);
        bool ProvjeriZauzetostRadnika(List<int> radnici, string termin, string datum);
        bool ProvjeriZauzetostVozila(List<int> vozila, string termin, string datum);
        bool ProvjeriAdresu(string adresa, string datum, string termin);
        DateTime[] VratiZauzeteDatume();
        void OsvjeziKalendar(MonthCalendar cal);
        void PreuzmiPodatkeOPoslu(DataGridViewRow row, frmAzurirajPosao f);
        void dajAdresu(frmDodajPosao f, string naziv);
        void dajAdresuAzuriranje(frmAzurirajPosao f, string naziv);
        List<CmbItemRadnik> GetRadnici();
        void OsvjeziDataGridOusluzi(DataGridView d, List<int> listaUsluga);

        BindingSource BindDgdVozila();
        BindingSource BindDgdKlijenti();
        BindingSource BindDgdUsluga();
        BindingSource BindDgdRadnici();

        bool checkIfRadniciExist();

        void SaljiMail();
        
    }
}
