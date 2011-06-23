using Kino.Schnittstelle;
using Kinokarten.Schnittstelle;
using Kinokarten.Schnittstelle.Interfaces;

namespace SystemAdministration.Interfaces
{
    public interface IAdministration
    {
        void FillSystemWithTestData(float kinokartenpreis);

        bool IsTicketBlocked(PublicVorstellung vorstellung, ISitz sitz);

        bool IsTicketReserved(PublicVorstellung vorstellung, ISitz sitz);
    }
}