using System;
using System.Collections.Generic;
using Database.Models;
using Kino.Schnittstelle;
using Kinokarten.Models;
using Kinokarten.Schnittstelle.Interfaces;

namespace Kinokarten.Schnittstelle
{
    public class KinokartenAdministration : IKinokartenAdministration
    {
        private EntityManager<Filmprogramm> _filmprogramme;
        private EntityManager<Vorstellung> _vorstellungen;
        private EntityManager<IFilm> _filme;

        #region Implementation of IKinokartenAdministration

        public void TestdatenEinrichten(float kinokartenpreis)
        {
            
        }

        public bool IsTicketBlocked(IPublicVorstellung vorstellung, ISitz sitz)
        {
            return _vorstellungen.GetElementWithId(vorstellung.GetIdentifier()).GetKinokarte(sitz).Blockiert;
        }

        public bool IsTicketReserved(IPublicVorstellung vorstellung, ISitz sitz)
        {
            return _vorstellungen.GetElementWithId(vorstellung.GetIdentifier()).GetKinokarte(sitz).Reserviert;
        }

        #endregion
    }
}