using System;
using Database.Interfaces;
using Kino.Models;

namespace Kino.Schnittstelle
{
    public interface ISitz : IDatabaseObject
    {
        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        Char Reihe();

        /// <summary>
        /// Gets the nr.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        int Nummer();

        ISitzIdentifikator Identifikator { get; }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        /// <remarks></remarks>
        string ToString();
    }
}