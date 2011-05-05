using System;
namespace Models {
    public class Ticket : Interfaces.Subject
    {
        private bool sold;
        private bool reserved;
        private bool discount;
        private float price;
        private Seat seat;
        private Show show;
        private string reservationNumber;

        public Ticket(float price, Seat seat, Show show)
        {
            this.price = price;
            this.seat = seat;
            this.show = show;
            this.sold = false;
            this.reserved = false;
            // Reservationsnummer erstellen
            this.reservationNumber = show.GetHashCode() + " " + seat.ToString();
        }

        public string ReservationNumber
        {
            get { return reservationNumber; }
        }

        public bool Reserved
        {
            get { return reserved; }
            set { reserved = value; }
        }

        public bool Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public bool Sold
        {
            get { return sold; }
            set { sold = value; }
        }

        public float Price
        {
            get {
                if (!discount)
                {
                    return price;
                }
                else
                {
                    return price * 0.9f; // 10% Rabatt
                }
            }
        }

        public Models.Seat Seat
        {
            get { return seat; }
        }

        public Models.Show Show
        {
            get { return show; }
        }
    }

}
