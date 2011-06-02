using System;
using Kinokarten.Schnittstelle.Interfaces;
using Users.Interfaces;

namespace Kinokarten.Models {
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
	internal class Buchung : Reservierung  {
        /// <summary>
        /// 
        /// </summary>
		private String isPayed;

        public Buchung(Kinokarte kinokarte, IKunde kunde, bool discount, IKinokarteBlockierungZugangsSchlüssel key) : base(kinokarte, kunde, discount, key)
        {
        }

        /// <summary>
        /// Gets the is payed.
        /// </summary>
        /// <remarks></remarks>
		public void GetIsPayed() {
			throw new System.Exception("Not implemented");
		}
        /// <summary>
        /// Sets the is payed.
        /// </summary>
        /// <param name="isPayed">The is payed.</param>
        /// <remarks></remarks>
		public void SetIsPayed(object isPayed) {
			throw new System.Exception("Not implemented");
		}

	}

}
