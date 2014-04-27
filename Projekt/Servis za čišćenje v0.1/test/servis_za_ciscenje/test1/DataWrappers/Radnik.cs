using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace servis_za_ciscenje.DataWrappers
{
    //Klasa služi kao omotač podataka za entitet Radnik
    class Radnik : OmotacPodataka
    {        
        public string ime { get; set; }
        public string prezime { get; set; }
        public string telefon { get; set; }

        public Radnik(int id, string ime, string prezime, string telefon)
        {
            base.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.telefon = telefon;
        }             
    }
}
