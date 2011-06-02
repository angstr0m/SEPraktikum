using System;
using Cinema.Schnittstelle;
using Database.Models;
using Kinokarten.Models;
using Kinokarten.Schnittstelle.Interfaces;
using Kinokarten.veraltet.InternalInterfaceMembers.Interfaces;
using Users.Interfaces;
using Users.Models;

namespace Kinokarten.veraltet.InternalInterfaceMembers
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    class KinokartenReservieren : IKinokarteReservieren
    {
        private EntityManager<Vorstellung> _databaseShows;
        private EntityManager<Kinokarte> _databaseTickets;
        private EntityManager<Filmprogramm> _databaseMoviePrograms;
        private EntityManager<Reservierung> _databaseReservations;
        private EntityManager<Kunde> _kunden;

        protected IBenutzerinformationen Benutzerinformationen;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public KinokartenReservieren(IBenutzerinformationen benutzerinformationen)
        {
            InitializeDatabase();

            this.Benutzerinformationen = benutzerinformationen;
        }


        /// <summary>
        /// Initialisiert alle benötigten Entity Manager.
        /// </summary>
        /// <remarks></remarks>
        private void InitializeDatabase()
        {
            _databaseShows = new EntityManager<Vorstellung>();
            _databaseTickets = new EntityManager<Kinokarte>();
            _databaseMoviePrograms = new EntityManager<Filmprogramm>();
            _databaseReservations = new EntityManager<Reservierung>();
        }

        /// <summary>
        /// Reserviert ein Kinokarte.
        /// </summary>
        /// <param name="vorstellung">Die gewünschte Vorstellung.</param>
        /// <param name="sitz">Der gewünschte Sitzplatz.</param>
        /// <param name="discount">Soll ein Rabatt auf den Preis der Kinokarte gewährt werden?</param>
        /// <param name="kundennummer"></param>
        /// <param name="key">Der TransaktionsSchlüssel der für das entsperren des Kinokarten gebraucht wird.</param>
        /// <returns> Die Reservationsnummer des reservierten Kinokarten. </returns>
        /// <remarks></remarks>
        public int KinokarteReservieren(IPublicVorstellung vorstellung, ISitzIdentifikator sitz, bool discount, int kundennummer, IKinokarteBlockierungZugangsSchlüssel key)
        {
            IKunde kunde = Benutzerinformationen.GetKunde(kundennummer);

            Kinokarte wantedKinokarte = _databaseShows.GetElementWithId(vorstellung.GetIdentifier()).GetKinokarte(sitz);

            Reservierung r = new Reservierung(wantedKinokarte, kunde, discount, key);

            return r.Reservierungsnummer;
        }

        /// <summary>
        /// Reserviert ein Kinokarte für einen Kunden.
        /// </summary>
        /// <param name="kinokarte">Das Kinokarte welches reserviert werden soll.</param>
        /// <param name="discount">Soll ein Rabatt auf die Karten gegeben werden?</param>
        /// <param name="kundennummer"></param>
        /// <param name="key">Der TransaktionsSchlüssel der für das entsperren des Kinokarten gebraucht wird.</param>
        /// <returns> Die Reservationsnummer des reservierten Kinokarten. </returns>
        /// <remarks></remarks>
        public int KinokarteReservieren(IPublicKinokarte kinokarte, bool discount, int kundennummer, IKinokarteBlockierungZugangsSchlüssel key)
        {
            Kinokarte wantedKinokarte = _databaseTickets.GetElementWithId(kinokarte.GetIdentifier());
            Reservierung r = _databaseReservations.GetElements().Find(delegate(Reservierung re)
                                                                         {
                                                                             return (re.Kunde.Kundennummer == kundennummer) &&
                                                                                    (re.Vorstellung == (Vorstellung) kinokarte.Vorstellung);
                                                                         });
            

            if (r == null)
            {
                r = new Reservierung(wantedKinokarte, _kunden.GetElements().Find(delegate(Kunde k)
                                                                                     {
                                                                                         return k.Kundennummer ==
                                                                                                kundennummer;
                                                                                     }), discount, key);
            } else
            {
                r.TicketHinzufügen(wantedKinokarte, key);
            }
            
            return r.Reservierungsnummer;
        }

        /// <summary>
        /// Entfernt das angegebene Kinokarte aus der zugeordneten Reservierung und gibt es wieder frei.
        /// </summary>
        /// <param name="vorstellung">Die gewünschte Vorstellung.</param>
        /// <param name="seat">Der gewünschte Sitzplatz.</param>
        /// <remarks></remarks>
        public void ReservierungFürTicketAufheben(IPublicVorstellung vorstellung, ISitzIdentifikator seat)
        {
            Kinokarte wantedKinokarte = _databaseTickets.GetElements().Find(delegate(Kinokarte t)
                                                                          {
                                                                              return t.Vorstellung == vorstellung && t.Sitz == seat;
                                                                          });

            _databaseReservations.GetElements().Find(delegate (Reservierung r)
                                                         {
                                                             return r.Kinokarten.Contains(wantedKinokarte);
                                                         }).TicketEntfernen(wantedKinokarte);

        }

        public void ReservierungFürTicketAufheben(IPublicKinokarte kinokarte)
        {
            Kinokarte wantedKinokarte = (Kinokarte) kinokarte;

            _databaseReservations.GetElements().Find(delegate(Reservierung r)
            {
                return r.Kinokarten.Contains(wantedKinokarte);
            }).TicketEntfernen(wantedKinokarte);
        }

        /// <summary>
        /// Blockiert das gewünschte Kinokarte, und gibt den Zugangsschlüssel für die Aufhebung der Blockierung zurück.
        /// </summary>
        /// <param name="vorstellung">Die gewünschte Vorstellung.</param>
        /// <param name="sitz">Der gewünschte Sitzplatz.</param>
        /// <returns> Schlüsselobjekt zum entblockieren des Kinokarten. </returns>
        /// <remarks></remarks>
        public IKinokarteBlockierungZugangsSchlüssel TicketBlockieren(IPublicVorstellung vorstellung, ISitzIdentifikator sitz)
        {

            Vorstellung wantedVorstellung = _databaseShows.GetElementWithId(vorstellung.GetIdentifier());

            IKinokarteBlockierungZugangsSchlüssel key = wantedVorstellung.GetKinokarte(sitz).Blockieren();

            return key;
        }

        public IKinokarteBlockierungZugangsSchlüssel TicketBlockieren(IPublicKinokarte kinokarte)
        {
            IKinokarteBlockierungZugangsSchlüssel key = _databaseTickets.GetElementWithId(kinokarte.GetIdentifier()).Blockieren();

            return key;
        }

        /// <summary>
        /// Hebt die Blockierung des Kinokarten mit Hilfe des übergebenen Schlüssels auf.
        /// </summary>
        /// <param name="vorstellung">Die gewünschte Vorstellung.</param>
        /// <param name="sitz">Der gewünschte Sitzplatz.</param>
        /// <param name="key">Zugangsschlüssel der zur Aufhebung der Blockade benötigt wird.</param>
        /// <remarks></remarks>
        public void TicketBlockierungAufheben(IPublicVorstellung vorstellung, ISitzIdentifikator sitz, IKinokarteBlockierungZugangsSchlüssel key)
        {

            Vorstellung wantedVorstellung = _databaseShows.GetElementWithId(vorstellung.GetIdentifier());

            wantedVorstellung.GetKinokarte(sitz).BlockierungAufheben(key);
        }

        public void TicketBlockierungAufheben(IPublicKinokarte kinokarte, IKinokarteBlockierungZugangsSchlüssel key)
        {
            _databaseTickets.GetElementWithId(kinokarte.GetIdentifier()).BlockierungAufheben(key);
        }

        /// <summary>
        /// Liefert das derzeit aktuelle Filmprogramm.
        /// </summary>
        /// <returns> Das Filmprogramm für diese Woche. </returns>
        /// <remarks></remarks>
        public IPublicFilmprogramm GetWöchentlichesFilmprogramm()
        {
            return (IPublicFilmprogramm)_databaseMoviePrograms.GetElements().Find(delegate(Filmprogramm m)
                                                          {
                                                              return (m.StartDatum <= DateTime.Today &&
                                                                      m.StartDatum.AddDays(7) >= DateTime.Today);
                                                          });
        }
    }
}
