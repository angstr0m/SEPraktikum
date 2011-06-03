using Kinokarten.Schnittstelle.Interfaces;
using Users.Interfaces;

namespace TicketOperations.PublicInterfaceMembers.Interfaces.Anwendungsfall_spezifische_Interfaces
{
    public interface IARegistrierterKundeReserviertKinokarteOnlineInformationen
    {
        // List<IPublicKinokarte> GetVerfügbareKinokartenFürVorstellung(IPublicVorstellung vorstellung);

        bool PrüfeAltersfreigabeFürVorstellung(IPublicVorstellung vorstellung, IKunde kunde);

        // bool PrüfeVerfügbarkeitVonSitzplatzFürVorstellung(IPublicVorstellung vorstellung, ISitz sitz);

        //float GetPreisFürKinokarte(IPublicVorstellung vorstellung, ISitz sitz, bool rabatt);
    }
}