using System;
using Base.AbstractClasses;

namespace Cinema.Models {
    /// <summary>
    /// Representing a single movie. Movies are organized in MoviePrograms.
    /// </summary>
    /// <remarks></remarks>
    public class Movie : Subject
    {
        /// <summary>
        /// Name of the movie.
        /// </summary>
        private String name;
        /// <summary>
        /// genre of the movie
        /// </summary>
        private String genre;
        /// <summary>
        /// duration in minutes
        /// </summary>
        private int duration;
        /// <summary>
        /// 
        /// </summary>
        private String originCountry;
        /// <summary>
        /// 
        /// </summary>
        private DateTime startDateTime;
        /// <summary>
        /// 
        /// </summary>
        private int week;
        /// <summary>
        /// FSK-rating of the movie.
        /// </summary>
        private int movieRating;
        /// <summary>
        /// 
        /// </summary>
        private String movieCast;
        /// <summary>
        /// 
        /// </summary>
        private String director;

        /// <summary>
        /// Initializes a new instance of the <see cref="Movie"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="genre">The genre.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="originCountry">The origin country.</param>
        /// <param name="startDateTime">The start date time.</param>
        /// <param name="movieRating">The movie rating.</param>
        /// <param name="movieCast">The movie cast.</param>
        /// <param name="director">The director.</param>
        /// <remarks></remarks>
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

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the genre.
        /// </summary>
        /// <value>The genre.</value>
        /// <remarks></remarks>
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>The duration.</value>
        /// <remarks></remarks>
        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        /// <summary>
        /// Gets or sets the origin country.
        /// </summary>
        /// <value>The origin country.</value>
        /// <remarks></remarks>
        public string OriginCountry
        {
            get { return originCountry; }
            set { originCountry = value; }
        }

        /// <summary>
        /// Gets or sets the start date time.
        /// </summary>
        /// <value>The start date time.</value>
        /// <remarks></remarks>
        public System.DateTime StartDateTime
        {
            get { return startDateTime; }
            set { startDateTime = value; }
        }

        /// <summary>
        /// Gets or sets the week.
        /// </summary>
        /// <value>The week.</value>
        /// <remarks></remarks>
        public int Week
        {
            get { return week; }
            set { week = value; }
        }

        /// <summary>
        /// Gets or sets the movie rating.
        /// </summary>
        /// <value>The movie rating.</value>
        /// <remarks></remarks>
        public int MovieRating
        {
            get { return movieRating; }
            set { movieRating = value; }
        }

        /// <summary>
        /// Gets or sets the movie cast.
        /// </summary>
        /// <value>The movie cast.</value>
        /// <remarks></remarks>
        public string MovieCast
        {
            get { return movieCast; }
            set { movieCast = value; }
        }

        /// <summary>
        /// Gets or sets the director.
        /// </summary>
        /// <value>The director.</value>
        /// <remarks></remarks>
        public string Director
        {
            get { return director; }
            set { director = value; }
        }
    }

}
