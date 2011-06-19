using System;
using System.Collections.Generic;
using Base.AbstractClasses;
using Database.Interfaces;
using Database.Models;
using Kino.Schnittstelle;

namespace Kino.Models
{
    /// <summary>
    /// Representing a phyisical room in the Cinema.
    /// </summary>
    /// <remarks></remarks>
    internal class Kinosaal : Subject, IKinosaal, IDatabaseObject
    {
        /// <summary>
        /// Die Sitzpl�tze dieses Kinosaals.
        /// </summary>
        private readonly List<Sitz> _sitzpl�tze;

        /// <summary>
        /// Die Anzahl der Sitze des Kinosaals.
        /// </summary>
        private int _sitzAnzahl;

        /// <summary>
        /// Die Id dieses Kinosaals in der Datenbank.
        /// </summary>
        private int id;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="Kinosaal"/> Klasse.
        /// </summary>
        /// <param name="name">Der Name des Kinosaals.</param>
        /// <param name="sitzpl�tze_pro_reihe">Anzahl der Sitzpl�tze pro Reihe.</param>
        /// <param name="anzahl_reihen">Anzahl der Reihen</param>
        /// <remarks></remarks>
        public Kinosaal(String name, int sitzpl�tze_pro_reihe, int anzahl_reihen)
        {
            Name = name;

            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            var seats = new List<Sitz>();
            seats.Capacity = sitzpl�tze_pro_reihe*anzahl_reihen;

            // Ben�tigte Anzahl von Sitzpl�tzen erstellen,
            // und den Sitzpl�tzen des Kinosaal hinzuf�gen.
            for (int i = 0; i < anzahl_reihen; i++)
            {
                char rank = alphabet[i];
                for (int j = 0; j < sitzpl�tze_pro_reihe; j++)
                {
                    var tempSitz = new Sitz(rank, j);
                    seats.Add(tempSitz);
                }
            }

            _sitzpl�tze = seats;
            SitzplatzAnzahlNeuBerechnen();

            EntityManager<Kinosaal> kinos��le = new EntityManager<Kinosaal>();
            kinos��le.AddElement(this);
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="Kinosaal"/> Klasse.
        /// Benutzen Sie diesen Konstruktor, wenn bereits eine Liste von Sitzpl�tzen vorhanden ist.
        /// </summary>
        /// <param name="name">Der Name des Kinosaals.</param>
        /// <param name="sitzpl�tze">Eine Liste von Sitzpl�tzen.</param>
        /// <remarks></remarks>
        public Kinosaal(String name, List<Sitz> sitzpl�tze)
        {
            Name = name;
            _sitzpl�tze = sitzpl�tze;
            SitzplatzAnzahlNeuBerechnen();
        }

        #region IKinosaal Members

        /// <summary>
        /// Gibt die Anzahl der Sitzpl�tze zur�ck.
        /// </summary>
        /// <remarks></remarks>
        public int SitzAnzahl
        {
            get { return _sitzAnzahl; }
        }

        /// <summary>
        /// Gibt den Namen des Kinosaals zur�ck, oder �ndert ihn.
        /// </summary>
        /// <value>Der Name des Kinosaals.</value>
        /// <remarks></remarks>
        public String Name { get; set; }

        /// <summary>
        /// Gibt eine Liste von Sitzpl�tzen zur�ck.
        /// Diese Liste enth�lt die Sitzpl�tze in diesem Kinosaal.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<ISitz> GetSitzpl�tze()
        {
            var returnList = new List<ISitz>();
            returnList.Capacity = _sitzpl�tze.Count;

            returnList.AddRange(_sitzpl�tze);

            //foreach (Sitz sitz in _sitzpl�tze)
            //{
            //    returnList.Add(sitz);
            //}

            return returnList;
        }

        #endregion

        /// <summary>
        /// Einen Sitzplatz zu den Sitzpl�tzen dieses Kinosaals hinzuf�gen.
        /// </summary>
        /// <param name="sitz">Der Sitz, welcher hinzugef�gt werden soll.</param>
        /// <remarks></remarks>
        public void SitzplatzHinzuf�gen(Sitz sitz)
        {
            _sitzpl�tze.Add(sitz);
            SitzplatzAnzahlNeuBerechnen();
        }

        /// <summary>
        /// Einen Sitzplatz von den Sitzpl�tzen dieses Kinosaals entfernen.
        /// </summary>
        /// <param name="sitz">Der Sitz, welcher entfernt werden soll.</param>
        /// <remarks></remarks>
        public void SitzplatzEntfernen(Sitz sitz)
        {
            _sitzpl�tze.Remove(sitz);
            SitzplatzAnzahlNeuBerechnen();
        }

        /// <summary>
        /// Berechnet die Anzahl der Sitzpl�tze neu.s
        /// </summary>
        /// <remarks></remarks>
        private void SitzplatzAnzahlNeuBerechnen()
        {
            _sitzAnzahl = _sitzpl�tze.Count;
            NotifyObservers();
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