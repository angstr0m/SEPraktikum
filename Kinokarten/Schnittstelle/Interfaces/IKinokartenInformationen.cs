using System;
using System.Collections.Generic;
using Kino.Schnittstelle;

namespace Kinokarten.Schnittstelle.Interfaces
{
    public interface IKinokartenInformationen
    {
        List<PublicKinokarte> GetVerf�gbareKinokartenF�rVorstellung(PublicVorstellung vorstellung);
        bool Pr�feAltersfreigabeF�rVorstellung(PublicVorstellung vorstellung, DateTime geburtsdatum);
        bool Pr�feVerf�gbarkeitVonSitzplatzF�rVorstellung(PublicVorstellung vorstellung, ISitz sitz);
        float GetPreisF�rKinokarte(PublicVorstellung vorstellung, ISitz sitz, bool rabatt);

        /// <summary>
        /// Liefert das derzeit aktuelle Filmprogramm.
        /// </summary>
        /// <returns> Das Filmprogramm f�r diese Woche. </returns>
        /// <remarks></remarks>
        PublicFilmprogramm GetW�chentlichesFilmprogramm();
    }
}