using System;
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
            IBenutzerinformationen benutzerinformationen = new Benutzerinformationen();
        }
    }
}
