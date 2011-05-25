using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.InterfaceMembers;

namespace TicketOperations.PublicInterfaceMembers.Interfaces.Anwendungsfall_spezifische_Interfaces
{
    public interface IABesucherReserviertKinokarteOnlineInformationen
    {
        List<IPublicKinokarte> GetVerfügbareKinokartenFürVorstellung(IPublicVorstellung vorstellung);

        bool PrüfeAltersfreigabeFürVorstellung(IPublicVorstellung vorstellung, DateTime geburtsdatum);

        bool PrüfeVerfügbarkeitVonSitzplatzFürVorstellung(IPublicVorstellung vorstellung, ISitz sitz);

        float GetPreisFürKinokarte(IPublicVorstellung gewählte_vorstellung, ISitz sitz, bool rabatt);
    }
}
