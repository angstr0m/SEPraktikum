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

		public int GetFreeSeats() {
			throw new System.Exception("Not implemented");
		}
		public int GetBlockedSeats() {
			throw new System.Exception("Not implemented");
		}
		public Ticket GetTicketFor(object row, object nr) {
			throw new System.Exception("Not implemented");
		}
		public void ReturnTicket(object ticket) {
			throw new System.Exception("Not implemented");
		}

	}

}
