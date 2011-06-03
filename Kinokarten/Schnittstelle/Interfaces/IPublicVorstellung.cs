using System;
using System.Collections.Generic;
using Kino.Schnittstelle;

namespace Kinokarten.Schnittstelle.Interfaces
{
    public interface IPublicVorstellung
    {
        /// <summary>
        /// Gibt die Startzeit der Vorstellung zur�ck.
        /// </summary>
        /// <value>Die Startzeit der Vorstellung.</value>
        /// <remarks></remarks>
        DateTime StartZeit { get; }

        /// <summary>
        /// Gibt die Spieldauer der Vorstellung zur�ck.
        /// </summary>
        /// <value>Die Spieldauer des Films dieser Vorstellung.</value>
        /// <remarks></remarks>
        int Spieldauer { get; }

        /// <summary>
        /// Gibt die Altersfreigabe des Films dieser Vorstellung zur�ck.
        /// </summary>
        /// <remarks></remarks>
        int Altersfreigabe { get; }

        /// <summary>
        /// Gibt den Namen des Films zur�ck, welcher in dieser Vorstellung gezeigt wird.
        /// </summary>
        /// <remarks></remarks>
        String Name { get; }

        int GetIdentifier();

        /// <summary>
        /// Gibt die Anzahl der noch verf�gbaren Kinokarten zur�ck.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        int GetAnzahlFreierKinokarten();

        /// <summary>
        /// Gibt die Anzahl der nicht verf�gbaren Kinokarten zur�ck.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        int GetAnzahlNichtVerf�gbarerKinokarten();

        /// <summary>
        /// Gibt eine Liste der Kinokarten dieser Vorstellung zur�ck, die weder gekauft noch reserviert wurden.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        List<IPublicKinokarte> Verf�gbareKinokarten();

        /// <summary>
        /// Gibt eine Liste der Kinokarten dieser Vorstellung zur�ck, welche reserviert wurden.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        List<IPublicKinokarte> ReservierteKinokarten();

        /// <summary>
        /// Gibt eine Liste der Kinokarten dieser Vorstellung zur�ck, welche verkauft wurden.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        List<IPublicKinokarte> VerkaufteKinokarten();

        /// <summary>
        /// Gibt eine Kinokarte an einem bestimmten Index zur�ck.
        /// </summary>
        /// <param name="index">Der Index der gew�nschten Kinokarte.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IPublicKinokarte GetKinokarte(int index);

        /// <summary>
        /// Gibt eine Kinokarte f�r einen bestimmten Sitz zur�ck.
        /// </summary>
        /// <param name="sitzIdentifikator"> Der Identifikator des gew�nschten Sitzplatzes.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IPublicKinokarte GetKinokarte(ISitzIdentifikator sitzIdentifikator);
    }
}