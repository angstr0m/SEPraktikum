using Kinokarten.veraltet.InternalInterfaceMembers;
using Users.Interfaces;

namespace Kinokarten.veraltet
{
    class RegistrierterKundeKinokartenReservieren : KinokartenReservieren, IRegistrierterKundeKinokartenReservierung
    {
        public RegistrierterKundeKinokartenReservieren(IBenutzerinformationen benutzerinformationen) : base(benutzerinformationen)
        {
        }
    }
}
