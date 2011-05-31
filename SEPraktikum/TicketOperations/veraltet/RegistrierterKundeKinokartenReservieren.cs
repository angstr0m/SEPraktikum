using TicketOperations.Schnittstelle.veraltet.InternalInterfaceMembers;
using Users.Interfaces;

namespace TicketOperations.Schnittstelle.veraltet
{
    class RegistrierterKundeKinokartenReservieren : KinokartenReservieren, IRegistrierterKundeKinokartenReservierung
    {
        public RegistrierterKundeKinokartenReservieren(IBenutzerinformationen benutzerinformationen) : base(benutzerinformationen)
        {
        }
    }
}
