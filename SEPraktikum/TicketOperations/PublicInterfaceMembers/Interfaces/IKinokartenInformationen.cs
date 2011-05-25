using System;
using Cinema.InterfaceMembers;
using TicketOperations.PublicInterfaceMembers.Interfaces.Anwendungsfall_spezifische_Interfaces;

namespace TicketOperations.PublicInterfaceMembers
{
    public interface IKinokartenInformationen : IABesucherReserviertKinokarteOnlineInformationen
    {
        /// <summary>
        /// Liefert das derzeit aktuelle Filmprogramm.
        /// </summary>
        /// <returns> Das Filmprogramm für diese Woche. </returns>
        /// <remarks></remarks>
        IPublicFilmprogramm GetWöchentlichesFilmprogramm();
    }
}
