using SystemAdministration.Interfaces;
using Anwendungskern.Schnittstelle;
using Cinema.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TicketOperations.Models;
using TicketOperations.PublicInterfaceMembers;
using Cinema.InterfaceMembers;
using System.Collections.Generic;
using TicketOperations.PublicInterfaceMembers.Interfaces;
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
        private float ticketpreis;
        private IPublicVorstellung _gewählte_Vorstellung;

        private IAdministration _administration;
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
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
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


        internal virtual IBesucher CreateIBesucher()
        {
            IBenutzerinformationen benutzerinformationen = new Benutzerinformationen();
            _kinokarteninformationen = new KinokartenInformationen();
            _kinokartenoperationen = new KinokartenOperationen(benutzerinformationen);
            IBesucher target = new Besucher(_kinokarteninformationen, _kinokartenoperationen);

            IKinoAdministration kinoAdministration = new KinoAdministration();
            IKinokartenAdministration kinokartenAdministration = new KinokartenAdministration();

            _administration = new Administration(kinokartenAdministration, kinoAdministration);

            return target;
        }

        [TestInitialize()]
        internal virtual void CreateTestData()
        {
            _administration.FillSystemWithTestData();

            _gewählte_Vorstellung = _kinokarteninformationen.GetWöchentlichesFilmprogramm().Vorstellungen[0];
            _sitz = _gewählte_Vorstellung.GetAvailableTickets()[0].Sitz;
        }

        /// <summary>
        ///A test for BlockiereSitzplatz
        ///</summary>
        [TestMethod()]
        public void BlockiereSitzplatzTest()
        {
            IBesucher target = CreateIBesucher();
            Type expected = typeof(IKinokarteBlockierungZugangsSchlüssel);
            IKinokarteBlockierungZugangsSchlüssel actual;
            actual = target.BlockiereSitzplatz(_gewählte_Vorstellung, _sitz);
            Assert.AreEqual(expected, actual.GetType());
        }

        /// <summary>
        ///A test for BlockierungFürSitzplatzAufheben
        ///</summary>
        [TestMethod()]
        public void BlockierungFürSitzplatzAufhebenTest()
        {
            IBesucher target = CreateIBesucher();
            IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel = target.BlockiereSitzplatz(_gewählte_Vorstellung,_sitz);
            target.BlockierungFürSitzplatzAufheben(_gewählte_Vorstellung, _sitz, zugangsSchlüssel);
            Assert.IsFalse(_administration.IsTicketBlocked(_gewählte_Vorstellung,sitz));
        }

        /// <summary>
        ///A test for GetPreisFürKinokarte
        ///</summary>
        [TestMethod()]
        public void GetPreisFürKinokarteTest()
        {
            IBesucher target = CreateIBesucher(); 
            bool rabatt = false;
            float expected = ticketpreis;
            float actual;
            actual = target.GetPreisFürKinokarte(_gewählte_Vorstellung, _sitz, rabatt);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetVerfügbareSitzplätzeFürVorstellung
        ///</summary>
        [TestMethod()]
        public void GetVerfügbareSitzplätzeFürVorstellungTest()
        {
            IBesucher target = CreateIBesucher();
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
            IBesucher target = CreateIBesucher();
            bool rabatt = false;
            IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel = target.BlockiereSitzplatz(_gewählte_Vorstellung, _sitz);
            int expected = 0;
            int actual;
            actual = target.KinokarteReservieren(_gewählte_Vorstellung, _sitz, rabatt, zugangsSchlüssel);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for PrüfeAltersfreigabe
        ///</summary>
        [TestMethod()]
        public void PrüfeAltersfreigabeTest()
        {
            IBesucher target = CreateIBesucher();
            DateTime geburtsdatum = new DateTime(1980, 6, 10);
            bool expected = true;
            bool actual;
            actual = target.PrüfeAltersfreigabe(_gewählte_Vorstellung, geburtsdatum);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SendeEmailMitReservierungsnummer
        ///</summary>
        [TestMethod()]
        public void SendeEmailMitReservierungsnummerTest()
        {
            IBesucher target = CreateIBesucher(); // TODO: Initialize to an appropriate value
            string email_adresse = string.Empty; // TODO: Initialize to an appropriate value
            int reservierungsnummer = 0; // TODO: Initialize to an appropriate value
            target.SendeEmailMitReservierungsnummer(email_adresse, reservierungsnummer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ÜberprüfeVerfügbarkeitVonSitzplatz
        ///</summary>
        [TestMethod()]
        public void ÜberprüfeVerfügbarkeitVonSitzplatzTest()
        {
            IBesucher target = CreateIBesucher();
            bool expected = true;
            bool actual;
            actual = target.ÜberprüfeVerfügbarkeitVonSitzplatz(_gewählte_Vorstellung, _sitz);
            Assert.AreEqual(expected, actual);
        }
    }
}
