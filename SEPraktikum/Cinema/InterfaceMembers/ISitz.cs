using System;
using Base.Interfaces;

namespace Cinema.InterfaceMembers
{
    public interface ISitz
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        /// <remarks></remarks>
        string Identifier { get; set; }

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        Char Reihe();

        /// <summary>
        /// Gets the nr.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        int Nummer();

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        /// <remarks></remarks>
        string ToString();

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