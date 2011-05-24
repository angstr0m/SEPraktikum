using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Users.Interfaces;

namespace TicketOperations.InterfaceMembers
{
    class BesucherKinokartenReservierung : KinokartenReservieren, IBesucherKinokartenReservierung
    {
        public BesucherKinokartenReservierung(IKundeninformationen kundeninformationen) : base(kundeninformationen)
        {
            
        }

        public int KinokarteReservieren(IPublicVorstellung vorstellung, ISitzIdentifikator sitz, bool rabatt, IKinokarteBlockierungZugangsSchlüssel transaktionsSchlüssel)
        {
            return base.KinokarteReservieren(vorstellung, sitz, rabatt, 0, transaktionsSchlüssel);
        }

        public int KinokarteReservieren(IPublicKinokarte kinokarte, bool rabatt, IKinokarteBlockierungZugangsSchlüssel transaktionsSchlüssel)
        {
            return base.KinokarteReservieren(kinokarte, rabatt, 0, transaktionsSchlüssel);
        }
    }
}
