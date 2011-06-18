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

        public List<IPublicKinokarte> GetVerfügbareKinokartenFürVorstellung(IPublicVorstellung vorstellung)
        {
            Vorstellung wantedVorstellung = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier());

            var publicKinokarten = new List<IPublicKinokarte>();

            foreach (Kinokarte kinokarte in wantedVorstellung.GetVerfügbareKinokarten())
            {
                publicKinokarten.Add(new PublicKinokarte(kinokarte));
            }

            return publicKinokarten;
        }


        public bool PrüfeAltersfreigabeFürVorstellung(IPublicVorstellung vorstellung, DateTime geburtsdatum)
        {
            Vorstellung wantedVorstellung = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier());
            TimeSpan temp = DateTime.Now.Date.Subtract(geburtsdatum.Date);
            TimeSpan temp2 = DateTime.Now - (DateTime.Now.Date.AddYears(-vorstellung.Altersfreigabe));
            return (temp.TotalDays >= temp2.TotalDays);
        }

        public bool PrüfeVerfügbarkeitVonSitzplatzFürVorstellung(IPublicVorstellung vorstellung, ISitz sitz)
        {
            Vorstellung wantedVorstellung = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier());
            Kinokarte kinokarte = wantedVorstellung.GetKinokarte(sitz);

            if (kinokarte.Reserviert || kinokarte.Verkauft || kinokarte.Reserviert)
            {
                return false;
            }

            return true;
        }


        public bool PrüfeAltersfreigabeFürVorstellung(IPublicVorstellung vorstellung, IKunde kunde)
        {
            Vorstellung wantedVorstellung = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier());

            return (DateTime.Now - kunde.Geburtsdatum).CompareTo(wantedVorstellung.Altersfreigabe) <= 0;
        }


        public float GetPreisFürKinokarte(IPublicVorstellung vorstellung, ISitz sitz, bool rabatt)
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
        public IPublicFilmprogramm GetWöchentlichesFilmprogramm()
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