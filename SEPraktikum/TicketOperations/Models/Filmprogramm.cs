using System;
using System.Collections.Generic;
using Base.AbstractClasses;
using Database.Interfaces;

namespace TicketOperations.Models {
    /// <summary>
    /// Dient der Sammlung aller Vorstellungen für eine Woche.
    /// </summary>
    /// <remarks></remarks>
	public class Filmprogramm : Subject, IDatabaseObject
    {
        private int id;
        /// <summary>
        /// Datum ab welchem das Filmprogramm für eine Woche gültig ist.
        /// </summary>
        private DateTime startDateTime;
        /// <summary>
        /// Die Vorstellungen dieses Filmprogramms.
        /// </summary>
        private List<Vorstellung> _vorstellungen;
        /// <summary>
        /// Zeigt an, ob das Filmprogramm bereits veröffentlicht wurde.
        /// </summary>
        private bool published;

        /// <summary>
        /// Initializes a new instance of the <see cref="Filmprogramm"/> class.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="vorstellungen">The vorstellungen.</param>
        /// <remarks></remarks>
        public Filmprogramm(DateTime startTime, List<Vorstellung> vorstellungen)
        {
            startDateTime = startTime;
            this._vorstellungen = vorstellungen;
            published = false;
        }

        /// <summary>
        /// Veröffentlicht das Filmprogramm.
        /// </summary>
        /// <remarks>Sobald das Filmprogramm öffentlich ist, kann es von Kunden eingesehen werden.</remarks>
        public void Veröffentlichen() 
        {
            published = true;
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

        public DateTime StartDateTime
        {
            get { return startDateTime; }
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
