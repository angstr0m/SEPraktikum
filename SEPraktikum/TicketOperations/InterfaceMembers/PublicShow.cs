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
    /// Decorator for the Show object.
    /// This class is meant for giving show objects to the outside, while hiding members and methods on the show-object which should not be seen.
    /// </summary>
    /// <remarks></remarks>
    class PublicShow : IPublicShow
    {
        private Show _show;

        public PublicShow(Show show)
        {
            _show = show;
        }

        public DateTime StartTime
        {
            get { return _show.StartTime; }
        }

        public int Duration
        {
            get { return _show.Duration; }
        }

        public int MovieRating
        {
            get { return _show.MovieRating; }
        }

        public string Name
        {
            get { return _show.Name; }
        }

        public int GetNumberOfFreeSeats()
        {
            return _show.GetNumberOfFreeSeats();
        }

        public int GetNumberOfBlockedSeats()
        {
            return _show.GetNumberOfBlockedSeats();
        }

        public List<IPublicTicket> GetAvailableTickets()
        {
            List<IPublicTicket> publictickets = new List<IPublicTicket>();
            List<Ticket> tickets = _show.GetAvailableTickets();

            foreach (var ticket in tickets)
            {
                publictickets.Add(new PublicTicket(ticket));
            }

            return publictickets;
        }

        public List<IPublicTicket> GetReservedTickets()
        {
            List<IPublicTicket> publictickets = new List<IPublicTicket>();
            List<Ticket> tickets = _show.GetReservedTickets();

            foreach (var ticket in tickets)
            {
                publictickets.Add(new PublicTicket(ticket));
            }

            return publictickets;
        }

        public List<IPublicTicket> GetSoldTickets()
        {
            List<IPublicTicket> publictickets = new List<IPublicTicket>();
            List<Ticket> tickets = _show.GetSoldTickets();

            foreach (var ticket in tickets)
            {
                publictickets.Add(new PublicTicket(ticket));
            }

            return publictickets;
        }

        public IPublicTicket GetTicket(int index)
        {
            return new PublicTicket(_show.GetTicket(index));
        }

        public IPublicTicket GetTicket(char row, int nr)
        {
            return new PublicTicket(_show.GetTicket(row, nr));
        }

        public int GetIdentifier()
        {
            return _show.GetIdentifier();
        }
    }
}
