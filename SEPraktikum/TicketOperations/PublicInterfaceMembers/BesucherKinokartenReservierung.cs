using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketOperations.InterfaceMembers
{
    class BesucherKinokartenReservierung : KinokarteReservieren, IBesucherKinokartenReservierung
    {
        public int TicketReservieren(IPublicVorstellung vorstellung, ISitzIdentifikator sitz, bool rabatt, IKinokarteBlockierungZugangsSchlüssel transaktionsSchlüssel)
        {
            throw new NotImplementedException();
        }

        public int TicketReservieren(IPublicKinokarte kinokarte, bool rabatt, IKinokarteBlockierungZugangsSchlüssel transaktionsSchlüssel)
        {
            throw new NotImplementedException();
        }
    }
}
