using System;
using System.Collections.Generic;
using Base.AbstractClasses;
using Database.Interfaces;

namespace TicketOperations.Models {
    /// <summary>
    /// Dient der Sammlung aller Vorstellungen f�r eine Woche.
    /// </summary>
    /// <remarks></remarks>
	internal class Filmprogramm : Subject, IDatabaseObject
    {
        private int id;
        /// <summary>
        /// Datum ab welchem das Filmprogramm f�r eine Woche g�ltig ist.
        /// </summary>
        private DateTime _startDatum;
        /// <summary>
        /// Die Vorstellungen dieses Filmprogramms.
        /// </summary>
        private List<Vorstellung> _vorstellungen;
        /// <summary>
        /// Zeigt an, ob das Filmprogramm bereits ver�ffentlicht wurde.
        /// </summary>
        private bool _ver�ffentlicht;

        public Filmprogramm(DateTime startTime, List<Vorstellung> vorstellungen)
        {
            _startDatum = startTime;
            this._vorstellungen = vorstellungen;
            _ver�ffentlicht = false;
        }

        public bool Ver�ffentlicht
        {
            get { return _ver�ffentlicht; }
        }

        /// <summary>
        /// Ver�ffentlicht das Filmprogramm.
        /// </summary>
        /// <remarks>Sobald das Filmprogramm �ffentlich ist, kann es von Kunden eingesehen werden.</remarks>
        public void Ver�ffentlichen() 
        {
            _ver�ffentlicht = true;
        }

        /// <summary>
        /// Gibt die Vorstellungen dieses Filmprogramms zur�ck.
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        public List<Vorstellung> Vorstellungen
        {
            get { return _vorstellungen; }
        }

        public DateTime StartDatum
        {
            get { return _startDatum; }
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
