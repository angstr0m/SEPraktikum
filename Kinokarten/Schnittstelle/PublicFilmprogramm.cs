using System.Collections.Generic;
using Kinokarten.Models;
using Kinokarten.Schnittstelle.Interfaces;

namespace Kinokarten.Schnittstelle
{
    public class PublicFilmprogramm
    {
        private readonly Filmprogramm _movieprogram;

        internal PublicFilmprogramm(Filmprogramm filmprogramm)
        {
            _movieprogram = filmprogramm;
        }

        #region PublicFilmprogramm Members

        public List<PublicVorstellung> Vorstellungen
        {
            get
            {
                var shows = new List<PublicVorstellung>();

                foreach (Vorstellung s in _movieprogram.Vorstellungen)
                {
                    shows.Add(new PublicVorstellung(s));
                }

                return shows;
            }
        }

        public int GetIdentifier()
        {
            return _movieprogram.GetIdentifier();
        }

        #endregion
    }
}