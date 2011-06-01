using System;
using Base.Interfaces;
using Database.Interfaces;

namespace Cinema.Schnittstelle
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

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        /// <remarks></remarks>
        string ToString();
    }
}