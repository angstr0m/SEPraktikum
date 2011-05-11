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
    class TicketOperations
    {
        /// <summary>
        /// A link to the database which provides access to all MoviePrograms.
        /// </summary>
        private static int _usedReservationNumbers = 0;
        private static EntityManager<Show> _databaseShows;
        private static EntityManager<Ticket> _databaseTickets;
        private static EntityManager<MovieProgram> _databaseMoviePrograms;

        private static void InitializeDatabase()
        {
            if (_databaseShows == null)
            {
                _databaseShows = new EntityManager<Show>();
            }

            if (_databaseTickets == null)
            {
                _databaseTickets = new EntityManager<Ticket>();
            }
        }

        /// <summary>
        /// Reserves the ticket identified by seat row and number.
        /// </summary>
        /// <param name="show">The show.</param>
        /// <param name="row">The row.</param>
        /// <param name="number">The number.</param>
        /// <remarks></remarks>
        public static void ReserveTicket(IPublicShow show, char row, int number, bool discount, Customer customer)
        {
            InitializeDatabase();

            Ticket wantedTicket = _databaseShows.GetElementWithId(show.GetIdentifier()).GetTicket(row, number);

            _usedReservationNumbers += 1;

            new Reservation(wantedTicket, customer, _usedReservationNumbers, discount);
        }

        /// <summary>
        /// Reserves the ticket.
        /// </summary>
        /// <param name="show">The show.</param>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
        public static void ReserveTicket(IPublicTicket ticket, bool discount, Customer customer)
        {
            InitializeDatabase();

            Ticket wantedTicket = _databaseTickets.GetElementWithId(ticket.GetIdentifier());

            _usedReservationNumbers += 1;

            new Reservation(wantedTicket, customer, _usedReservationNumbers, discount);
        }

        /// <summary>
        /// Blocks the ticket identified by seat row and number.
        /// </summary>
        /// <param name="show">The show.</param>
        /// <param name="row">The row.</param>
        /// <param name="number">The number.</param>
        /// <remarks></remarks>
        public static void BlockTicket(IPublicShow show, char row, int number)
        {
            InitializeDatabase();

            Show wantedShow = _databaseShows.GetElementWithId(show.GetIdentifier());

            wantedShow.GetTicket(row, number).Blocked = true;

            // Unblocking the ticket must be done in the GUI!
        }

        /// <summary>
        /// Blocks the ticket.
        /// </summary>
        /// <param name="show">The show.</param>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
        public static void BlockTicket(IPublicTicket ticket)
        {
            InitializeDatabase();

            _databaseTickets.GetElementWithId(ticket.GetIdentifier()).Blocked = true;
        }

        /// <summary>
        /// Resets the ticket.
        /// </summary>
        /// <param name="movieProgram">The movie program.</param>
        /// <param name="show">The show.</param>
        /// <param name="row">The row.</param>
        /// <param name="nr">The nr.</param>
        /// <remarks></remarks>
        public static void ResetTicket(IPublicShow show, char row, int nr)
        {
            InitializeDatabase();

            Ticket wantedTicket = _databaseShows.GetElementWithId(show.GetIdentifier()).GetTicket(row, nr);

            wantedTicket.Reserved = false;
            wantedTicket.Discount = false;
        }

        /// <summary>
        /// Returns the Ticket.
        /// </summary>
        /// <param name="ticket">The ticket to get.</param>
        /// <remarks></remarks>
        public static void ResetTicket(IPublicTicket ticket)
        {
            InitializeDatabase();

            Ticket wantedTicket = _databaseTickets.GetElementWithId(ticket.GetIdentifier());

            wantedTicket.Reserved = false;
            wantedTicket.Discount = false;
        }

        /// <summary>
        /// Gets the movie program for the actual week.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public IPublicMovieProgram GetMovieProgramForThisWeek()
        {
            
        }
    }
}
