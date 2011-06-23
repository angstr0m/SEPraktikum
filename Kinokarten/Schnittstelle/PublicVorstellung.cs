using System;
using System.Collections.Generic;
using Kino.Schnittstelle;
using Kinokarten.Models;
using Kinokarten.Schnittstelle.Interfaces;

namespace Kinokarten.Schnittstelle
{
    /// <summary>
    /// Decorator for the vorstellung object.
    /// This class is meant for giving vorstellung objects to the outside, while hiding members and methods on the vorstellung-object which should not be seen.
    /// </summary>
    /// <remarks></remarks>
    public class PublicVorstellung
    {
        private readonly Vorstellung _vorstellung;

        internal PublicVorstellung(Vorstellung vorstellung)
        {
            _vorstellung = vorstellung;
        }

        #region PublicVorstellung Members

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

        public List<PublicKinokarte> VerfügbareKinokarten()
        {
            var publictickets = new List<PublicKinokarte>();
            List<Kinokarte> tickets = _vorstellung.GetVerfügbareKinokarten();

            foreach (Kinokarte ticket in tickets)
            {
                publictickets.Add(new PublicKinokarte(ticket));
            }

            return publictickets;
        }

        public List<PublicKinokarte> ReservierteKinokarten()
        {
            var publictickets = new List<PublicKinokarte>();
            List<Kinokarte> tickets = _vorstellung.GetReservierteKinokarten();

            foreach (Kinokarte ticket in tickets)
            {
                publictickets.Add(new PublicKinokarte(ticket));
            }

            return publictickets;
        }

        public List<PublicKinokarte> VerkaufteKinokarten()
        {
            var publictickets = new List<PublicKinokarte>();
            List<Kinokarte> tickets = _vorstellung.GetVerkaufteKinokarten();

            foreach (Kinokarte ticket in tickets)
            {
                publictickets.Add(new PublicKinokarte(ticket));
            }

            return publictickets;
        }

        public PublicKinokarte GetKinokarte(int index)
        {
            return new PublicKinokarte(_vorstellung.GetKinokarte(index));
        }

        /// <summary>
        /// Gibt eine Kinokarte für einen bestimmten Sitz zurück.
        /// </summary>
        /// <param name="sitzIdentifikator"> Der Identifikator des gewünschten Sitzplatzes.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public PublicKinokarte GetKinokarte(ISitzIdentifikator sitzIdentifikator)
        {
            return new PublicKinokarte(_vorstellung.GetKinokarte(sitzIdentifikator));
        }

        public int GetIdentifier()
        {
            return _vorstellung.GetIdentifier();
        }

        #endregion

        public int GetNumberOfFreeSeats()
        {
            return _vorstellung.GetNumberOfFreeSeats();
        }

        public int GetNumberOfBlockedSeats()
        {
            return _vorstellung.GetNumberOfBlockedSeats();
        }

        public PublicKinokarte GetKinokarte(char row, int nr)
        {
            return new PublicKinokarte(_vorstellung.GetKinokarte(row, nr));
        }
    }
}