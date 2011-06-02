using System;
using System.Collections.Generic;
using Base.AbstractClasses;
using Cinema.Schnittstelle;
using Database.Interfaces;

namespace TicketOperations.Models {
    
    /// <summary>
    /// Eine Vorstellung repr�sentiert eine einzelne Vorf�hrung eines Films in einem bestimmten Kinosaal.
    /// </summary>
    /// 
    /// <remarks></remarks>
    internal class Vorstellung : Subject, IDatabaseObject
    {

        private int id;
        /// <summary>
        /// Startzeit des Vorstellung.
        /// </summary>
        private DateTime _startZeit;
        /// <summary>
        /// Der Film der in der Vorstellung gezeigt wird.
        /// </summary>
        private IFilm _film;
        /// <summary>
        /// Der Kinosaal in dem die Vorstellung gezeigt wird.
        /// </summary>
        private IKinosaal _kinosaal;
        /// <summary>
        /// Zeigt an, ob es w�hrend der Vorstellung eine Pause gibt oder nicht. 
        /// </summary>
        private bool _pause;
        /// <summary>
        /// Die Kinokarten dieser Vorstellung.
        /// </summary>
        private List<Kinokarte> _kinokarten;

        /// <summary>
        /// Gibt die Startzeit dieser Vorstellung zur�ck.
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        public DateTime StartZeit
        {
            get { return _startZeit; }
        }

        /// <summary>
        /// Gibt die Spieldauer des zugeh�rigen Films zur�ck.
        /// </summary>
        /// <value>The duration.</value>
        /// <remarks></remarks>
        public int Duration
        {
            get { return _film.Dauer; }
        }

