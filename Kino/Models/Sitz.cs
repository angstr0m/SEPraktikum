using System;
using Base.AbstractClasses;
using Database.Interfaces;
using Database.Models;
using Kino.Schnittstelle;

namespace Kino.Models
{
    /// <summary>
    /// Representing a single Sitz in a specific Kinosaal
    /// </summary>
    /// <remarks></remarks>
    internal class Sitz : Subject, ISitz, IDatabaseObject
    {
        private readonly SitzIdentifikator _identifikator;

        public ISitzIdentifikator Identifikator
        {
            get { return _identifikator as ISitzIdentifikator; }
        }

        private int id;

        /// <summary>
        /// string for representation of the Sitz in the GUI.
        /// </summary>
        private string identifier;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sitz"/> class.
        /// </summary>
        /// <param name="sitzReihe"></param>
        /// <param name="sitzNummer"></param>
        /// <remarks></remarks>
        public Sitz(Char sitzReihe, int sitzNummer)
        {
            _identifikator = new SitzIdentifikator(sitzReihe, sitzNummer);
            identifier = "Reihe: " + sitzReihe + ", Nummer: " + sitzNummer;

            EntityManager<Sitz> sitze = new EntityManager<Sitz>();
            sitze.AddElement(this);
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

        #region ISitz Members

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public Char Reihe()
        {
            return _identifikator.Reihe;
        }

        /// <summary>
        /// Gets the nr.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public int Nummer()
        {
            return _identifikator.Nummer;
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

        #endregion

        #region Implementation of IDatabaseObject

        public void SetIdentifier(int id)
        {
            this.id = id;
        }

        public int GetIdentifier()
        {
            return id;
        }

        #endregion
    }
}