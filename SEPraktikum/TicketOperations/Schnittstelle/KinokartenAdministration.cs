using System;
using System.Collections.Generic;
using Cinema.Models;
using Cinema.Schnittstelle;
using Kinokarten.Models;
using Kinokarten.Schnittstelle.Interfaces;
using Database.Models;

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

            Vorstellung vorstellung1 = new Vorstellung(new DateTime(2011, 05, 26, 12, 00, 00, 00), (IFilm)kinoinfo.GetFilme()[0], (IKinosaal)kinoinfo.GetKinosäle()[0], false, 6.0f);
            Vorstellung vorstellung2 = new Vorstellung(new DateTime(2011, 05, 26, 13, 00, 00, 00), (IFilm)kinoinfo.GetFilme()[1], (IKinosaal)kinoinfo.GetKinosäle()[1], false, 6.0f);
            Vorstellung vorstellung3 = new Vorstellung(new DateTime(2011, 05, 26, 14, 00, 00, 00), (IFilm)kinoinfo.GetFilme()[2], (IKinosaal)kinoinfo.GetKinosäle()[2], false, 6.0f);
            Vorstellung vorstellung4 = new Vorstellung(new DateTime(2011, 05, 26, 18, 00, 00, 00), (IFilm)kinoinfo.GetFilme()[3], (IKinosaal)kinoinfo.GetKinosäle()[0], false, 6.0f);
            Vorstellung vorstellung5 = new Vorstellung(new DateTime(2011, 05, 26, 18, 00, 00, 00), (IFilm)kinoinfo.GetFilme()[4], (IKinosaal)kinoinfo.GetKinosäle()[1], false, 6.0f);
            Vorstellung vorstellung6 = new Vorstellung(new DateTime(2011, 05, 27, 12, 00, 00, 00), (IFilm)kinoinfo.GetFilme()[0], (IKinosaal)kinoinfo.GetKinosäle()[0], false, 6.0f);
            Vorstellung vorstellung7 = new Vorstellung(new DateTime(2011, 05, 27, 13, 00, 00, 00), (IFilm)kinoinfo.GetFilme()[1], (IKinosaal)kinoinfo.GetKinosäle()[1], false, 6.0f);
            Vorstellung vorstellung8 = new Vorstellung(new DateTime(2011, 05, 27, 14, 00, 00, 00), (IFilm)kinoinfo.GetFilme()[2], (IKinosaal)kinoinfo.GetKinosäle()[2], false, 6.0f);
            Vorstellung vorstellung9 = new Vorstellung(new DateTime(2011, 05, 27, 18, 00, 00, 00), (IFilm)kinoinfo.GetFilme()[3], (IKinosaal)kinoinfo.GetKinosäle()[0], false, 6.0f);
            Vorstellung vorstellung10 = new Vorstellung(new DateTime(2011, 05, 27, 18, 00, 00, 00), (IFilm)kinoinfo.GetFilme()[4], (IKinosaal)kinoinfo.GetKinosäle()[1], false, 6.0f);
            Vorstellung vorstellung11 = new Vorstellung(new DateTime(2011, 05, 28, 12, 00, 00, 00), (IFilm)kinoinfo.GetFilme()[0], (IKinosaal)kinoinfo.GetKinosäle()[0], false, 6.0f);
            Vorstellung vorstellung12 = new Vorstellung(new DateTime(2011, 05, 28, 13, 00, 00, 00), (IFilm)kinoinfo.GetFilme()[1], (IKinosaal)kinoinfo.GetKinosäle()[1], false, 6.0f);
            Vorstellung vorstellung13 = new Vorstellung(new DateTime(2011, 05, 28, 14, 00, 00, 00), (IFilm)kinoinfo.GetFilme()[2], (IKinosaal)kinoinfo.GetKinosäle()[2], false, 6.0f);
            Vorstellung vorstellung14 = new Vorstellung(new DateTime(2011, 05, 28, 18, 00, 00, 00), (IFilm)kinoinfo.GetFilme()[3], (IKinosaal)kinoinfo.GetKinosäle()[0], false, 6.0f);
            Vorstellung vorstellung15 = new Vorstellung(new DateTime(2011, 05, 28, 18, 00, 00, 00), (IFilm)kinoinfo.GetFilme()[4], (IKinosaal)kinoinfo.GetKinosäle()[1], false, 6.0f);
            List<Vorstellung> vorstellungen = new List<Vorstellung>();
            vorstellungen.Add((Vorstellung)vorstellung1);
            vorstellungen.Add((Vorstellung)vorstellung2);
            vorstellungen.Add((Vorstellung)vorstellung3);
            vorstellungen.Add((Vorstellung)vorstellung4);
            vorstellungen.Add((Vorstellung)vorstellung5);
            vorstellungen.Add((Vorstellung)vorstellung6);
            vorstellungen.Add((Vorstellung)vorstellung7);
            vorstellungen.Add((Vorstellung)vorstellung8);
            vorstellungen.Add((Vorstellung)vorstellung9);
            vorstellungen.Add((Vorstellung)vorstellung10);
            vorstellungen.Add((Vorstellung)vorstellung11);
            vorstellungen.Add((Vorstellung)vorstellung12);
            vorstellungen.Add((Vorstellung)vorstellung13);
            vorstellungen.Add((Vorstellung)vorstellung14);
            vorstellungen.Add((Vorstellung)vorstellung15);
            Filmprogramm filmprogramm = new Filmprogramm(DateTime.Now, vorstellungen);

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
