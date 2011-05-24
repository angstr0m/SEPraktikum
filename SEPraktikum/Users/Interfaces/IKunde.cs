using System;
using System.Collections.Generic;
using Base.Interfaces;
using Database.Interfaces;
using Finances.Models;
using Users.Models;

namespace Users.Interfaces
{
    public interface IKunde : IDatabaseObject
    {
        void AddAdress(Adress newAdress);
        void RemoveAdress(Adress adress);

        Zahlungsinformationen Zahlungsinformationen { get; }

        float Rabatt { get; }

        string Telefonnummer { get; }

        DateTime Geburtsdatum { get; }

        List<Adress> Adresse { get; }

        string Name { get; }

        int Kundennummer { get; }

        int Id { get; }

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