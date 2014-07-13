using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using servis_za_ciscenje.SlojPodataka;
using servis_za_ciscenje.Views;
using System.Windows.Forms;
using System.Text.RegularExpressions;




namespace servis_za_ciscenje.Sloj_logike
{
    class Logika : IPoslovnaLogika
    {
        

        private ServisCiscenjeDBEntities db = new ServisCiscenjeDBEntities();
        private PomocnaKlasa pomocna = new PomocnaKlasa();

        //provjera korisnika kod prijave u sustav
        public void provjeriKorisnika(string username, string password)
        {
            //u k se nalaze svi atributi(stupci) iz tablice baze podataka, a db sadrži sve tablice iz baze podataka
            //k je proizvoljna varijabla
            //db.korisnici.where()... će vratiti Iqueryable tip podatka pa moraš .SingleOrDefault kako bi dobio samo jedan objekt
            //u protivnom se mora foreachat(castati u korisnici)

            korisnici kor = db.korisnici.Where(k => k.username.Equals(username) && k.password.Equals(password)).SingleOrDefault();
            if (kor != null)
            {
                frmMain newMain = new frmMain();
                newMain.Show();

                frmLogin f1 = (frmLogin)Application.OpenForms["frmLogin"];
                f1.Hide();

                SaljiMail();

            }
            else
            {
                MessageBox.Show("Neispravno korisničko ime i/ili lozinka");

                // Loop through all the controls on the form. 
                for (int i = 0; i < frmLogin.ActiveForm.Controls.Count; i++)
                {
                    if (frmLogin.ActiveForm.Controls[i].Name.Equals("txtUsername"))
                    {
                        frmLogin.ActiveForm.Controls[i].Text = "";
                    }
                    if (frmLogin.ActiveForm.Controls[i].Name.Equals("txtPassword"))
                    {
                        frmLogin.ActiveForm.Controls[i].Text = "";
                    }

                }

            }

        }


