using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SEPraktikum
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Models.testClass();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SEPraktikum());
        }
    }
}
