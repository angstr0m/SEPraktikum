using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.InterfaceMembers;
using Cinema.Models;
using TicketOperations.PublicInterfaceMembers.Interfaces;
using TicketOperations.Models;

namespace TicketOperations.PublicInterfaceMembers
{
    public class KinokartenAdministration : IKinokartenAdministration
    {
        #region Implementation of IKinokartenAdministration

        public void FillWithTestData()
        {
            IKinoInformationen kinoinfo = new KinoInformationen();
          
            IPublicVorstellung vorstellung1 = new PublicVorstellung(new Vorstellung(new DateTime(2011,05,26,12,00,00,00), (Film)kinoinfo.GetFilme()[0], (Kinosaal)kinoinfo.GetKinosäle()[0], false, 6.0f));
            IPublicVorstellung vorstellung2 = new PublicVorstellung(new Vorstellung(new DateTime(2011,05,26,13,00,00,00), (Film)kinoinfo.GetFilme()[1], (Kinosaal)kinoinfo.GetKinosäle()[1], false, 6.0f));
            IPublicVorstellung vorstellung3 = new PublicVorstellung(new Vorstellung(new DateTime(2011,05,26,14,00,00,00), (Film)kinoinfo.GetFilme()[2], (Kinosaal)kinoinfo.GetKinosäle()[2], false, 6.0f));
            IPublicVorstellung vorstellung4 = new PublicVorstellung(new Vorstellung(new DateTime(2011,05,26,18,00,00,00), (Film)kinoinfo.GetFilme()[3], (Kinosaal)kinoinfo.GetKinosäle()[0], false, 6.0f));
            IPublicVorstellung vorstellung5 = new PublicVorstellung(new Vorstellung(new DateTime(2011,05,26,18,00,00,00), (Film)kinoinfo.GetFilme()[4], (Kinosaal)kinoinfo.GetKinosäle()[1], false, 6.0f));
            IPublicVorstellung vorstellung6 = new PublicVorstellung(new Vorstellung(new DateTime(2011,05,27,12,00,00,00), (Film)kinoinfo.GetFilme()[0], (Kinosaal)kinoinfo.GetKinosäle()[0], false, 6.0f));
            IPublicVorstellung vorstellung7 = new PublicVorstellung(new Vorstellung(new DateTime(2011,05,27,13,00,00,00), (Film)kinoinfo.GetFilme()[1], (Kinosaal)kinoinfo.GetKinosäle()[1], false, 6.0f));
            IPublicVorstellung vorstellung8 = new PublicVorstellung(new Vorstellung(new DateTime(2011,05,27,14,00,00,00), (Film)kinoinfo.GetFilme()[2], (Kinosaal)kinoinfo.GetKinosäle()[2], false, 6.0f));
            IPublicVorstellung vorstellung9 = new PublicVorstellung(new Vorstellung(new DateTime(2011,05,27,18,00,00,00), (Film)kinoinfo.GetFilme()[3], (Kinosaal)kinoinfo.GetKinosäle()[0], false, 6.0f));
            IPublicVorstellung vorstellung10 = new PublicVorstellung(new Vorstellung(new DateTime(2011,05,27,18,00,00,00), (Film)kinoinfo.GetFilme()[4], (Kinosaal)kinoinfo.GetKinosäle()[1], false, 6.0f));
            IPublicVorstellung vorstellung11 = new PublicVorstellung(new Vorstellung(new DateTime(2011,05,28,12,00,00,00), (Film)kinoinfo.GetFilme()[0], (Kinosaal)kinoinfo.GetKinosäle()[0], false, 6.0f));
            IPublicVorstellung vorstellung12 = new PublicVorstellung(new Vorstellung(new DateTime(2011,05,28,13,00,00,00), (Film)kinoinfo.GetFilme()[1], (Kinosaal)kinoinfo.GetKinosäle()[1], false, 6.0f));
            IPublicVorstellung vorstellung13 = new PublicVorstellung(new Vorstellung(new DateTime(2011,05,28,14,00,00,00), (Film)kinoinfo.GetFilme()[2], (Kinosaal)kinoinfo.GetKinosäle()[2], false, 6.0f));
            IPublicVorstellung vorstellung14 = new PublicVorstellung(new Vorstellung(new DateTime(2011,05,28,18,00,00,00), (Film)kinoinfo.GetFilme()[3], (Kinosaal)kinoinfo.GetKinosäle()[0], false, 6.0f));
            IPublicVorstellung vorstellung15 = new PublicVorstellung(new Vorstellung(new DateTime(2011, 05, 28, 18, 00, 00, 00), (Film)kinoinfo.GetFilme()[4], (Kinosaal)kinoinfo.GetKinosäle()[1], false, 6.0f));
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
            IPublicFilmprogramm filmprogramm = new PublicFilmprogramm(new Filmprogramm(new DateTime(2011,05,23,00,00,00,01),vorstellungen));
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
