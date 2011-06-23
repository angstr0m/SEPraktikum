using Kino.Schnittstelle;

namespace Kinokarten.Schnittstelle.Interfaces
{
    public interface IKinokartenOperationen
    {
        IKinokarteBlockierungZugangsSchlüssel BlockiereKinokarte(PublicVorstellung gewählte_vorstellung, ISitz sitz);

        int KinokarteReservieren(PublicVorstellung gewählte_vorstellung, ISitz sitz, bool rabatt,
                                 IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel);

        void BlockierungFürSitzplatzAufheben(PublicVorstellung gewählte_vorstellung, ISitz sitz,
                                             IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel);

        int KinokarteReservieren(int kundennummer, PublicVorstellung gewählte_vorstellung, ISitz sitz, bool rabatt,
                                 IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel);
    }
}