using System;
using System.Collections.Generic;
using Database.Interfaces;

namespace Cinema.Models {
    /// <summary>
    /// Representing a phyisical room in the Cinema.
    /// </summary>
    /// <remarks></remarks>
    public class Kinosaal : Base.AbstractClasses.Subject, IDatabaseObject, IKinosaal
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
        private List<Sitz> seats;

        /// <summary>
        /// Gets the Sitz count.
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
        public List<Sitz> GetSeats()
        {
            return new List<Sitz>(seats); // seats are immutable.
        }

        /// <summary>
        /// Adds the Sitz.
        /// </summary>
        /// <param name="sitz">The Sitz.</param>
        /// <remarks></remarks>
        public void AddSeat(Sitz sitz) {
            seats.Add(sitz);
            UpdateSeatCount();
        }

        /// <summary>
        /// Removes the Sitz.
        /// </summary>
        /// <param name="sitz">The Sitz.</param>
        /// <remarks></remarks>
        public void RemoveSeat(Sitz sitz)
        {
            seats.Remove(sitz);
            UpdateSeatCount();
        }

        /// <summary>
        /// Updates the Sitz count.
        /// </summary>
        /// <remarks></remarks>
        private void UpdateSeatCount()
        {
            this.seatCount = seats.Count;
            NotifyObservers();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Kinosaal"/> class.
        /// </summary>
        /// <param name="_name">The _name.</param>
        /// <param name="seats_per_rank">The seats_per_rank.</param>
        /// <param name="ranks">The ranks.</param>
        /// <remarks></remarks>
        public Kinosaal(String _name, int seats_per_rank, int ranks)
        {
            this.name = _name;

            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            List<Sitz> seats = new List<Sitz>();

            // Generate the needed number of seats.
            for (int i = 0; i < ranks; i++)
            {
                char rank = alphabet[i];
                for (int j = 0; j < seats_per_rank; j++)
                {
                    Sitz tempSitz = new Sitz(rank, j);
                    seats.Add(tempSitz);
                }
            }

            this.seats = seats;
            UpdateSeatCount();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Kinosaal"/> class.
        /// </summary>
        /// <param name="_name">The _name.</param>
        /// <param name="_seats">The _seats.</param>
        /// <remarks></remarks>
        public Kinosaal(String _name, List<Sitz> _seats)
        {
            this.name = _name;
            this.seats = _seats;
            UpdateSeatCount();
        }

        public void SetIdentifier(int id)
        {
            throw new NotImplementedException();
        }

        public int GetIdentifier()
        {
            throw new NotImplementedException();
        }
    }

}
