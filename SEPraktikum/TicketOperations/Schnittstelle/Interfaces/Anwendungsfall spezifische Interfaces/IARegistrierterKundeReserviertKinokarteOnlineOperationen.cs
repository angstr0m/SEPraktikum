using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Schnittstelle;
using TicketOperations.Schnittstelle.Interfaces;
using Users.Interfaces;

namespace TicketOperations.PublicInterfaceMembers.Interfaces.Anwendungsfall_spezifische_Interfaces
{
    public interface IARegistrierterKundeReserviertKinokarteOnlineOperationen
    {
       // IKinokarteBlockierungZugangsSchlüssel BlockiereKinokarte(IPublicVorstellung gewählte_vorstellung, ISitz sitz);

        int KinokarteReservieren(int kundennummer,IPublicVorstellung gewählte_vorstellung, ISitz sitz, bool rabatt, IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel);

        void BlockierungFürSitzplatzAufheben(IPublicVorstellung gewählte_vorstellung, ISitz sitz, IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel);

       
    }
}
