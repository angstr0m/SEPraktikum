using System;
using System.Collections.Generic;
using Base.Interfaces;
using Cinema.Models;
using Database.Interfaces;

namespace Cinema.Schnittstelle
{
    public interface IKinosaal : IDatabaseObject
    {
        /// <summary>
        /// Gibt die Anzahl der Sitze im Kino zurück.
        /// </summary>
        /// <remarks></remarks>
        int SitzAnzahl { get; }

        /// <summary>
        /// Gibt den Namen des Kinosaals zurück.
        /// </summary>
        /// <value>Der Name des Kinosaals.</value>
        /// <remarks></remarks>
        String Name { get; }

        /// <summary>
        /// Gibt eine Liste von Sitzplätzen zurück.
        /// Diese Liste enthält die Sitzplätze in diesem Kinosaal.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        List<ISitz> GetSitzplätze();
    }
}