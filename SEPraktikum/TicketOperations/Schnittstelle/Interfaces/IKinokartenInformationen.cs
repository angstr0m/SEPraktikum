using System;
using System.Collections.Generic;
using Cinema.Schnittstelle;
using TicketOperations.PublicInterfaceMembers.Interfaces.Anwendungsfall_spezifische_Interfaces;

namespace TicketOperations.Schnittstelle.Interfaces
{
    public interface IKinokartenInformationen : IABesucherReserviertKinokarteOnlineInformationen
    {
        List<IPublicKinokarte> GetVerfügbareKinokartenFürVorstellung(IPublicVorstellung vorstellung);
        bool PrüfeAltersfreigabeFürVorstellung(IPublicVorstellung vorstellung, DateTime geburtsdatum);
        bool PrüfeVerfügbarkeitVonSitzplatzFürVorstellung(IPublicVorstellung vorstellung, ISitz sitz);
        float GetPreisFürKinokarte(IPublicVorstellung vorstellung, ISitz sitz, bool rabatt);

        /// <summary>
        /// Liefert das derzeit aktuelle Filmprogramm.
        /// </summary>
        /// <returns> Das Filmprogramm für diese Woche. </returns>
        /// <remarks></remarks>
        IPublicFilmprogramm GetWöchentlichesFilmprogramm();
    }
}