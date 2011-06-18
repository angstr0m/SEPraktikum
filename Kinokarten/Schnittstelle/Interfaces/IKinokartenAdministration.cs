using System.Collections.Generic;
using Kino.Schnittstelle;

namespace Kinokarten.Schnittstelle.Interfaces
{
    public interface IKinokartenAdministration
    {
        void TestdatenEinrichten(float kinokartenpreis);

        bool IsTicketBlocked(IPublicVorstellung vorstellung, ISitz sitz);

        bool IsTicketReserved(IPublicVorstellung vorstellung, ISitz sitz);
    }
}