using System;
using System.Collections.Generic;
using Base.AbstractClasses;
using Users.Models;
using Database.Models;
using Database.Interfaces;
using TicketOperations.InterfaceMembers;

namespace TicketOperations.Models {
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class Reservierung : Subject, IDatabaseObject
    {
        private int _id;
        private bool _discount;
        /// <summary>
        /// 
        /// </summary>
        private int _reservationNumber;
        /// <summary>
        /// 
        /// </summary>
        private Vorstellung _vorstellung;
        /// <summary>
        /// 
        /// </summary>
        private List<Ticket> _tickets;
        /// <summary>
        /// 
        /// </summary>
        private Customer _customer;

        private EntityManager<Reservierung> _database;

        public Reservierung(Ticket ticket, Customer customer, bool discount, ITicketBlockierungZugangsSchlüssel key)
        {
            _vorstellung = ticket.Vorstellung;
            _tickets = new List<Ticket>();
            this.AddTicket(ticket, key);
            _reservationNumber = _tickets.Count;
            _customer = customer;
            _discount = discount;

            _database = new EntityManager<Reservierung>();
            _database.AddElement(this);
        }

        /// <summary>
        /// Adds the ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
        public void AddTicket(Ticket ticket, ITicketBlockierungZugangsSchlüssel key)
        {
            if (_vorstellung != null && ticket.Vorstellung != _vorstellung)
            {
                throw new System.Exception("Tickets in a reservation must all belong to the same vorstellung!");
            }

            if (ticket.Reserved || ticket.Sold)
            {
                throw new System.Exception("Ticket already bought or reserved!");
            }

            ticket.UnBlock(key);

            ticket.Discount = _discount;
            ticket.Reserved = true;
            _tickets.Add(ticket);
        }
        /// <summary>
        /// Removes the ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
        public void RemoveTicket(Ticket ticket)
        {
            ticket.Reserved = false;
            _tickets.Remove(ticket);

            if (_tickets.Count == 0)
            {
                _database.RemoveElement(this);
            }
        }
        /// <summary>
        /// Prices this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public float Price()
        {
            float price = 0;

            foreach (Ticket ticket in _tickets)
            {
                price += ticket.Price;
            }

            return price;
        }
        
        /// <summary>
        /// Cancels the reservation.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public void CancelReservation()
        {
            foreach (Ticket ticket in _tickets)
            {
                ticket.Reserved = false;
            }

            _database.RemoveElement(this);
        }


        public int ReservationNumber
        {
            get { return _reservationNumber; }
        }

        public TicketOperations.Models.Vorstellung Vorstellung
        {
            get { return _vorstellung; }
        }

        public System.Collections.Generic.List<TicketOperations.Models.Ticket> Tickets
        {
            get { return _tickets; }
        }

        public Users.Models.Customer Customer
        {
            get { return _customer; }
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
