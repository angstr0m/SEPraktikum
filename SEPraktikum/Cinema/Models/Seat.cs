using System;

namespace Cinema.Models {
    /// <summary>
    /// Representing a single seat in a specific MovieTheatre
    /// </summary>
    /// <remarks></remarks>
    public class Seat : Base.AbstractClasses.Subject
    {
        /// <summary>
        /// string for representation of the seat in the GUI.
        /// </summary>
        private string identifier;
        /// <summary>
        /// 
        /// </summary>
		private Char seatRow;
        /// <summary>
        /// 
        /// </summary>
		private int seatNr;

        /// <summary>
        /// Initializes a new instance of the <see cref="Seat"/> class.
        /// </summary>
        /// <param name="seatRow">The seat row.</param>
        /// <param name="seatNr">The seat nr.</param>
        /// <remarks></remarks>
        public Seat(Char seatRow, int seatNr)
        {
            this.seatRow = seatRow;
            this.seatNr = seatNr;
            identifier = "Reihe: " + seatRow + ", Nummer: " + seatNr;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        /// <remarks></remarks>
        public string Identifier
        {
            get { return identifier; }
            set { identifier = value; }
        }

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public Char GetRow() {
            return seatRow;
		}

        /// <summary>
        /// Gets the nr.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
		public int GetNr() {
			return seatNr;
		}

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        /// <remarks></remarks>
        public override string ToString()
        {
            return identifier;
        }
	}
}
