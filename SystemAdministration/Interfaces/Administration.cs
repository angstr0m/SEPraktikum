using Kino.Schnittstelle;
using Kinokarten.Schnittstelle.Interfaces;

namespace SystemAdministration.Interfaces
{
    public class Administration : IAdministration
    {
        private readonly IKinoAdministration _kinoAdministration;
        private readonly IKinokartenAdministration _kinokartenAdministration;

        public Administration(IKinokartenAdministration kinokartenAdministration, IKinoAdministration kinoAdministration)
        {
            _kinokartenAdministration = kinokartenAdministration;
            _kinoAdministration = kinoAdministration;
        }

        #region Implementation of IAdministration

        public void FillSystemWithTestData()
        {
            _kinoAdministration.TestdatenEinrichten();
            _kinokartenAdministration.FillWithTestData();
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