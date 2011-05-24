using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database.Models;
using TicketOperations.Models;
using Users.Models;
using Users.Interfaces;
using System.Timers;

namespace TicketOperations.InterfaceMembers
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

        protected IKundeninformationen _kundeninformationen;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public KinokartenReservieren(IKundeninformationen kundeninformationen)
        {
            InitializeDatabase();

            this._kundeninformationen = kundeninformationen;
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
        /// <param name="seat">Der gewünschte Sitzplatz.</param>
        /// <param name="discount">Soll ein Rabatt auf den Preis der Kinokarte gewährt werden?</param>
        /// <param name="kundennummer"></param>
        /// <param name="key">Der TransaktionsSchlüssel der für das entsperren des Kinokarten gebraucht wird.</param>
        /// <returns> Die Reservationsnummer des reservierten Kinokarten. </returns>
        /// <remarks></remarks>
        public int KinokarteReservieren(IPublicVorstellung vorstellung, ISitzIdentifikator seat, bool discount, int kundennummer, IKinokarteBlockierungZugangsSchlüssel key)
        {
            IKunde kunde = _kundeninformationen.GetKunde(kundennummer);

            Kinokarte wantedKinokarte = _databaseShows.GetElementWithId(vorstellung.GetIdentifier()).GetKinokarte(null);

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
                r = new Reservierung(wantedKinokarte, kundennummer, discount, key);
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
        /// <param name="seat">Der gewünschte Sitzplatz.</param>
        /// <returns> Schlüsselobjekt zum entblockieren des Kinokarten. </returns>
        /// <remarks></remarks>
        public IKinokarteBlockierungZugangsSchlüssel TicketBlockieren(IPublicVorstellung vorstellung, ISitzIdentifikator seat)
        {

            Vorstellung wantedVorstellung = _databaseShows.GetElementWithId(vorstellung.GetIdentifier());

            IKinokarteBlockierungZugangsSchlüssel key = wantedVorstellung.GetKinokarte(null).Blockieren();

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
        /// <param name="seat">Der gewünschte Sitzplatz.</param>
        /// <param name="key">Zugangsschlüssel der zur Aufhebung der Blockade benötigt wird.</param>
        /// <remarks></remarks>
        public void TicketBlockierungAufheben(IPublicVorstellung vorstellung, ISitzIdentifikator seat, IKinokarteBlockierungZugangsSchlüssel key)
        {

            Vorstellung wantedVorstellung = _databaseShows.GetElementWithId(vorstellung.GetIdentifier());

            wantedVorstellung.GetKinokarte(null).BlockierungAufheben(key);
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
                                                              return (m.StartDateTime <= DateTime.Today &&
                                                                      m.StartDateTime.AddDays(7) >= DateTime.Today);
                                                          });
        }
    }
}
