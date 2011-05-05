using System;
using Base.AbstractClasses;

namespace Cinema.Models {
    public class Movie : Subject
    {
        private String name;
        private String genre;
        private int duration;
        private String originCountry;
        private DateTime startDateTime;
        private int week;
        private int movieRating;
        private String movieCast;
        private String director;

        public Movie(String name ,String genre, int duration, string originCountry, DateTime startDateTime, int movieRating, string movieCast, string director)
        {
            this.name = name;
            this.genre = genre;
            this.duration = duration;
            this.originCountry = originCountry;
            this.startDateTime = startDateTime;
            this.movieRating = movieRating;
            this.movieCast = movieCast;
            this.director = director;
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public string OriginCountry
        {
            get { return originCountry; }
            set { originCountry = value; }
        }

        public System.DateTime StartDateTime
        {
            get { return startDateTime; }
            set { startDateTime = value; }
        }

        public int Week
        {
            get { return week; }
            set { week = value; }
        }

        public int MovieRating
        {
            get { return movieRating; }
            set { movieRating = value; }
        }

        public string MovieCast
        {
            get { return movieCast; }
            set { movieCast = value; }
        }

        public string Director
        {
            get { return director; }
            set { director = value; }
        }
    }

}
