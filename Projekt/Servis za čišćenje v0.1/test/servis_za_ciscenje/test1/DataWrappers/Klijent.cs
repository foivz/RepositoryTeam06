using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace servis_za_ciscenje.DataWrappers
{
    //Omotač podataka za entitet Klijent
    class Klijent : OmotacPodataka
    {
        public string adresa { get; set; }
        public string telefon { get; set; }

        public Klijent(int id, string adresa, string telefon)
        {
            base.id = id;
            this.adresa = adresa;
            this.telefon = telefon;            
        }
    }
}
