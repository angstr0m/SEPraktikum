using Database.Models;
using Finances.Schnittstelle;
using Kino.Schnittstelle;
using Kinokarten.Models;
using Kinokarten.Schnittstelle.Interfaces;
using Users.Interfaces;

namespace Kinokarten.Schnittstelle
{
    public class KinokartenOperationen : IKinokartenOperationen
    {
        private readonly IBenutzerinformationen _benutzerinformationen;
        private readonly IFinanzenOperationen _finanzenoperationen;

        private readonly EntityManager<Vorstellung> _vorstellungen;
        private EntityManager<Filmprogramm> _filmprogramme;
        private EntityManager<Kinokarte> _kinokarten;
        private EntityManager<Reservierung> _reservierungen;

        public KinokartenOperationen(IBenutzerinformationen benutzerinformationen, IFinanzenOperationen finanzenOperationen)
        {
            _benutzerinformationen = benutzerinformationen;
            _finanzenoperationen = finanzenOperationen;

            _vorstellungen = new EntityManager<Vorstellung>();
            _kinokarten = new EntityManager<Kinokarte>();
            _filmprogramme = new EntityManager<Filmprogramm>();
            _reservierungen = new EntityManager<Reservierung>();
        }

        #region Implementation of IKinokartenOperationen

        public IKinokarteBlockierungZugangsSchlüssel BlockiereKinokarte(PublicVorstellung vorstellung, ISitz sitz)
        {
            Vorstellung wantedVorstellung = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier());

            IKinokarteBlockierungZugangsSchlüssel key = wantedVorstellung.GetKinokarte(sitz).Blockieren();

            return key;
        }

        public int KinokarteReservieren(PublicVorstellung vorstellung, ISitz sitz, bool rabatt,
                                        IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel)
        {
            IKunde kunde = _benutzerinformationen.GetBesucher();

            Kinokarte wantedKinokarte = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier()).GetKinokarte(sitz);

            var r = new Reservierung(wantedKinokarte, kunde, rabatt, zugangsSchlüssel);

            return r.Reservierungsnummer;
        }

        public int KinokarteReservieren(int kundennummer, PublicVorstellung vorstellung, ISitz sitz, bool rabatt,
                                        IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel)
        {
            IKunde kunde = _benutzerinformationen.GetKunde(kundennummer);

            Kinokarte wantedKinokarte = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier()).GetKinokarte(sitz);

            var r = new Reservierung(wantedKinokarte, kunde, rabatt, zugangsSchlüssel);

            return r.Reservierungsnummer;
        }


        public void BlockierungFürSitzplatzAufheben(PublicVorstellung vorstellung, ISitz sitz,
                                                    IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel)
        {
            Vorstellung wantedVorstellung = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier());

            wantedVorstellung.GetKinokarte(sitz).BlockierungAufheben(zugangsSchlüssel);
        }

        #endregion
    }
}