using System;
using System.Collections.Generic;
using Base.AbstractClasses;
using Database.Interfaces;
using Database.Models;
using Kinokarten.Schnittstelle.Interfaces;
using Users.Interfaces;

namespace Kinokarten.Models
{
    /// <summary>
    /// Repräsentiert eine Reservierung.
    /// Tätigt ein Kunde eine Reservierung, wird ein neues Objekt dieses Typs erzeugt und in der Datenbank gespeichert.
    /// </summary>
    /// <remarks></remarks>
    internal class Reservierung : Subject, IDatabaseObject
    {
        /// <summary>
        /// Die Kinokarten die zu dieser Reservierung gehören.
        /// </summary>
        private readonly List<Kinokarte> _kinokarten;

        /// <summary>
        /// Die Referenz auf den Kunden, welcher diese Reservierung getätigt hat.
        /// </summary>
        private readonly IKunde _kunde;

        /// <summary>
        /// Gibt an, ob auf die Karten dieser Vorstellung ein Rabatt von 10% auf den Preis gewährt wird.
        /// </summary>
        private readonly bool _rabatt;

        /// <summary>
        /// Ermöglicht den Zugriff auf die Reservierungen in der Datenbank.
        /// </summary>
        private readonly EntityManager<Reservierung> _reservierungen;

        /// <summary>
        /// Die Reservierungsnummer unter der die Karten dieser Reservierung abgeholt werden können.
        /// </summary>
        private readonly int _reservierungsnummer;

        /// <summary>
        /// Die Vorstellung zu der die Karten dieser Vorstellung gehören.
        /// </summary>
        private readonly Vorstellung _vorstellung;

        private int _id;

        public Reservierung(Kinokarte kinokarte, IKunde kunde, bool rabatt, IKinokarteBlockierungZugangsSchlüssel key)
        {
            _vorstellung = kinokarte.Vorstellung;
            _kinokarten = new List<Kinokarte>();
            TicketHinzufügen(kinokarte, key);
            _reservierungsnummer = _kinokarten.Count;
            _kunde = kunde;
            _rabatt = rabatt;

            _reservierungen = new EntityManager<Reservierung>();
            _reservierungen.AddElement(this);
        }


        /// <summary>
        /// Gibt die Reservierungsnummer diese Reservierung zurück.
        /// </summary>
        /// <remarks></remarks>
        public int Reservierungsnummer
        {
            get { return _reservierungsnummer; }
        }

        /// <summary>
        /// Gibt die Vorstellung zu der diese Reservierung gehört zurück.
        /// </summary>
        /// <remarks></remarks>
        public Vorstellung Vorstellung
        {
            get { return _vorstellung; }
        }

        /// <summary>
        /// Gibt die Kinokarten zurück, die zu dieser Vorstellung gehören.
        /// </summary>
        /// <remarks></remarks>
        public List<Kinokarte> Kinokarten
        {
            get { return _kinokarten; }
        }

        /// <summary>
        /// Gibt den Kunden zurück, dem diese Registrierung zugeordnet ist.
        /// </summary>
        /// <remarks></remarks>
        public IKunde Kunde
        {
            get { return _kunde; }
        }

        /// <summary>
        /// Kinokarte der Reservierung hinzufügen
        /// </summary>
        /// <param name="kinokarte">Das Kinokarte welches der Reservierung hinzugefügt werden soll.</param>
        /// <remarks></remarks>
        public void TicketHinzufügen(Kinokarte kinokarte, IKinokarteBlockierungZugangsSchlüssel key)
        {
            if (_vorstellung != null && kinokarte.Vorstellung != _vorstellung)
            {
                throw new Exception("Kinokarten in a reservation must all belong to the same vorstellung!");
            }

            if (kinokarte.Reserviert || kinokarte.Verkauft)
            {
                throw new Exception("Kinokarte already bought or reserved!");
            }

            kinokarte.BlockierungAufheben(key);

            kinokarte.Rabatt = _rabatt;
            kinokarte.Reservieren();
            _kinokarten.Add(kinokarte);
        }

        /// <summary>
        /// Entfernt das übergebene Kinokarte aus dieser Reservierung.
        /// </summary>
        /// <param name="kinokarte">Das Kinokarte.</param>
        /// <remarks></remarks>
        public void TicketEntfernen(Kinokarte kinokarte)
        {
            kinokarte.ReservierungAufheben();
            _kinokarten.Remove(kinokarte);

            if (_kinokarten.Count == 0)
            {
                _reservierungen.RemoveElement(this);
            }
        }

        /// <summary>
        /// Gibt den Preis dieser Reservierung zurück.
        /// </summary>
        /// <returns></returns>
        /// <remarks> Der Preis dieser Reservierung ergibt sich hierbei aus der Summe der Preise aller Kinokarten. </remarks>
        public float Price()
        {
            float price = 0;

            // Den Preis aller Kinokarten dieser Reservierung aufsummieren.
            foreach (Kinokarte ticket in _kinokarten)
            {
                price += ticket.Preis;
            }

            return price;
        }

        /// <summary>
        /// Storniert diese Reservierung.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public void ReservierungStornieren()
        {
            // Den Reservierungsstatus der enthaltenen Kinokarten aufheben.
            foreach (Kinokarte ticket in _kinokarten)
            {
                ticket.ReservierungAufheben();
            }

            // Dann diese Reservierung aus der Datenbank entfernen.
            _reservierungen.RemoveElement(this);
        }

        public void SetIdentifier(int id)
        {
            _id = id;
        }

        public int GetIdentifier()
        {
            return _id;
        }
    }
}