using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using servis_za_ciscenje.SlojPodataka;
using System.Windows.Forms;
using servis_za_ciscenje.Views;
using System.Net;

namespace servis_za_ciscenje.Sloj_logike
{
    class PomocnaKlasa
    {

        //metoda za provjeru formata email adrese
        public bool EmailIsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public List<PosaoGrid> DohvatiTermine()
        {
            List<PosaoGrid> listaTermina = new List<PosaoGrid>();
            string[] polje = {"08:00-09:00", "09:00-10:00", "10:00-11:00", "11:00-12:00",
                              "12:00-13:00", "13:00-14:00", "14:00-15:00", "15:00-16:00",
                              "16:00-17:00", "17:00-18:00", "18:00-19:00", "19:00-20:00"
                             };

            foreach (var item in polje)
            {
                listaTermina.Add(new PosaoGrid { Vrijeme = item });
            }

            return listaTermina;
        }

        public List<string> DohvatiTermineZaAzuriranje()
        {
            List<string> listaTermina = new List<string>();
            string[] polje = {"08:00-09:00", "09:00-10:00", "10:00-11:00", "11:00-12:00",
                              "12:00-13:00", "13:00-14:00", "14:00-15:00", "15:00-16:00",
                              "16:00-17:00", "17:00-18:00", "18:00-19:00", "19:00-20:00"
                             };

            foreach (var item in polje)
            {
                listaTermina.Add(item);
            }

            return listaTermina;
        }

        public List<string> DohvatiTipPosla()
        {
            List<string> tipoviPosla = new List<string>();
            tipoviPosla.Add("Žurno");
            tipoviPosla.Add("Obično");

            return tipoviPosla;
        }

        public List<string> DohvatiTrajanje()
        {
            List<string> listaTrajanja = new List<string>();
            listaTrajanja.Add("1");
            listaTrajanja.Add("2");
            listaTrajanja.Add("3");
            listaTrajanja.Add("4");
            listaTrajanja.Add("5");
            listaTrajanja.Add("6");
            listaTrajanja.Add("7");
            listaTrajanja.Add("8");
            listaTrajanja.Add("9");
            listaTrajanja.Add("10");

            return listaTrajanja;
        }

        private string VratiReprezentativniTerminZaBroj(int broj)
        {
            string termin = "";
            switch (broj)
            {
                case 1:
                    termin = "08:00";
                    break;
                case 2:
                    termin = "09:00";
                    break;
                case 3:
                    termin = "10:00";
                    break;
                case 4:
                    termin = "11:00";
                    break;
                case 5:
                    termin = "12:00";
                    break;
                case 6:
                    termin = "13:00";
                    break;
                case 7:
                    termin = "14:00";
                    break;
                case 8:
                    termin = "15:00";
                    break;
                case 9:
                    termin = "16:00";
                    break;
                case 10:
                    termin = "17:00";
                    break;
                case 11:
                    termin = "18:00";
                    break;
                case 12:
                    termin = "19:00";
                    break;
                case 13:
                    termin = "20:00";
                    break;
                default:
                    break;
            }



            return termin;
        }

        private int VratiReprezentativniBrojZaTermin(string dioTermina)
        {
            int broj = 0;
            switch (dioTermina)
            {
                case "08:00":
                    broj = 1;
                    break;
                case "09:00":
                    broj = 2;
                    break;
                case "10:00":
                    broj = 3;
                    break;
                case "11:00":
                    broj = 4;
                    break;
                case "12:00":
                    broj = 5;
                    break;
                case "13:00":
                    broj = 6;
                    break;
                case "14:00":
                    broj = 7;
                    break;
                case "15:00":
                    broj = 8;
                    break;
                case "16:00":
                    broj = 9;
                    break;
                case "17:00":
                    broj = 10;
                    break;
                case "18:00":
                    broj = 11;
                    break;
                case "19:00":
                    broj = 12;
                    break;
                case "20:00":
                    broj = 13;
                    break;
                default:
                    break;
            }

            return broj;
        }


