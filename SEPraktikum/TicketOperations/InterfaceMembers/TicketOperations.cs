using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database.Models;
using TicketOperations.Models;
using Users.Models;
using System.Timers;

namespace TicketOperations.InterfaceMembers
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    class TicketOperations : ITicketOperations
    {
        private EntityManager<Show> _databaseShows;
        private EntityManager<Ticket> _databaseTickets;
        private EntityManager<MovieProgram> _databaseMoviePrograms;
        private EntityManager<Reservation> _databaseReservations;

        public TicketOperations()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            _databaseShows = new EntityManager<Show>();
            _databaseTickets = new EntityManager<Ticket>();
            _databaseMoviePrograms = new EntityManager<MovieProgram>();
            _databaseReservations = new EntityManager<Reservation>();
        }

        public int ReserveTicket(IPublicShow show, ISeatIdentifier seat, bool discount, Customer customer, ITicketBlockAccessKey key)
        {
            Ticket wantedTicket = _databaseShows.GetElementWithId(show.GetIdentifier()).GetTicket(seat);

            Reservation r = new Reservation(wantedTicket, customer, discount, key);

            return r.ReservationNumber;
        }

        public int ReserveTicket(IPublicTicket ticket, bool discount, Customer customer, ITicketBlockAccessKey key)
        {
            Ticket wantedTicket = _databaseTickets.GetElementWithId(ticket.GetIdentifier());
            Reservation r = _databaseReservations.GetElements().Find(delegate(Reservation re)
                                                                         {
                                                                             return (re.Customer == customer) &&
                                                                                    (re.Show == (Show) ticket.Show);
                                                                         });

            if (r == null)
            {
                r = new Reservation(wantedTicket, customer, discount, key);
            } else
            {
                r.AddTicket(wantedTicket, key);
            }
            
            return r.ReservationNumber;
        }

        public void UnReserveTicket(IPublicShow show, ISeatIdentifier seat)
        {
            Ticket wantedTicket = _databaseTickets.GetElements().Find(delegate(Ticket t)
                                                                          {
                                                                              return t.Show == show && t.Seat == seat;
                                                                          });

            _databaseReservations.GetElements().Find(delegate (Reservation r)
                                                         {
                                                             return r.Tickets.Contains(wantedTicket);
                                                         }).RemoveTicket(wantedTicket);

        }

        public void UnReserveTicket(IPublicTicket ticket)
        {
            Ticket wantedTicket = (Ticket) ticket;

            _databaseReservations.GetElements().Find(delegate(Reservation r)
            {
                return r.Tickets.Contains(wantedTicket);
            }).RemoveTicket(wantedTicket);
        }

        public ITicketBlockAccessKey BlockTicket(IPublicShow show, ISeatIdentifier seat)
        {

            Show wantedShow = _databaseShows.GetElementWithId(show.GetIdentifier());

            ITicketBlockAccessKey key = wantedShow.GetTicket(seat).Block();

            return key;
        }

        public ITicketBlockAccessKey BlockTicket(IPublicTicket ticket)
        {
            ITicketBlockAccessKey key = _databaseTickets.GetElementWithId(ticket.GetIdentifier()).Block();

            return key;
        }

        public void UnBlockTicket(IPublicShow show, ISeatIdentifier seat, ITicketBlockAccessKey key)
        {

            Show wantedShow = _databaseShows.GetElementWithId(show.GetIdentifier());

            wantedShow.GetTicket(seat).UnBlock(key);
        }

        public void UnBlockTicket(IPublicTicket ticket, ITicketBlockAccessKey key)
        {
            _databaseTickets.GetElementWithId(ticket.GetIdentifier()).UnBlock(key);
        }

        /// <summary>
        /// Gets the movie program for the actual week.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public IPublicMovieProgram GetMovieProgramForThisWeek()
        {
            return (IPublicMovieProgram)_databaseMoviePrograms.GetElements().Find(delegate(MovieProgram m)
                                                          {
                                                              return (m.StartDateTime <= DateTime.Today &&
                                                                      m.StartDateTime.AddDays(7) >= DateTime.Today);
                                                          });
        }
    }
}
