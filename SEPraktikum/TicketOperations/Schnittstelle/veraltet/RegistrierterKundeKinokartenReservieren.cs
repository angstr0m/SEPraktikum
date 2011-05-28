using TicketOperations.InternalInterfaceMembers;
using Users.Interfaces;

namespace TicketOperations.PublicInterfaceMembers
{
    class RegistrierterKundeKinokartenReservieren : KinokartenReservieren, IRegistrierterKundeKinokartenReservierung
    {
        public RegistrierterKundeKinokartenReservieren(IBenutzerinformationen benutzerinformationen) : base(benutzerinformationen)
        {
        }
    }
}
