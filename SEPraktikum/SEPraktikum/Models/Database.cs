using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Database : Interfaces.Subject, Interfaces.Model
    {
        private static Database instance;
        private List<MovieTheatre> movieTheatres;
        private List<MovieProgram> moviePrograms;

        private Database() {
            movieTheatres = new List<MovieTheatre>();
            moviePrograms = new List<MovieProgram>();
            FillWithTestData();
        }

        public static Database Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }

        #region MovieTheatreLogic
        public void addMovieTheatre(MovieTheatre movieTheatre)
        {
            movieTheatres.Add(movieTheatre);
            NotifyObservers();
        }

        public List<MovieTheatre> getMovieTheatres()
        {
            if (movieTheatres == null)
            {
                movieTheatres = new List<MovieTheatre>(); 
            }
            return movieTheatres;
        }

        public void removeMovieTheatre(MovieTheatre movieTheatre)
        {
            movieTheatres.Remove(movieTheatre);
            NotifyObservers();
        }
        #endregion

        #region MovieProgram

        public void addMovieProgram(MovieProgram movieProgram)
        {
            moviePrograms.Add(movieProgram);
            NotifyObservers();
        }

        public MovieProgram getMovieProgramForThisWeek()
        {
            return moviePrograms[0];
        }

        public List<MovieProgram> getMoviePrograms()
        {
            return moviePrograms;
        }

        public void removeMovieTheatre(MovieProgram movieProgram)
        {
            moviePrograms.Remove(movieProgram);
            NotifyObservers();
        }

        #endregion

        private void FillWithTestData()
        {
            MovieTheatre testMovieTheatre = new MovieTheatre("test Kinosaal", 5, 5);
            List<Show> testShows = new List<Show>();
            Show testShow = new Show(new DateTime(2011, 5, 2, 20, 15, 00), new Movie("DER TESTFILM", "TestGenre", 120, "TestLand", new DateTime(2011,1,1), 10, "Testmann, Testmann2", "TestRegisseur"), testMovieTheatre, true, 100.0f);
            testShows.Add(testShow);
            MovieProgram testMovieProgram = new MovieProgram(new DateTime(2011, 5, 2), testShows);
            
            addMovieTheatre(testMovieTheatre);
            addMovieProgram(testMovieProgram);
        }
    }
}
