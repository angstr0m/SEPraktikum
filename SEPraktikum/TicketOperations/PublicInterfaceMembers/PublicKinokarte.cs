using TicketOperations.Models;

namespace TicketOperations.PublicInterfaceMembers
{
    class PublicKinokarte : IPublicKinokarte
    {
        private Kinokarte _kinokarte;

        public PublicKinokarte(Kinokarte kinokarte)
        {
            _kinokarte = kinokarte;
        }

        public int GetIdentifier()
        {
            return _kinokarte.GetIdentifier();
        }

        public string ReservationNumber
        {
            get { return _kinokarte.Reservationsnummer; }
        }

        public bool Reserved
        {
            get { return _kinokarte.Reserviert; }
        }

        public bool Discount
        {
            get { return _kinokarte.Rabatt; }
        }

        public bool Sold
        {
            get { return _kinokarte.Verkauft; }
        }

        public float Price
        {
            get { return _kinokarte.Preis; }
        }

        public Cinema.Models.Sitz Sitz
        {
            get { return _kinokarte.Sitz; }
        }

        public IPublicVorstellung Vorstellung
        {
            get { return new PublicVorstellung(_kinokarte.Vorstellung); }
        }
    }
}
