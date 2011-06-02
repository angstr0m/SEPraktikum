using System;
using System.Collections.Generic;
using Cinema.Models;
using Cinema.Schnittstelle;
using Fassade.Schnittstelle;
using Kinokarten.Schnittstelle;
using Kinokarten.Schnittstelle.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemAdministration.Interfaces;
using Users.Interfaces;

namespace TestAnwendungskern
{


    /// <summary>
    ///This is a test class for IBesucherTest and is intended
    ///to contain all IBesucherTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IBesucherTest

        {

        private float ticketpreis = 6.0f;
        private IPublicVorstellung _gewählte_Vorstellung;
        private static IAdministration _administration;
        private IKinokartenInformationen _kinokarteninformationen;
        private IKinokartenOperationen _kinokartenoperationen;

        private ISitz _sitz;

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            IKinoAdministration kinoAdministration = new KinoAdministration();
            IKinokartenAdministration kinokartenAdministration = new KinokartenAdministration();

            _administration = new Administration(kinokartenAdministration, kinoAdministration); 

        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        internal virtual IFassadeBesucher CreateIBesucher()
        {
            IBenutzerinformationen benutzerinformationen = new Benutzerinformationen();
            _kinokarteninformationen = new KinokartenInformationen();
            _kinokartenoperationen = new KinokartenOperationen(benutzerinformationen);
            IFassadeBesucher target = new FassadeBesucher(_kinokarteninformationen, _kinokartenoperationen, benutzerinformationen);
            _administration.FillSystemWithTestData();

            _gewählte_Vorstellung = _kinokarteninformationen.GetWöchentlichesFilmprogramm().Vorstellungen[0];
            _sitz = (ISitz)_gewählte_Vorstellung.VerfügbareKinokarten()[0].Sitz;        
            

            return target;
        }

        [TestInitialize()]
        public virtual void CreateTestData()
        {
            
         
        }

        /// <summary>
        ///A test for BlockiereSitzplatz
        ///</summary>
        [TestMethod()]
        public void BlockiereSitzplatzTest()
        {
            IFassadeBesucher target = CreateIBesucher();
            Type expected = typeof(KinokarteBlockierungZugangsSchlüssel);
            KinokarteBlockierungZugangsSchlüssel actual;
            actual = target.BlockiereSitzplatz(_gewählte_Vorstellung, _sitz) as KinokarteBlockierungZugangsSchlüssel;
            Assert.AreEqual(expected, actual.GetType());
            // new            
           // Assert.IsTrue(_administration.IsTicketBlocked(_gewählte_Vorstellung, _sitz));
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for BlockierungFürSitzplatzAufheben
        ///</summary>
        [TestMethod()]
        public void BlockierungFürSitzplatzAufhebenTest()
        {
            IFassadeBesucher target = CreateIBesucher();
            IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel = target.BlockiereSitzplatz(_gewählte_Vorstellung, _sitz);
            target.BlockierungFürSitzplatzAufheben(_gewählte_Vorstellung, _sitz, zugangsSchlüssel);
            Assert.IsFalse(_administration.IsTicketBlocked(_gewählte_Vorstellung, _sitz));
            Assert.IsNotNull(zugangsSchlüssel);
        }

        /// <summary>
        ///A test for GetPreisFürKinokarte
        ///</summary>
        [TestMethod()]
        public void GetPreisFürKinokarteTest()
        {
            //test für wenn rabatt gesetzt, dann ticketpreis expectected == ticketpreis actual setzen
            IFassadeBesucher target = CreateIBesucher();
            bool rabatt = false;
            float expected = ticketpreis;
            float actual;
            actual = target.GetPreisFürKinokarte(_gewählte_Vorstellung, _sitz, rabatt);
            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for GetVerfügbareSitzplätzeFürVorstellung
        ///</summary>
        [TestMethod()]
        public void GetVerfügbareSitzplätzeFürVorstellungTest()
        {
            IFassadeBesucher target = CreateIBesucher();
            Type expected = typeof(List<ISitz>);
            List<ISitz> actual;
            actual = target.GetVerfügbareSitzplätzeFürVorstellung(_gewählte_Vorstellung);
            Assert.AreEqual(expected, actual.GetType());
        }

        /// <summary>
        ///A test for KinokarteReservieren
        ///</summary>
        [TestMethod()]
        public void KinokarteReservierenTest()
        {

            IFassadeBesucher target = CreateIBesucher();
            bool rabatt = false;
            IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel = target.BlockiereSitzplatz(_gewählte_Vorstellung, _sitz);
            int expected = 1;
            int actual;
            actual = target.KinokarteReservieren(_gewählte_Vorstellung, _sitz, rabatt, zugangsSchlüssel);
            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for PrüfeAltersfreigabe
        ///</summary>
        [TestMethod()]
        public void PrüfeAltersfreigabeTest()
        {
            //Prüfung ob Alterspreigabe bei allen vorstellungen nach 22uhr min 16Jahre 

            IFassadeBesucher target = CreateIBesucher();
            DateTime geburtsdatum = new DateTime(1980, 6, 10);
            bool expected = true;
            bool actual;
            actual = target.PrüfeAltersfreigabe(_gewählte_Vorstellung, geburtsdatum);
            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);

        }

        /// <summary>
        ///A test for SendeEmailMitReservierungsnummer
        ///</summary>
        [TestMethod()]
        public void SendeEmailMitReservierungsnummerTest()
        {
            IFassadeBesucher target = CreateIBesucher();
            string email_adresse = "Email";// Email Adresse von Benutzer bekommen
            IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel = target.BlockiereSitzplatz(_gewählte_Vorstellung, _sitz);
            int reservierungsnummer = target.KinokarteReservieren(_gewählte_Vorstellung, _sitz, false, zugangsSchlüssel);
            target.SendeEmailMitReservierungsnummer(email_adresse, reservierungsnummer);
            Assert.IsNotNull(email_adresse);
            // Test auf eigener Email ob email ankommt ist wohl besser
        }

        /// <summary>
        ///A test for ÜberprüfeVerfügbarkeitVonSitzplatz
        ///</summary>
        [TestMethod()]
        public void ÜberprüfeVerfügbarkeitVonSitzplatzTest()
        {
            IFassadeBesucher target = CreateIBesucher();
            bool expected = true;
            bool actual;
            actual = target.ÜberprüfeVerfügbarkeitVonSitzplatz(_gewählte_Vorstellung, _sitz);
            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
        }
    }
}
