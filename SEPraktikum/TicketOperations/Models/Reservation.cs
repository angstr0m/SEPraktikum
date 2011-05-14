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
    public class Reservation : Subject, IDatabaseObject
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
        private Show _show;
        /// <summary>
        /// 
        /// </summary>
        private List<Ticket> _tickets;
        /// <summary>
        /// 
        /// </summary>
        private Customer _customer;

        private EntityManager<Reservation> _database;

        public Reservation(Ticket ticket, Customer customer, bool discount, ITicketBlockAccessKey key)
        {
            if (ticket.Reserved || ticket.Sold)
            {
                throw new System.Exception("Ticket already bought or reserved!");
            }

            ticket.UnBlock(key);

            _show = ticket.Show;
            _tickets = new List<Ticket>();
            this.AddTicket(ticket);
            _reservationNumber = _tickets.Count;
            _customer = customer;
            _discount = discount;

            _database = new EntityManager<Reservation>();
            _database.AddElement(this);
        }

        /// <summary>
        /// Adds the ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
        public void AddTicket(Ticket ticket)
        {
            if (ticket.Show != _show)
            {
                throw new System.Exception("Tickets in a reservation must all belong to the same show!");
            }

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

        public TicketOperations.Models.Show Show
        {
            get { return _show; }
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
