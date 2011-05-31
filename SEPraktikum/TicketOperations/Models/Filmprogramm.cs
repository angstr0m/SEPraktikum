using System;
using System.Collections.Generic;
using Base.AbstractClasses;
using Database.Interfaces;

namespace TicketOperations.Models {
    /// <summary>
    /// Dient der Sammlung aller Vorstellungen für eine Woche.
    /// </summary>
    /// <remarks></remarks>
	internal class Filmprogramm : Subject, IDatabaseObject
    {
        private int id;
        /// <summary>
        /// Datum ab welchem das Filmprogramm für eine Woche gültig ist.
        /// </summary>
        private DateTime _startDatum;
        /// <summary>
        /// Die Vorstellungen dieses Filmprogramms.
        /// </summary>
        private List<Vorstellung> _vorstellungen;
        /// <summary>
        /// Zeigt an, ob das Filmprogramm bereits veröffentlicht wurde.
        /// </summary>
        private bool _veröffentlicht;

        public Filmprogramm(DateTime startTime, List<Vorstellung> vorstellungen)
        {
            _startDatum = startTime;
            this._vorstellungen = vorstellungen;
            _veröffentlicht = false;
        }

        public bool Veröffentlicht
        {
            get { return _veröffentlicht; }
        }

        /// <summary>
        /// Veröffentlicht das Filmprogramm.
        /// </summary>
        /// <remarks>Sobald das Filmprogramm öffentlich ist, kann es von Kunden eingesehen werden.</remarks>
        public void Veröffentlichen() 
        {
            _veröffentlicht = true;
        }

        /// <summary>
        /// Gibt die Vorstellungen dieses Filmprogramms zurück.
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
