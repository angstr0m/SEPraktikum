using System.Collections.Generic;
using Kinokarten.Models;
using Kinokarten.Schnittstelle.Interfaces;

namespace Kinokarten.Schnittstelle
{
    internal class PublicFilmprogramm : IPublicFilmprogramm
    {
        private readonly Filmprogramm _movieprogram;

        internal PublicFilmprogramm(Filmprogramm filmprogramm)
        {
            _movieprogram = filmprogramm;
        }

        #region IPublicFilmprogramm Members

        public List<IPublicVorstellung> Vorstellungen
        {
            get
            {
                var shows = new List<IPublicVorstellung>();

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