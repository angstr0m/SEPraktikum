using Base.AbstractClasses;
using Cinema.Models;

namespace TicketOperations.Models {
    /// <summary>
    /// Represents a ticket for a Movie show.
    /// A ticket can be reserved and or bought. 
    /// However, tickets that aren't bought, half an hour before the show starts, are set to non reserved and can only be bought until the show starts. 
    /// A ticket is connected to one single Show.
    /// </summary>
    /// <remarks></remarks>
    public class Ticket : Subject
    {
        /// <summary>
        /// Indicates if the ticket has been bought by a customer.
        /// </summary>
        private bool sold;
        /// <summary>
        /// Indicates if the ticket has been reserved by a customer.
        /// </summary>
        private bool reserved;
        /// <summary>
        /// Indicates if the ticket should have a discount.
        /// This will be set to true if a student/pupil or pensioneer has bought it.
        /// </summary>
        private bool discount;
        /// <summary>
        /// The price of the ticket.
        /// </summary>
        private float price;
        /// <summary>
        /// The seat the ticket belongs to.
        /// </summary>
        private Seat seat;
        /// <summary>
        /// The show the ticket belongs to.
        /// </summary>
        private Show show;
        /// <summary>
        /// The reservation number of the ticket.
        /// It is used by the customer to buy the ticket, if he reserved it previously.
        /// </summary>
        private string reservationNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ticket"/> class.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="seat">The seat.</param>
        /// <param name="show">The show.</param>
        /// <remarks></remarks>
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

        /// <summary>
        /// Gets the reservation number.
        /// </summary>
        /// <remarks></remarks>
        public string ReservationNumber
        {
            get { return reservationNumber; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Ticket"/> is reserved.
        /// </summary>
        /// <value><c>true</c> if reserved; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        public bool Reserved
        {
            get { return reserved; }
            set { reserved = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Ticket"/> is discounted.
        /// This is true when it was bought buy a student/pupil and or pensioneer.
        /// The discount is always 10%.
        /// </summary>
        /// <value><c>true</c> if the ticketprice is discounted; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        public bool Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Ticket"/> is sold.
        /// </summary>
        /// <value><c>true</c> if sold; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        public bool Sold
        {
            get { return sold; }
            set { sold = value; }
        }

        /// <summary>
        /// Gets the price of the ticket, taking into account any discount.
        /// </summary>
        /// <remarks></remarks>
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

        /// <summary>
        /// Gets the seat that belongs to this ticket.
        /// </summary>
        /// <remarks></remarks>
        public Seat Seat
        {
            get { return seat; }
        }

        /// <summary>
        /// Gets the show this ticket is for.
        /// </summary>
        /// <remarks></remarks>
        public Models.Show Show
        {
            get { return show; }
        }
    }

}
