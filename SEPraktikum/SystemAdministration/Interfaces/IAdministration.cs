using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Schnittstelle;
using Kinokarten.Schnittstelle.Interfaces;
using TicketOperations.PublicInterfaceMembers;

namespace SystemAdministration.Interfaces
{
    public interface IAdministration
    {
        void FillSystemWithTestData();

        bool IsTicketBlocked(IPublicVorstellung vorstellung, ISitz sitz);

        bool IsTicketReserved(IPublicVorstellung vorstellung, ISitz sitz);
    }
}
