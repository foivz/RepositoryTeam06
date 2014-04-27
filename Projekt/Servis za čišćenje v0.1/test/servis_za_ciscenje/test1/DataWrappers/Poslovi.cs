using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace servis_za_ciscenje.DataWrappers
{
    //Klasa služi kao omotač podataka za entitet Termin
    class Poslovi : OmotacPodataka
    {
        public DateTime datum { get; set; }
        public string adresaCiscenja { get; set; }
        public int velicinaProstora { get; set; }
        public bool zurni { get; set; }
        public Klijent klijent { get; set; } // tu ce imati tocno odredjenog klijenta
        public Vozilo vozilo { get; set; } 
        public List<Radnik> popisRadnika { get; set; } //Agregacija UML

        public Poslovi(int id, DateTime datum, string adresaCiscenja, int velicinaProstora, bool zurni, Klijent klijent, Vozilo vozilo, List<Radnik> listaRadnika)
        {
            base.id = id;
            this.adresaCiscenja = adresaCiscenja;
            this.velicinaProstora = velicinaProstora;
            this.zurni = zurni;
            this.klijent = klijent;
            this.vozilo = vozilo;
            this.popisRadnika = listaRadnika;
        }

        public void DodajRadnika(Radnik r)
        {
            this.popisRadnika.Add(r);
        }

        public void IzbrisiRadnika(Radnik r)
        {
            bool postoji = false;
            Radnik pom = null;
            foreach (Radnik rad in popisRadnika)
            {
                if (rad.id == r.id)
                {
                    postoji = true;
                    pom = rad;
                }
            }

            if (postoji && pom != null)
            {
                this.popisRadnika.Remove(pom);
            }
        }
    }
}
