using System;
using System.Collections.Generic;
using SystemAdministration.Interfaces;
using Fassade.Schnittstelle;
using Kino.Schnittstelle;
using Kinokarten.Schnittstelle;
using Kinokarten.Schnittstelle.Interfaces;
using Users.Interfaces;
using NUnit.Framework;

using NUnitAssert = NUnit.Framework.Assert;


using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using ClassCleanup = NUnit.Framework.TestFixtureTearDownAttribute;
using ClassInitialize = NUnit.Framework.TestFixtureSetUpAttribute;

namespace TestAnwendungskern
{
    /// <summary>
    ///This is a test class for IBesucherTest and is intended
    ///to contain all IBesucherTest Unit Tests
    ///</summary>
    [TestClass]
    public class IBesucherTest

    {
        private static IAdministration _administration;
        private IPublicVorstellung _gewählte_Vorstellung;
        private IKinokartenInformationen _kinokarteninformationen;
        private IKinokartenOperationen _kinokartenoperationen;

        private ISitz _sitz;
        // Preis den alle Testkinokarten verwenden werden.
        private const float KinokartenPreis = 6.0f;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes

        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class

        [ClassInitialize]
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
            IFassadeBesucher target = new FassadeBesucher(_kinokarteninformationen, _kinokartenoperationen,
                                                          benutzerinformationen);
            _administration.FillSystemWithTestData(KinokartenPreis);

            _gewählte_Vorstellung = _kinokarteninformationen.GetWöchentlichesFilmprogramm().Vorstellungen[0];
            _sitz = _gewählte_Vorstellung.VerfügbareKinokarten()[0].Sitz;


            return target;
        }

        [TestInitialize]
        public virtual void CreateTestData()
        {
        }

        /// <summary>
        /// TF-1: Blockieren eines Sitzplatzes in einem Kinosaal.
        /// </summary>
        /// <description>
        /// Der Status eines nicht blockierten Sitzplatzes soll auf blockiert gesetzt werden.
        /// </description>
        /// <precondition>
        /// _gewählte_Vorstellung muss auf eine gültige Vorstellung verweisen,
        /// _sitz muss auf einen Sitz in dieser Vorstellung verweisen, der noch nicht blockiert wurde.
        /// </precondition>
        /// <input>
        /// Keine direkte Eingabe des Benutzers.
        /// </input>
        /// <output>
        /// Keine direkte Ausgabe an den Benutzer.
        /// </output>
        /// <verification>
        /// Es wird überprüft:
        /// - ob die Methode einen gültigen Zugangsschlüssel zurückgegeben hat.
        /// - ob der Sitzplatz auf den Status blockiert gesetzt wurde.
        /// </verification>
        [Test]
        public void BlockiereSitzplatzTest_Success()
        {
            IFassadeBesucher target = CreateIBesucher();
            Type expected = typeof (KinokarteBlockierungZugangsSchlüssel);
            KinokarteBlockierungZugangsSchlüssel actual;
            actual = target.BlockiereSitzplatz(_gewählte_Vorstellung, _sitz) as KinokarteBlockierungZugangsSchlüssel;
            Assert.AreEqual(expected, actual.GetType());        
            Assert.IsTrue(_administration.IsTicketBlocked(_gewählte_Vorstellung, _sitz));
            Assert.IsNotNull(actual);
        }

        /// <summary>
        /// TF-2: Blockierung eines bereits blockierten Sitzplatzes aufheben.
        /// </summary>
        /// <description>
        /// Die Blockierung eines bereits blockierten Sitzplatzes soll aufgehoben werden.
        /// </description>
        /// <precondition>
        /// TF-1 muss funktionieren.
        /// _gewählte_Vorstellung muss auf eine gültige Vorstellung verweisen,
        /// _sitz muss auf einen Sitz in dieser Vorstellung verweisen, der noch nicht blockiert wurde.
        /// </precondition>
        /// <input>
        /// Keine direkte Eingabe des Benutzers.
        /// </input>
        /// <output>
        /// Keine direkte Ausgabe an den Benutzer.
        /// </output>
        /// <verification>
        /// Es wird überprüft:
        /// - ob der Status des Tickets auf nicht blockiert gesetzt wurde.
        /// </verification>
        [Test]
        public void BlockierungFürSitzplatzAufhebenTest_Success()
        {
            IFassadeBesucher target = CreateIBesucher();
            // Gewünschten Sitzplatz blockieren.
            IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel = target.BlockiereSitzplatz(_gewählte_Vorstellung,
                                                                                               _sitz);
            target.BlockierungFürSitzplatzAufheben(_gewählte_Vorstellung, _sitz, zugangsSchlüssel);
            Assert.IsFalse(_administration.IsTicketBlocked(_gewählte_Vorstellung, _sitz));
        }

