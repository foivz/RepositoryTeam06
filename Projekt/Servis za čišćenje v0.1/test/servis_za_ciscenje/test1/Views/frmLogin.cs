using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace servis_za_ciscenje.Views
{
    // Klasa sadrži metode za obradu događaja na formi Login
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // testni podaci
            if (username == "admin" && password == "123456")
            { 
                //otvori main form
                frmMain newMain = new frmMain();
                newMain.Show();
            }
            else
            {
                // prikaži poruku o neuspjehu i očisti textboxove
                MessageBox.Show("Uneseni podaci nisu točni!");
                txtUsername.Clear();
                txtPassword.Clear();
            }

        }
    }
}
