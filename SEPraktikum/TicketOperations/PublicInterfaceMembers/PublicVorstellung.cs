using System;
using System.Collections.Generic;
using TicketOperations.Models;

namespace TicketOperations.PublicInterfaceMembers
{
    /// <summary>
    /// Decorator for the vorstellung object.
    /// This class is meant for giving vorstellung objects to the outside, while hiding members and methods on the vorstellung-object which should not be seen.
    /// </summary>
    /// <remarks></remarks>
    public class PublicVorstellung : IPublicVorstellung
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

        /// <summary>
        /// Gets the number of free tickets.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public int GetNumberOfFreeTickets()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the number of tickets that has been sold or reserved.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public int GetNumberOfUnavailableTickets()
        {
            throw new NotImplementedException();
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
            List<Kinokarte> tickets = _vorstellung.GetVerfügbareKinokarten();

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
