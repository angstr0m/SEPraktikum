using System;
using System.Collections.Generic;
using Kino.Schnittstelle;
using Kinokarten.Schnittstelle.Interfaces;

namespace TicketOperations.PublicInterfaceMembers.Interfaces.Anwendungsfall_spezifische_Interfaces
{
    public interface IABesucherReserviertKinokarteOnlineInformationen
    {
        List<IPublicKinokarte> GetVerfügbareKinokartenFürVorstellung(IPublicVorstellung vorstellung);

        bool PrüfeAltersfreigabeFürVorstellung(IPublicVorstellung vorstellung, DateTime geburtsdatum);

        bool PrüfeVerfügbarkeitVonSitzplatzFürVorstellung(IPublicVorstellung vorstellung, ISitz sitz);

        float GetPreisFürKinokarte(IPublicVorstellung vorstellung, ISitz sitz, bool rabatt);
    }
}