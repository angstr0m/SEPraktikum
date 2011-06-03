using System;
using System.Collections.Generic;
using Kino.Schnittstelle;

namespace Kinokarten.Schnittstelle.Interfaces
{
    public interface IPublicVorstellung
    {
        /// <summary>
        /// Gibt die Startzeit der Vorstellung zurück.
        /// </summary>
        /// <value>Die Startzeit der Vorstellung.</value>
        /// <remarks></remarks>
        DateTime StartZeit { get; }

        /// <summary>
        /// Gibt die Spieldauer der Vorstellung zurück.
        /// </summary>
        /// <value>Die Spieldauer des Films dieser Vorstellung.</value>
        /// <remarks></remarks>
        int Spieldauer { get; }

        /// <summary>
        /// Gibt die Altersfreigabe des Films dieser Vorstellung zurück.
        /// </summary>
        /// <remarks></remarks>
        int Altersfreigabe { get; }

        /// <summary>
        /// Gibt den Namen des Films zurück, welcher in dieser Vorstellung gezeigt wird.
        /// </summary>
        /// <remarks></remarks>
        String Name { get; }

        int GetIdentifier();

        /// <summary>
        /// Gibt die Anzahl der noch verfügbaren Kinokarten zurück.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        int GetAnzahlFreierKinokarten();

        /// <summary>
        /// Gibt die Anzahl der nicht verfügbaren Kinokarten zurück.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        int GetAnzahlNichtVerfügbarerKinokarten();

        /// <summary>
        /// Gibt eine Liste der Kinokarten dieser Vorstellung zurück, die weder gekauft noch reserviert wurden.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        List<IPublicKinokarte> VerfügbareKinokarten();

        /// <summary>
        /// Gibt eine Liste der Kinokarten dieser Vorstellung zurück, welche reserviert wurden.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        List<IPublicKinokarte> ReservierteKinokarten();

        /// <summary>
        /// Gibt eine Liste der Kinokarten dieser Vorstellung zurück, welche verkauft wurden.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        List<IPublicKinokarte> VerkaufteKinokarten();

        /// <summary>
        /// Gibt eine Kinokarte an einem bestimmten Index zurück.
        /// </summary>
        /// <param name="index">Der Index der gewünschten Kinokarte.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IPublicKinokarte GetKinokarte(int index);

        /// <summary>
        /// Gibt eine Kinokarte für einen bestimmten Sitz zurück.
        /// </summary>
        /// <param name="sitzIdentifikator"> Der Identifikator des gewünschten Sitzplatzes.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IPublicKinokarte GetKinokarte(ISitzIdentifikator sitzIdentifikator);
    }
}