using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database.Models;
using TicketOperations.Models;
using Users.Models;
using System.Timers;

namespace TicketOperations.InterfaceMembers
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    class KinokarteReservieren : IKinokarteReservieren
    {
        private EntityManager<Vorstellung> _databaseShows;
        private EntityManager<Ticket> _databaseTickets;
        private EntityManager<Filmprogramm> _databaseMoviePrograms;
        private EntityManager<Reservierung> _databaseReservations;


        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public KinokarteReservieren()
        {
            InitializeDatabase();
        }


        /// <summary>
        /// Initialisiert alle benötigten Entity Manager.
        /// </summary>
        /// <remarks></remarks>
        private void InitializeDatabase()
        {
            _databaseShows = new EntityManager<Vorstellung>();
            _databaseTickets = new EntityManager<Ticket>();
            _databaseMoviePrograms = new EntityManager<Filmprogramm>();
            _databaseReservations = new EntityManager<Reservierung>();
        }

        /// <summary>
        /// Reserviert ein Ticket.
        /// </summary>
        /// <param name="vorstellung">Die gewünschte Vorstellung.</param>
        /// <param name="seat">Der gewünschte Sitzplatz.</param>
        /// <param name="discount">Soll ein Rabatt auf den Preis der Kinokarte gewährt werden?</param>
        /// <param name="customer">Der Kunde.</param>
        /// <param name="key">Der TransaktionsSchlüssel der für das entsperren des Tickets gebraucht wird.</param>
        /// <returns> Die Reservationsnummer des reservierten Tickets. </returns>
        /// <remarks></remarks>
        public int TicketReservieren(IPublicVorstellung vorstellung, ISitzIdentifikator seat, bool discount, Customer customer, ITicketBlockierungZugangsSchlüssel key)
        {
            Ticket wantedTicket = _databaseShows.GetElementWithId(vorstellung.GetIdentifier()).GetTicket(seat);

            Reservierung r = new Reservierung(wantedTicket, customer, discount, key);

            return r.ReservationNumber;
        }

        /// <summary>
        /// Reserviert ein Ticket für einen Kunden.
        /// </summary>
        /// <param name="ticket">Das Ticket welches reserviert werden soll.</param>
        /// <param name="discount">Soll ein Rabatt auf die Karten gegeben werden?</param>
        /// <param name="customer">Der Kunde.</param>
        /// <param name="key">Der TransaktionsSchlüssel der für das entsperren des Tickets gebraucht wird.</param>
        /// <returns> Die Reservationsnummer des reservierten Tickets. </returns>
        /// <remarks></remarks>
        public int TicketReservieren(IPublicTicket ticket, bool discount, Customer customer, ITicketBlockierungZugangsSchlüssel key)
        {
            Ticket wantedTicket = _databaseTickets.GetElementWithId(ticket.GetIdentifier());
            Reservierung r = _databaseReservations.GetElements().Find(delegate(Reservierung re)
                                                                         {
                                                                             return (re.Customer == customer) &&
                                                                                    (re.Vorstellung == (Vorstellung) ticket.Vorstellung);
                                                                         });

            if (r == null)
            {
                r = new Reservierung(wantedTicket, customer, discount, key);
            } else
            {
                r.AddTicket(wantedTicket, key);
            }
            
            return r.ReservationNumber;
        }

        /// <summary>
        /// Entfernt das angegebene Ticket aus der zugeordneten Reservierung und gibt es wieder frei.
        /// </summary>
        /// <param name="vorstellung">Die gewünschte Vorstellung.</param>
        /// <param name="seat">Der gewünschte Sitzplatz.</param>
        /// <remarks></remarks>
        public void ReservierungFürTicketAufheben(IPublicVorstellung vorstellung, ISitzIdentifikator seat)
        {
            Ticket wantedTicket = _databaseTickets.GetElements().Find(delegate(Ticket t)
                                                                          {
                                                                              return t.Vorstellung == vorstellung && t.Seat == seat;
                                                                          });

            _databaseReservations.GetElements().Find(delegate (Reservierung r)
                                                         {
                                                             return r.Tickets.Contains(wantedTicket);
                                                         }).RemoveTicket(wantedTicket);

        }

        public void ReservierungFürTicketAufheben(IPublicTicket ticket)
        {
            Ticket wantedTicket = (Ticket) ticket;

            _databaseReservations.GetElements().Find(delegate(Reservierung r)
            {
                return r.Tickets.Contains(wantedTicket);
            }).RemoveTicket(wantedTicket);
        }

        /// <summary>
        /// Blockiert das gewünschte Ticket, und gibt den Zugangsschlüssel für die Aufhebung der Blockierung zurück.
        /// </summary>
        /// <param name="vorstellung">Die gewünschte Vorstellung.</param>
        /// <param name="seat">Der gewünschte Sitzplatz.</param>
        /// <returns> Schlüsselobjekt zum entblockieren des Tickets. </returns>
        /// <remarks></remarks>
        public ITicketBlockierungZugangsSchlüssel TicketBlockieren(IPublicVorstellung vorstellung, ISitzIdentifikator seat)
        {

            Vorstellung wantedVorstellung = _databaseShows.GetElementWithId(vorstellung.GetIdentifier());

            ITicketBlockierungZugangsSchlüssel key = wantedVorstellung.GetTicket(seat).Block();

            return key;
        }

        public ITicketBlockierungZugangsSchlüssel TicketBlockieren(IPublicTicket ticket)
        {
            ITicketBlockierungZugangsSchlüssel key = _databaseTickets.GetElementWithId(ticket.GetIdentifier()).Block();

            return key;
        }

        /// <summary>
        /// Hebt die Blockierung des Tickets mit Hilfe des übergebenen Schlüssels auf.
        /// </summary>
        /// <param name="vorstellung">Die gewünschte Vorstellung.</param>
        /// <param name="seat">Der gewünschte Sitzplatz.</param>
        /// <param name="key">Zugangsschlüssel der zur Aufhebung der Blockade benötigt wird.</param>
        /// <remarks></remarks>
        public void TicketBlockierungAufheben(IPublicVorstellung vorstellung, ISitzIdentifikator seat, ITicketBlockierungZugangsSchlüssel key)
        {

            Vorstellung wantedVorstellung = _databaseShows.GetElementWithId(vorstellung.GetIdentifier());

            wantedVorstellung.GetTicket(seat).UnBlock(key);
        }

        public void TicketBlockierungAufheben(IPublicTicket ticket, ITicketBlockierungZugangsSchlüssel key)
        {
            _databaseTickets.GetElementWithId(ticket.GetIdentifier()).UnBlock(key);
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
