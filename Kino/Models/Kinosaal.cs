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
        /// Die Sitzplätze dieses Kinosaals.
        /// </summary>
        private readonly List<Sitz> _sitzplätze;

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
        /// <param name="sitzplätze_pro_reihe">Anzahl der Sitzplätze pro Reihe.</param>
        /// <param name="anzahl_reihen">Anzahl der Reihen</param>
        /// <remarks></remarks>
        public Kinosaal(String name, int sitzplätze_pro_reihe, int anzahl_reihen)
        {
            Name = name;

            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            var seats = new List<Sitz>();
            seats.Capacity = sitzplätze_pro_reihe*anzahl_reihen;

            // Benötigte Anzahl von Sitzplätzen erstellen,
            // und den Sitzplätzen des Kinosaal hinzufügen.
            for (int i = 0; i < anzahl_reihen; i++)
            {
                char rank = alphabet[i];
                for (int j = 0; j < sitzplätze_pro_reihe; j++)
                {
                    var tempSitz = new Sitz(rank, j);
                    seats.Add(tempSitz);
                }
            }

            _sitzplätze = seats;
            SitzplatzAnzahlNeuBerechnen();

            EntityManager<Kinosaal> kinosääle = new EntityManager<Kinosaal>();
            kinosääle.AddElement(this);
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="Kinosaal"/> Klasse.
        /// Benutzen Sie diesen Konstruktor, wenn bereits eine Liste von Sitzplätzen vorhanden ist.
        /// </summary>
        /// <param name="name">Der Name des Kinosaals.</param>
        /// <param name="sitzplätze">Eine Liste von Sitzplätzen.</param>
        /// <remarks></remarks>
        public Kinosaal(String name, List<Sitz> sitzplätze)
        {
            Name = name;
            _sitzplätze = sitzplätze;
            SitzplatzAnzahlNeuBerechnen();
        }

        #region IKinosaal Members

        /// <summary>
        /// Gibt die Anzahl der Sitzplätze zurück.
        /// </summary>
        /// <remarks></remarks>
        public int SitzAnzahl
        {
            get { return _sitzAnzahl; }
        }

        /// <summary>
        /// Gibt den Namen des Kinosaals zurück, oder ändert ihn.
        /// </summary>
        /// <value>Der Name des Kinosaals.</value>
        /// <remarks></remarks>
        public String Name { get; set; }

        /// <summary>
        /// Gibt eine Liste von Sitzplätzen zurück.
        /// Diese Liste enthält die Sitzplätze in diesem Kinosaal.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<ISitz> GetSitzplätze()
        {
            var returnList = new List<ISitz>();
            returnList.Capacity = _sitzplätze.Count;

            returnList.AddRange(_sitzplätze);

            //foreach (Sitz sitz in _sitzplätze)
            //{
            //    returnList.Add(sitz);
            //}

            return returnList;
        }

        #endregion

        /// <summary>
        /// Einen Sitzplatz zu den Sitzplätzen dieses Kinosaals hinzufügen.
        /// </summary>
        /// <param name="sitz">Der Sitz, welcher hinzugefügt werden soll.</param>
        /// <remarks></remarks>
        public void SitzplatzHinzufügen(Sitz sitz)
        {
            _sitzplätze.Add(sitz);
            SitzplatzAnzahlNeuBerechnen();
        }

        /// <summary>
        /// Einen Sitzplatz von den Sitzplätzen dieses Kinosaals entfernen.
        /// </summary>
        /// <param name="sitz">Der Sitz, welcher entfernt werden soll.</param>
        /// <remarks></remarks>
        public void SitzplatzEntfernen(Sitz sitz)
        {
            _sitzplätze.Remove(sitz);
            SitzplatzAnzahlNeuBerechnen();
        }

        /// <summary>
        /// Berechnet die Anzahl der Sitzplätze neu.s
        /// </summary>
        /// <remarks></remarks>
        private void SitzplatzAnzahlNeuBerechnen()
        {
            _sitzAnzahl = _sitzplätze.Count;
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