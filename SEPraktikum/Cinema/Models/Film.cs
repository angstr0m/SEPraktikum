using System;
using Base.AbstractClasses;
using Cinema.InterfaceMembers;
using Database.Interfaces;

namespace Cinema.Models
{
    /// <summary>
    /// Representing a single movie. Movies are organized in MoviePrograms.
    /// </summary>
    /// <remarks></remarks>
    public class Film : Subject, IDatabaseObject, IFilm
    {
        private int id;
        /// <summary>
        /// Name of the movie.
        /// </summary>
        private String name;
        /// <summary>
        /// genre of the movie
        /// </summary>
        private String genre;
        /// <summary>
        /// Dauer in minutes
        /// </summary>
        private int _dauer;
        /// <summary>
        /// 
        /// </summary>
        private String originCountry;
        /// <summary>
        /// 
        /// </summary>
        private int week;
        /// <summary>
        /// FSK-rating of the movie.
        /// </summary>
        private int _altersfreigabe;
        /// <summary>
        /// 
        /// </summary>
        private String movieCast;
        /// <summary>
        /// 
        /// </summary>
        private String director;

        /// <summary>
        /// Initializes a new instance of the <see cref="Film"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="genre">The genre.</param>
        /// <param name="_dauer">The Dauer.</param>
        /// <param name="originCountry">The origin country.</param>
        /// <param name="startDateTime">The start date time.</param>
        /// <param name="_altersfreigabe">The movie rating.</param>
        /// <param name="movieCast">The movie cast.</param>
        /// <param name="director">The director.</param>
        /// <remarks></remarks>
        public Film(String name, String genre, int _dauer, string originCountry, int _altersfreigabe, string movieCast, string director)
        {
            this.name = name;
            this.genre = genre;
            this._dauer = _dauer;
            this.originCountry = originCountry;

            this._altersfreigabe = _altersfreigabe;
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
        /// Gets or sets the Dauer.
        /// </summary>
        /// <value>The Dauer.</value>
        /// <remarks></remarks>
        public int Dauer
        {
            get { return _dauer; }
            set { _dauer = value; }
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
        public DateTime StartDateTime
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
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
        public int Altersfreigabe
        {
            get { return _altersfreigabe; }
            set { _altersfreigabe = value; }
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

        public void SetIdentifier(int id)
        {
            this.id = id;
        }

        public int GetIdentifier()
        {
            return id;
        }
    }

}
