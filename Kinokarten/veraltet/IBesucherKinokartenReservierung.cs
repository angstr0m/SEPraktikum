using Cinema.Schnittstelle;
using Kinokarten.Schnittstelle.Interfaces;
using Kinokarten.veraltet.InternalInterfaceMembers.Interfaces;

namespace Kinokarten.veraltet
{
    interface IBesucherKinokartenReservierung : IKinokarteReservieren
    {
        


        /// <summary>
        /// Reserviert ein Kinokarte für einen Besucher.
        /// </summary>
        /// <param name="vorstellung">Die gewünschte Vorstellung.</param>
        /// <param name="sitz">Der gewünschte Sitz.</param>
        /// <remarks></remarks>
        int KinokarteReservieren(IPublicVorstellung vorstellung, ISitzIdentifikator sitz, bool rabatt, IKinokarteBlockierungZugangsSchlüssel transaktionsSchlüssel);

        /// <summary>
        /// Reserviert das TIcket für einen Besucher
        /// </summary>
        /// <param name="kinokarte">Das gewünschte Kinokarte.</param>
        /// <param name="rabatt">Hat den Wert true, wenn Rabatt gegeben werden soll.</param>
        /// <param name="transaktionsSchlüssel">Der Transaktionsschlüssel um das geblockte Kinokarte freizuschalten.</param>
        /// <returns> Gibt die Reservierungsnummer für das Kinokarte zurück. </returns>
        /// <remarks></remarks>
        int KinokarteReservieren(IPublicKinokarte kinokarte, bool rabatt, IKinokarteBlockierungZugangsSchlüssel transaktionsSchlüssel);
    }
}
