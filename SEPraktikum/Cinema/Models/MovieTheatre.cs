using System;
using System.Collections.Generic;

namespace Cinema.Models {
    /// <summary>
    /// Representing a phyisical room in the Cinema.
    /// </summary>
    /// <remarks></remarks>
    public class MovieTheatre : Base.AbstractClasses.Subject
    {
        /// <summary>
        /// 
        /// </summary>
        private String name;
        /// <summary>
        /// 
        /// </summary>
        private int seatCount;
        /// <summary>
        /// 
        /// </summary>
        private List<Seat> seats;

        /// <summary>
        /// Gets the seat count.
        /// </summary>
        /// <remarks></remarks>
        public int SeatCount
        {
            get { return seatCount; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets the seats.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<Seat> GetSeats()
        {
            return new List<Seat>(seats); // seats are immutable.
        }

        /// <summary>
        /// Adds the seat.
        /// </summary>
        /// <param name="seat">The seat.</param>
        /// <remarks></remarks>
        public void AddSeat(Seat seat) {
            seats.Add(seat);
            UpdateSeatCount();
        }

        /// <summary>
        /// Removes the seat.
        /// </summary>
        /// <param name="seat">The seat.</param>
        /// <remarks></remarks>
        public void RemoveSeat(Seat seat)
        {
            seats.Remove(seat);
            UpdateSeatCount();
        }

        /// <summary>
        /// Updates the seat count.
        /// </summary>
        /// <remarks></remarks>
        private void UpdateSeatCount()
        {
            this.seatCount = seats.Count;
            NotifyObservers();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieTheatre"/> class.
        /// </summary>
        /// <param name="_name">The _name.</param>
        /// <param name="seats_per_rank">The seats_per_rank.</param>
        /// <param name="ranks">The ranks.</param>
        /// <remarks></remarks>
        public MovieTheatre(String _name, int seats_per_rank, int ranks)
        {
            this.name = _name;

            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            List<Seat> seats = new List<Seat>();

            // Generate the needed number of seats.
            for (int i = 0; i < ranks; i++)
            {
                char rank = alphabet[i];
                for (int j = 0; j < seats_per_rank; j++)
                {
                    Seat temp_seat = new Seat(rank, j);
                    seats.Add(temp_seat);
                }
            }

            this.seats = seats;
            UpdateSeatCount();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieTheatre"/> class.
        /// </summary>
        /// <param name="_name">The _name.</param>
        /// <param name="_seats">The _seats.</param>
        /// <remarks></remarks>
        public MovieTheatre(String _name, List<Seat> _seats)
        {
            this.name = _name;
            this.seats = _seats;
            UpdateSeatCount();
        }
	}

}
