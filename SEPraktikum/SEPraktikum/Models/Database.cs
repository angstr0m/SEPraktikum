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

        private Database() {
            movieTheatres = new List<MovieTheatre>();
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
    }
}
