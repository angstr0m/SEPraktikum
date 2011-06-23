using System.Collections.Generic;
using Kino.Schnittstelle;

namespace Kinokarten.Schnittstelle.Interfaces
{
    public interface IKinokartenAdministration
    {
        void TestdatenEinrichten(float kinokartenpreis);

        bool IsTicketBlocked(PublicVorstellung vorstellung, ISitz sitz);

        bool IsTicketReserved(PublicVorstellung vorstellung, ISitz sitz);
    }
}