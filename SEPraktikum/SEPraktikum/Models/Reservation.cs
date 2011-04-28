using System;
using System.Collections.Generic;
namespace Models {
    public class Reservation : Interfaces.Subject
    {
		private int number;
		private Show show;
		private List<Ticket> tickets;
		private Customer customer;

		public Customer Customer() {
			throw new System.Exception("Not implemented");
		}
		public void Customer(Customer customer) {
			throw new System.Exception("Not implemented");
		}
		public int Number() {
			throw new System.Exception("Not implemented");
		}
		public Show Show() {
			throw new System.Exception("Not implemented");
		}
		public void Show(Show show) {
			throw new System.Exception("Not implemented");
		}
		public void AddTicket(Ticket ticket) {
			throw new System.Exception("Not implemented");
		}
		public void RemoveTicket(Ticket ticket) {
			throw new System.Exception("Not implemented");
		}
		public int Price() {
			throw new System.Exception("Not implemented");
		}
		public Ticket Each() {
			throw new System.Exception("Not implemented");
		}
		public Booking ToBooking() {
			throw new System.Exception("Not implemented");
		}
		public bool CancelReservation() {
			throw new System.Exception("Not implemented");
		}

	}

}
