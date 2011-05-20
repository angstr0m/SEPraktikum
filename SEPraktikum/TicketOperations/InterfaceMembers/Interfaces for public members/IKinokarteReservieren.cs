using Users.Models;

namespace TicketOperations.InterfaceMembers
{
    public interface IKinokarteReservieren
    {
        /// <summary>
        /// Reserves the ticket identified by seat row and number.
        /// </summary>
        /// <param name="vorstellung">The vorstellung.</param>
        /// <param name="row">The row.</param>
        /// <param name="number">The number.</param>
        /// <remarks></remarks>
        int TicketReservieren(IPublicVorstellung vorstellung, ISitzIdentifikator seat , bool discount, Customer customer, ITicketBlockierungZugangsSchl�ssel transactionkey);

        /// <summary>
        /// Reserves the ticket.
        /// </summary>
        /// <param name="show">The vorstellung.</param>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
        int TicketReservieren(IPublicTicket ticket, bool discount, Customer customer, ITicketBlockierungZugangsSchl�ssel transactionkey);

        /// <summary>
        /// Blocks the ticket identified by seat row and number.
        /// </summary>
        /// <param name="vorstellung">The vorstellung.</param>
        /// <param name="row">The row.</param>
        /// <param name="number">The number.</param>
        /// <remarks></remarks>
        ITicketBlockierungZugangsSchl�ssel TicketBlockieren(IPublicVorstellung vorstellung, ISitzIdentifikator seat);

        /// <summary>
        /// Blocks the ticket.
        /// </summary>
        /// <param name="show">The vorstellung.</param>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
        ITicketBlockierungZugangsSchl�ssel TicketBlockieren(IPublicTicket ticket);

        /// <summary>
        /// Unblocks the ticket identified by seat row and number.
        /// </summary>
        /// <param name="vorstellung">The vorstellung.</param>
        /// <param name="row">The row.</param>
        /// <param name="number">The number.</param>
        /// <remarks></remarks>
        void TicketBlockierungAufheben(IPublicVorstellung vorstellung, ISitzIdentifikator seat, ITicketBlockierungZugangsSchl�ssel key);

        /// <summary>
        /// Unblocks the ticket.
        /// </summary>
        /// <param name="show">The vorstellung.</param>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
        void TicketBlockierungAufheben(IPublicTicket ticket, ITicketBlockierungZugangsSchl�ssel key);

        /// <summary>
        /// Resets the ticket.
        /// </summary>
        /// <param name="movieProgram">The movie program.</param>
        /// <param name="vorstellung">The vorstellung.</param>
        /// <param name="row">The row.</param>
        /// <param name="nr">The nr.</param>
        /// <remarks></remarks>
        void ReservierungF�rTicketAufheben(IPublicVorstellung vorstellung, ISitzIdentifikator seat);

        /// <summary>
        /// Returns the Ticket.
        /// </summary>
        /// <param name="ticket">The ticket to get.</param>
        /// <remarks></remarks>
        void ReservierungF�rTicketAufheben(IPublicTicket ticket);

        /// <summary>
        /// Gets the movie program for the actual week.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        IPublicFilmprogramm GetW�chentlichesFilmprogramm();
    }
}