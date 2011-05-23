using System;
using Base.Interfaces;

namespace Cinema.Models
{
    public interface IFilm
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        String Name { get; set; }

        /// <summary>
        /// Gets or sets the genre.
        /// </summary>
        /// <value>The genre.</value>
        /// <remarks></remarks>
        string Genre { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>The duration.</value>
        /// <remarks></remarks>
        int Dauer { get; set; }

        /// <summary>
        /// Gets or sets the origin country.
        /// </summary>
        /// <value>The origin country.</value>
        /// <remarks></remarks>
        string OriginCountry { get; set; }

        /// <summary>
        /// Gets or sets the start date time.
        /// </summary>
        /// <value>The start date time.</value>
        /// <remarks></remarks>
        System.DateTime StartDateTime { get; set; }

        /// <summary>
        /// Gets or sets the week.
        /// </summary>
        /// <value>The week.</value>
        /// <remarks></remarks>
        int Week { get; set; }

        /// <summary>
        /// Gets or sets the movie rating.
        /// </summary>
        /// <value>The movie rating.</value>
        /// <remarks></remarks>
        int Altersfreigabe { get; set; }

        /// <summary>
        /// Gets or sets the movie cast.
        /// </summary>
        /// <value>The movie cast.</value>
        /// <remarks></remarks>
        string MovieCast { get; set; }

        /// <summary>
        /// Gets or sets the director.
        /// </summary>
        /// <value>The director.</value>
        /// <remarks></remarks>
        string Director { get; set; }

        /// <summary>
        /// Adds the observer to the observer list.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <remarks></remarks>
        void AddObserver(Observer observer);

        /// <summary>
        /// Removes the observer from the observer list.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <remarks></remarks>
        void RemoveObserver(Observer observer);

        /// <summary>
        /// Notifies the observers.
        /// </summary>
        /// <remarks></remarks>
        void NotifyObservers();
    }
}