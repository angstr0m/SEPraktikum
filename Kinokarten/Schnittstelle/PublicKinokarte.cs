using Kino.Schnittstelle;
using Kinokarten.Models;
using Kinokarten.Schnittstelle.Interfaces;

namespace Kinokarten.Schnittstelle
{
    public class PublicKinokarte
    {
        private readonly Kinokarte _kinokarte;

        internal PublicKinokarte(Kinokarte kinokarte)
        {
            _kinokarte = kinokarte;
        }

        #region PublicKinokarte Members

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

        public PublicVorstellung Vorstellung
        {
            get { return new PublicVorstellung(_kinokarte.Vorstellung); }
        }

        #endregion
    }
}