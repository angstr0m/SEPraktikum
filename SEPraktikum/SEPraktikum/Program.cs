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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Views.SEPraktikum());
        }

        private static void FillWithTestData()
        {
            MovieTheatre testMovieTheatre = new MovieTheatre("test Kinosaal", 5, 5);
            List<Show> testShows = new List<Show>();
            Show testShow = new Show(new DateTime(2011, 5, 2, 20, 15, 00), new Movie("DER TESTFILM", "TestGenre", 120, "TestLand", new DateTime(2011, 1, 1), 10, "Testmann, Testmann2", "TestRegisseur"), testMovieTheatre, true, 100.0f);
            testShows.Add(testShow);
            MovieProgram testMovieProgram = new MovieProgram(new DateTime(2011, 5, 2), testShows);

            EntityManager<MovieTheatre> emt = new EntityManager<MovieTheatre>();
            emt.AddElement(testMovieTheatre);

            EntityManager<MovieProgram> emp = new EntityManager<MovieProgram>();
            emp.AddElement(testMovieProgram);
        }
    }
}
