using System;
using System.Collections.Generic;

namespace TicketOperations.InterfaceMembers
{
    public interface IPublicVorstellung
    {
        int GetIdentifier();

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        /// <remarks></remarks>
        DateTime StartTime { get; }

        /// <summary>
        /// Gets the duration of the movie shown.
        /// </summary>
        /// <value>The duration.</value>
        /// <remarks></remarks>
        int Duration { get; }

        /// <summary>
        /// Gets the movie rating (parental advisory) of the movie shown.
        /// </summary>
        /// <remarks></remarks>
        int MovieRating { get; }

        /// <summary>
        /// Gets the name of the movie that is shown.
        /// </summary>
        /// <remarks></remarks>
        String Name { get; }

        /// <summary>
        /// Gets the number of free tickets.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        int GetNumberOfFreeTickets();

        /// <summary>
        /// Gets the number of tickets that has been sold or reserved.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        int GetNumberOfUnavailableTickets();

        /// <summary>
        /// Gets the available tickets.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        List<IPublicTicket> GetAvailableTickets();

        /// <summary>
        /// Gets the reserved tickets.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        List<IPublicTicket> GetReservedTickets();

        /// <summary>
        /// Gets the sold tickets.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        List<IPublicTicket> GetSoldTickets();

        /// <summary>
        /// Gets the ticket at index.
        /// </summary>
        /// <param name="index">The index of the wanted ticket.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IPublicTicket GetTicket(int index);

        /// <summary>
        /// Gets the ticket for a specific seat, identified by row and number of the seat.
        /// </summary>
        /// <param name="row">The row of the seat (A-Z).</param>
        /// <param name="nr">The number of the seat.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IPublicTicket GetTicket(char row, int nr);
    }
}