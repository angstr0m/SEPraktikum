using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Cinema.Models;
using TicketOperations.Models;
using Database.Models;

namespace SEPraktikum.Views.HauptmenuViewSub
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FillWithTestData();
            BuildComponents();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Views.SEPraktikum());
        }

        private static void BuildComponents()
        {
            
        }

        private static void FillWithTestData()
        {
            Kinosaal testKinosaal = new Kinosaal("test Kinosaal", 5, 5);
            List<Vorstellung> testShows = new List<Vorstellung>();
            Vorstellung testVorstellung = new Vorstellung(new DateTime(2011, 5, 2, 20, 15, 00), new Film("DER TESTFILM", "TestGenre", 120, "TestLand", new DateTime(2011, 1, 1), 10, "Testmann, Testmann2", "TestRegisseur"), testKinosaal, true, 100.0f);
            testShows.Add(testVorstellung);
            Filmprogramm testFilmprogramm = new Filmprogramm(new DateTime(2011, 5, 2), testShows);

            EntityManager<Kinosaal> emt = new EntityManager<Kinosaal>();
            emt.AddElement(testKinosaal);

            EntityManager<Filmprogramm> emp = new EntityManager<Filmprogramm>();
            emp.AddElement(testFilmprogramm);
        }
    }
}
