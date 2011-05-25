using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.InterfaceMembers;
using TicketOperations.PublicInterfaceMembers.Interfaces;

namespace TicketOperations.PublicInterfaceMembers
{
    public class KinokartenAdministration : IKinokartenAdministration
    {
        #region Implementation of IKinokartenAdministration

        public void FillWithTestData()
        {
            throw new NotImplementedException();
        }

        public bool IsTicketBlocked(IPublicVorstellung vorstellung, ISitz sitz)
        {
            throw new NotImplementedException();
        }

        public bool IsTicketReserved(IPublicVorstellung vorstellung, ISitz sitz)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