        /// <summary>
        /// Gibt die Altersfreigabe das Films zur�ck.
        /// </summary>
        /// <remarks></remarks>
        public int Altersfreigabe
        {
            get { return _film.Altersfreigabe; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vorstellung"/> class.
        /// </summary>
        /// <param name="startZeit">The start time.</param>
        /// <param name="_film">The Film.</param>
        /// <param name="kinosaal">The _kinosaal.</param>
        /// <param name="pause">if set to <c>true</c> [pause].</param>
        /// <param name="ticketPrice">The Kinokarte price.</param>
        /// <remarks></remarks>
        public Vorstellung(DateTime startZeit, IFilm _film, IKinosaal kinosaal, bool pause, float ticketPrice)
        {
            this._startZeit = startZeit;
            this._film = _film;
            this._kinosaal = kinosaal;
            this._pause = pause;
            this._kinokarten = new List<Kinokarte>();

            foreach (ISitz s in kinosaal.GetSitzpl�tze())
            {
                _kinokarten.Add(new Kinokarte(ticketPrice, s, this));
            }
        }

        /// <summary>
        /// Gibt die Anzahl der Kinokarten zur�ck, die weder verkauft noch reserviert sind.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public int GetNumberOfFreeSeats()
        {
            return _kinokarten.FindAll(
                    delegate(Kinokarte t)
                    {
                        return (!t.Verkauft && !t.Reserviert);
                    }
                ).Count;
        }

        /// <summary>
        /// Gibt die Anzahl der Kinokarten zur�ck, die gekauft oder reserviert wurden.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public int GetNumberOfBlockedSeats()
        {
            return _kinokarten.FindAll(
                    delegate(Kinokarte t)
                    {
                        return (t.Verkauft || t.Reserviert);
                    }
                ).Count;
        }

        /// <summary>
        /// Gibt die Kinokarten dieser Vorstellung zur�ck, die weder verkauft noch reserviert sind.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<Kinokarte> GetVerf�gbareKinokarten()
        {
            return _kinokarten.FindAll(
                    delegate(Kinokarte t)
                    {
                        return (!t.Verkauft && !t.Reserviert);
                    }
                );
        }

        /// <summary>
        /// Gibt die reservierten Kinokarten zur�ck.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<Kinokarte> GetReservierteKinokarten()
        {
            return _kinokarten.FindAll(
                    delegate(Kinokarte t)
                    {
                        return (t.Reserviert);
                    }
                );
        }

        /// <summary>
        /// Liefert die verkauften Kinokarten zur�ck.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<Kinokarte> GetVerkaufteKinokarten()
        {
            return _kinokarten.FindAll(
                    delegate(Kinokarte t)
                    {
                        return (t.Verkauft);
                    }
                );
        }

        /// <summary>
        /// Gibt eine bestimmte Kinokarte aus dieser Vorstellung zur�ck.
        /// </summary>
        /// <param name="index">Der Index der gew�nschten Kinokarte.</param>
        /// <returns>Die gew�nschte Kinokarte.</returns>
        /// <remarks></remarks>
        public Kinokarte GetKinokarte(int index)
        {
            return _kinokarten[index];
        }

        /// <summary>
        /// Gibt eine bestimmte Kinokarte aus dieser Vorstellung zur�ck.
        /// </summary>
        /// <param name="seat">Die Reihe des Sitzes (A-Z).</param>
        /// <returns>Die gew�nschte Kinokarte.</returns>
        /// <remarks></remarks>
        public Kinokarte GetKinokarte(ISitz sitz)
        {
            return GetKinokarte(sitz.Reihe(), sitz.Nummer());
        }

        /// <summary>
        /// Gibt eine bestimmte Kinokarte aus dieser Vorstellung zur�ck.
        /// </summary>
        /// <param name="reihe">Die Reihe des Sitzes der gew�nschten Kinokarte (A-Z).</param>
        /// <param name="nummer">Dir Nummer der gew�nschten Kinokarte.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public Kinokarte GetKinokarte(char reihe, int nummer)
        {
            return _kinokarten.Find(
                    delegate(Kinokarte t)
                    {
                        return ((t.Sitz.Reihe() == reihe) && (t.Sitz.Nummer() == nummer));
                    }
                );
        }

        /// <summary>
        /// Gibt den Namen des Films zur�ck, der gezeigt wird.
        /// </summary>
        /// <remarks></remarks>
        public String Name
        {
            get
            {
                return _film.Name;
            }
        }

        /// <summary>
        /// Reserviert die angegebene Kinokarte.
        /// </summary>
        /// <param name="kinokarte"></param>
        /// <remarks></remarks>
        public void ReserviereKinokarte(Kinokarte kinokarte)
        {
            kinokarte.Reservieren();
            NotifyObservers();
        }

        /// <summary>
        /// Reserviert die angegebene Kinokarte.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="nr"></param>
        /// <remarks></remarks>
        public void ReserviereKinokarte(char row, int nr)
        {
            GetKinokarte(row, nr).Reservieren();
            NotifyObservers();
        }

        /// <summary>
        /// Verkauft die angegebene Kinokarte.
        /// </summary>
        /// <param name="kinokarte"></param>
        /// <remarks></remarks>
        public void VerkaufeKinokarte(Kinokarte kinokarte)
        {
            kinokarte.Verkauft = true;
            NotifyObservers();
        }

        /// <summary>
        /// Verkauft die angegebene Kinokarte.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="nr"></param>
        /// <remarks></remarks>
        public void VerkaufeKinokarte(char row, int nr)
        {
            GetKinokarte(row, nr).Verkauft = true;
            NotifyObservers();
        }

        /// <summary>
        /// Macht den Verkauf und oder die Reservierung einer Kinokarte r�ckg�ngig.
        /// </summary>
        /// <param name="kinokarte">The Kinokarte to get.</param>
        /// <remarks></remarks>
        public void KinokarteZur�cksetzen(Kinokarte kinokarte)
        {
            if (!_kinokarten.Contains(kinokarte))
            {
                throw new ArgumentException("Die Kinokarte " + kinokarte.ToString() + " geh�rt nicht zu dieser Vorstellung!");
            }
            kinokarte.Verkauft = false;
            kinokarte.ReservierungAufheben();
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
