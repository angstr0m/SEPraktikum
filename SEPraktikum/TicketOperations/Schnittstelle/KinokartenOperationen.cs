using Cinema.Schnittstelle;
using Database.Models;
using Kinokarten.Models;
using Kinokarten.Schnittstelle.Interfaces;
using Users.Interfaces;

namespace Kinokarten.Schnittstelle
{
    public class KinokartenOperationen : IKinokartenOperationen
    {
        private IBenutzerinformationen _benutzerinformationen;

        private EntityManager<Vorstellung> _vorstellungen;
        private EntityManager<Kinokarte> _kinokarten;
        private EntityManager<Filmprogramm> _filmprogramme;
        private EntityManager<Reservierung> _reservierungen;

        public KinokartenOperationen(IBenutzerinformationen benutzerinformationen)
        {
            _benutzerinformationen = benutzerinformationen;

            _vorstellungen = new EntityManager<Vorstellung>();
            _kinokarten = new EntityManager<Kinokarte>();
            _filmprogramme = new EntityManager<Filmprogramm>();
            _reservierungen = new EntityManager<Reservierung>();
        }

        #region Implementation of IABesucherReserviertKinokarteOnlineOperationen

        public IKinokarteBlockierungZugangsSchlüssel BlockiereKinokarte(IPublicVorstellung vorstellung, ISitz sitz)
        {
            Vorstellung wantedVorstellung = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier());

            IKinokarteBlockierungZugangsSchlüssel key = wantedVorstellung.GetKinokarte(sitz).Blockieren();

            return key;
        }

        public int KinokarteReservieren(IPublicVorstellung vorstellung, ISitz sitz, bool rabatt, IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel)
        {
            IKunde kunde = _benutzerinformationen.GetBesucher();

            Kinokarte wantedKinokarte = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier()).GetKinokarte(sitz);

            Reservierung r = new Reservierung(wantedKinokarte, kunde, rabatt, zugangsSchlüssel);

            return r.Reservierungsnummer;
        }

        public int KinokarteReservieren(int kundennummer, IPublicVorstellung vorstellung, ISitz sitz, bool rabatt, IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel) {
           IKunde kunde = _benutzerinformationen.GetKunde(kundennummer);

           Kinokarte wantedKinokarte = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier()).GetKinokarte(sitz);

           Reservierung r = new Reservierung(wantedKinokarte, kunde, rabatt, zugangsSchlüssel);

           return r.Reservierungsnummer;
        }


        public void BlockierungFürSitzplatzAufheben(IPublicVorstellung vorstellung, ISitz sitz, IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel)
        {
            Vorstellung wantedVorstellung = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier());

            wantedVorstellung.GetKinokarte(sitz).BlockierungAufheben(zugangsSchlüssel);
        }
        #endregion
    }
}