        /// <summary>
        /// TF-3: Preis für eine Kinokarte abfragen ohne Rabbatierung.
        /// </summary>
        /// <description>
        /// Der Preis einer Kinokarte soll abgefragt werden. Ein Rabatt wird hierbei nicht gegebeben.
        /// </description>
        /// <precondition>
        /// In _kinokartenPreis muss der gewünschte Preis für die Kinokarte hinterlegt sein.
        /// _gewählte_Vorstellung muss auf eine gültige Vorstellung verweisen,
        /// _sitz muss auf einen Sitz in dieser Vorstellung verweisen.
        /// </precondition>
        /// <input>
        /// Keine direkte Eingabe des Benutzers.
        /// </input>
        /// <output>
        /// Keine direkte Ausgabe an den Benutzer.
        /// </output>
        /// <verification>
        /// Es wird überprüft:
        /// - ob der Preis der Kinokarte dem eingestellten Preis entspricht.
        /// </verification>
        [Test]
        public void GetPreisFürKinokarteTest_Success()
        {
            //test für wenn rabatt gesetzt, dann _kinokartenPreis expectected == _kinokartenPreis actual setzen
            IFassadeBesucher target = CreateIBesucher();
            bool rabatt = false;
            float expected = KinokartenPreis;
            float actual;
            actual = target.GetPreisFürKinokarte(_gewählte_Vorstellung, _sitz, rabatt);
            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        /// TF-4: Preis für eine Kinokarte abfragen ohne Rabbatierung.
        /// </summary>
        /// <description>
        /// Der Preis einer Kinokarte soll abgefragt werden. Ein Rabatt wird hierbei nicht gegebeben.
        /// </description>
        /// <precondition>
        /// In _kinokartenPreis muss der gewünschte Preis für die Kinokarte hinterlegt sein.
        /// _gewählte_Vorstellung muss auf eine gültige Vorstellung verweisen,
        /// _sitz muss auf einen Sitz in dieser Vorstellung verweisen.
        /// </precondition>
        /// <input>
        /// Keine direkte Eingabe des Benutzers.
        /// </input>
        /// <output>
        /// Keine direkte Ausgabe an den Benutzer.
        /// </output>
        /// <verification>
        /// Es wird überprüft:
        /// - ob der Preis der Kinokarte dem eingestellten Preis entspricht.
        /// </verification>
        [Test]
        public void GetPreisFürKinokarteMitRabattTest_Success()
        {
            //test für wenn rabatt gesetzt, dann _kinokartenPreis expectected == _kinokartenPreis actual setzen
            IFassadeBesucher target = CreateIBesucher();
            bool rabatt = false;
            float expected = KinokartenPreis;
            float actual;
            actual = target.GetPreisFürKinokarte(_gewählte_Vorstellung, _sitz, rabatt);
            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for GetVerfügbareSitzplätzeFürVorstellung
        ///</summary>
        [Test]
        public void GetVerfügbareSitzplätzeFürVorstellungTest()
        {
            IFassadeBesucher target = CreateIBesucher();
            Type expected = typeof (List<ISitz>);
            List<ISitz> actual;
            actual = target.GetVerfügbareSitzplätzeFürVorstellung(_gewählte_Vorstellung);
            Assert.AreEqual(expected, actual.GetType());
        }

        /// <summary>
        ///A test for KinokarteReservieren
        ///</summary>
        [Test]
        public void KinokarteReservierenTest()
        {
            IFassadeBesucher target = CreateIBesucher();
            bool rabatt = false;
            IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel = target.BlockiereSitzplatz(_gewählte_Vorstellung,
                                                                                               _sitz);
            int expected = 1;
            int actual;
            actual = target.KinokarteReservieren(_gewählte_Vorstellung, _sitz, rabatt, zugangsSchlüssel);
            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for PrüfeAltersfreigabe
        ///</summary>
        [Test]
        public void PrüfeAltersfreigabeTest()
        {
            //Prüfung ob Alterspreigabe bei allen vorstellungen nach 22uhr min 16Jahre 

            IFassadeBesucher target = CreateIBesucher();
            var geburtsdatum = new DateTime(1980, 6, 10);
            bool expected = true;
            bool actual;
            actual = target.PrüfeAltersfreigabe(_gewählte_Vorstellung, geburtsdatum);
            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for SendeEmailMitReservierungsnummer
        ///</summary>
        [Test]
        public void SendeEmailMitReservierungsnummerTest()
        {
            IFassadeBesucher target = CreateIBesucher();
            string email_adresse = "malte.eckhoff@jokersworld.de";
            IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel = target.BlockiereSitzplatz(_gewählte_Vorstellung,
                                                                                               _sitz);
            int reservierungsnummer = target.KinokarteReservieren(_gewählte_Vorstellung, _sitz, false, zugangsSchlüssel);
            target.SendeEmailMitReservierungsnummer(email_adresse, reservierungsnummer);
            Assert.IsNotNull(email_adresse);
            // Ob die E-Mail auch wirklich ankommt muss vom Besitzer des E-Mail Kontos gerprüft werden!
        }

        /// <summary>
        ///A test for ÜberprüfeVerfügbarkeitVonSitzplatz
        ///</summary>
        [Test]
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