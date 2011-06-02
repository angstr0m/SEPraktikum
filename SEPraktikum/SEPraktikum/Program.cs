using System;
using Cinema.Schnittstelle;
using Kinokarten.Schnittstelle;
using Kinokarten.Schnittstelle.Interfaces;
using Users.Interfaces;

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
            BuildComponents();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Views.SEPraktikum());
        }

        private static void BuildComponents()
        {
            // Komponenten initialisieren.
            // Abhängigkeiten zwischen den Komponenten werden per Constructor-Injection aufgebaut.
            IBenutzerinformationen benutzerinformationen = new Benutzerinformationen();
            IKinoInformationen kinoInformationen = new KinoInformationen();
            IKinokartenInformationen kinokartenInformationen = new KinokartenInformationen();
            IKinokartenOperationen kinokartenOperationen = new KinokartenOperationen(benutzerinformationen);
        }
    }
}
