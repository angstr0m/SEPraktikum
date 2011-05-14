using System;
using Base.Interfaces;
using Finances.Models;

namespace Users.Models
{
    public interface ICustomer
    {
        int CustomerID();
        void AddAdress(Adress newAdress);
        void RemoveAdress(Adress adress);
        DateTime BirthDateTime();
        void BirthDateTime(DateTime birthDateTime);
        String Phone();
        void Phone(String phone);
        float Discount();
        void Discount(float discount);
        Account Account();
        String GetPassword();
        void SetPassword(String password);
        String GetSurname();
        void SetSurname(String vorname);
        String GetEMail();
        void SetEMail(String eMail);
        String GetName();
        void SetName(String name);
        String GetSessionID();
        void SetSessionID(String sessionID);

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