using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.InterfaceMembers;

namespace TicketOperations.PublicInterfaceMembers
{
    class KinokartenInformationen : IKinokartenInformationen
    {
        #region Implementation of IABesucherReserviertKinokarteOnlineInformationen

        public List<IPublicKinokarte> GetVerfügbareKinokartenFürVorstellung(IPublicVorstellung vorstellung)
        {
            throw new NotImplementedException();
        }

        public bool PrüfeAltersfreigabeFürVorstellung(IPublicVorstellung vorstellung, DateTime geburtsdatum)
        {
            throw new NotImplementedException();
        }

        public bool PrüfeVerfügbarkeitVonSitzplatzFürVorstellung(IPublicVorstellung vorstellung, ISitz sitz)
        {
            throw new NotImplementedException();
        }

        public float GetPreisFürKinokarte(IPublicVorstellung gewählte_vorstellung, ISitz sitz, bool rabatt)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