        public string ParsirajTermin(string termin, string brojSati)
        {
            string parsiraniTermin = "";
            if (brojSati.Equals("1"))
            {
                parsiraniTermin = termin;
            }
            else
            {
                string[] poljeTermin = termin.Split('-');
                int broj = VratiReprezentativniBrojZaTermin(poljeTermin[0]);
                broj = broj + Convert.ToInt32(brojSati);
                string drugiDioTermina = VratiReprezentativniTerminZaBroj(broj);
                parsiraniTermin = poljeTermin[0] + "-" + drugiDioTermina;
            }

            return parsiraniTermin;
        }

        public string[] VratiPoljeTermina(string termin)
        {
            string[] poljeTermina = new string[20];
            string[] polje = termin.Split('-');
            int brojPrviDio = VratiReprezentativniBrojZaTermin(polje[0]);
            int brojDrugiDio = VratiReprezentativniBrojZaTermin(polje[1]);
            if (brojDrugiDio - brojPrviDio == 1)
            {
                poljeTermina[0] = termin;
            }
            else
            {
                int x = brojDrugiDio - brojPrviDio;
                for (int i = 1; i <= x; i++)
                {

                    string prviDioTer = VratiReprezentativniTerminZaBroj(i);
                    string drugiDioTer = VratiReprezentativniTerminZaBroj(i + 1);
                    string ter = prviDioTer + "-" + drugiDioTer;
                    int index = i - 1;
                    poljeTermina[index] = ter;
                }
            }



            return poljeTermina;
        }

        public void NapuniComboboxevePopisAdresa(BindingSource bs, frmDayView f, int cmbBroj)
        {
            switch (cmbBroj)
            {
                case 0:
                    f.Cmb0 = bs;
                    break;
                case 1:
                    f.Cmb1 = bs;
                    break;
                case 2:
                    f.Cmb2 = bs;
                    break;
                case 3:
                    f.Cmb3 = bs;
                    break;
                case 4:
                    f.Cmb4 = bs;
                    break;
                case 5:
                    f.Cmb5 = bs;
                    break;
                case 6:
                    f.Cmb6 = bs;
                    break;
                case 7:
                    f.Cmb7 = bs;
                    break;
                case 8:
                    f.Cmb8 = bs;
                    break;
                case 9:
                    f.Cmb9 = bs;
                    break;
                case 10:
                    f.Cmb10 = bs;
                    break;
                case 11:
                    f.Cmb11 = bs;
                    break;
                default:
                    break;
            }

        }


        public void SendEmail(string toEmail, string klijentNaziv, string termin, string datum)
        {
            string msgSubject = "Čišćenje - podsjetnik za termin";

            string msgBody = " Poštovani " + klijentNaziv + " , \n podsjećamo Vas da se bliži termin koji ste zakazali kod nas.\n" +
                         "Datum: " + datum +"\n" + "Termin: " + termin + " \n" +  "Lijep pozdrav, \n destruktori.pi@gmail.com";

            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(
                  "destruktori.pi@gmail.com", "destruktori123");
                MailMessage msg = new MailMessage();
                msg.To.Add(toEmail);
                msg.From = new MailAddress("ciscenje@gmail.com");
                msg.Subject = msgSubject;
                msg.Body = msgBody;
                client.Send(msg);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public List<string> DohvatiUnaprijed() {
            List<string> listaDana = new List<string>();
            listaDana.Add("");
            listaDana.Add("2");
            listaDana.Add("3");
            listaDana.Add("4");
            listaDana.Add("5");
            listaDana.Add("6");
            listaDana.Add("7");
            listaDana.Add("8");
            listaDana.Add("9");
            listaDana.Add("10");
            listaDana.Add("11");
            listaDana.Add("12");
            listaDana.Add("13");
            listaDana.Add("14");

            return listaDana;
        }



    }
}
