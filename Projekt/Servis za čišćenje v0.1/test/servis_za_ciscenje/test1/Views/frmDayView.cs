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
    public partial class frmDayView : Form
    {
        public frmDayView()
        {
            InitializeComponent();
        }

        public frmDayView(DateTime dan)
        {
            InitializeComponent();
            MessageBox.Show("datum primljeni: " + dan.ToShortDateString());
        }

        private void frmDayView_Load(object sender, EventArgs e)
        {

        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
