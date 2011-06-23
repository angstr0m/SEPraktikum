using System;
using System.Collections.Generic;
using Database.Models;
using Kino.Schnittstelle;
using Kinokarten.Models;
using Kinokarten.Schnittstelle.Interfaces;
using Users.Interfaces;

namespace Kinokarten.Schnittstelle
{
    public class KinokartenInformationen : IKinokartenInformationen
    {
        private readonly EntityManager<Filmprogramm> _filmprogramme;
        private readonly EntityManager<Vorstellung> _vorstellungen;

        public KinokartenInformationen()
        {
            _vorstellungen = new EntityManager<Vorstellung>();
            _filmprogramme = new EntityManager<Filmprogramm>();
        }

        #region Implementation of IABesucherReserviertKinokarteOnlineInformationen

        public List<PublicKinokarte> GetVerfügbareKinokartenFürVorstellung(PublicVorstellung vorstellung)
        {
            Vorstellung wantedVorstellung = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier());

            var publicKinokarten = new List<PublicKinokarte>();

            foreach (Kinokarte kinokarte in wantedVorstellung.GetVerfügbareKinokarten())
            {
                publicKinokarten.Add(new PublicKinokarte(kinokarte));
            }

            return publicKinokarten;
        }


        public bool PrüfeAltersfreigabeFürVorstellung(PublicVorstellung vorstellung, DateTime geburtsdatum)
        {
            Vorstellung wantedVorstellung = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier());
            TimeSpan temp = DateTime.Now.Date.Subtract(geburtsdatum.Date);
            TimeSpan temp2 = DateTime.Now - (DateTime.Now.Date.AddYears(-vorstellung.Altersfreigabe));
            return (temp.TotalDays >= temp2.TotalDays);
        }

        public bool PrüfeVerfügbarkeitVonSitzplatzFürVorstellung(PublicVorstellung vorstellung, ISitz sitz)
        {
            Vorstellung wantedVorstellung = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier());
            Kinokarte kinokarte = wantedVorstellung.GetKinokarte(sitz);

            if (kinokarte.Reserviert || kinokarte.Verkauft || kinokarte.Blockiert)
            {
                return false;
            }

            return true;
        }


        public bool PrüfeAltersfreigabeFürVorstellung(PublicVorstellung vorstellung, IKunde kunde)
        {
            Vorstellung wantedVorstellung = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier());

            return (DateTime.Now - kunde.Geburtsdatum).TotalDays >= (DateTime.Now - DateTime.Now.AddYears(-wantedVorstellung.Altersfreigabe)).TotalDays;
        }


        public float GetPreisFürKinokarte(PublicVorstellung vorstellung, ISitz sitz, bool rabatt)
        {
            Vorstellung wantedVorstellung = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier());
            Kinokarte kinokarte = wantedVorstellung.GetKinokarte(sitz);

            kinokarte.Rabatt = rabatt;
            return kinokarte.Preis;
        }

        /// <summary>
        /// Liefert das derzeit aktuelle Filmprogramm.
        /// </summary>
        /// <returns> Das Filmprogramm für diese Woche. </returns>
        /// <remarks></remarks>
        public PublicFilmprogramm GetWöchentlichesFilmprogramm()
        {
            return new PublicFilmprogramm(_filmprogramme.GetElements().Find(delegate(Filmprogramm m)
                                                                                {
                                                                                    return (m.StartDatum.Date <=
                                                                                            DateTime.Today &&
                                                                                            m.StartDatum.AddDays(7).Date >=
                                                                                            DateTime.Today);
                                                                                }));
        }

        #endregion
    }
}