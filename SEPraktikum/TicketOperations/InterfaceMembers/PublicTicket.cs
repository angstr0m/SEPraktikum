using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketOperations.Models;

namespace TicketOperations.InterfaceMembers
{
    class PublicTicket : IPublicTicket
    {
        private Ticket _ticket;

        public PublicTicket(Ticket ticket)
        {
            _ticket = ticket;
        }

        public int GetIdentifier()
        {
            return _ticket.GetIdentifier();
        }

        public string ReservationNumber
        {
            get { return _ticket.ReservationNumber; }
        }

        public bool Reserved
        {
            get { return _ticket.Reserved; }
        }

        public bool Discount
        {
            get { return _ticket.Discount; }
        }

        public bool Sold
        {
            get { return _ticket.Sold; }
        }

        public float Price
        {
            get { return _ticket.Price; }
        }

        public Cinema.Models.Seat Seat
        {
            get { return _ticket.Seat; }
        }

        public IPublicVorstellung Vorstellung
        {
            get { return new PublicVorstellung(_ticket.Vorstellung); }
        }
    }
}
