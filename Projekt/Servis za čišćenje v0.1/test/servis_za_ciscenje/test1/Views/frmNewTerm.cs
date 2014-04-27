using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace servis_za_ciscenje
{
    public partial class frmNewTerm : Form
    {
        public frmNewTerm()
        {
            InitializeComponent();
        }

        private void txtSize_Leave(object sender, EventArgs e)
        {
            /*
             todo:
             * currency with 2 decimal places
             * handle invalid input types (strings in int txtboxes)
             */
            txtCurrency.Text = "";
            int size = int.Parse(txtSize.Text);
            float total = 0;
            float currency = 4.2f; // price by m2
            
            // handle currency by m2
            total = (size * currency); 
            
            // MessageBox.Show(a.ToString());

            // write to textbox
            txtCurrency.Text += total.ToString();
        }
    }
}
