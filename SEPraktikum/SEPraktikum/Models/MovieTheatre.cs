using System;
using System.Collections.Generic;
namespace Models {
    public class MovieTheatre : Interfaces.Subject
    {
        private String name;
        private int seatCount;
        private List<Seat> seats;

        public int SeatCount
        {
            get { return seatCount; }
        }
        
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Seat> GetSeats()
        {
            return new List<Seat>(seats); // seats are immutable.
        }

        public void AddSeat(Seat seat) {
            seats.Add(seat);
            UpdateSeatCount();
        }

        public void RemoveSeat(Seat seat)
        {
            seats.Remove(seat);
            UpdateSeatCount();
        }

        private void UpdateSeatCount()
        {
            this.seatCount = seats.Count;
            NotifyObservers();
        }

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

        public MovieTheatre(String _name, List<Seat> _seats)
        {
            this.name = _name;
            this.seats = _seats;
            UpdateSeatCount();
        }
	}

}
