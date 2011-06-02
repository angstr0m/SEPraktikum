using System;
using System.Collections.Generic;
using Cinema.Schnittstelle;
using Kinokarten.Models;
using Kinokarten.Schnittstelle.Interfaces;

namespace Kinokarten.Schnittstelle
{
    /// <summary>
    /// Decorator for the vorstellung object.
    /// This class is meant for giving vorstellung objects to the outside, while hiding members and methods on the vorstellung-object which should not be seen.
    /// </summary>
    /// <remarks></remarks>
    public class PublicVorstellung : IPublicVorstellung
    {
        private Vorstellung _vorstellung;

        internal PublicVorstellung(Vorstellung vorstellung)
        {
            _vorstellung = vorstellung;
        }

        public DateTime StartZeit
        {
            get { return _vorstellung.StartZeit; }
        }

        public int Spieldauer
        {
            get { return _vorstellung.Duration; }
        }

        public int Altersfreigabe
        {
            get { return _vorstellung.Altersfreigabe; }
        }

        public string Name
        {
            get { return _vorstellung.Name; }
        }

        /// <summary>
        /// Gets the number of free tickets.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public int GetAnzahlFreierKinokarten()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the number of tickets that has been sold or reserved.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public int GetAnzahlNichtVerfügbarerKinokarten()
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfFreeSeats()
        {
            return _vorstellung.GetNumberOfFreeSeats();
        }

        public int GetNumberOfBlockedSeats()
        {
            return _vorstellung.GetNumberOfBlockedSeats();
        }

        public List<IPublicKinokarte> VerfügbareKinokarten()
        {
            List<IPublicKinokarte> publictickets = new List<IPublicKinokarte>();
            List<Kinokarte> tickets = _vorstellung.GetVerfügbareKinokarten();

            foreach (var ticket in tickets)
            {
                publictickets.Add(new PublicKinokarte(ticket));
            }

            return publictickets;
        }

        public List<IPublicKinokarte> ReservierteKinokarten()
        {
            List<IPublicKinokarte> publictickets = new List<IPublicKinokarte>();
            List<Kinokarte> tickets = _vorstellung.GetReservierteKinokarten();

            foreach (var ticket in tickets)
            {
                publictickets.Add(new PublicKinokarte(ticket));
            }

            return publictickets;
        }

        public List<IPublicKinokarte> VerkaufteKinokarten()
        {
            List<IPublicKinokarte> publictickets = new List<IPublicKinokarte>();
            List<Kinokarte> tickets = _vorstellung.GetVerkaufteKinokarten();

            foreach (var ticket in tickets)
            {
                publictickets.Add(new PublicKinokarte(ticket));
            }

            return publictickets;
        }

        public IPublicKinokarte GetKinokarte(int index)
        {
            return new PublicKinokarte(_vorstellung.GetKinokarte(index));
        }

        /// <summary>
        /// Gibt eine Kinokarte für einen bestimmten Sitz zurück.
        /// </summary>
        /// <param name="sitzIdentifikator"> Der Identifikator des gewünschten Sitzplatzes.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public IPublicKinokarte GetKinokarte(ISitzIdentifikator sitzIdentifikator)
        {
            return new PublicKinokarte(_vorstellung.GetKinokarte(sitzIdentifikator));
        }

        public IPublicKinokarte GetKinokarte(char row, int nr)
        {
            return new PublicKinokarte(_vorstellung.GetKinokarte(row, nr));
        }

        public int GetIdentifier()
        {
            return _vorstellung.GetIdentifier();
        }
    }
}
