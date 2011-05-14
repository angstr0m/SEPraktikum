using System;
using System.Collections.Generic;
using Base.AbstractClasses;
using Cinema.Models;
using Database.Interfaces;
using TicketOperations.InterfaceMembers;

namespace TicketOperations.Models {
    
    /// <summary>
    /// A show represents a single viewing of a movie in a specific Movietheatre.
    /// </summary>
    /// <remarks></remarks>
    public class Show : Subject, IDatabaseObject
    {

        private int id;
        /// <summary>
        /// The time, when the movie showing starts.
        /// </summary>
        private DateTime startTime;
        /// <summary>
        /// The movie that is shown.
        /// </summary>
        private Movie movie;
        /// <summary>
        /// The Movietheatre in which the movie is shown.
        /// </summary>
        private MovieTheatre hall;
        /// <summary>
        /// The duration of the movie shown.
        /// </summary>
        private int duration;
        /// <summary>
        /// Indicates if the movie has a pause through the showing.
        /// </summary>
        private bool pause;
        /// <summary>
        /// The tickets associated with this Show.
        /// </summary>
        private List<Ticket> tickets;

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        /// <remarks></remarks>
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        /// <summary>
        /// Gets the duration of the movie shown.
        /// </summary>
        /// <value>The duration.</value>
        /// <remarks></remarks>
        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        /// <summary>
        /// Gets the movie rating (parental advisory) of the movie shown.
        /// </summary>
        /// <remarks></remarks>
        public int MovieRating
        {
            get { return movie.MovieRating; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Show"/> class.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="movie">The movie.</param>
        /// <param name="hall">The hall.</param>
        /// <param name="pause">if set to <c>true</c> [pause].</param>
        /// <param name="ticketPrice">The ticket price.</param>
        /// <remarks></remarks>
        public Show(DateTime startTime, Movie movie, MovieTheatre hall, bool pause, float ticketPrice)
        {
            this.startTime = startTime;
            this.movie = movie;
            this.hall = hall;
            this.duration = movie.Duration;
            this.pause = pause;
            this.tickets = new List<Ticket>();

            foreach (Seat s in hall.GetSeats())
            {
                tickets.Add(new Ticket(ticketPrice, s, this));
            }
        }

        /// <summary>
        /// Gets the number of free tickets.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public int GetNumberOfFreeSeats()
        {
            return tickets.FindAll(
                    delegate(Ticket t)
                    {
                        return (!t.Sold && !t.Reserved);
                    }
                ).Count;
        }

        /// <summary>
        /// Gets the number of tickets that has been sold or reserved.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public int GetNumberOfBlockedSeats()
        {
            return tickets.FindAll(
                    delegate(Ticket t)
                    {
                        return (t.Sold || t.Reserved);
                    }
                ).Count;
        }

        /// <summary>
        /// Gets the available tickets.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<Ticket> GetAvailableTickets()
        {
            return tickets.FindAll(
                    delegate(Ticket t)
                    {
                        return (!t.Sold && !t.Reserved);
                    }
                );
        }

        /// <summary>
        /// Gets the reserved tickets.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<Ticket> GetReservedTickets()
        {
            return tickets.FindAll(
                    delegate(Ticket t)
                    {
                        return (t.Reserved);
                    }
                );
        }

        /// <summary>
        /// Gets the sold tickets.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<Ticket> GetSoldTickets()
        {
            return tickets.FindAll(
                    delegate(Ticket t)
                    {
                        return (t.Sold);
                    }
                );
        }

        /// <summary>
        /// Gets the ticket at index.
        /// </summary>
        /// <param name="index">The index of the wanted ticket.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public Ticket GetTicket(int index)
        {
            return tickets[index];
        }

        /// <summary>
        /// Gets the ticket for a specific seat, identified by row and number of the seat.
        /// </summary>
        /// <param name="row">The row of the seat (A-Z).</param>
        /// <param name="nr">The number of the seat.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public Ticket GetTicket(ISeatIdentifier seat)
        {
            return GetTicket(seat.row(), seat.number());
        }

        /// <summary>
        /// Gets the ticket for a specific seat, identified by row and number of the seat.
        /// </summary>
        /// <param name="row">The row of the seat (A-Z).</param>
        /// <param name="nr">The number of the seat.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public Ticket GetTicket(char row, int nr)
        {
            return tickets.Find(
                    delegate(Ticket t)
                    {
                        return ((t.Seat.GetRow() == row) && (t.Seat.GetNr() == nr));
                    }
                );
        }

        /// <summary>
        /// Gets the name of the movie that is shown.
        /// </summary>
        /// <remarks></remarks>
        public String Name
        {
            get
            {
                return movie.Name;
            }
        }

        /// <summary>
        /// Reserves the specific ticket.
        /// </summary>
        /// <param name="ticket">The ticket that should be reserved.</param>
        /// <remarks></remarks>
        public void ReserveTicket(Ticket ticket)
        {
            ticket.Reserved = true;
            NotifyObservers();
        }

        /// <summary>
        /// Reserves the ticket for a specific seat identified by row and number.
        /// </summary>
        /// <param name="row">The row of the seat.</param>
        /// <param name="nr">The number of the seat.</param>
        /// <remarks></remarks>
        public void ReserveTicket(char row, int nr)
        {
            GetTicket(row, nr).Reserved = true;
            NotifyObservers();
        }

        /// <summary>
        /// Sells the specific ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
        public void SellTicket(Ticket ticket)
        {
            ticket.Sold = true;
            NotifyObservers();
        }

        /// <summary>
        /// Sells the ticket for a specific seat identified by row and number.
        /// </summary>
        /// <param name="row">The row of the wanted seat.</param>
        /// <param name="nr">The number of the wanted seat.</param>
        /// <remarks></remarks>
        public void SellTicket(char row, int nr)
        {
            GetTicket(row, nr).Sold = true;
            NotifyObservers();
        }

        /// <summary>
        /// Get a specific ticket from this show.
        /// </summary>
        /// <param name="ticket">The ticket to get.</param>
        /// <remarks></remarks>
        public void ReturnTicket(Ticket ticket)
        {
            if (!tickets.Contains(ticket))
            {
                throw new ArgumentException("The ticket " + ticket.ToString() + " is not contained in this Show!");
            }
            ticket.Sold = false;
            ticket.Reserved = false;
            NotifyObservers();
        }

        public void SetIdentifier(int id)
        {
            this.id = id;
        }

        public int GetIdentifier()
        {
            return id;
        }
    }

}