        /*CRUD vozila*/
        public void dodajVozilo(string regOznaka, string model)
        {
            if (regOznaka.Equals("") || model.Equals(""))
            {
                MessageBox.Show("Unesite oba polja");
            }
            else
            {
                Match ispravnaRegOznaka = Regex.Match(regOznaka, "^[A-Za-zžčćšđĐĆŠŽČ]{2}-[0-9]{4}-[A-Za-zžčćšđĐĆŠŽČ]{2}$");
                if (!ispravnaRegOznaka.Success)
                {
                    MessageBox.Show("Unesena registracijska oznaka nije ispravnog formata");
                }
                else
                {
                    vozila vozilo = db.vozila.Where(v => v.registracijska_oznaka.Equals(regOznaka)).SingleOrDefault();
                    if (vozilo == null)
                    {
                        db.vozila.Add(new vozila { registracijska_oznaka = regOznaka, model = model });
                        db.SaveChanges();
                        MessageBox.Show("Vozilo je dodano u bazu podataka");
                        for (int i = 0; i < frmDodajVozilo.ActiveForm.Controls.Count; i++)
                        {
                            if (frmDodajVozilo.ActiveForm.Controls[i].Name.Equals("tbxRegOznaka"))
                            {
                                frmDodajVozilo.ActiveForm.Controls[i].Text = "";
                            }
                            if (frmDodajVozilo.ActiveForm.Controls[i].Name.Equals("tbxModel"))
                            {
                                frmDodajVozilo.ActiveForm.Controls[i].Text = "";
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Vozilo s unesenom registracijskom oznakom već postoji u bazi podataka");
                    }
                }
            }

        }




        public void brisiVozilo(DataGridViewRow row)
        {
            if (row != null)
            {
                DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da želite obrisati odabrano vozilo?", "Potvrda brisanja vozila", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string regOznaka = row.Cells[1].Value.ToString();
                    vozila vozilo = db.vozila.Where(v => v.registracijska_oznaka.Equals(regOznaka)).SingleOrDefault();
                    db.vozila.Remove(vozilo);
                    db.SaveChanges();
                    MessageBox.Show("Vozilo je uspješno obrisano iz baze podataka.");

                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Odaberite vozilo koje želite obrisati");
            }

        }


        public void azurirajVozilo(DataGridViewRow row, string registracija, string model)
        {
            if (row != null)
            {

                if (registracija.Equals("") || model.Equals(""))
                {
                    MessageBox.Show("Popunite oba polja");
                }
                else
                {
                    Match ispravnaRegOznaka = Regex.Match(registracija, "^[A-Za-zžčćšđĐĆŠŽČ]{2}-[0-9]{4}-[A-Za-zžčćšđĐĆŠŽČ]{2}$");
                    if (!ispravnaRegOznaka.Success)
                    {
                        MessageBox.Show("Unesena registracijska oznaka nije ispravnog formata.");
                    }
                    else
                    {
                        string regOznaka = row.Cells[1].Value.ToString();
                        vozila vozilo = db.vozila.Where(v => v.registracijska_oznaka.Equals(regOznaka)).SingleOrDefault();
                        if (registracija != regOznaka)
                        {
                            vozila voziloUbazi = db.vozila.Where(v => v.registracijska_oznaka.Equals(registracija)).SingleOrDefault();
                            if (voziloUbazi != null)
                            {
                                MessageBox.Show("Vozilo sa tom registracijskom oznakom već postoji u bazi podataka.");
                                return;
                            }
                            else
                            {
                                vozilo.registracijska_oznaka = registracija;
                                vozilo.model = model;
                            }
                        }
                        else
                        {
                            vozilo.registracijska_oznaka = registracija;
                            vozilo.model = model;
                        }

                        DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da želite ažurirati odabrano vozilo?", "Potvrda ažuriranja vozila", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            db.SaveChanges();
                            MessageBox.Show("Vozilo je uspješno ažurirano.");
                            frmAzurirajVozilo f1 = (frmAzurirajVozilo)Application.OpenForms["frmAzurirajVozilo"];
                            f1.Close();

                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Odaberite vozilo koje želite ažurirati");
            }
        }

        public void getPodaciVozilo(DataGridViewRow row, Form f)
        {
            string regOznaka = row.Cells[1].Value.ToString();
            vozila vozilo = db.vozila.Where(v => v.registracijska_oznaka.Equals(regOznaka)).SingleOrDefault();

            for (int i = 0; i < f.Controls.Count; i++)
            {
                if (f.Controls[i].Name.Equals("tbxRegOznaka"))
                {

                    f.Controls[i].Text = vozilo.registracijska_oznaka;
                }
                if (f.Controls[i].Name.Equals("tbxModel"))
                {
                    f.Controls[i].Text = vozilo.model;
                }

            }
        }

        //###########################################################################################################


        //CRUD Klijenti
        public void dodajKlijenta(string adresa, string kontakt, string naziv, string email, bool obavijest)
        {
            if (adresa.Equals("") || kontakt.Equals("") || naziv.Equals("") || email.Equals(""))
            {
                MessageBox.Show("Popunite sva polja");
            }
            else
            {
                if (!pomocna.EmailIsValid(email))
                {
                    MessageBox.Show("Email adresa je neispravnog formata!");
                }
                else
                {
                    klijent postojeciKlijentAdresa = db.klijent.Where(k => k.email.Equals(email)).SingleOrDefault();
                    klijent postojeciKlijentMail = db.klijent.Where(k => k.email.Equals(email)).SingleOrDefault();
                    if (postojeciKlijentAdresa != null)
                    {
                        MessageBox.Show("Već postoji klijent na navedenoj adresi.");
                        return;
                    }
                    if (postojeciKlijentMail != null)
                    {
                        MessageBox.Show("Već postoji klijent sa navedenim email adresom.");
                        return;
                    }

                    string notifications = "";
                    if (obavijest == true)
                    {
                        notifications = "Da";
                    }
                    else
                    {
                        notifications = "Ne";
                    }

                    db.klijent.Add(new klijent { adresa = adresa, kontakt = kontakt, naziv = naziv, email = email, primanjeObavijesti = notifications });
                    db.SaveChanges();
                    MessageBox.Show("Klijent je uspješno dodan u bazu podataka");


                    for (int i = 0; i < frmDodajKlijenta.ActiveForm.Controls.Count; i++)
                    {
                        if (frmDodajKlijenta.ActiveForm.Controls[i].Name.Equals("tbxAdresa"))
                        {
                            frmDodajKlijenta.ActiveForm.Controls[i].Text = "";
                        }
                        if (frmDodajKlijenta.ActiveForm.Controls[i].Name.Equals("tbxKontakt"))
                        {
                            frmDodajKlijenta.ActiveForm.Controls[i].Text = "";
                        }
                        if (frmDodajKlijenta.ActiveForm.Controls[i].Name.Equals("tbxNaziv"))
                        {
                            frmDodajKlijenta.ActiveForm.Controls[i].Text = "";
                        }
                        if (frmDodajKlijenta.ActiveForm.Controls[i].Name.Equals("tbxEmail"))
                        {
                            frmDodajKlijenta.ActiveForm.Controls[i].Text = "";
                        }

                    }


                }
            }
        }

        public void brisiKlijenta(DataGridViewRow row)
        {
            if (row != null)
            {
                DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da želite obrisati odabranog klijenta?", "Potvrda brisanja klijenta", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string idKlijenta = row.Cells[0].Value.ToString();
                    int id = Convert.ToInt32(idKlijenta);
                    klijent klijent = db.klijent.Where(k => k.id_klijent.Equals(id)).SingleOrDefault();
                    db.klijent.Remove(klijent);
                    db.SaveChanges();
                    MessageBox.Show("Klijent je uspješno obrisan iz baze podataka.");

                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Odaberite klijenta kojeg želite obrisati");
            }
        }

        public void azurirajKlijenta(DataGridViewRow row, string adresa, string kontakt, string naziv, string email, bool obavijest)
        {
            if (row != null)
            {
                if (adresa.Equals("") || kontakt.Equals("") || naziv.Equals("") || email.Equals(""))
                {
                    MessageBox.Show("Popunite sva polja");
                }
                else
                {
                    if (!pomocna.EmailIsValid(email))
                    {
                        MessageBox.Show("Email adresa je neispravnog formata!");
                    }
                    else
                    {
                        string notification = "";
                        if (obavijest == true)
                        {
                            notification = "Da";
                        }
                        else
                        {
                            notification = "Ne";
                        }

                        string postojeciMail = row.Cells[4].Value.ToString();
                        klijent kl = db.klijent.Where(k => k.email.Equals(postojeciMail)).SingleOrDefault();
                        if (postojeciMail != email)
                        {
                            klijent postojeciKlijentAdresa = db.klijent.Where(k => k.adresa.Equals(adresa)).SingleOrDefault();
                            klijent postojeciKlijentMail = db.klijent.Where(k => k.email.Equals(email)).SingleOrDefault();
                            if (postojeciKlijentAdresa != null)
                            {
                                MessageBox.Show("Već postoji klijent na navedenoj adresi.");
                                return;
                            }
                            if (postojeciKlijentMail != null)
                            {
                                MessageBox.Show("Već postoji klijent sa navedenim email adresom.");
                                return;
                            }
                            kl.email = email;
                            kl.adresa = adresa;
                            kl.kontakt = kontakt;
                            kl.naziv = naziv;
                            kl.primanjeObavijesti = notification;
                        }
                        else
                        {
                            kl.email = email;
                            kl.adresa = adresa;
                            kl.kontakt = kontakt;
                            kl.naziv = naziv;
                            kl.primanjeObavijesti = notification;
                        }

                        DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da želite ažurirati odabranog klijenta?", "Potvrda ažuriranja klijenta", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            db.SaveChanges();
                            MessageBox.Show("Klijent je uspješno ažuriran");

                            frmAzurirajKlijenta f1 = (frmAzurirajKlijenta)Application.OpenForms["frmAzurirajKlijenta"];
                            f1.Close();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            return;
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Odaberite klijenta kojeg želite ažurirati");
            }

        }




        public void getPodaciKlijent(DataGridViewRow row, Form f)
        {
            string idKlijenta = row.Cells[0].Value.ToString();
            int id = Convert.ToInt32(idKlijenta);

            klijent klijent = db.klijent.Where(k => k.id_klijent.Equals(id)).SingleOrDefault();

            for (int i = 0; i < f.Controls.Count; i++)
            {
                if (f.Controls[i].Name.Equals("tbxAdresa"))
                {
                    f.Controls[i].Text = klijent.adresa;
                }
                if (f.Controls[i].Name.Equals("tbxKontakt"))
                {
                    f.Controls[i].Text = klijent.kontakt;
                }
                if (f.Controls[i].Name.Equals("tbxNaziv"))
                {
                    f.Controls[i].Text = klijent.naziv;
                }
                if (f.Controls[i].Name.Equals("tbxEmail"))
                {
                    f.Controls[i].Text = klijent.email;
                }

            }
        }


        //###########################################################################################################


        //CRUD usluge
        public void dodajUslugu(string naziv, string faktor)
        {
            if (naziv.Equals("") || faktor.Equals(""))
            {
                MessageBox.Show("Popunite oba polja");
            }
            else
            {
                double number;
                if (Double.TryParse(faktor, out number))
                {

                    usluga usl = db.usluga.Where(u => u.naziv.Equals(naziv)).SingleOrDefault();

                    if (usl != null)
                    {
                        MessageBox.Show("Već postoji usluga s tim nazivom.");
                    }
                    else
                    {
                        db.usluga.Add(new usluga { naziv = naziv, cijenaKvadrat = number });
                        db.SaveChanges();
                        MessageBox.Show("Usluga je uspješno dodana u bazu podataka.");

                        for (int i = 0; i < frmDodajUslugu.ActiveForm.Controls.Count; i++)
                        {
                            if (frmDodajUslugu.ActiveForm.Controls[i].Name.Equals("tbxNaziv"))
                            {
                                frmDodajUslugu.ActiveForm.Controls[i].Text = "";
                            }
                            if (frmDodajUslugu.ActiveForm.Controls[i].Name.Equals("tbxFaktor"))
                            {
                                frmDodajUslugu.ActiveForm.Controls[i].Text = "";
                            }
                        }
                    }




                }
                else
                {
                    MessageBox.Show("Unesena cijena mora biti broj");
                }
            }
        }

        public void brisiUslugu(DataGridViewRow row)
        {
            if (row != null)
            {
                DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da želite obrisati odabranu uslugu?", "Potvrda brisanja usluge", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string idUsluge = row.Cells[0].Value.ToString();
                    int id = Convert.ToInt32(idUsluge);
                    usluga usluga = db.usluga.Where(u => u.id_usluga.Equals(id)).SingleOrDefault();
                    db.usluga.Remove(usluga);
                    db.SaveChanges();
                    MessageBox.Show("Usluga je uspješno obrisana iz baze podataka.");
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Odaberite uslugu koju želite obrisati");
            }
        }

        public void azurirajUslugu(DataGridViewRow row, string naziv, string faktor)
        {
            if (row != null)
            {
                if (naziv.Equals("") || faktor.Equals(""))
                {
                    MessageBox.Show("Popunite oba polja");
                }
                else
                {
                    double number;
                    if (Double.TryParse(faktor, out number))
                    {
                        if (number < 0.5 || number > 3)
                        {
                            MessageBox.Show("Faktor mora biti u rasponu 0.5 do 3.0");
                        }
                        else
                        {
                            string nazivPostojeceUsluge = row.Cells[1].Value.ToString();
                            usluga usl = db.usluga.Where(u => u.naziv.Equals(nazivPostojeceUsluge)).SingleOrDefault();

                            if (nazivPostojeceUsluge != naziv)
                            {
                                usluga u = db.usluga.Where(x => x.naziv.Equals(naziv)).SingleOrDefault();
                                if (u != null)
                                {
                                    MessageBox.Show("Već postoji usluga s tim nazivom");
                                    return;
                                }
                                else
                                {
                                    usl.naziv = naziv;
                                    usl.cijenaKvadrat = (float)number;
                                }
                            }
                            else
                            {
                                usl.naziv = naziv;
                                usl.cijenaKvadrat = (float)number;
                            }

                            DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da želite ažurirati odabranu uslugu?", "Potvrda brisanja usluge", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                db.SaveChanges();
                                MessageBox.Show("Usluga je uspješno ažurirana.");

                                frmAzurirajUslugu f1 = (frmAzurirajUslugu)Application.OpenForms["frmAzurirajUslugu"];
                                f1.Close();
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Uneseni faktor mora biti broj u rasponu 0.5 do 3.0");
                    }
                }
            }
            else
            {
                MessageBox.Show("Odaberite uslugu koju želite ažurirati.");
            }
        }



        public void getPodaciUsluga(DataGridViewRow row, Form f)
        {
            string idUsluga = row.Cells[0].Value.ToString();
            int id = Convert.ToInt32(idUsluga);

            usluga usluga = db.usluga.Where(u => u.id_usluga.Equals(id)).SingleOrDefault();

            for (int i = 0; i < f.Controls.Count; i++)
            {
                if (f.Controls[i].Name.Equals("tbxNaziv"))
                {

                    f.Controls[i].Text = usluga.naziv;
                }
                if (f.Controls[i].Name.Equals("tbxCijena"))
                {
                    f.Controls[i].Text = usluga.cijenaKvadrat.ToString();
                }

            }
        }

        //###########################################################################################################


        //CRUD radnici
        public void dodajRadnika(string ime, string prezime, string brojTelefona)
        {
            if (ime.Equals("") || prezime.Equals("") || brojTelefona.Equals(""))
            {
                MessageBox.Show("Popunite sva polja");
            }
            else
            {
                Match ispravnoIme = Regex.Match(ime, @"^[a-zA-ZČŠĐŽĆčćžđš-]+$");
                Match ispravnoPrezime = Regex.Match(prezime, @"^[a-zA-ZČŠĐŽĆčćžđš-]+$");
                Match ispravanTelefon = Regex.Match(brojTelefona, "^[0-9-]+$");

                if (!ispravnoIme.Success || !ispravnoPrezime.Success || !ispravanTelefon.Success)
                {
                    MessageBox.Show("Uneseno ime, prezime ili broj telefona su neispravnog formata");
                }
                else
                {
                    int brojac = 0;
                    foreach (var item in db.radnici)
                    {
                        string broj = item.telefon.Replace("-", string.Empty);
                        string pomBroj = brojTelefona.Replace("-", string.Empty);
                        if (broj.Equals(pomBroj))
                        {
                            brojac++;
                        }
                    }
                    if (brojac > 0)
                    {
                        MessageBox.Show("Već postoji radnik s unesenim brojem telefona");
                    }
                    else
                    {
                        db.radnici.Add(new radnici { ime = ime, prezime = prezime, telefon = brojTelefona });
                        db.SaveChanges();
                        MessageBox.Show("Novi radnik je uspješno dodan u bazu podataka");

                        for (int i = 0; i < frmDodajRadnika.ActiveForm.Controls.Count; i++)
                        {
                            if (frmDodajRadnika.ActiveForm.Controls[i].Name.Equals("tbxIme"))
                            {
                                frmDodajRadnika.ActiveForm.Controls[i].Text = "";
                            }
                            if (frmDodajRadnika.ActiveForm.Controls[i].Name.Equals("tbxPrezime"))
                            {
                                frmDodajRadnika.ActiveForm.Controls[i].Text = "";
                            }
                            if (frmDodajRadnika.ActiveForm.Controls[i].Name.Equals("tbxBrojTelefona"))
                            {
                                frmDodajRadnika.ActiveForm.Controls[i].Text = "";
                            }

                        }
                    }
                }
            }
        }

        public void brisiRadnika(DataGridViewRow row)
        {
            if (row != null)
            {
                DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da želite obrisati odabranog radnika?", "Potvrda brisanja radnika", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string idRadnika = row.Cells[0].Value.ToString();
                    int id = Convert.ToInt32(idRadnika);
                    radnici radnik = db.radnici.Where(r => r.idradnik.Equals(id)).SingleOrDefault();
                    db.radnici.Remove(radnik);
                    db.SaveChanges();
                    MessageBox.Show("Radnik je uspješno obrisan iz baze podataka.");
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Odaberite radnika kojeg želite obrisati");
            }
        }

        public void azurirajRadnika(DataGridViewRow row, string ime, string prezime, string brojTelefona)
        {
            if (row != null)
            {
                if (ime.Equals("") || prezime.Equals("") || brojTelefona.Equals(""))
                {
                    MessageBox.Show("Popunite sva polja");
                }
                else
                {
                    Match ispravnoIme = Regex.Match(ime, @"^[a-zA-ZČŠĐŽĆčćžđš-]+$");
                    Match ispravnoPrezime = Regex.Match(prezime, @"^[a-zA-ZČŠĐŽĆčćžđš-]+$");
                    Match ispravanTelefon = Regex.Match(brojTelefona, "^[0-9-]+$");
                    if (!ispravnoIme.Success || !ispravnoPrezime.Success || !ispravanTelefon.Success)
                    {
                        MessageBox.Show("Uneseno ime, prezime ili broj telefona su neispravnog formata");
                    }
                    else
                    {
                        string telefon = row.Cells[3].Value.ToString();
                        radnici rad = db.radnici.Where(r => r.telefon.Equals(telefon)).SingleOrDefault();
                        if (telefon != brojTelefona)
                        {
                            int brojac = 0;
                            foreach (var item in db.radnici)
                            {
                                string broj = item.telefon.Replace("-", string.Empty);
                                string pomBroj = brojTelefona.Replace("-", string.Empty);
                                if (broj.Equals(pomBroj))
                                {
                                    brojac++;
                                }
                            }
                            if (brojac > 0)
                            {
                                MessageBox.Show("Već postoji radnik s unesenim brojem telefona");
                                return;
                            }
                            else
                            {
                                rad.ime = ime;
                                rad.prezime = prezime;
                                rad.telefon = brojTelefona;
                            }
                        }
                        else
                        {
                            rad.ime = ime;
                            rad.prezime = prezime;
                            rad.telefon = brojTelefona;
                        }

                        DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da želite ažurirati odabranog radnika?", "Potvrda ažuriranja radnika", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            db.SaveChanges();
                            MessageBox.Show("Radnik je uspješno ažuriran.");

                            frmAzurirajRadnika f1 = (frmAzurirajRadnika)Application.OpenForms["frmAzurirajRadnika"];
                            f1.Close();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Odaberite radnika kojeg želite ažurirati.");
            }

        }


        public void getPodaciRadnik(DataGridViewRow row, Form f)
        {
            string idRadnika = row.Cells[0].Value.ToString();
            int id = Convert.ToInt32(idRadnika);

            radnici radnik = db.radnici.Where(r => r.idradnik.Equals(id)).SingleOrDefault();

            for (int i = 0; i < f.Controls.Count; i++)
            {
                if (f.Controls[i].Name.Equals("tbxIme"))
                {

                    f.Controls[i].Text = radnik.ime;
                }
                if (f.Controls[i].Name.Equals("tbxPrezime"))
                {
                    f.Controls[i].Text = radnik.prezime;
                }
                if (f.Controls[i].Name.Equals("tbxBrojTelefona"))
                {
                    f.Controls[i].Text = radnik.telefon;
                }

            }
        }

        //###########################################################################################################

        public BindingSource BindDgdRadnici()
        {
            ServisCiscenjeDBEntities db2 = new ServisCiscenjeDBEntities();

            List<radnici> listaRadnika = new List<radnici>();
            foreach (var item in db2.radnici.ToList())
            {
                listaRadnika.Add(item);
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = listaRadnika;

            return bs;
        }

        public BindingSource BindDgdVozila()
        {
            ServisCiscenjeDBEntities db2 = new ServisCiscenjeDBEntities();

            List<vozila> listaVozila = new List<vozila>();
            foreach (var item in db2.vozila.ToList())
            {
                listaVozila.Add(item);
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = listaVozila;

            return bs;
        }

        public BindingSource BindDgdKlijenti()
        {
            ServisCiscenjeDBEntities db2 = new ServisCiscenjeDBEntities();

            List<klijent> listaVozila = new List<klijent>();
            foreach (var item in db2.klijent.ToList())
            {
                listaVozila.Add(item);
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = listaVozila;

            return bs;
        }

        public BindingSource BindDgdUsluga()
        {
            ServisCiscenjeDBEntities db2 = new ServisCiscenjeDBEntities();

            List<usluga> listaUsluga = new List<usluga>();
            foreach (var item in db2.usluga.ToList())
            {
                listaUsluga.Add(item);
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = listaUsluga;

            return bs;
        }

        public List<string> DohvatiKlijente()
        {
            List<string> listaKlijenata = new List<string>();
            foreach (var item in db.klijent.ToList())
            {
                listaKlijenata.Add(item.naziv);
            }
            return listaKlijenata;
        }


        public void dodajPosao(string datum, string vrijeme, string adresa, string kvadratura, string tipPosla, string cijena, string klijent, List<int> usluga, List<int> radnik, List<int> vozilo, string trajanjePosla, string unaprijed)
        {
            if (adresa.Equals("") || kvadratura.Equals("") || klijent.Equals("") || usluga.Count == 0 || radnik.Count == 0 || vozilo.Count == 0)
            {
                MessageBox.Show("Popunite sva polja na formi");
            }
            else
            {
                int number;
                if (Int32.TryParse(kvadratura, out number) == false)
                {
                    MessageBox.Show("Unesena kvadratura nije ispravnog formata");
                }
                else
                {
                    string termin = pomocna.ParsirajTermin(vrijeme, trajanjePosla);
                    string[] poljeTermin = termin.Split('-');
                    if (poljeTermin[1].Equals(""))
                    {
                        MessageBox.Show("Pogrešan odabir kod termina. Pazite da ukupan termin ne prelazi 20:00 h.");
                    }
                    else
                    {
                        //provjeri radnike jesu li zauzeti u tom terminu
                        bool validRadnici = ProvjeriZauzetostRadnika(radnik, termin, datum);

                        //provjeri vozila jesu li zauzeta
                        bool validVozila = ProvjeriZauzetostVozila(vozilo, termin, datum);

                        if (validRadnici == false)
                        {
                            MessageBox.Show("Netko ili svi odabrani radnici su zauzeti u odabranom terminu");
                        }
                        else
                        {
                            if (validVozila == false)
                            {
                                MessageBox.Show("Netko ili sva odabrana vozila su zauzeta u odabranom terminu");
                            }
                            else
                            {
                                if (ProvjeriAdresu(adresa, datum, termin) == false)
                                {
                                    MessageBox.Show("Adresa je već dodana za taj termin");
                                }
                                else
                                {
                                    klijent kl = db.klijent.Where(k => k.naziv.Equals(klijent)).SingleOrDefault();
                                    int idKlijenta = kl.id_klijent;

                                    posao pos = new posao { adresa_ciscenja = adresa, velicina_prostora = Convert.ToInt32(kvadratura), cijena = cijena, vrijeme = termin, datum = Convert.ToDateTime(datum), tip_posla = tipPosla, klijentid_klijent = idKlijenta, mailPoslan = false };
                                    db.posao.Add(pos);
                                    db.SaveChanges();

                                    int idPosla = pos.id_posao;

                                    foreach (var itemVozilo in vozilo)
                                    {
                                        db.radna_skupina.Add(new radna_skupina { posaoid_posao = idPosla, vozilaid_vozilo = itemVozilo });
                                        db.SaveChanges();
                                    }

                                    foreach (var itemRadnik in radnik)
                                    {
                                        db.tim.Add(new tim { posaoid_posao = idPosla, radniciidradnik = itemRadnik });
                                        db.SaveChanges();
                                    }

                                    foreach (var itemUsluga in usluga)
                                    {
                                        db.usluga_posao.Add(new usluga_posao { posaoid_posao = idPosla, uslugaid_usluga = itemUsluga });
                                        db.SaveChanges();
                                    }

                                    if (!unaprijed.Equals(""))
                                    {
                                        DateTime dt = Convert.ToDateTime(datum);
                                        DateTime maxUnaprijed = dt.AddMonths(2);
                                        do
                                        {
                                            dt = dt.AddDays(Convert.ToInt32(unaprijed));

                                            klijent kli = db.klijent.Where(k => k.naziv.Equals(klijent)).SingleOrDefault();
                                            int idKli = kli.id_klijent;

                                            posao poslic = new posao { adresa_ciscenja = adresa, velicina_prostora = Convert.ToInt32(kvadratura), cijena = cijena, vrijeme = termin, datum = dt, tip_posla = tipPosla, klijentid_klijent = idKli };
                                            db.posao.Add(poslic);
                                            db.SaveChanges();

                                            int idPoslica = poslic.id_posao;

                                            foreach (var itemVozilo in vozilo)
                                            {
                                                db.radna_skupina.Add(new radna_skupina { posaoid_posao = idPoslica, vozilaid_vozilo = itemVozilo });
                                                db.SaveChanges();
                                            }

                                            foreach (var itemRadnik in radnik)
                                            {
                                                db.tim.Add(new tim { posaoid_posao = idPoslica, radniciidradnik = itemRadnik });
                                                db.SaveChanges();
                                            }

                                            foreach (var itemUsluga in usluga)
                                            {
                                                db.usluga_posao.Add(new usluga_posao { posaoid_posao = idPoslica, uslugaid_usluga = itemUsluga });
                                                db.SaveChanges();
                                            }

                                        } while (dt < maxUnaprijed);


                                    }


                                    MessageBox.Show("Posao je uspješno dodan.");

                                    frmDodajPosao f1 = (frmDodajPosao)Application.OpenForms["frmDodajPosao"];
                                    f1.Close();
                                }

                            }
                        }
                    }



                }
            }
        }

        public void azurirajPosao(DataGridViewRow row, string datum, string vrijeme, string adresa, string kvadratura, string tipPosla, string cijena, string klijent, List<int> usluga, List<int> radnik, List<int> vozilo, string trajanjePosla)
        {
            string idPosao = row.Cells[5].Value.ToString();
            int ID = Convert.ToInt32(idPosao);

            //spremi trenutne postavke za posao koji se želi ažurirati
            var usluge = db.usluga_posao.Where(u => u.posaoid_posao.Equals(ID));
            var tim = db.tim.Where(t => t.posaoid_posao.Equals(ID));
            var radna = db.radna_skupina.Where(r => r.posaoid_posao.Equals(ID));
            posao posao = db.posao.Where(p => p.id_posao.Equals(ID)).SingleOrDefault();

            if (adresa.Equals("") || kvadratura.Equals("") || klijent.Equals("") || cijena.Equals("") || usluga.Count == 0 || vozilo.Count == 0 || radnik.Count == 0)
            {
                MessageBox.Show("Sva polja moraju biti popunjena");
            }
            else
            {
                int number;
                if (Int32.TryParse(kvadratura, out number) == false)
                {
                    MessageBox.Show("Unesena kvadratura nije ispravnog formata");
                }
                else
                {
                    // bool adresaZauzeta = false;
                    bool radniciZauzeti = false;
                    bool vozilaZauzeta = false;

                    string termin = pomocna.ParsirajTermin(vrijeme, trajanjePosla);
                    string[] poljeTermin = termin.Split('-');
                    if (poljeTermin[1].Equals(""))
                    {
                        MessageBox.Show("Pogrešan odabir kod termina. Pazite da ukupan termin ne prelazi 20:00 h.");
                    }
                    else
                    {
                        //provjeri adresu
                        //foreach (var item in db.posao)
                        //{
                        //    if (!item.id_posao.Equals(ID))
                        //    {
                        //        DateTime dt = Convert.ToDateTime(datum);

                        //        if (item.adresa_ciscenja.Equals(adresa) && item.datum == dt)
                        //        {
                        //            string terminPosla = item.vrijeme;
                        //            string[] poljeZeljenihTermina = pomocna.VratiPoljeTermina(termin);
                        //            string[] poljeZauzetihTermina = pomocna.VratiPoljeTermina(terminPosla);
                        //            if (poljeZauzetihTermina.Any(x => poljeZeljenihTermina.Contains(x)))
                        //            {
                        //                adresaZauzeta = true;
                        //            }

                        //        }
                        //    }
                        //}
                        //provjeri radnike
                        foreach (int idRadnika in radnik)
                        {
                            foreach (var item in db.tim)
                            {
                                if (!item.posaoid_posao.Equals(ID))
                                {
                                    if (idRadnika.Equals(item.radniciidradnik))
                                    {
                                        if (item.posao.datum.Equals(Convert.ToDateTime(datum)))
                                        {
                                            string terminPosla = item.posao.vrijeme;
                                            string[] poljeZeljenihTermina = pomocna.VratiPoljeTermina(termin);
                                            string[] poljeZauzetihTermina = pomocna.VratiPoljeTermina(terminPosla);

                                            foreach (var itemZeljeni in poljeZeljenihTermina)
                                            {
                                                if (itemZeljeni != null)
                                                {
                                                    foreach (var itemZauzeti in poljeZauzetihTermina)
                                                    {
                                                        if (itemZauzeti != null)
                                                        {
                                                            if (itemZeljeni.Equals(itemZauzeti))
                                                            {
                                                                radniciZauzeti = false;
                                                            }
                                                        }
                                                    }
                                                }

                                            }
                                        }

                                    }
                                }

                            }
                        }
                        //provjeri vozila
                        foreach (int idVozila in vozilo)
                        {
                            foreach (var item in db.radna_skupina)
                            {
                                if (!item.posaoid_posao.Equals(ID))
                                {
                                    if (idVozila.Equals(item.vozilaid_vozilo))
                                    {
                                        if (item.posao.datum.Equals(Convert.ToDateTime(datum)))
                                        {
                                            string terminPosla = item.posao.vrijeme;
                                            string[] poljeZeljenihTermina = pomocna.VratiPoljeTermina(termin);
                                            string[] poljeZauzetihTermina = pomocna.VratiPoljeTermina(terminPosla);

                                            foreach (var itemZeljeni in poljeZeljenihTermina)
                                            {
                                                if (itemZeljeni != null)
                                                {
                                                    foreach (var itemZauzeti in poljeZauzetihTermina)
                                                    {
                                                        if (itemZauzeti != null)
                                                        {
                                                            if (itemZeljeni.Equals(itemZauzeti))
                                                            {
                                                                vozilaZauzeta = false;
                                                            }
                                                        }
                                                    }
                                                }

                                            }
                                        }

                                    }
                                }

                            }
                        }

                        //if (adresaZauzeta)
                        //{
                        //    MessageBox.Show("Adresa je zauzeta");
                        //}
                        if (radniciZauzeti)
                        {
                            MessageBox.Show("Jedan ili više radnika je u to vrijeme zazeto");
                        }
                        else if (vozilaZauzeta)
                        {
                            MessageBox.Show("Jedno ili više vozila su u tom terminu zauzeti");
                        }
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da želite ažurirati posao?", "Potvrda ažuriranja posla", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {

                                klijent kl = db.klijent.Where(k => k.naziv.Equals(klijent)).SingleOrDefault();
                                int idKlijenta = kl.id_klijent;

                                posao.adresa_ciscenja = adresa;
                                posao.cijena = cijena;
                                posao.klijentid_klijent = idKlijenta;
                                posao.tip_posla = tipPosla;
                                posao.vrijeme = termin;
                                posao.velicina_prostora = Convert.ToInt32(kvadratura);


                                //obriši sve iz slabih entiteta vezano za taj posao
                                var uslugeStaro = db.usluga_posao.Where(u => u.posaoid_posao.Equals(ID));
                                foreach (var item in uslugeStaro)
                                {
                                    db.usluga_posao.Remove(item);
                                }
                                db.SaveChanges();
                                var timStaro = db.tim.Where(t => t.posaoid_posao.Equals(ID));

                                foreach (var itemTim in timStaro)
                                {
                                    db.tim.Remove(itemTim);
                                }
                                db.SaveChanges();

                                var radnaStaro = db.radna_skupina.Where(r => r.posaoid_posao.Equals(ID));
                                foreach (var itemRadna in radnaStaro)
                                {
                                    db.radna_skupina.Remove(itemRadna);
                                }
                                db.SaveChanges();

                                //dodaj ažuriranje vrijednosti u slabe entitete

                                foreach (var itemVozilo in vozilo)
                                {
                                    db.radna_skupina.Add(new radna_skupina { posaoid_posao = posao.id_posao, vozilaid_vozilo = itemVozilo });
                                    db.SaveChanges();
                                }

                                foreach (var itemRadnik in radnik)
                                {
                                    db.tim.Add(new tim { posaoid_posao = posao.id_posao, radniciidradnik = itemRadnik });
                                    db.SaveChanges();
                                }

                                foreach (var itemUsluga in usluga)
                                {
                                    db.usluga_posao.Add(new usluga_posao { posaoid_posao = posao.id_posao, uslugaid_usluga = itemUsluga });
                                    db.SaveChanges();
                                }


                                frmAzurirajPosao f1 = (frmAzurirajPosao)Application.OpenForms["frmAzurirajPosao"];
                                f1.Close();

                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }

                }
            }


        }

        public void brisiPosao(DataGridViewRow row)
        {
            object nesto = row.Cells[1].Value;

            if (nesto != null)
            {

                DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da želite obrisati odabrani posao?", "Potvrda brisanja posla", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string IDposla = row.Cells[5].Value.ToString();
                    int ID = Convert.ToInt32(IDposla);

                    var usluge = db.usluga_posao.Where(u => u.posaoid_posao.Equals(ID));
                    foreach (var item in usluge)
                    {
                        db.usluga_posao.Remove(item);
                    }
                    db.SaveChanges();

                    var tim = db.tim.Where(t => t.posaoid_posao.Equals(ID));

                    foreach (var itemTim in tim)
                    {
                        db.tim.Remove(itemTim);
                    }

                    db.SaveChanges();

                    var radna = db.radna_skupina.Where(r => r.posaoid_posao.Equals(ID));
                    foreach (var itemRadna in radna)
                    {
                        db.radna_skupina.Remove(itemRadna);
                    }

                    db.SaveChanges();

                    posao pos = db.posao.Where(p => p.id_posao.Equals(ID)).SingleOrDefault();
                    db.posao.Remove(pos);
                    db.SaveChanges();

                    MessageBox.Show("Posao je uspješno izbrisan.");
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }

            }

        }

        public List<int> DohvatiOdabraneUsluge(DataGridView d)
        {
            List<int> listaOdabranihUsluga = new List<int>();
            foreach (DataGridViewRow row in d.Rows)
            {
                if (Convert.ToBoolean(row.Cells[4].Value))
                {
                    listaOdabranihUsluga.Add(Convert.ToInt32(row.Cells[0].Value));
                }
            }
            return listaOdabranihUsluga;
        }


        public void PripremiDataGridOdaberiUsluge(DataGridView d, frmDodajPosao f)
        {
            d.Columns[0].Visible = false;
            d.Columns[1].HeaderText = "Naziv";
            d.Columns[2].HeaderText = "Cijena/m2";
            d.Columns[3].Visible = false;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            d.Columns.Add(chk);

            d.Columns[0].ReadOnly = true;
            d.Columns[1].ReadOnly = true;
            d.Columns[2].ReadOnly = true;
            d.Columns[3].ReadOnly = true;
            d.Columns[4].ReadOnly = false;

            if (f.listaUsluga.Count != 0)
            {
                foreach (var item in f.listaUsluga)
                {
                    foreach (DataGridViewRow item2 in d.Rows)
                    {
                        if (item.Equals(Convert.ToInt32(item2.Cells[0].Value)))
                        {
                            item2.Cells[4].Value = true;
                        }
                    }
                }
            }
        }


        public void PripremiDataGridOdaberiRadnike(DataGridView d, frmDodajPosao f)
        {
            d.Columns[0].Visible = false;
            d.Columns[1].HeaderText = "Ime";
            d.Columns[2].HeaderText = "Prezime";
            d.Columns[3].HeaderText = "Broj telefona";
            d.Columns[4].Visible = false;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            d.Columns.Add(chk);

            d.Columns[0].ReadOnly = true;
            d.Columns[1].ReadOnly = true;
            d.Columns[2].ReadOnly = true;
            d.Columns[3].ReadOnly = true;
            d.Columns[4].ReadOnly = true;
            d.Columns[5].ReadOnly = false;

            if (f.listaRadnika.Count != 0)
            {
                foreach (var item in f.listaRadnika)
                {
                    foreach (DataGridViewRow item2 in d.Rows)
                    {
                        if (item.Equals(Convert.ToInt32(item2.Cells[0].Value)))
                        {
                            item2.Cells[5].Value = true;
                        }
                    }
                }
            }
        }

        public void PripremiDataGridOdaberiVozila(DataGridView d, frmDodajPosao f)
        {
            d.Columns[0].Visible = false;
            d.Columns[1].HeaderText = "Registracijska oznaka";
            d.Columns[2].HeaderText = "Model";
            d.Columns[3].Visible = false;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            d.Columns.Add(chk);

            d.Columns[0].ReadOnly = true;
            d.Columns[1].ReadOnly = true;
            d.Columns[2].ReadOnly = true;
            d.Columns[3].ReadOnly = true;
            d.Columns[4].ReadOnly = false;

            if (f.listaVozila.Count != 0)
            {
                foreach (var item in f.listaVozila)
                {
                    foreach (DataGridViewRow item2 in d.Rows)
                    {
                        if (item.Equals(Convert.ToInt32(item2.Cells[0].Value)))
                        {
                            item2.Cells[4].Value = true;
                        }
                    }
                }
            }
        }


        public List<int> DohvatiOdabraneRadnike(DataGridView d)
        {
            List<int> listaOdabranihRadnika = new List<int>();
            foreach (DataGridViewRow row in d.Rows)
            {
                if (Convert.ToBoolean(row.Cells[5].Value))
                {
                    listaOdabranihRadnika.Add(Convert.ToInt32(row.Cells[0].Value));
                }
            }
            return listaOdabranihRadnika;
        }

        public List<int> DohvatiOdabranaVozila(DataGridView d)
        {
            List<int> listaOdabranihVozila = new List<int>();
            foreach (DataGridViewRow row in d.Rows)
            {
                if (Convert.ToBoolean(row.Cells[4].Value))
                {
                    listaOdabranihVozila.Add(Convert.ToInt32(row.Cells[0].Value));
                }
            }
            return listaOdabranihVozila;
        }

        public void IzracunCijene(frmDodajPosao f)
        {
            if (f.Kvadratura != "")
            {
                const double faktorŽurno = 2.5;
                double cijena = 1;

                foreach (var item in f.listaUsluga)
                {
                    usluga usl = db.usluga.Where(u => u.id_usluga.Equals(item)).SingleOrDefault();
                    cijena *= usl.cijenaKvadrat ?? 1;
                }
                cijena = cijena * Convert.ToDouble(f.Kvadratura);
                if (f.Tip.Equals("Žurno"))
                {
                    cijena = cijena * faktorŽurno;
                }

                f.Cijena = cijena.ToString();
            }

        }


        public bool ProvjeriZauzetostRadnika(List<int> radnici, string termin, string datum)
        {
            foreach (int idRadnika in radnici)
            {
                foreach (var item in db.tim)
                {
                    if (idRadnika.Equals(item.radniciidradnik))
                    {
                        if (item.posao.datum.Equals(Convert.ToDateTime(datum)))
                        {
                            string terminPosla = item.posao.vrijeme;
                            string[] poljeZeljenihTermina = pomocna.VratiPoljeTermina(termin);
                            string[] poljeZauzetihTermina = pomocna.VratiPoljeTermina(terminPosla);

                            foreach (var itemZeljeni in poljeZeljenihTermina)
                            {
                                if (itemZeljeni != null)
                                {
                                    foreach (var itemZauzeti in poljeZauzetihTermina)
                                    {
                                        if (itemZauzeti != null)
                                        {
                                            if (itemZeljeni.Equals(itemZauzeti))
                                            {
                                                return false;
                                            }
                                        }
                                    }
                                }

                            }
                        }

                    }
                }
            }

            return true;
        }

        public bool ProvjeriZauzetostVozila(List<int> vozila, string termin, string datum)
        {
            foreach (int idVozila in vozila)
            {
                foreach (var item in db.radna_skupina)
                {
                    if (idVozila.Equals(item.vozilaid_vozilo))
                    {
                        if (item.posao.datum.Equals(Convert.ToDateTime(datum)))
                        {
                            string terminPosla = item.posao.vrijeme;
                            string[] poljeZeljenihTermina = pomocna.VratiPoljeTermina(termin);
                            string[] poljeZauzetihTermina = pomocna.VratiPoljeTermina(terminPosla);

                            foreach (var itemZeljeni in poljeZeljenihTermina)
                            {
                                if (itemZeljeni != null)
                                {
                                    foreach (var itemZauzeti in poljeZauzetihTermina)
                                    {
                                        if (itemZauzeti != null)
                                        {
                                            if (itemZeljeni.Equals(itemZauzeti))
                                            {
                                                return false;
                                            }
                                        }
                                    }
                                }

                            }
                        }

                    }
                }
            }

            return true;
        }

        public void PripremiDataGridPopisPoslova(DataGridView d, frmDayView f, string datum)
        {
            d.Columns[0].ReadOnly = true;
            d.Columns[1].ReadOnly = true;
            d.Columns[2].ReadOnly = true;
            d.Columns[3].ReadOnly = true;
            d.Columns[4].ReadOnly = true;
            d.Columns[5].Visible = false;

            d.Columns[0].HeaderText = "Termini";
            d.Columns[1].HeaderText = "Kvadratura";
            d.Columns[2].HeaderText = "Tip posla";
            d.Columns[3].HeaderText = "Cijena";
            d.Columns[4].HeaderText = "Klijent";

            ServisCiscenjeDBEntities db2 = new ServisCiscenjeDBEntities();
            foreach (DataGridViewRow dr in d.Rows)
            {
                dr.Height = 27;

                List<CmbItemAdresa> listaAdresa = new List<CmbItemAdresa>();
                string termin = dr.Cells[0].Value.ToString();

                foreach (var item in db2.posao)
                {
                    string[] poljeTermina = pomocna.VratiPoljeTermina(item.vrijeme);
                    if (poljeTermina.Contains(termin) && item.datum.Equals(Convert.ToDateTime(datum)))
                    {
                        listaAdresa.Add(new CmbItemAdresa { Adresa = item.adresa_ciscenja, ID = item.id_posao });
                    }
                }

                BindingSource bs = new BindingSource();
                bs.DataSource = listaAdresa;

                pomocna.NapuniComboboxevePopisAdresa(bs, f, dr.Index);

            }
        }

        public DateTime[] VratiZauzeteDatume()
        {
            DateTime[] absentDates = new DateTime[100000];
            List<DateTime> listaDatuma = new List<DateTime>();
            int brojPoslova = db.posao.Count();
            foreach (var item in db.posao)
            {
                if (item.datum != null)
                {
                    DateTime dat = item.datum ?? DateTime.Now;
                    listaDatuma.Add(dat);
                }
            }

            for (int i = 0; i < listaDatuma.Count; i++)
            {
                absentDates[i] = listaDatuma.ElementAt(i);
            }

            return absentDates;
        }

        public void PoveziCmbxSaDataGridom(DataGridView d, frmDayView f)
        {
            foreach (DataGridViewRow row in d.Rows)
            {
                switch (row.Index)
                {
                    case 0:
                        if (f.Cmb0Text != null)
                        {
                            int idUsluge;
                            if (f.Cmb0Text is CmbItemAdresa)
                            {
                                CmbItemAdresa adr = (CmbItemAdresa)f.Cmb0Text;
                                idUsluge = adr.ID;
                            }
                            else
                            {
                                idUsluge = (int)f.Cmb0Text;
                            }

                            //posao pos = db.posao.Where(p => p.adresa_ciscenja.Equals(f.Cmb0Text) && p.datum == dt1).SingleOrDefault();
                            posao pos = db.posao.Where(p => p.id_posao.Equals(idUsluge)).SingleOrDefault();
                            if (pos != null)
                            {
                                row.Cells[1].Value = pos.velicina_prostora;
                                row.Cells[2].Value = pos.tip_posla;
                                row.Cells[3].Value = pos.cijena;
                                row.Cells[4].Value = pos.klijent.naziv;
                                row.Cells[5].Value = pos.id_posao;
                            }
                        }

                        break;
                    case 1:
                        if (f.Cmb1Text != null)
                        {
                            int idUsluge;
                            if (f.Cmb1Text is CmbItemAdresa)
                            {
                                CmbItemAdresa adr = (CmbItemAdresa)f.Cmb1Text;
                                idUsluge = adr.ID;
                            }
                            else
                            {
                                idUsluge = (int)f.Cmb1Text;
                            }
                            //posao pos1 = db.posao.Where(p => p.adresa_ciscenja.Equals(f.Cmb1Text)).SingleOrDefault();
                            posao pos1 = db.posao.Where(p => p.id_posao.Equals(idUsluge)).SingleOrDefault();
                            if (pos1 != null)
                            {
                                row.Cells[1].Value = pos1.velicina_prostora;
                                row.Cells[2].Value = pos1.tip_posla;
                                row.Cells[3].Value = pos1.cijena;
                                row.Cells[4].Value = pos1.klijent.naziv;
                                row.Cells[5].Value = pos1.id_posao;
                            }

                        }

                        break;
                    case 2:
                        if (f.Cmb2Text != null)
                        {
                            int idUsluge;
                            if (f.Cmb2Text is CmbItemAdresa)
                            {
                                CmbItemAdresa adr = (CmbItemAdresa)f.Cmb2Text;
                                idUsluge = adr.ID;
                            }
                            else
                            {
                                idUsluge = (int)f.Cmb2Text;
                            }
                            posao pos2 = db.posao.Where(p => p.id_posao.Equals(idUsluge)).SingleOrDefault();
                            if (pos2 != null)
                            {
                                row.Cells[1].Value = pos2.velicina_prostora;
                                row.Cells[2].Value = pos2.tip_posla;
                                row.Cells[3].Value = pos2.cijena;
                                row.Cells[4].Value = pos2.klijent.naziv;
                                row.Cells[5].Value = pos2.id_posao;
                            }
                        }

                        break;
                    case 3:
                        if (f.Cmb3Text != null)
                        {
                            int idUsluge;
                            if (f.Cmb3Text is CmbItemAdresa)
                            {
                                CmbItemAdresa adr = (CmbItemAdresa)f.Cmb3Text;
                                idUsluge = adr.ID;
                            }
                            else
                            {
                                idUsluge = (int)f.Cmb3Text;
                            }
                            posao pos11 = db.posao.Where(p => p.id_posao.Equals(idUsluge)).SingleOrDefault();
                            if (pos11 != null)
                            {
                                row.Cells[1].Value = pos11.velicina_prostora;
                                row.Cells[2].Value = pos11.tip_posla;
                                row.Cells[3].Value = pos11.cijena;
                                row.Cells[4].Value = pos11.klijent.naziv;
                                row.Cells[5].Value = pos11.id_posao;
                            }
                        }

                        break;
                    case 4:
                        if (f.Cmb4Text != null)
                        {
                            int idUsluge;
                            if (f.Cmb4Text is CmbItemAdresa)
                            {
                                CmbItemAdresa adr = (CmbItemAdresa)f.Cmb4Text;
                                idUsluge = adr.ID;
                            }
                            else
                            {
                                idUsluge = (int)f.Cmb4Text;
                            }
                            posao pos3 = db.posao.Where(p => p.id_posao.Equals(idUsluge)).SingleOrDefault();
                            if (pos3 != null)
                            {
                                row.Cells[1].Value = pos3.velicina_prostora;
                                row.Cells[2].Value = pos3.tip_posla;
                                row.Cells[3].Value = pos3.cijena;
                                row.Cells[4].Value = pos3.klijent.naziv;
                                row.Cells[5].Value = pos3.id_posao;
                            }
                        }

                        break;
                    case 5:
                        if (f.Cmb5Text != null)
                        {
                            int idUsluge;
                            if (f.Cmb5Text is CmbItemAdresa)
                            {
                                CmbItemAdresa adr = (CmbItemAdresa)f.Cmb5Text;
                                idUsluge = adr.ID;
                            }
                            else
                            {
                                idUsluge = (int)f.Cmb5Text;
                            }
                            posao pos4 = db.posao.Where(p => p.id_posao.Equals(idUsluge)).SingleOrDefault();
                            if (pos4 != null)
                            {
                                row.Cells[1].Value = pos4.velicina_prostora;
                                row.Cells[2].Value = pos4.tip_posla;
                                row.Cells[3].Value = pos4.cijena;
                                row.Cells[4].Value = pos4.klijent.naziv;
                                row.Cells[5].Value = pos4.id_posao;
                            }
                        }

                        break;
                    case 6:
                        if (f.Cmb6Text != null)
                        {
                            int idUsluge;
                            if (f.Cmb6Text is CmbItemAdresa)
                            {
                                CmbItemAdresa adr = (CmbItemAdresa)f.Cmb6Text;
                                idUsluge = adr.ID;
                            }
                            else
                            {
                                idUsluge = (int)f.Cmb6Text;
                            }
                            posao pos5 = db.posao.Where(p => p.id_posao.Equals(idUsluge)).SingleOrDefault();
                            if (pos5 != null)
                            {
                                row.Cells[1].Value = pos5.velicina_prostora;
                                row.Cells[2].Value = pos5.tip_posla;
                                row.Cells[3].Value = pos5.cijena;
                                row.Cells[4].Value = pos5.klijent.naziv;
                                row.Cells[5].Value = pos5.id_posao;
                            }
                        }
                        break;
                    case 7:
                        if (f.Cmb7Text != null)
                        {
                            int idUsluge;
                            if (f.Cmb7Text is CmbItemAdresa)
                            {
                                CmbItemAdresa adr = (CmbItemAdresa)f.Cmb7Text;
                                idUsluge = adr.ID;
                            }
                            else
                            {
                                idUsluge = (int)f.Cmb7Text;
                            }
                            posao pos6 = db.posao.Where(p => p.id_posao.Equals(idUsluge)).SingleOrDefault();
                            if (pos6 != null)
                            {
                                row.Cells[1].Value = pos6.velicina_prostora;
                                row.Cells[2].Value = pos6.tip_posla;
                                row.Cells[3].Value = pos6.cijena;
                                row.Cells[4].Value = pos6.klijent.naziv;
                                row.Cells[5].Value = pos6.id_posao;
                            }
                        }
                        break;
                    case 8:
                        if (f.Cmb8Text != null)
                        {
                            int idUsluge;
                            if (f.Cmb8Text is CmbItemAdresa)
                            {
                                CmbItemAdresa adr = (CmbItemAdresa)f.Cmb8Text;
                                idUsluge = adr.ID;
                            }
                            else
                            {
                                idUsluge = (int)f.Cmb8Text;
                            }
                            posao pos7 = db.posao.Where(p => p.id_posao.Equals(idUsluge)).SingleOrDefault();
                            if (pos7 != null)
                            {
                                row.Cells[1].Value = pos7.velicina_prostora;
                                row.Cells[2].Value = pos7.tip_posla;
                                row.Cells[3].Value = pos7.cijena;
                                row.Cells[4].Value = pos7.klijent.naziv;
                                row.Cells[5].Value = pos7.id_posao;
                            }
                        }
                        break;
                    case 9:
                        if (f.Cmb9Text != null)
                        {
                            int idUsluge;
                            if (f.Cmb9Text is CmbItemAdresa)
                            {
                                CmbItemAdresa adr = (CmbItemAdresa)f.Cmb9Text;
                                idUsluge = adr.ID;
                            }
                            else
                            {
                                idUsluge = (int)f.Cmb9Text;
                            }
                            posao pos8 = db.posao.Where(p => p.id_posao.Equals(idUsluge)).SingleOrDefault();
                            if (pos8 != null)
                            {
                                row.Cells[1].Value = pos8.velicina_prostora;
                                row.Cells[2].Value = pos8.tip_posla;
                                row.Cells[3].Value = pos8.cijena;
                                row.Cells[4].Value = pos8.klijent.naziv;
                                row.Cells[5].Value = pos8.id_posao;
                            }
                        }
                        break;
                    case 10:
                        if (f.Cmb10Text != null)
                        {
                            int idUsluge;
                            if (f.Cmb10Text is CmbItemAdresa)
                            {
                                CmbItemAdresa adr = (CmbItemAdresa)f.Cmb10Text;
                                idUsluge = adr.ID;
                            }
                            else
                            {
                                idUsluge = (int)f.Cmb10Text;
                            }
                            posao pos9 = db.posao.Where(p => p.id_posao.Equals(idUsluge)).SingleOrDefault();
                            if (pos9 != null)
                            {
                                row.Cells[1].Value = pos9.velicina_prostora;
                                row.Cells[2].Value = pos9.tip_posla;
                                row.Cells[3].Value = pos9.cijena;
                                row.Cells[4].Value = pos9.klijent.naziv;
                                row.Cells[5].Value = pos9.id_posao;
                            }
                        }
                        break;
                    case 11:
                        if (f.Cmb11Text != null)
                        {
                            int idUsluge;
                            if (f.Cmb11Text is CmbItemAdresa)
                            {
                                CmbItemAdresa adr = (CmbItemAdresa)f.Cmb11Text;
                                idUsluge = adr.ID;
                            }
                            else
                            {
                                idUsluge = (int)f.Cmb11Text;
                            }
                            posao pos10 = db.posao.Where(p => p.id_posao.Equals(idUsluge)).SingleOrDefault();
                            if (pos10 != null)
                            {
                                row.Cells[1].Value = pos10.velicina_prostora;
                                row.Cells[2].Value = pos10.tip_posla;
                                row.Cells[3].Value = pos10.cijena;
                                row.Cells[4].Value = pos10.klijent.naziv;
                                row.Cells[5].Value = pos10.id_posao;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        public bool ProvjeriAdresu(string adresa, string datum, string termin)
        {
            foreach (var item in db.posao)
            {
                if (item.datum.Equals(Convert.ToDateTime(datum)))
                {
                    if (item.adresa_ciscenja.Equals(adresa))
                    {
                        string[] poljeZeljenihTermina = pomocna.VratiPoljeTermina(termin);
                        string[] poljeZauzetihTermina = pomocna.VratiPoljeTermina(item.vrijeme);

                        foreach (var itemZeljeni in poljeZeljenihTermina)
                        {
                            if (itemZeljeni != null)
                            {
                                foreach (var itemZauzeti in poljeZauzetihTermina)
                                {
                                    if (itemZauzeti != null)
                                    {
                                        if (itemZeljeni.Equals(itemZauzeti))
                                        {
                                            return false;
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }

            return true;
        }

        public void OsvjeziKalendar(MonthCalendar cal)
        {
            cal.BoldedDates = VratiZauzeteDatume();
        }


        public void PreuzmiPodatkeOPoslu(DataGridViewRow row, frmAzurirajPosao f)
        {
            string klijent = row.Cells[4].Value.ToString();
            if (klijent != "")
            {
                string idPosla = row.Cells[5].Value.ToString();
                int ID = Convert.ToInt32(idPosla);
                foreach (var item in db.posao)
                {
                    if (item.id_posao.Equals(ID))
                    {
                        int broj;
                        string vri = item.vrijeme;
                        string[] polje = pomocna.VratiPoljeTermina(vri);
                        if (polje.Length == 1)
                        {
                            broj = 1;
                        }
                        else
                        {
                            broj = polje.Length;
                        }


                        f.Datum = item.datum.ToString();
                        f.Vrijeme = polje[0];
                        f.Adresa = item.adresa_ciscenja;
                        f.Kvadratura = item.velicina_prostora.ToString();
                        f.TipPosla = item.tip_posla;
                        f.Klijent = item.klijent.naziv;
                        f.TrajanjePosla = broj.ToString();
                        f.Cijena = item.cijena;
                    }
                }
            }
            
        }


        public void PripremiDataGridOdaberiUslugeZaAzuriranje(DataGridView d, frmAzurirajPosao f, DataGridViewRow row)
        {
            d.Columns[0].Visible = false;
            d.Columns[1].HeaderText = "Naziv";
            d.Columns[2].HeaderText = "Cijena/m2";
            d.Columns[3].Visible = false;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            d.Columns.Add(chk);

            d.Columns[0].ReadOnly = true;
            d.Columns[1].ReadOnly = true;
            d.Columns[2].ReadOnly = true;
            d.Columns[3].ReadOnly = true;
            d.Columns[4].ReadOnly = false;

            if (f.listaUsluga.Count != 0)
            {
                foreach (var item in f.listaUsluga)
                {
                    foreach (DataGridViewRow item2 in d.Rows)
                    {
                        if (item.Equals(Convert.ToInt32(item2.Cells[0].Value)))
                        {
                            item2.Cells[4].Value = true;
                        }
                    }
                }
            }
        }

        public void PripremiDataGridOdaberiRadnikeZaAzuriranje(DataGridView d, frmAzurirajPosao f, DataGridViewRow row)
        {
            d.Columns[0].Visible = false;
            d.Columns[1].HeaderText = "Ime";
            d.Columns[2].HeaderText = "Prezime";
            d.Columns[3].HeaderText = "Broj telefona";
            d.Columns[4].Visible = false;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            d.Columns.Add(chk);

            d.Columns[0].ReadOnly = true;
            d.Columns[1].ReadOnly = true;
            d.Columns[2].ReadOnly = true;
            d.Columns[3].ReadOnly = true;
            d.Columns[4].ReadOnly = true;
            d.Columns[5].ReadOnly = false;

            if (f.listaRadnika.Count != 0)
            {
                foreach (var item in f.listaRadnika)
                {
                    foreach (DataGridViewRow item2 in d.Rows)
                    {
                        if (item.Equals(Convert.ToInt32(item2.Cells[0].Value)))
                        {
                            item2.Cells[5].Value = true;
                        }
                    }
                }
            }
        }

        public void PripremiDataGridOdaberiVozilaZaAzuriranje(DataGridView d, frmAzurirajPosao f, DataGridViewRow row)
        {
            d.Columns[0].Visible = false;
            d.Columns[1].HeaderText = "Registracijska oznaka";
            d.Columns[2].HeaderText = "Model";
            d.Columns[3].Visible = false;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            d.Columns.Add(chk);

            d.Columns[0].ReadOnly = true;
            d.Columns[1].ReadOnly = true;
            d.Columns[2].ReadOnly = true;
            d.Columns[3].ReadOnly = true;
            d.Columns[4].ReadOnly = false;

            if (f.listaVozila.Count != 0)
            {
                foreach (var item in f.listaVozila)
                {
                    foreach (DataGridViewRow item2 in d.Rows)
                    {
                        if (item.Equals(Convert.ToInt32(item2.Cells[0].Value)))
                        {
                            item2.Cells[4].Value = true;
                        }
                    }
                }
            }
        }


        public void IzracunCijeneKodAzuriranja(frmAzurirajPosao f)
        {
            if (f.KvadraturaGet != "")
            {
                const double faktorŽurno = 2.5;
                double cijena = 1;

                foreach (var item in f.listaUsluga)
                {
                    usluga usl = db.usluga.Where(u => u.id_usluga.Equals(item)).SingleOrDefault();
                    cijena *= usl.cijenaKvadrat ?? 1;
                }
                cijena = cijena * Convert.ToDouble(f.KvadraturaGet);
                if (f.TipGet.Equals("Žurno"))
                {
                    cijena = cijena * faktorŽurno;
                }

                f.Cijena = cijena.ToString();
            }
        }


        public void PreuzmiListuRadnika(DataGridViewRow row, frmAzurirajPosao f)
        {
            string idUsluga = row.Cells[5].Value.ToString();
            int ID = Convert.ToInt32(idUsluga);

            foreach (var item in db.tim)
            {
                if (item.posaoid_posao.Equals(ID))
                {
                    f.listaRadnika.Add(item.radniciidradnik);
                }
            }
        }

        public void PreuzmiListuUsluga(DataGridViewRow row, frmAzurirajPosao f)
        {
            string idUsluga = row.Cells[5].Value.ToString();
            int ID = Convert.ToInt32(idUsluga);

            foreach (var item in db.usluga_posao)
            {
                if (item.posaoid_posao.Equals(ID))
                {
                    f.listaUsluga.Add(item.uslugaid_usluga);
                }
            }
        }

        public void PreuzmiListuVozila(DataGridViewRow row, frmAzurirajPosao f)
        {
            string idUsluga = row.Cells[5].Value.ToString();
            int ID = Convert.ToInt32(idUsluga);

            foreach (var item in db.radna_skupina)
            {
                if (item.posaoid_posao.Equals(ID))
                {
                    f.listaVozila.Add(item.vozilaid_vozilo);
                }
            }


        }

        public void dajAdresu(frmDodajPosao f, string naziv)
        {
            foreach (var item in db.klijent)
            {
                if (item.naziv.Equals(naziv))
                {
                    f.Adresa = item.adresa;
                }
            }
        }


        public void dajAdresuAzuriranje(frmAzurirajPosao f, string naziv)
        {
            foreach (var item in db.klijent)
            {
                if (item.naziv.Equals(naziv))
                {
                    f.Adresa = item.adresa;
                }
            }
        }


        public void SaljiMail()
        {
            const double dayInMillisec = 86400000.0;
            DateTime now = DateTime.Now.Date;
            foreach (var posao in db.posao)
            {
                if (posao.klijent.primanjeObavijesti.Equals("Da") && posao.mailPoslan.Equals(false))
                {
                    DateTime datumBaza = posao.datum ?? DateTime.Now;
                    TimeSpan preostaloVrijeme = datumBaza.Subtract(now);
                    double da = preostaloVrijeme.TotalMilliseconds;

                    if (preostaloVrijeme.TotalMilliseconds <= dayInMillisec)
                    {
                        
                        pomocna.SendEmail(posao.klijent.email, posao.klijent.naziv, posao.vrijeme, posao.datum.ToString());
                        posao.mailPoslan = true;
                        db.SaveChanges();
                    }
                }
            }
        }

        public List<CmbItemRadnik> GetRadnici()
        {
            List<CmbItemRadnik> listaRadnika = new List<CmbItemRadnik>();
            foreach (var item in db.radnici)
            {
                listaRadnika.Add(new CmbItemRadnik { ID = item.idradnik, ImePrezime = item.ime + " " + item.prezime });
            }

            return listaRadnika;
        }


        public void OsvjeziDataGridOusluzi(DataGridView d, List<int> listaUsluga)
        {
            List<usluga> lista = new List<usluga>();
            foreach (var idUsluga in listaUsluga)
            {
                foreach (var item in db.usluga)
                {
                    if (item.id_usluga.Equals(idUsluga))
                    {
                        lista.Add(item);
                    }
                }

            }

            BindingSource bs = new BindingSource();
            bs.DataSource = lista;
            d.DataSource = bs;
            d.Columns[0].Visible = false;
            d.Columns[1].HeaderText = "Naziv";
            d.Columns[2].HeaderText = "Cijena/m2";
            d.Columns[3].Visible = false;

        }

    }
}
