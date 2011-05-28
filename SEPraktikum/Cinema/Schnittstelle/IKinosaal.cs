using System;
using System.Collections.Generic;
using Base.Interfaces;
using Cinema.Models;
using Database.Interfaces;

namespace Cinema.InterfaceMembers
{
    public interface IKinosaal : IDatabaseObject
    {
        /// <summary>
        /// Gets the Sitz count.
        /// </summary>
        /// <remarks></remarks>
        int SeatCount { get; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        String Name { get; set; }

        /// <summary>
        /// Gets the seats.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        List<Sitz> GetSeats();

        /// <summary>
        /// Adds the Sitz.
        /// </summary>
        /// <param name="sitz">The Sitz.</param>
        /// <remarks></remarks>
        void AddSeat(Sitz sitz);

        /// <summary>
        /// Removes the Sitz.
        /// </summary>
        /// <param name="sitz">The Sitz.</param>
        /// <remarks></remarks>
        void RemoveSeat(Sitz sitz);

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