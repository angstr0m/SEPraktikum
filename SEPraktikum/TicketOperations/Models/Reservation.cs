using System.Collections.Generic;
using Base.AbstractClasses;
using Users.Models;

namespace TicketOperations.Models {
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class Reservation : Subject
    {
        /// <summary>
        /// 
        /// </summary>
		private int number;
        /// <summary>
        /// 
        /// </summary>
		private Show show;
        /// <summary>
        /// 
        /// </summary>
		private List<Ticket> tickets;
        /// <summary>
        /// 
        /// </summary>
		private Customer customer;

        /// <summary>
        /// Customers this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
		public Customer Customer() {
			throw new System.Exception("Not implemented");
		}
        /// <summary>
        /// Customers the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <remarks></remarks>
		public void Customer(Customer customer) {
			throw new System.Exception("Not implemented");
		}
        /// <summary>
        /// Numbers this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
		public int Number() {
			throw new System.Exception("Not implemented");
		}
        /// <summary>
        /// Shows this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
		public Show Show() {
			throw new System.Exception("Not implemented");
		}
        /// <summary>
        /// Shows the specified show.
        /// </summary>
        /// <param name="show">The show.</param>
        /// <remarks></remarks>
		public void Show(Show show) {
			throw new System.Exception("Not implemented");
		}
        /// <summary>
        /// Adds the ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
		public void AddTicket(Ticket ticket) {
			throw new System.Exception("Not implemented");
		}
        /// <summary>
        /// Removes the ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
		public void RemoveTicket(Ticket ticket) {
			throw new System.Exception("Not implemented");
		}
        /// <summary>
        /// Prices this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
		public int Price() {
			throw new System.Exception("Not implemented");
		}
        /// <summary>
        /// Eaches this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
		public Ticket Each() {
			throw new System.Exception("Not implemented");
		}
        /// <summary>
        /// Toes the booking.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
		public Booking ToBooking() {
			throw new System.Exception("Not implemented");
		}
        /// <summary>
        /// Cancels the reservation.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
		public bool CancelReservation() {
			throw new System.Exception("Not implemented");
		}

	}

}
