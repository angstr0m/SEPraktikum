using System;
using System.Collections.Generic;
using Cinema.Schnittstelle;
using Kinokarten.Schnittstelle.Interfaces;
using TicketOperations.PublicInterfaceMembers;
using Users.Interfaces;


namespace Fassade.Schnittstelle
{
    public interface IFassadeBesucher
    {
        /// <summary>
        /// Gibt eine Liste der verfügbaren Sitzplätze für die gewählte Vorstellung zurück.
        /// </summary>
        /// @param  gewählte_Vorstellung - die Vorstellung, für die die Liste der Sitzplätze zurückgegeben werden soll.
        /// @return Gibt eine Liste der Sitzplätze ,der gewählten Vorstellung, die weder blockiert, reserviert oder verkauft sind, zurück.
        /// @throw
        /// @pre    
        /// @post
        /// @typ    Abfrage.
        /// @remarks    
        List<ISitz> GetVerfügbareSitzplätzeFürVorstellung(IPublicVorstellung gewählte_Vorstellung);

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
        bool PrüfeAltersfreigabe(IPublicVorstellung gewählte_vorstellung, DateTime geburtsdatum);

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
        bool ÜberprüfeVerfügbarkeitVonSitzplatz(IPublicVorstellung gewählte_vorstellung, ISitz sitz);

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
        IKinokarteBlockierungZugangsSchlüssel BlockiereSitzplatz(IPublicVorstellung gewählte_vorstellung, ISitz sitz);

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
        float GetPreisFürKinokarte(IPublicVorstellung gewählte_vorstellung, ISitz sitz, bool rabatt);

        /// <summary>
        /// Reserviert die gewünschte Kinokarte für den FassadeBesucher, und gibt die Reservierungsnummer für die Karte zurück.
        /// </summary>
        /// @param  gewählte_Vorstellung - Die Vorstellung, der die zu reservierende Kinokarte zugeordnet ist.
        /// @param  sitz - Der gewünschte Sitzplatz über den die zu reservierende Kinokarte ermittelt wird.
        /// @param  rabatt - Bestimmt ob auf den Preis der Karte ein Rabatt gegeben werden soll.
        /// @param  zugangsSchlüssel - Ein ZugangsSchlüsselObjekt, der für den Zugriff auf die blockierte Kinokarte notwendig ist.
        /// @return Gibt die Reservierungsnummer für die reservierte Kinokarte zurück.
        /// @throw  ZugangsSchlüsselUngültigException
        /// @pre    Die gewünschte Kinokarte ist blockiert
        /// @pre    Die gewünschte Kinokarte ist nicht bereits verkauft
        /// @pre    Die gewünschte Kinokarte ist nicht bereits reserviert    
        /// @post   Die gewünschte Kinokarte ist für den FassadeBesucher reserviert
        /// @post   Die gewünschte Kinokarte ist nicht mehr blockiert
        /// @typ    Kommando.
        /// @remarks    Bevor die Kinokarte reserviert werden kann, muss sie mit Hilfe der Funktion BlockiereSitzplatz blockiert worden sein.
        int KinokarteReservieren(IPublicVorstellung gewählte_vorstellung, ISitz sitz, bool rabatt, IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel);

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
        void BlockierungFürSitzplatzAufheben(IPublicVorstellung gewählte_vorstellung, ISitz sitz, IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel);

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
        void SendeEmailMitReservierungsnummer(string email_adresse, int reservierungsnummer);


        /// <summary>
        /// Gibt die Kundeninformationen anhand der kundennummer aus.
        /// </summary>
        /// @param kundennummer - Die Kundennummer des Kunden
        /// @return 
        /// @throw
        /// @pre die Kundennummer ist syntaktisch gültig
        /// @pre die Kundennummer ist semantisch gültig
        /// @post Die Informationen des Kunden wurden ausgegeben
        /// @typ Abfrage
        /// <returns></returns>

        IKunde GetKundenInformationen(int kundennummer);    
       



    }
}
