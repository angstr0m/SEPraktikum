using System;
using System.Collections.Generic;
using Base.AbstractClasses;
using TicketOperations.PublicInterfaceMembers;
using Users.Interfaces;
using Users.Models;
using Database.Models;
using Database.Interfaces;

namespace TicketOperations.Models {
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class Reservierung : Subject, IDatabaseObject
    {
        private int _id;
        private bool _discount;
        private int _reservierungsnummer;
        private Vorstellung _vorstellung;
        private List<Kinokarte> _kinokarten;
        private IKunde _kunde;

        private EntityManager<Reservierung> _database;

        public Reservierung(Kinokarte kinokarte, IKunde kunde, bool discount, IKinokarteBlockierungZugangsSchl�ssel key)
        {
            _vorstellung = kinokarte.Vorstellung;
            _kinokarten = new List<Kinokarte>();
            this.TicketHinzuf�gen(kinokarte, key);
            _reservierungsnummer = _kinokarten.Count;
            _kunde = kunde;
            _discount = discount;

            _database = new EntityManager<Reservierung>();
            _database.AddElement(this);
        }

        /// <summary>
        /// Kinokarte der Reservierung hinzuf�gen
        /// </summary>
        /// <param name="kinokarte">Das Kinokarte welches der Reservierung hinzugef�gt werden soll.</param>
        /// <remarks></remarks>
        public void TicketHinzuf�gen(Kinokarte kinokarte, IKinokarteBlockierungZugangsSchl�ssel key)
        {
            if (_vorstellung != null && kinokarte.Vorstellung != _vorstellung)
            {
                throw new System.Exception("Kinokarten in a reservation must all belong to the same vorstellung!");
            }

            if (kinokarte.Reserviert || kinokarte.Verkauft)
            {
                throw new System.Exception("Kinokarte already bought or reserved!");
            }

            kinokarte.BlockierungAufheben(key);

            kinokarte.Rabatt = _discount;
            kinokarte.Reservieren();
            _kinokarten.Add(kinokarte);
        }

        /// <summary>
        /// Entfernt das �bergebene Kinokarte aus dieser Reservierung.
        /// </summary>
        /// <param name="kinokarte">Das Kinokarte.</param>
        /// <remarks></remarks>
        public void TicketEntfernen(Kinokarte kinokarte)
        {
            kinokarte.ReservierungAufheben();
            _kinokarten.Remove(kinokarte);

            if (_kinokarten.Count == 0)
            {
                _database.RemoveElement(this);
            }
        }
        /// <summary>
        /// Gibt den Preis dieser Reservierung zur�ck.
        /// </summary>
        /// <returns></returns>
        /// <remarks> Der Preis dieser Reservierung ergibt sich hierbei aus der Summe der Preise aller Kinokarten. </remarks>
        public float Price()
        {
            float price = 0;

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
            _database.RemoveElement(this);
        }


        /// <summary>
        /// Gibt die Reservierungsnummer diese Reservierung zur�ck.
        /// </summary>
        /// <remarks></remarks>
        public int Reservierungsnummer
        {
            get { return _reservierungsnummer; }
        }

        /// <summary>
        /// Gibt die Vorstellung zu der diese Reservierung geh�rt zur�ck.
        /// </summary>
        /// <remarks></remarks>
        public TicketOperations.Models.Vorstellung Vorstellung
        {
            get { return _vorstellung; }
        }

        /// <summary>
        /// Gibt die Kinokarten zur�ck, die zu dieser Vorstellung geh�ren.
        /// </summary>
        /// <remarks></remarks>
        public System.Collections.Generic.List<TicketOperations.Models.Kinokarte> Kinokarten
        {
            get { return _kinokarten; }
        }

        /// <summary>
        /// Gibt den Kunden zur�ck, dem diese Registrierung zugeordnet ist.
        /// </summary>
        /// <remarks></remarks>
        public IKunde Kunde
        {
            get { return _kunde; }
        }

        public void SetIdentifier(int id)
        {
            this._id = id;
        }

        public int GetIdentifier()
        {
            return _id;
        }
    }

}
