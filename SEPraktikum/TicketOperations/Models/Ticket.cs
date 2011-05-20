using System;
using Base.AbstractClasses;
using Cinema.Models;
using Database.Interfaces;
using Database.Models;
using TicketOperations.InterfaceMembers;

namespace TicketOperations.Models {
    
    /// <summary>
    /// Represents a ticket for a Movie vorstellung.
    /// A ticket can be reserved and or bought. 
    /// However, tickets that aren't bought, half an hour before the vorstellung starts, are set to non reserved and can only be bought until the vorstellung starts. 
    /// A ticket is connected to one single vorstellung.
    /// </summary>
    /// <remarks></remarks>
    public class Ticket : Subject, IDatabaseObject
    {
        private int id;
        private ITicketBlockierungZugangsSchlüssel key;
        /// <summary>
        /// Indicates if the ticket has been bought by a customer.
        /// </summary>
        private bool sold;
        /// <summary>
        /// Indicates if the ticket has been reserved by a customer.
        /// </summary>
        private bool reserved;

        private bool blocked;
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
        /// The vorstellung the ticket belongs to.
        /// </summary>
        private Vorstellung vorstellung;
        /// <summary>
        /// The reservation number of the ticket.
        /// It is used by the customer to buy the ticket, if he reserved it previously.
        /// </summary>
        private string reservationNumber;
        private EntityManager<Reservierung> _databaseReservation;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ticket"/> class.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="seat">The seat.</param>
        /// <param name="vorstellung">The vorstellung.</param>
        /// <remarks></remarks>
        public Ticket(float price, Seat seat, Vorstellung vorstellung)
        {
            this.price = price;
            this.seat = seat;
            this.vorstellung = vorstellung;
            this.sold = false;
            this.reserved = false;
            // Reservationsnummer erstellen
            this.reservationNumber = vorstellung.GetHashCode() + " " + seat.ToString();
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
        /// Gets the vorstellung this ticket is for.
        /// </summary>
        /// <remarks></remarks>
        public Models.Vorstellung Vorstellung
        {
            get { return vorstellung; }
        }

        public bool Blocked
        {
            get { return blocked; }
        }

        public ITicketBlockierungZugangsSchlüssel Block()
        {
            if (key != null && Blocked)
            {
                throw new TicketBlockedException();
            }

            this.blocked = true;
            key = new TicketBlockierungZugangsSchlüssel();
            return key;
        }

        public void UnBlock(ITicketBlockierungZugangsSchlüssel key)
        {
            if (this.key != key)
            {
                throw new WrongAccessKeyException();
            }

            if (!this.Blocked)
            {
                throw new TicketNotBlockedException();
            }

            this.blocked = false;
        }

        public void UnReserve()
        {
            if (Blocked)
            {
                throw new TicketBlockedException();
            }

            if (!Reserved)
            {
                throw new TicketNotReservedException();
            }

            reserved = false;
            discount = false;

            Reservierung reservierung = _databaseReservation.GetElements().Find(delegate(Reservierung r) { return r.Tickets.Contains(this); });
            reservierung.RemoveTicket(this);
        }

        public void SetIdentifier(int id)
        {
            this.id = id;
        }

        public int GetIdentifier()
        {
            return id;
        }
    }

}

public class TicketBlockedException : Exception
{
    
}

public class TicketNotBlockedException : Exception
{

}

public class WrongAccessKeyException : Exception
{
    
}

public class TicketNotReservedException : Exception
{
    
}