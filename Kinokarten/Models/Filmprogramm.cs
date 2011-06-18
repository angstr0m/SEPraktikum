using System;
using System.Collections.Generic;
using Base.AbstractClasses;
using Database.Interfaces;
using Database.Models;

namespace Kinokarten.Models
{
    /// <summary>
    /// Dient der Sammlung aller Vorstellungen für eine Woche.
    /// </summary>
    /// <remarks></remarks>
    internal class Filmprogramm : Subject, IDatabaseObject
    {
        /// <summary>
        /// Datum ab welchem das Filmprogramm für eine Woche gültig ist.
        /// </summary>
        private readonly DateTime _startDatum;

        /// <summary>
        /// Die Vorstellungen dieses Filmprogramms.
        /// </summary>
        private readonly List<Vorstellung> _vorstellungen;

        /// <summary>
        /// Zeigt an, ob das Filmprogramm bereits veröffentlicht wurde.
        /// </summary>
        private bool _veröffentlicht;

        private int id;

        public Filmprogramm(DateTime startTime, List<Vorstellung> vorstellungen)
        {
            _startDatum = startTime;
            _vorstellungen = vorstellungen;
            _veröffentlicht = false;

            EntityManager<Filmprogramm> filmprogramme = new EntityManager<Filmprogramm>();
            filmprogramme.AddElement(this);
        }

        public bool Veröffentlicht
        {
            get { return _veröffentlicht; }
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

        /// <summary>
        /// Veröffentlicht das Filmprogramm.
        /// </summary>
        /// <remarks>Sobald das Filmprogramm öffentlich ist, kann es von Kunden eingesehen werden.</remarks>
        public void Veröffentlichen()
        {
            _veröffentlicht = true;
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