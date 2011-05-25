using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.InterfaceMembers;
using Database.Models;
using TicketOperations.Models;

namespace TicketOperations.PublicInterfaceMembers
{
    class KinokartenInformationen : IKinokartenInformationen
    {
        private EntityManager<Vorstellung> _vorstellungen;

        KinokartenInformationen()
        {
            _vorstellungen = new EntityManager<Vorstellung>();
        }

        #region Implementation of IABesucherReserviertKinokarteOnlineInformationen

        public List<IPublicKinokarte> GetVerfügbareKinokartenFürVorstellung(IPublicVorstellung vorstellung)
        {
            Vorstellung wantedVorstellung = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier());

            List<IPublicKinokarte> publicKinokarten = new List<IPublicKinokarte>();

            foreach (Kinokarte kinokarte in wantedVorstellung.GetVerfügbareKinokarten())
            {
                publicKinokarten.Add(new PublicKinokarte(kinokarte));
            }

            return publicKinokarten;
        }

        public bool PrüfeAltersfreigabeFürVorstellung(IPublicVorstellung vorstellung, DateTime geburtsdatum)
        {
            Vorstellung wantedVorstellung = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier());

            return (DateTime.Now - geburtsdatum).CompareTo(wantedVorstellung.Altersfreigabe) <= 0;
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

        public float GetPreisFürKinokarte(IPublicVorstellung vorstellung, ISitz sitz, bool rabatt)
        {
            Vorstellung wantedVorstellung = _vorstellungen.GetElementWithId(vorstellung.GetIdentifier());
            Kinokarte kinokarte = wantedVorstellung.GetKinokarte(sitz);

            kinokarte.Rabatt = rabatt;
            return kinokarte.Preis;
        }

        #endregion
    }
}
