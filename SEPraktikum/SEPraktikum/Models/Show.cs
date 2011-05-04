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

        public Show(DateTime startTime, Movie movie, MovieTheatre hall, bool pause, float ticketPrice)
        {
            this.startTime = startTime;
            this.movie = movie;
            this.hall = hall;
            this.duration = movie.Duration;
            this.pause = pause;

            foreach (Seat s in hall.GetSeats())
            {
                tickets.Add(new Ticket(ticketPrice, s, this)); 
            }
        }

		public int GetNumberOfFreeSeats() {
            return tickets.FindAll(
                    delegate(Ticket t)
                    {
                        return (!t.Sold);
                    }
                ).Count;
		}

		public int GetNumberOfBlockedSeats() {
            return tickets.FindAll(
                    delegate(Ticket t)
                    {
                        return (t.Sold);
                    }
                ).Count;
		}

        public List<Ticket> GetUnsoldTickets()
        {
            return tickets.FindAll(
                    delegate(Ticket t)
                    {
                        return (!t.Sold);
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

        public void SellTicket(Ticket ticket)
        {
            ticket.Sold = true;
        }

        public void SellTicket(char row, int nr)
        {
            tickets.Find(
                    delegate(Ticket t)
                    {
                        return ((t.Seat.GetRow() == row) && (t.Seat.GetNr() == nr));
                    }
                ).Sold = true;
        }

		public void ReturnTicket(Ticket ticket) {
            ticket.Sold = false;
		}
	}

}
