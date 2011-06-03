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

        #region Implementation of IKinokartenAdministration

        public void FillWithTestData()

        {
            _vorstellungen = new EntityManager<Vorstellung>();
            _filmprogramme = new EntityManager<Filmprogramm>();
            _vorstellungen.RemoveAllElements();
            _filmprogramme.RemoveAllElements();

            IKinoInformationen kinoinfo = new KinoInformationen();

            var vorstellung1 = new Vorstellung(new DateTime(2011, 05, 26, 12, 00, 00, 00), kinoinfo.GetFilme()[0],
                                               kinoinfo.GetKinosäle()[0], false, 6.0f);
            var vorstellung2 = new Vorstellung(new DateTime(2011, 05, 26, 13, 00, 00, 00), kinoinfo.GetFilme()[1],
                                               kinoinfo.GetKinosäle()[1], false, 6.0f);
            var vorstellung3 = new Vorstellung(new DateTime(2011, 05, 26, 14, 00, 00, 00), kinoinfo.GetFilme()[2],
                                               kinoinfo.GetKinosäle()[2], false, 6.0f);
            var vorstellung4 = new Vorstellung(new DateTime(2011, 05, 26, 18, 00, 00, 00), kinoinfo.GetFilme()[3],
                                               kinoinfo.GetKinosäle()[0], false, 6.0f);
            var vorstellung5 = new Vorstellung(new DateTime(2011, 05, 26, 18, 00, 00, 00), kinoinfo.GetFilme()[4],
                                               kinoinfo.GetKinosäle()[1], false, 6.0f);
            var vorstellung6 = new Vorstellung(new DateTime(2011, 05, 27, 12, 00, 00, 00), kinoinfo.GetFilme()[0],
                                               kinoinfo.GetKinosäle()[0], false, 6.0f);
            var vorstellung7 = new Vorstellung(new DateTime(2011, 05, 27, 13, 00, 00, 00), kinoinfo.GetFilme()[1],
                                               kinoinfo.GetKinosäle()[1], false, 6.0f);
            var vorstellung8 = new Vorstellung(new DateTime(2011, 05, 27, 14, 00, 00, 00), kinoinfo.GetFilme()[2],
                                               kinoinfo.GetKinosäle()[2], false, 6.0f);
            var vorstellung9 = new Vorstellung(new DateTime(2011, 05, 27, 18, 00, 00, 00), kinoinfo.GetFilme()[3],
                                               kinoinfo.GetKinosäle()[0], false, 6.0f);
            var vorstellung10 = new Vorstellung(new DateTime(2011, 05, 27, 18, 00, 00, 00), kinoinfo.GetFilme()[4],
                                                kinoinfo.GetKinosäle()[1], false, 6.0f);
            var vorstellung11 = new Vorstellung(new DateTime(2011, 05, 28, 12, 00, 00, 00), kinoinfo.GetFilme()[0],
                                                kinoinfo.GetKinosäle()[0], false, 6.0f);
            var vorstellung12 = new Vorstellung(new DateTime(2011, 05, 28, 13, 00, 00, 00), kinoinfo.GetFilme()[1],
                                                kinoinfo.GetKinosäle()[1], false, 6.0f);
            var vorstellung13 = new Vorstellung(new DateTime(2011, 05, 28, 14, 00, 00, 00), kinoinfo.GetFilme()[2],
                                                kinoinfo.GetKinosäle()[2], false, 6.0f);
            var vorstellung14 = new Vorstellung(new DateTime(2011, 05, 28, 18, 00, 00, 00), kinoinfo.GetFilme()[3],
                                                kinoinfo.GetKinosäle()[0], false, 6.0f);
            var vorstellung15 = new Vorstellung(new DateTime(2011, 05, 28, 18, 00, 00, 00), kinoinfo.GetFilme()[4],
                                                kinoinfo.GetKinosäle()[1], false, 6.0f);
            var vorstellungen = new List<Vorstellung>();
            vorstellungen.Add(vorstellung1);
            vorstellungen.Add(vorstellung2);
            vorstellungen.Add(vorstellung3);
            vorstellungen.Add(vorstellung4);
            vorstellungen.Add(vorstellung5);
            vorstellungen.Add(vorstellung6);
            vorstellungen.Add(vorstellung7);
            vorstellungen.Add(vorstellung8);
            vorstellungen.Add(vorstellung9);
            vorstellungen.Add(vorstellung10);
            vorstellungen.Add(vorstellung11);
            vorstellungen.Add(vorstellung12);
            vorstellungen.Add(vorstellung13);
            vorstellungen.Add(vorstellung14);
            vorstellungen.Add(vorstellung15);
            var filmprogramm = new Filmprogramm(DateTime.Now, vorstellungen);

            _vorstellungen.AddElement(vorstellung1);
            _vorstellungen.AddElement(vorstellung2);
            _vorstellungen.AddElement(vorstellung3);
            _vorstellungen.AddElement(vorstellung4);
            _vorstellungen.AddElement(vorstellung5);
            _vorstellungen.AddElement(vorstellung6);
            _vorstellungen.AddElement(vorstellung7);
            _vorstellungen.AddElement(vorstellung8);
            _vorstellungen.AddElement(vorstellung9);
            _vorstellungen.AddElement(vorstellung10);
            _vorstellungen.AddElement(vorstellung11);
            _vorstellungen.AddElement(vorstellung12);
            _vorstellungen.AddElement(vorstellung13);
            _vorstellungen.AddElement(vorstellung14);
            _vorstellungen.AddElement(vorstellung15);
            _filmprogramme.AddElement(filmprogramm);
        }

        public bool IsTicketBlocked(IPublicVorstellung vorstellung, ISitz sitz)
        {
            throw new NotImplementedException();
        }

        public bool IsTicketReserved(IPublicVorstellung vorstellung, ISitz sitz)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}