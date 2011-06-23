using System;
using System.Collections.Generic;
using Kino.Schnittstelle;

namespace Kinokarten.Schnittstelle.Interfaces
{
    public interface IKinokartenInformationen
    {
        List<PublicKinokarte> GetVerfügbareKinokartenFürVorstellung(PublicVorstellung vorstellung);
        bool PrüfeAltersfreigabeFürVorstellung(PublicVorstellung vorstellung, DateTime geburtsdatum);
        bool PrüfeVerfügbarkeitVonSitzplatzFürVorstellung(PublicVorstellung vorstellung, ISitz sitz);
        float GetPreisFürKinokarte(PublicVorstellung vorstellung, ISitz sitz, bool rabatt);

        /// <summary>
        /// Liefert das derzeit aktuelle Filmprogramm.
        /// </summary>
        /// <returns> Das Filmprogramm für diese Woche. </returns>
        /// <remarks></remarks>
        PublicFilmprogramm GetWöchentlichesFilmprogramm();
    }
}