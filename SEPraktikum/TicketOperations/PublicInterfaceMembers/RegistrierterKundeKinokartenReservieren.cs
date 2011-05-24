using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Users.Interfaces;

namespace TicketOperations.InterfaceMembers
{
    class RegistrierterKundeKinokartenReservieren : KinokartenReservieren, IRegistrierterKundeKinokartenReservierung
    {
        public RegistrierterKundeKinokartenReservieren(IKundeninformationen kundeninformationen) : base(kundeninformationen)
        {
        }
    }
}
