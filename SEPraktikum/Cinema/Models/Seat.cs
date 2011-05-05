using System;

namespace Cinema.Models {
    public class Seat : Base.AbstractClasses.Subject
    {
        private string identifier;
		private Char seatRow;
		private int seatNr;

        public Seat(Char seatRow, int seatNr)
        {
            this.seatRow = seatRow;
            this.seatNr = seatNr;
            identifier = "Reihe: " + seatRow + ", Nummer: " + seatNr;
        }

        public string Identifier
        {
            get { return identifier; }
            set { identifier = value; }
        }
		
        public Char GetRow() {
            return seatRow;
		}

		public int GetNr() {
			return seatNr;
		}

        public override string ToString()
        {
            return identifier;
        }
	}
}
