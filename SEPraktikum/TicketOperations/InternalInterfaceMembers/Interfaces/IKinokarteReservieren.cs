using Users.Models;

namespace TicketOperations.InterfaceMembers
{
    public interface IKinokarteReservieren
    {
        /// <summary>
        /// Reserves the kinokarte identified by seat row and number.
        /// </summary>
        /// <param name="vorstellung">The vorstellung.</param>
        /// <param name="row">The row.</param>
        /// <param name="number">The number.</param>
        /// <remarks></remarks>
        int TicketReservieren(IPublicVorstellung vorstellung, ISitzIdentifikator seat , bool discount, Kunde customer, IKinokarteBlockierungZugangsSchlüssel transactionkey);

        /// <summary>
        /// Reserves the kinokarte.
        /// </summary>
        /// <param name="show">The vorstellung.</param>
        /// <param name="kinokarte">The kinokarte.</param>
        /// <remarks></remarks>
        int TicketReservieren(IPublicKinokarte kinokarte, bool discount, Kunde customer, IKinokarteBlockierungZugangsSchlüssel transactionkey);

        /// <summary>
        /// Blocks the kinokarte identified by seat row and number.
        /// </summary>
        /// <param name="vorstellung">The vorstellung.</param>
        /// <param name="row">The row.</param>
        /// <param name="number">The number.</param>
        /// <remarks></remarks>
        IKinokarteBlockierungZugangsSchlüssel TicketBlockieren(IPublicVorstellung vorstellung, ISitzIdentifikator seat);

        /// <summary>
        /// Blocks the kinokarte.
        /// </summary>
        /// <param name="show">The vorstellung.</param>
        /// <param name="kinokarte">The kinokarte.</param>
        /// <remarks></remarks>
        IKinokarteBlockierungZugangsSchlüssel TicketBlockieren(IPublicKinokarte kinokarte);

        /// <summary>
        /// Unblocks the kinokarte identified by seat row and number.
        /// </summary>
        /// <param name="vorstellung">The vorstellung.</param>
        /// <param name="row">The row.</param>
        /// <param name="number">The number.</param>
        /// <remarks></remarks>
        void TicketBlockierungAufheben(IPublicVorstellung vorstellung, ISitzIdentifikator seat, IKinokarteBlockierungZugangsSchlüssel key);

        /// <summary>
        /// Unblocks the kinokarte.
        /// </summary>
        /// <param name="show">The vorstellung.</param>
        /// <param name="kinokarte">The kinokarte.</param>
        /// <remarks></remarks>
        void TicketBlockierungAufheben(IPublicKinokarte kinokarte, IKinokarteBlockierungZugangsSchlüssel key);

        /// <summary>
        /// Resets the kinokarte.
        /// </summary>
        /// <param name="movieProgram">The movie program.</param>
        /// <param name="vorstellung">The vorstellung.</param>
        /// <param name="row">The row.</param>
        /// <param name="nr">The nr.</param>
        /// <remarks></remarks>
        void ReservierungFürTicketAufheben(IPublicVorstellung vorstellung, ISitzIdentifikator seat);

        /// <summary>
        /// Returns the Kinokarte.
        /// </summary>
        /// <param name="kinokarte">The kinokarte to get.</param>
        /// <remarks></remarks>
        void ReservierungFürTicketAufheben(IPublicKinokarte kinokarte);

        /// <summary>
        /// Gets the movie program for the actual week.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        IPublicFilmprogramm GetWöchentlichesFilmprogramm();
    }
}