using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.InterfaceMembers;

namespace TicketOperations.PublicInterfaceMembers.Interfaces
{
    public interface IKinokartenAdministration
    {
        void FillWithTestData();

        bool IsTicketBlocked(IPublicVorstellung vorstellung, ISitz sitz);

        bool IsTicketReserved(IPublicVorstellung vorstellung, ISitz sitz);
    }
}
