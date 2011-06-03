using Kino.Schnittstelle;
using Kinokarten.Schnittstelle.Interfaces;

namespace SystemAdministration.Interfaces
{
    public interface IAdministration
    {
        void FillSystemWithTestData();

        bool IsTicketBlocked(IPublicVorstellung vorstellung, ISitz sitz);

        bool IsTicketReserved(IPublicVorstellung vorstellung, ISitz sitz);
    }
}