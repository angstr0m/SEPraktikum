using System;
using System.Collections.Generic;
namespace Models {
    public class Show : Interfaces.Subject
    {
        private DateTime startTime;
		private Movie movie;
		private MovieTheatre hall;
        private int duration;      
		private bool pause;
		private List<Ticket> tickets;

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public int MovieRating
        {
            get { return movie.MovieRating; }
        }

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

		public int GetNumberOfFreeSeats() {
            return tickets.FindAll(
                    delegate(Ticket t)
                    {
                        return (!t.Sold && !t.Reserved);
                    }
                ).Count;
		}

		public int GetNumberOfBlockedSeats() {
            return tickets.FindAll(
                    delegate(Ticket t)
                    {
                        return (t.Sold || t.Reserved);
                    }
                ).Count;
		}

        public List<Ticket> GetAvailableTickets()
        {
            return tickets.FindAll(
                    delegate(Ticket t)
                    {
                        return (!t.Sold && !t.Reserved);
                    }
                );
        }

        public List<Ticket> GetReservedTickets()
        {
            return tickets.FindAll(
                    delegate(Ticket t)
                    {
                        return (t.Reserved);
                    }
                );
        }

        public List<Ticket> GetSoldTickets()
        {
            return tickets.FindAll(
                    delegate(Ticket t)
                    {
                        return (t.Sold);
                    }
                );
        }

		public Ticket GetTicketFor(char row, int nr) {
            return tickets.Find(
                    delegate(Ticket t)
                    {
                        return ((t.Seat.GetRow() == row) && (t.Seat.GetNr() == nr));
                    }
                );
		}

        public String Name
        {
            get
            {
                return movie.Name;
            }
        }

        public void ReserveTicket(Ticket ticket)
        {
            ticket.Reserved = true;
            NotifyObservers();
        }

        public void ReserveTicket(char row, int nr)
        {
            tickets.Find(
                    delegate(Ticket t)
                    {
                        return ((t.Seat.GetRow() == row) && (t.Seat.GetNr() == nr));
                    }
                ).Reserved = true;
            NotifyObservers();
        }

        public void SellTicket(Ticket ticket)
        {
            ticket.Sold = true;
            NotifyObservers();
        }

        public void SellTicket(char row, int nr)
        {
            tickets.Find(
                    delegate(Ticket t)
                    {
                        return ((t.Seat.GetRow() == row) && (t.Seat.GetNr() == nr));
                    }
                ).Sold = true;
            NotifyObservers();
        }

		public void ReturnTicket(Ticket ticket) {
            ticket.Sold = false;
            NotifyObservers();
		}
	}

}
