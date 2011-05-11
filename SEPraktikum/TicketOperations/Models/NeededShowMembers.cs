namespace TicketOperations.Models
{
    public interface NeededShowMembers
    {
        /// <summary>
        /// Reserves the specific ticket.
        /// </summary>
        /// <param name="ticket">The ticket that should be reserved.</param>
        /// <remarks></remarks>
        void ReserveTicket(Ticket ticket);

        /// <summary>
        /// Reserves the ticket for a specific seat identified by row and number.
        /// </summary>
        /// <param name="row">The row of the seat.</param>
        /// <param name="nr">The number of the seat.</param>
        /// <remarks></remarks>
        void ReserveTicket(char row, int nr);

        /// <summary>
        /// Sells the specific ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
        void SellTicket(Ticket ticket);

        /// <summary>
        /// Sells the ticket for a specific seat identified by row and number.
        /// </summary>
        /// <param name="row">The row of the wanted seat.</param>
        /// <param name="nr">The number of the wanted seat.</param>
        /// <remarks></remarks>
        void SellTicket(char row, int nr);

        /// <summary>
        /// Get a specific ticket from this show.
        /// </summary>
        /// <param name="ticket">The ticket to get.</param>
        /// <remarks></remarks>
        void ReturnTicket(Ticket ticket);
    }
}