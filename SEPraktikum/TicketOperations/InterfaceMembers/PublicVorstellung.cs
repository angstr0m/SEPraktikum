using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Models;
using Database.Interfaces;
using TicketOperations.Models;

namespace TicketOperations.InterfaceMembers
{
    /// <summary>
    /// Decorator for the vorstellung object.
    /// This class is meant for giving vorstellung objects to the outside, while hiding members and methods on the vorstellung-object which should not be seen.
    /// </summary>
    /// <remarks></remarks>
    class PublicVorstellung : IPublicVorstellung
    {
        private Vorstellung _vorstellung;

        public PublicVorstellung(Vorstellung vorstellung)
        {
            _vorstellung = vorstellung;
        }

        public DateTime StartTime
        {
            get { return _vorstellung.StartTime; }
        }

        public int Duration
        {
            get { return _vorstellung.Duration; }
        }

        public int MovieRating
        {
            get { return _vorstellung.MovieRating; }
        }

        public string Name
        {
            get { return _vorstellung.Name; }
        }

        public int GetNumberOfFreeSeats()
        {
            return _vorstellung.GetNumberOfFreeSeats();
        }

        public int GetNumberOfBlockedSeats()
        {
            return _vorstellung.GetNumberOfBlockedSeats();
        }

        public List<IPublicTicket> GetAvailableTickets()
        {
            List<IPublicTicket> publictickets = new List<IPublicTicket>();
            List<Ticket> tickets = _vorstellung.GetAvailableTickets();

            foreach (var ticket in tickets)
            {
                publictickets.Add(new PublicTicket(ticket));
            }

            return publictickets;
        }

        public List<IPublicTicket> GetReservedTickets()
        {
            List<IPublicTicket> publictickets = new List<IPublicTicket>();
            List<Ticket> tickets = _vorstellung.GetReservedTickets();

            foreach (var ticket in tickets)
            {
                publictickets.Add(new PublicTicket(ticket));
            }

            return publictickets;
        }

        public List<IPublicTicket> GetSoldTickets()
        {
            List<IPublicTicket> publictickets = new List<IPublicTicket>();
            List<Ticket> tickets = _vorstellung.GetSoldTickets();

            foreach (var ticket in tickets)
            {
                publictickets.Add(new PublicTicket(ticket));
            }

            return publictickets;
        }

        public IPublicTicket GetTicket(int index)
        {
            return new PublicTicket(_vorstellung.GetTicket(index));
        }

        public IPublicTicket GetTicket(char row, int nr)
        {
            return new PublicTicket(_vorstellung.GetTicket(row, nr));
        }

        public int GetIdentifier()
        {
            return _vorstellung.GetIdentifier();
        }
    }
}
