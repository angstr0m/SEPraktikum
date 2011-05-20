namespace TicketOperations.InterfaceMembers
{
    interface IBesucherKinokartenReservierung : IKinokarteReservieren
    {
        /// <summary>
        /// Reserviert ein Ticket für einen Besucher.
        /// </summary>
        /// <param name="vorstellung">Die gewünschte Vorstellung.</param>
        /// <param name="sitz">Der gewünschte Sitz.</param>
        /// <remarks></remarks>
        int TicketReservieren(IPublicVorstellung vorstellung, ISitzIdentifikator sitz, bool rabatt, ITicketBlockierungZugangsSchlüssel transaktionsSchlüssel);

        /// <summary>
        /// Reserviert das TIcket für einen Besucher
        /// </summary>
        /// <param name="ticket">Das gewünschte Ticket.</param>
        /// <param name="rabatt">Hat den Wert true, wenn Rabatt gegeben werden soll.</param>
        /// <param name="transaktionsSchlüssel">Der Transaktionsschlüssel um das geblockte Ticket freizuschalten.</param>
        /// <returns> Gibt die Reservierungsnummer für das Ticket zurück. </returns>
        /// <remarks></remarks>
        int TicketReservieren(IPublicTicket ticket, bool rabatt, ITicketBlockierungZugangsSchlüssel transaktionsSchlüssel);
    }
}
