using Cinema.Schnittstelle;
using TicketOperations.Models;
using TicketOperations.Schnittstelle.Interfaces;

namespace TicketOperations.Schnittstelle
{
    class PublicKinokarte : IPublicKinokarte
    {
        private Kinokarte _kinokarte;

        internal PublicKinokarte(Kinokarte kinokarte)
        {
            _kinokarte = kinokarte;
        }

        public int GetIdentifier()
        {
            return _kinokarte.GetIdentifier();
        }

        public bool Reserviert
        {
            get { return _kinokarte.Reserviert; }
        }

        public bool Rabatt
        {
            get { return _kinokarte.Rabatt; }
        }

        public bool Verkauft
        {
            get { return _kinokarte.Verkauft; }
        }

        public float Preis
        {
            get { return _kinokarte.Preis; }
        }

        public ISitz Sitz
        {
            get { return _kinokarte.Sitz; }
        }

        public IPublicVorstellung Vorstellung
        {
            get { return new PublicVorstellung(_kinokarte.Vorstellung); }
        }
    }
}
