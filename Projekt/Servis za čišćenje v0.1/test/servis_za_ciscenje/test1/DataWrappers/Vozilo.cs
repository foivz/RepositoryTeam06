using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace servis_za_ciscenje.DataWrappers
{
    //Klasa služi kao omotač podataka za entitet Vozilo
    class Vozilo : OmotacPodataka
    {
        public string registracija { get; set; }
        public string model { get; set; }
        
        public Vozilo(int id, string registracija, string model)
        {
            base.id = id;
            this.registracija = registracija;
            this.model = model;
        }
    }
}
