using Cinema.Schnittstelle;

namespace TicketOperations.Schnittstelle.Interfaces
{
    public interface IKinokartenAdministration
    {
        void FillWithTestData();

        bool IsTicketBlocked(IPublicVorstellung vorstellung, ISitz sitz);

        bool IsTicketReserved(IPublicVorstellung vorstellung, ISitz sitz);
    }
}
