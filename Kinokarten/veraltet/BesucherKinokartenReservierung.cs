﻿using Cinema.Schnittstelle;
using Kinokarten.Schnittstelle.Interfaces;
using Kinokarten.veraltet.InternalInterfaceMembers;
using Users.Interfaces;

namespace Kinokarten.veraltet
{
    class BesucherKinokartenReservierung : KinokartenReservieren, IBesucherKinokartenReservierung
    {
        public BesucherKinokartenReservierung(IBenutzerinformationen benutzerinformationen) : base(benutzerinformationen)
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
