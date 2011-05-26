using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.InterfaceMembers;
using TicketOperations.PublicInterfaceMembers;
using TicketOperations.PublicInterfaceMembers.Interfaces;

namespace SystemAdministration.Interfaces
{
    public class Administration : IAdministration
    {
        private IKinokartenAdministration _kinokartenAdministration;
        private IKinoAdministration _kinoAdministration;

        public Administration(IKinokartenAdministration kinokartenAdministration, IKinoAdministration kinoAdministration)
        {
            _kinokartenAdministration = kinokartenAdministration;
            _kinoAdministration = kinoAdministration;
        }

        #region Implementation of IAdministration
        
        public void FillSystemWithTestData()
        {
            _kinokartenAdministration.FillWithTestData();
            _kinoAdministration.FillWithTestData();
        }

        public bool IsTicketBlocked(IPublicVorstellung vorstellung, ISitz sitz)
        {
            return _kinokartenAdministration.IsTicketBlocked(vorstellung, sitz);
        }

        public bool IsTicketReserved(IPublicVorstellung vorstellung, ISitz sitz)
        {
            return _kinokartenAdministration.IsTicketReserved(vorstellung, sitz);
        }

        #endregion
    }
}
