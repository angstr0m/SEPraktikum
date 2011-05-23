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
            get { return _vorstellung.Altersfreigabe; }
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

        public List<IPublicKinokarte> GetAvailableTickets()
        {
            List<IPublicKinokarte> publictickets = new List<IPublicKinokarte>();
            List<Kinokarte> tickets = _vorstellung.GetVerügbareKinokarten();

            foreach (var ticket in tickets)
            {
                publictickets.Add(new PublicKinokarte(ticket));
            }

            return publictickets;
        }

        public List<IPublicKinokarte> GetReservedTickets()
        {
            List<IPublicKinokarte> publictickets = new List<IPublicKinokarte>();
            List<Kinokarte> tickets = _vorstellung.GetReservierteKinokarten();

            foreach (var ticket in tickets)
            {
                publictickets.Add(new PublicKinokarte(ticket));
            }

            return publictickets;
        }

        public List<IPublicKinokarte> GetSoldTickets()
        {
            List<IPublicKinokarte> publictickets = new List<IPublicKinokarte>();
            List<Kinokarte> tickets = _vorstellung.GetVerkaufteKinokarten();

            foreach (var ticket in tickets)
            {
                publictickets.Add(new PublicKinokarte(ticket));
            }

            return publictickets;
        }

        public IPublicKinokarte GetTicket(int index)
        {
            return new PublicKinokarte(_vorstellung.GetKinokarte(index));
        }

        public IPublicKinokarte GetTicket(char row, int nr)
        {
            return new PublicKinokarte(_vorstellung.GetKinokarte(row, nr));
        }

        public int GetIdentifier()
        {
            return _vorstellung.GetIdentifier();
        }
    }
}
