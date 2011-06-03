using System;
using System.Collections.Generic;
using Kino.Schnittstelle;
using TicketOperations.PublicInterfaceMembers.Interfaces.Anwendungsfall_spezifische_Interfaces;

namespace Kinokarten.Schnittstelle.Interfaces
{
    public interface IKinokartenInformationen : IABesucherReserviertKinokarteOnlineInformationen,
                                                IARegistrierterKundeReserviertKinokarteOnlineInformationen
    {
        List<IPublicKinokarte> GetVerf�gbareKinokartenF�rVorstellung(IPublicVorstellung vorstellung);
        bool Pr�feAltersfreigabeF�rVorstellung(IPublicVorstellung vorstellung, DateTime geburtsdatum);
        bool Pr�feVerf�gbarkeitVonSitzplatzF�rVorstellung(IPublicVorstellung vorstellung, ISitz sitz);
        float GetPreisF�rKinokarte(IPublicVorstellung vorstellung, ISitz sitz, bool rabatt);

        /// <summary>
        /// Liefert das derzeit aktuelle Filmprogramm.
        /// </summary>
        /// <returns> Das Filmprogramm f�r diese Woche. </returns>
        /// <remarks></remarks>
        IPublicFilmprogramm GetW�chentlichesFilmprogramm();
    }
}