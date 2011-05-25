using Anwendungskern.Schnittstelle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TicketOperations.PublicInterfaceMembers;
using Cinema.InterfaceMembers;
using System.Collections.Generic;

namespace TestAnwendungskern
{
    
    
    /// <summary>
    ///This is a test class for IBesucherTest and is intended
    ///to contain all IBesucherTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IBesucherTest
    {


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
            // TODO: Instantiate an appropriate concrete class.
            IBesucher target = null;
            return target;
        }

        /// <summary>
        ///A test for BlockiereSitzplatz
        ///</summary>
        [TestMethod()]
        public void BlockiereSitzplatzTest()
        {
            IBesucher target = CreateIBesucher(); // TODO: Initialize to an appropriate value
            IPublicVorstellung gewählte_vorstellung = null; // TODO: Initialize to an appropriate value
            ISitz sitz = null; // TODO: Initialize to an appropriate value
            IKinokarteBlockierungZugangsSchlüssel expected = null; // TODO: Initialize to an appropriate value
            IKinokarteBlockierungZugangsSchlüssel actual;
            actual = target.BlockiereSitzplatz(gewählte_vorstellung, sitz);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BlockierungFürSitzplatzAufheben
        ///</summary>
        [TestMethod()]
        public void BlockierungFürSitzplatzAufhebenTest()
        {
            IBesucher target = CreateIBesucher(); // TODO: Initialize to an appropriate value
            IPublicVorstellung gewählte_vorstellung = null; // TODO: Initialize to an appropriate value
            ISitz sitz = null; // TODO: Initialize to an appropriate value
            IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel = null; // TODO: Initialize to an appropriate value
            target.BlockierungFürSitzplatzAufheben(gewählte_vorstellung, sitz, zugangsSchlüssel);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetPreisFürKinokarte
        ///</summary>
        [TestMethod()]
        public void GetPreisFürKinokarteTest()
        {
            IBesucher target = CreateIBesucher(); // TODO: Initialize to an appropriate value
            IPublicVorstellung gewählte_vorstellung = null; // TODO: Initialize to an appropriate value
            ISitz sitz = null; // TODO: Initialize to an appropriate value
            bool rabatt = false; // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            actual = target.GetPreisFürKinokarte(gewählte_vorstellung, sitz, rabatt);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetVerfügbareSitzplätzeFürVorstellung
        ///</summary>
        [TestMethod()]
        public void GetVerfügbareSitzplätzeFürVorstellungTest()
        {
            IBesucher target = CreateIBesucher(); // TODO: Initialize to an appropriate value
            IPublicVorstellung gewählte_Vorstellung = null; // TODO: Initialize to an appropriate value
            List<ISitz> expected = null; // TODO: Initialize to an appropriate value
            List<ISitz> actual;
            actual = target.GetVerfügbareSitzplätzeFürVorstellung(gewählte_Vorstellung);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for KinokarteReservieren
        ///</summary>
        [TestMethod()]
        public void KinokarteReservierenTest()
        {
            IBesucher target = CreateIBesucher(); // TODO: Initialize to an appropriate value
            IPublicVorstellung gewählte_vorstellung = null; // TODO: Initialize to an appropriate value
            ISitz sitz = null; // TODO: Initialize to an appropriate value
            bool rabatt = false; // TODO: Initialize to an appropriate value
            IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.KinokarteReservieren(gewählte_vorstellung, sitz, rabatt, zugangsSchlüssel);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PrüfeAltersfreigabe
        ///</summary>
        [TestMethod()]
        public void PrüfeAltersfreigabeTest()
        {
            IBesucher target = CreateIBesucher(); // TODO: Initialize to an appropriate value
            IPublicVorstellung gewählte_vorstellung = null; // TODO: Initialize to an appropriate value
            DateTime geburtsdatum = new DateTime(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.PrüfeAltersfreigabe(gewählte_vorstellung, geburtsdatum);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
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
            IBesucher target = CreateIBesucher(); // TODO: Initialize to an appropriate value
            IPublicVorstellung gewählte_vorstellung = null; // TODO: Initialize to an appropriate value
            ISitz sitz = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ÜberprüfeVerfügbarkeitVonSitzplatz(gewählte_vorstellung, sitz);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
