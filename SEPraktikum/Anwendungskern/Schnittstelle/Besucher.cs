using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.InterfaceMembers;
using Cinema.Models;
using TicketOperations.PublicInterfaceMembers;

namespace Anwendungskern.Schnittstelle
{
    class Besucher : IBesucher
    {
        private IKinokartenInformationen _kinokartenInformationen;
        private IKinokartenOperationen _kinokartenOperationen;

        Besucher (IKinokartenInformationen kinokartenInformationen, IKinokartenOperationen kinokartenOperationen)
        {
            _kinokartenInformationen = kinokartenInformationen;
            _kinokartenOperationen = kinokartenOperationen;
        }

        #region Implementation of IBesucher

        /// <summary>
        /// Gibt eine Liste der Sitzplätze für die gewählte Vorstellung zurück.
        /// </summary>
        /// @param  gewählte_Vorstellung - die Vorstellung, für die die Liste der Sitzplätze zurückgegeben werden soll.
        /// @return Gibt eine Liste der Sitzplätze der gewählten Vorstellung zurück.
        /// @throw
        /// @pre    
        /// @post
        /// @typ    Abfrage.
        /// @remarks    
        public List<ISitz> GetVerfügbareSitzplätzeFürVorstellung(IPublicVorstellung gewählte_Vorstellung)
        {
            List<IPublicKinokarte> kinokarten = _kinokartenInformationen.GetVerfügbareKinokartenFürVorstellung(gewählte_Vorstellung);

            List<ISitz> verfügbareSitzplätze = new List<ISitz>();

            foreach (IPublicKinokarte kinokarte in kinokarten)
            {
                verfügbareSitzplätze.Add(kinokarte.Sitz);
            }

            return verfügbareSitzplätze;
        }

        /// <summary>
        /// Überprüft ob ein Kunde alt genug ist, um den Film der angegebenen Vorstellung ansehen zu dürfen.
        /// Die Überprüfung wird anhand der Altersfreigabe des Films der Vorstellung durchgeführt. 
        /// </summary>
        /// @param  gewählte_Vorstellung - die Vorstellung, deren Altersfreigabe für die Überprüfung genutzt werden soll.
        /// @param  geburtsdatum - Das Geburtsdatum des Kunden.
        /// @return Gibt true zurück, falls der Kunde alt genug ist um den Film zu sehen, sonst false.
        /// @throw
        /// @pre    
        /// @post
        /// @typ    Abfrage.
        /// @remarks
        public bool PrüfeAltersfreigabe(IPublicVorstellung gewählte_vorstellung, DateTime geburtsdatum)
        {
            return _kinokartenInformationen.PrüfeAltersfreigabeFürVorstellung(gewählte_vorstellung, geburtsdatum);
        }

        /// <summary>
        /// Überprüft ob eine Kinokarte für den angegebenen Sitzplatz für die angegebene Vorstellung noch nicht reserviert und/oder verkauft wurde.
        /// </summary>
        /// @param  gewählte_Vorstellung - die Vorstellung, für die die Kinokarte auf Verfügbarkeit hin überprüft werden soll.
        /// @param  sitz - Der Sitzplatz dessen Verfügbarkeit für die gewählte Vorstellung überprüft werden soll.
        /// @return Gibt true zurück, falls die gewünschte Kinokarte noch verfügbar ist, sonst false.
        /// @throw
        /// @pre    
        /// @post
        /// @typ    Abfrage.
        /// @remarks
        public bool ÜberprüfeVerfügbarkeitVonSitzplatz(IPublicVorstellung gewählte_vorstellung, ISitz sitz)
        {
            return _kinokartenInformationen.PrüfeVerfügbarkeitVonSitzplatzFürVorstellung(gewählte_vorstellung, sitz);
        }

        /// <summary>
        /// Blockiert die Kinokarte für den gewählten Sitzplatz, und die gewählte Vorstellung.
        /// </summary>
        /// @param  gewählte_Vorstellung - die Vorstellung, für die die Kinokarte blockiert werden soll.
        /// @param  sitz - Der Sitzplatz welcher blockiert werden soll.
        /// @return Gibt ein Schlüsselobjekt zurück, mit dem auf die blockierte Kinokarte zugegriffen werden kann.
        /// @throw  
        /// @pre    Die gewünschte Kinokarte ist nicht blockiert
        /// @pre    Die gewünschte Kinokarte ist nicht bereits verkauft
        /// @pre    Die gewünschte Kinokarte ist nicht bereits reserviert
        /// @post   Die gewünschte Kinokarte ist blockiert.
        /// @typ    Kommando.
        /// @remarks
        public IKinokarteBlockierungZugangsSchlüssel BlockiereSitzplatz(IPublicVorstellung gewählte_vorstellung, ISitz sitz)
        {
            return _kinokartenOperationen.BlockiereKinokarte(gewählte_vorstellung, sitz);
        }

        /// <summary>
        /// Hebt die Blockierung einer Kinokarte für den gewählten Sitzplatz, und die gewählte Vorstellung auf.
        /// </summary>
        /// @param  gewählte_Vorstellung - Die Vorstellung, der die zu entblockierende Kinokarte zugeordnet ist.
        /// @param  sitz - Der Sitzplatz dessen Blockierung aufgehoben werden soll.
        /// @param  zugangsSchlüssel - Der Zugangsschlüssel der benötigt wird um die Blockierung des Sitzplatzes aufzuheben.
        /// @return 
        /// @throw  
        /// @pre    Die gewünschte Kinokarte ist blockiert
        /// @post   Die gewünschte Kinokarte ist nicht mehr blockiert.
        /// @typ    Kommando.
        /// @remarks
        public void SitzplatzBlockierungAufheben(IPublicVorstellung gewählte_vorstellung, ISitz sitz, IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel)
        {
            _kinokartenOperationen.BlockierungFürSitzplatzAufheben(gewählte_vorstellung,sitz,zugangsSchlüssel);
        }

