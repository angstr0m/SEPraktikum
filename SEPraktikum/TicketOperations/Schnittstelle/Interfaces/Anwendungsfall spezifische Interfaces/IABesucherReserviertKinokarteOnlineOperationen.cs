using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Schnittstelle;
using Kinokarten.Schnittstelle.Interfaces;

namespace TicketOperations.PublicInterfaceMembers.Interfaces.Anwendungsfall_spezifische_Interfaces
{
    public interface IABesucherReserviertKinokarteOnlineOperationen
    {
        IKinokarteBlockierungZugangsSchlüssel BlockiereKinokarte(IPublicVorstellung gewählte_vorstellung, ISitz sitz);

        int KinokarteReservieren(IPublicVorstellung gewählte_vorstellung, ISitz sitz, bool rabatt, IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel);

        void BlockierungFürSitzplatzAufheben(IPublicVorstellung gewählte_vorstellung, ISitz sitz, IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel);
    }
}
