using System;
using Base.AbstractClasses;
using Cinema.Schnittstelle;
using Database.Interfaces;

namespace Cinema.Models
{
    /// <summary>
    /// Repräsentiert einen Film.
    /// Dieser Film kann in mehreren Vorstellungen gezeigt werden.
    /// </summary>
    /// <remarks></remarks>
    internal class Film : Subject, IDatabaseObject, IFilm
    {
        /// <summary>
        /// Die Id des Objekts in der Datenbank.
        /// </summary>
        private int id;
        /// <summary>
        /// Der Name des Films.
        /// </summary>
        private String name;
        /// <summary>
        /// Das Genre des Films.
        /// </summary>
        private String genre;
        /// <summary>
        /// Dauer des Films in Minuten.
        /// </summary>
        private int _dauer;
        /// <summary>
        /// Land in dem der Film produziert wurde.
        /// </summary>
        private String herkunftsLand;
        /// <summary>
        /// Altersfreigabe des Films.
        /// </summary>
        private int _altersfreigabe;
        /// <summary>
        /// Schauspieler die an diesem Film mitgewirkt haben.
        /// </summary>
        private String schauspieler;
        /// <summary>
        /// Der name des Regisseurs des Films.
        /// </summary>
        private String regisseur;

        public Film(String name, String genre, int _dauer, string herkunftsLand, int _altersfreigabe, string schauspieler, string regisseur)
        {
            this.name = name;
            this.genre = genre;
            this._dauer = _dauer;
            this.herkunftsLand = herkunftsLand;

            this._altersfreigabe = _altersfreigabe;
            this.schauspieler = schauspieler;
            this.regisseur = regisseur;
        }


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

        public int Id
        {
            get { return id; }
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
