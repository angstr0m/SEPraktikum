using System;
using Base.AbstractClasses;
using Database.Interfaces;
using Kino.Schnittstelle;

namespace Kino.Models
{
    /// <summary>
    /// Repräsentiert einen Film.
    /// Dieser Film kann in mehreren Vorstellungen gezeigt werden.
    /// </summary>
    /// <remarks></remarks>
    internal class Film : Subject, IDatabaseObject, IFilm
    {
        /// <summary>
        /// Altersfreigabe des Films.
        /// </summary>
        private readonly int _altersfreigabe;

        /// <summary>
        /// Dauer des Films in Minuten.
        /// </summary>
        private readonly int _dauer;

        /// <summary>
        /// Das Genre des Films.
        /// </summary>
        private readonly String genre;

        /// <summary>
        /// Land in dem der Film produziert wurde.
        /// </summary>
        private readonly String herkunftsLand;

        /// <summary>
        /// Der Name des Films.
        /// </summary>
        private readonly String name;

        /// <summary>
        /// Der name des Regisseurs des Films.
        /// </summary>
        private readonly String regisseur;

        /// <summary>
        /// Schauspieler die an diesem Film mitgewirkt haben.
        /// </summary>
        private readonly String schauspieler;

        /// <summary>
        /// Die Id des Objekts in der Datenbank.
        /// </summary>
        private int id;

        public Film(String name, String genre, int _dauer, string herkunftsLand, int _altersfreigabe,
                    string schauspieler, string regisseur)
        {
            this.name = name;
            this.genre = genre;
            this._dauer = _dauer;
            this.herkunftsLand = herkunftsLand;

            this._altersfreigabe = _altersfreigabe;
            this.schauspieler = schauspieler;
            this.regisseur = regisseur;
        }

        public int Id
        {
            get { return id; }
        }

        #region IFilm Members

        public string Regisseur
        {
            get { return regisseur; }
        }

        public string Schauspieler
        {
            get { return schauspieler; }
        }

        public int Altersfreigabe
        {
            get { return _altersfreigabe; }
        }

        public string HerkunftsLand
        {
            get { return herkunftsLand; }
        }

        public int Dauer
        {
            get { return _dauer; }
        }

        public string Genre
        {
            get { return genre; }
        }

        public string Name
        {
            get { return name; }
        }

        #endregion

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