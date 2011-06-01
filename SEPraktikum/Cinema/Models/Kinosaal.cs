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
        /// Die Sitzpl�tze dieses Kinosaals.
        /// </summary>
        private List<Sitz> _sitzpl�tze;

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
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gibt eine Liste von Sitzpl�tzen zur�ck.
        /// Diese Liste enth�lt die Sitzpl�tze in diesem Kinosaal.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<ISitz> GetSitzpl�tze()
        {
            List<ISitz> returnList = new List<ISitz>();

            foreach (Sitz sitz in _sitzpl�tze)
            {
                returnList.Add(sitz);
            }

            return returnList;
        }

        /// <summary>
        /// Einen Sitzplatz zu den Sitzpl�tzen dieses Kinosaals hinzuf�gen.
        /// </summary>
        /// <param name="sitz">Der Sitz, welcher hinzugef�gt werden soll.</param>
        /// <remarks></remarks>
        public void SitzplatzHinzuf�gen(Sitz sitz) {
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
            this._sitzAnzahl = _sitzpl�tze.Count;
            NotifyObservers();
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="Kinosaal"/> Klasse.
        /// </summary>
        /// <param name="name">Der Name des Kinosaals.</param>
        /// <param name="sitzpl�tze_pro_reihe">Anzahl der Sitzpl�tze pro Reihe.</param>
        /// <param name="anzahl_reihen">Anzahl der Reihen</param>
        /// <remarks></remarks>
        public Kinosaal(String name, int sitzpl�tze_pro_reihe, int anzahl_reihen)
        {
            this._name = name;

            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            List<Sitz> seats = new List<Sitz>();

            // Ben�tigte Anzahl von Sitzpl�tzen erstellen,
            // und den Sitzpl�tzen des Kinosaal hinzuf�gen.
            for (int i = 0; i < anzahl_reihen; i++)
            {
                char rank = alphabet[i];
                for (int j = 0; j < sitzpl�tze_pro_reihe; j++)
                {
                    Sitz tempSitz = new Sitz(rank, j);
                    seats.Add(tempSitz);
                }
            }

            this._sitzpl�tze = seats;
            SitzplatzAnzahlNeuBerechnen();
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
            this._name = name;
            this._sitzpl�tze = sitzpl�tze;
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
