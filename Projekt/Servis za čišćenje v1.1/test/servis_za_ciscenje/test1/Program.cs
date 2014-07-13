using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using servis_za_ciscenje.Views;

namespace servis_za_ciscenje
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
