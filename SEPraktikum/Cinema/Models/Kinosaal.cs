using System;
using System.Collections.Generic;
using Cinema.Schnittstelle;
using Database.Interfaces;

namespace Cinema.Models {
    /// <summary>
    /// Representing a phyisical room in the Cinema.
    /// </summary>
    /// <remarks></remarks>
    internal class Kinosaal : Base.AbstractClasses.Subject, IKinosaal
    {
        /// <summary>
        /// Die Id dieses Kinosaals in der Datenbank.
        /// </summary>
        private int id;
        /// <summary>
        /// Der Name des Kinosaals.
        /// </summary>
        private String _name;
        /// <summary>
        /// Die Anzahl der Sitze des Kinosaals.
        /// </summary>
        private int _sitzAnzahl;
        /// <summary>
        /// Die Sitzplätze dieses Kinosaals.
        /// </summary>
        private List<Sitz> _sitzplätze;

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
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gibt eine Liste von Sitzplätzen zurück.
        /// Diese Liste enthält die Sitzplätze in diesem Kinosaal.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<ISitz> GetSitzplätze()
        {
            List<ISitz> returnList = new List<ISitz>();

            foreach (Sitz sitz in _sitzplätze)
            {
                returnList.Add(sitz);
            }

            return returnList;
        }

        /// <summary>
        /// Einen Sitzplatz zu den Sitzplätzen dieses Kinosaals hinzufügen.
        /// </summary>
        /// <param name="sitz">Der Sitz, welcher hinzugefügt werden soll.</param>
        /// <remarks></remarks>
        public void SitzplatzHinzufügen(Sitz sitz) {
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
            this._sitzAnzahl = _sitzplätze.Count;
            NotifyObservers();
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="Kinosaal"/> Klasse.
        /// </summary>
        /// <param name="name">Der Name des Kinosaals.</param>
        /// <param name="sitzplätze_pro_reihe">Anzahl der Sitzplätze pro Reihe.</param>
        /// <param name="anzahl_reihen">Anzahl der Reihen</param>
        /// <remarks></remarks>
        public Kinosaal(String name, int sitzplätze_pro_reihe, int anzahl_reihen)
        {
            this._name = name;

            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            List<Sitz> seats = new List<Sitz>();

            // Benötigte Anzahl von Sitzplätzen erstellen,
            // und den Sitzplätzen des Kinosaal hinzufügen.
            for (int i = 0; i < anzahl_reihen; i++)
            {
                char rank = alphabet[i];
                for (int j = 0; j < sitzplätze_pro_reihe; j++)
                {
                    Sitz tempSitz = new Sitz(rank, j);
                    seats.Add(tempSitz);
                }
            }

            this._sitzplätze = seats;
            SitzplatzAnzahlNeuBerechnen();
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
            this._name = name;
            this._sitzplätze = sitzplätze;
            SitzplatzAnzahlNeuBerechnen();
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
