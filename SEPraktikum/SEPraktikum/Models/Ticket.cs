using System;
namespace Models {
    public class Ticket : Interfaces.Subject
    {
        private bool sold;
        private float price;
        private Seat seat;
        private Show show;

        public Ticket(float price, Seat seat, Show show)
        {
            this.price = price;
            this.seat = seat;
            this.show = show;
            this.sold = false;
        }

        public bool Sold
        {
            get { return sold; }
            set { sold = value; }
        }

        public float Price
        {
            get { return price; }
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
