using Users.Models;

namespace TicketOperations.InterfaceMembers
{
    public interface ITicketOperations
    {
        /// <summary>
        /// Reserves the ticket identified by seat row and number.
        /// </summary>
        /// <param name="show">The show.</param>
        /// <param name="row">The row.</param>
        /// <param name="number">The number.</param>
        /// <remarks></remarks>
        int ReserveTicket(IPublicShow show, ISeatIdentifier seat , bool discount, Customer customer, ITicketBlockAccessKey transactionkey);

        /// <summary>
        /// Reserves the ticket.
        /// </summary>
        /// <param name="show">The show.</param>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
        int ReserveTicket(IPublicTicket ticket, bool discount, Customer customer, ITicketBlockAccessKey transactionkey);

        /// <summary>
        /// Blocks the ticket identified by seat row and number.
        /// </summary>
        /// <param name="show">The show.</param>
        /// <param name="row">The row.</param>
        /// <param name="number">The number.</param>
        /// <remarks></remarks>
        ITicketBlockAccessKey BlockTicket(IPublicShow show, ISeatIdentifier seat);

        /// <summary>
        /// Blocks the ticket.
        /// </summary>
        /// <param name="show">The show.</param>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
        ITicketBlockAccessKey BlockTicket(IPublicTicket ticket);

        /// <summary>
        /// Unblocks the ticket identified by seat row and number.
        /// </summary>
        /// <param name="show">The show.</param>
        /// <param name="row">The row.</param>
        /// <param name="number">The number.</param>
        /// <remarks></remarks>
        void UnBlockTicket(IPublicShow show, ISeatIdentifier seat, ITicketBlockAccessKey key);

        /// <summary>
        /// Unblocks the ticket.
        /// </summary>
        /// <param name="show">The show.</param>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
        void UnBlockTicket(IPublicTicket ticket, ITicketBlockAccessKey key);

        /// <summary>
        /// Resets the ticket.
        /// </summary>
        /// <param name="movieProgram">The movie program.</param>
        /// <param name="show">The show.</param>
        /// <param name="row">The row.</param>
        /// <param name="nr">The nr.</param>
        /// <remarks></remarks>
        void UnReserveTicket(IPublicShow show, ISeatIdentifier seat);

        /// <summary>
        /// Returns the Ticket.
        /// </summary>
        /// <param name="ticket">The ticket to get.</param>
        /// <remarks></remarks>
        void UnReserveTicket(IPublicTicket ticket);

        /// <summary>
        /// Gets the movie program for the actual week.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        IPublicMovieProgram GetMovieProgramForThisWeek();
    }
}