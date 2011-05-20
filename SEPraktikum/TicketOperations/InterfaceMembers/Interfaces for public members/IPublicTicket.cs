using Cinema.Models;
using TicketOperations.Models;

namespace TicketOperations.InterfaceMembers
{
    public interface IPublicTicket
    {
        int GetIdentifier();

        /// <summary>
        /// Gets the reservation number.
        /// </summary>
        /// <remarks></remarks>
        string ReservationNumber { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Ticket"/> is reserved.
        /// </summary>
        /// <value><c>true</c> if reserved; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        bool Reserved { get;}

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Ticket"/> is discounted.
        /// This is true when it was bought buy a student/pupil and or pensioneer.
        /// The discount is always 10%.
        /// </summary>
        /// <value><c>true</c> if the ticketprice is discounted; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        bool Discount { get;}

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Ticket"/> is sold.
        /// </summary>
        /// <value><c>true</c> if sold; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        bool Sold { get;}

        /// <summary>
        /// Gets the price of the ticket, taking into account any discount.
        /// </summary>
        /// <remarks></remarks>
        float Price { get; }

        /// <summary>
        /// Gets the seat that belongs to this ticket.
        /// </summary>
        /// <remarks></remarks>
        Seat Seat { get; }

        /// <summary>
        /// Gets the vorstellung this ticket is for.
        /// </summary>
        /// <remarks></remarks>
        IPublicVorstellung Vorstellung { get; }
    }
}