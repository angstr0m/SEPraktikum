﻿using System;
using System.Collections.Generic;
using Cinema.Models;
using TicketOperations.Models;

namespace TicketOperations.InterfaceMembers
{
    interface IBesucherKinokartenReservierung : IKinokarteReservieren
    {
        /// <summary>
        /// Gibt eine Liste der Sitzplätze für die gewählte Vorstellung zurück.
        /// </summary>
        /// @param  gewählte_Vorstellung - die Vorstellung, für die die Liste der Sitzplätze zurückgegeben werden soll.
        /// @return Gibt eine Liste der Sitzplätze der gewählten Vorstellung zurück.
        /// @throw
        /// @pre    
        /// @post
        /// @remarks
        List<ISitz> GetSitzplätzeFürVorstellung(IPublicVorstellung gewählte_Vorstellung);

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
        /// @remarks
        bool PrüfeAltersfreigabe(IPublicVorstellung gewählte_vorstellung, DateTime geburtsdatum);

        /// <summary>
        /// Überprüft ob eine Kinokarte für den angegebenen Sitzplatz für die angegebene Vorstellung noch nicht reserviert und/oder verkauft wurde.
        /// </summary>
        /// @param  gewählte_Vorstellung - die Vorstellung, für die die Kinokarte auf Verfügbarkeit hin überprüft werden soll.
        /// @return Gibt true zurück, falls die gewünschte Kinokarte noch verfügbar ist, sonst false.
        /// @throw
        /// @pre    
        /// @post
        /// @remarks
        bool ÜberprüfeVerfügbarkeitVonSitzplatz(IPublicVorstellung gewählte_vorstellung, ISitz sitz);

        /// <summary>
        /// Blockiert die Kinokarte für den gewählten Sitzplatz, und die gewählte Vorstellung.
        /// </summary>
        /// @param  gewählte_Vorstellung - die Vorstellung, für die die Kinokarte blockiert werden soll.
        /// @return Gibt ein Schlüsselobjekt zurück, mit dem auf die blockierte Kinokarte zugegriffen werden kann.
        /// @throw  
        /// @pre    Die gewünschte Kinokarte ist nicht blockiert
        /// @pre    Die gewünschte Kinokarte ist nicht bereits verkauft
        /// @pre    Die gewünschte Kinokarte ist nicht bereits reserviert
        /// @post   Die gewünschte Kinokarte ist blockiert.
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
        /// @remarks
        float GetPreisFürKinokarte(IPublicVorstellung gewählte_vorstellung, ISitz sitz, bool rabatt);

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
        /// @remarks    Bevor die Kinokarte reserviert werden kann, muss sie mit Hilfe der Funktion BlockiereSitzplatz blockiert worden sein.
        int KinokarteReservieren(IPublicVorstellung gewählte_vorstellung, ISitz sitz, IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel);

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
        /// @remarks    Um eine gültige Reservierungsnummer zu erhalten muss erst die Reservierung einer Karte über die jeweiligen Methoden vorgenommen werden.
        void SendeEmailMitReservierungsnummer(string email_adresse, int reservierungsnummer);


        /// <summary>
        /// Reserviert ein Kinokarte für einen Besucher.
        /// </summary>
        /// <param name="vorstellung">Die gewünschte Vorstellung.</param>
        /// <param name="sitz">Der gewünschte Sitz.</param>
        /// <remarks></remarks>
        int KinokarteReservieren(IPublicVorstellung vorstellung, ISitzIdentifikator sitz, bool rabatt, IKinokarteBlockierungZugangsSchlüssel transaktionsSchlüssel);

        /// <summary>
        /// Reserviert das TIcket für einen Besucher
        /// </summary>
        /// <param name="kinokarte">Das gewünschte Kinokarte.</param>
        /// <param name="rabatt">Hat den Wert true, wenn Rabatt gegeben werden soll.</param>
        /// <param name="transaktionsSchlüssel">Der Transaktionsschlüssel um das geblockte Kinokarte freizuschalten.</param>
        /// <returns> Gibt die Reservierungsnummer für das Kinokarte zurück. </returns>
        /// <remarks></remarks>
        int KinokarteReservieren(IPublicKinokarte kinokarte, bool rabatt, IKinokarteBlockierungZugangsSchlüssel transaktionsSchlüssel);
    }
}
