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
        int TicketReservieren(IPublicVorstellung vorstellung, ISitzIdentifikator seat , bool discount, Customer customer, ITicketBlockierungZugangsSchlüssel transactionkey);

        /// <summary>
        /// Reserves the ticket.
        /// </summary>
        /// <param name="show">The vorstellung.</param>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
        int TicketReservieren(IPublicTicket ticket, bool discount, Customer customer, ITicketBlockierungZugangsSchlüssel transactionkey);

        /// <summary>
        /// Blocks the ticket identified by seat row and number.
        /// </summary>
        /// <param name="vorstellung">The vorstellung.</param>
        /// <param name="row">The row.</param>
        /// <param name="number">The number.</param>
        /// <remarks></remarks>
        ITicketBlockierungZugangsSchlüssel TicketBlockieren(IPublicVorstellung vorstellung, ISitzIdentifikator seat);

        /// <summary>
        /// Blocks the ticket.
        /// </summary>
        /// <param name="show">The vorstellung.</param>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
        ITicketBlockierungZugangsSchlüssel TicketBlockieren(IPublicTicket ticket);

        /// <summary>
        /// Unblocks the ticket identified by seat row and number.
        /// </summary>
        /// <param name="vorstellung">The vorstellung.</param>
        /// <param name="row">The row.</param>
        /// <param name="number">The number.</param>
        /// <remarks></remarks>
        void TicketBlockierungAufheben(IPublicVorstellung vorstellung, ISitzIdentifikator seat, ITicketBlockierungZugangsSchlüssel key);

        /// <summary>
        /// Unblocks the ticket.
        /// </summary>
        /// <param name="show">The vorstellung.</param>
        /// <param name="ticket">The ticket.</param>
        /// <remarks></remarks>
        void TicketBlockierungAufheben(IPublicTicket ticket, ITicketBlockierungZugangsSchlüssel key);

        /// <summary>
        /// Resets the ticket.
        /// </summary>
        /// <param name="movieProgram">The movie program.</param>
        /// <param name="vorstellung">The vorstellung.</param>
        /// <param name="row">The row.</param>
        /// <param name="nr">The nr.</param>
        /// <remarks></remarks>
        void ReservierungFürTicketAufheben(IPublicVorstellung vorstellung, ISitzIdentifikator seat);

        /// <summary>
        /// Returns the Ticket.
        /// </summary>
        /// <param name="ticket">The ticket to get.</param>
        /// <remarks></remarks>
        void ReservierungFürTicketAufheben(IPublicTicket ticket);

        /// <summary>
        /// Gets the movie program for the actual week.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        IPublicFilmprogramm GetWöchentlichesFilmprogramm();
    }
}