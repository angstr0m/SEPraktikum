using System.Collections.Generic;
using TicketOperations.Models;
using TicketOperations.Schnittstelle.Interfaces;

namespace TicketOperations.Schnittstelle
{
    class PublicFilmprogramm : IPublicFilmprogramm
    {
        private Filmprogramm _movieprogram;

        public PublicFilmprogramm(Filmprogramm filmprogramm)
        {
            _movieprogram = filmprogramm;
        }

        public List<IPublicVorstellung> Vorstellungen
        {
            get 
            { 
                List<IPublicVorstellung> shows = new List<IPublicVorstellung>();

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
    }
}