        /// <summary>
        /// Gibt den Preis in € für eine bestimmte Kinokarte zurück.
        /// Gegebenenfalls wird ein Rabatt auf den Preis der Karte gewährt.
        /// </summary>
        /// @param  gewählte_Vorstellung - die Vorstellung, der die gewünschte Kinokarte zugeordnet ist.
        /// @param  sitz - Der gewünschte Sitzplatz über den die Kinokarte ermittelt wird.
        /// @param  rabatt - Gibt an ob auf den Preis der Kinokarte ein Rabatt gewährt werden soll.
        /// @return Gibt den Preis, unter Berücksichtigung des optionalen Rabattes, der gewünschten Kinokarte zurück.
        /// @throw  
        /// @pre    
        /// @post
        /// @typ    Abfrage.
        /// @remarks
        public float GetPreisFürKinokarte(IPublicVorstellung gewählte_vorstellung, ISitz sitz, bool rabatt)
        {
            return _kinokartenInformationen.GetPreisFürKinokarte(gewählte_vorstellung, sitz, rabatt);
        }

        /// <summary>
        /// Reserviert die gewünschte Kinokarte für den Besucher, und gibt die Reservierungsnummer für die Karte zurück.
        /// </summary>
        /// @param  gewählte_Vorstellung - Die Vorstellung, der die zu reservierende Kinokarte zugeordnet ist.
        /// @param  sitz - Der gewünschte Sitzplatz über den die zu reservierende Kinokarte ermittelt wird.
        /// @param  zugangsSchlüssel - Ein ZugangsSchlüsselObjekt, der für den Zugriff auf die blockierte Kinokarte notwendig ist.
        /// @return Gibt die Reservierungsnummer für die reservierte Kinokarte zurück.
        /// @throw  ZugangsSchlüsselUngültigException
        /// @pre    Die gewünschte Kinokarte ist blockiert
        /// @pre    Die gewünschte Kinokarte ist nicht bereits verkauft
        /// @pre    Die gewünschte Kinokarte ist nicht bereits reserviert    
        /// @post   Die gewünschte Kinokarte ist für den Besucher reserviert
        /// @post   Die gewünschte Kinokarte ist nicht mehr blockiert
        /// @typ    Kommando.
        /// @remarks    Bevor die Kinokarte reserviert werden kann, muss sie mit Hilfe der Funktion BlockiereSitzplatz blockiert worden sein.
        public int KinokarteReservieren(IPublicVorstellung gewählte_vorstellung, ISitz sitz, bool rabatt, IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel)
        {
            return _kinokartenOperationen.KinokarteReservieren(gewählte_vorstellung, sitz, rabatt, zugangsSchlüssel);
        }

        /// <summary>
        /// Hebt die Blockierung einer vorher blockierten Kinokarte auf.
        /// </summary>
        /// @param  gewählte_Vorstellung - Die Vorstellung, der die zu entblockierende Kinokarte zugeordnet ist.
        /// @param  sitz - Der gewünschte Sitzplatz über den die zu entblockierende Kinokarte ermittelt wird.
        /// @param  zugangsSchlüssel - Ein ZugangsSchlüsselObjekt, der für den Zugriff auf die blockierte Kinokarte notwendig ist.
        /// @return Gibt die Reservierungsnummer für die reservierte Kinokarte zurück.
        /// @throw  ZugangsSchlüsselUngültigException
        /// @pre    Die gewünschte Kinokarte ist blockiert    
        /// @post   Die gewünschte Kinokarte ist nicht mehr blockiert
        /// @typ    Kommando.
        /// @remarks    Bevor die Blockierung einer Kinokarte aufgehoben werden kann, muss diese zuvor mit der Methode BlockiereSitzplatz blockiert worden sein.
        public void BlockierungFürSitzplatzAufheben(IPublicVorstellung gewählte_vorstellung, ISitz sitz, IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel)
        {
            _kinokartenOperationen.BlockierungFürSitzplatzAufheben(gewählte_vorstellung, sitz, zugangsSchlüssel);
        }

        /// <summary>
        /// Sendet eine E-Mail mit der entsprechenden Reservierungsnummer an die angegebene E-Mail Adresse.
        /// </summary>
        /// @param  email_adresse - E-Mail-Adresse des Kunden, an den die E-Mail verschickt werden soll.
        /// @param  reservierungsnummer - Die Reservierungsnummer die in die E-Mail eingefügt werden soll.
        /// @return 
        /// @throw  
        /// @pre    Die angegebene E-Mail Adresse ist syntaktisch gültig.
        /// @pre    Die angegebene E-Mail Adresse ist semantisch gültig.
        /// @pre    Die angegebene Reservierungsnummer ist gültig.   
        /// @post   Es ist eine E-Mail an den Kunden verschickt worden.
        /// @post   Die verschickte E-Mail enthält die angegebene Reservierungsnummer.
        /// @typ    Kommando.
        /// @remarks    Um eine gültige Reservierungsnummer zu erhalten muss erst die Reservierung einer Karte über die jeweiligen Methoden vorgenommen werden.
        public void SendeEmailMitReservierungsnummer(string email_adresse, int reservierungsnummer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
