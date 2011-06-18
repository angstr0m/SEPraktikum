using SystemAdministration.Interfaces;
using Database.Models;
using Kino.Models;
using Kinokarten.Models;
using Kinokarten.Schnittstelle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Kinokarten.Schnittstelle.Interfaces;
using Kino.Schnittstelle;
using System.Collections.Generic;
using Users.Interfaces;

namespace TestAnwendungskern
{
    /// <summary>
    ///This is a test class for KinokartenInformationenTest and is intended
    ///to contain all KinokartenInformationenTest Unit Tests
    ///</summary>
    [TestClass()]
    public class KinokartenInformationenTest
    {
        EntityManager<Vorstellung> _vorstellungen = new EntityManager<Vorstellung>();
        EntityManager<Filmprogramm> _filmprogramme = new EntityManager<Filmprogramm>();
        static EntityManager<Film> _filme = new EntityManager<Film>();
        static EntityManager<Kinosaal> _kinosäle = new EntityManager<Kinosaal>();

        private IPublicVorstellung _gewählte_Vorstellung;
        private ISitz _sitz;
        // Preis den alle Testkinokarten verwenden werden.
        private const float KinokartenPreis = 6.0f;

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

        // Testklasse initialisieren
        [ClassInitialize]
        public static void InitializeTest(TestContext testContext)
        {
            _filme.RemoveAllElements();
            _kinosäle.RemoveAllElements();

            var hdr1 = new Film("Herr der Ringe - Die Gefährten", "Adventure", 178, "USA", 12,
                                "Elijah Wood, Ian McKellen, Orlando Bloom, Viggo Mortensen", "Peter Jackson");
            var hdr2 = new Film("Der Herr der Ringe - Die zwei Türme", "Adventure", 179, "USA", 12,
                                "Elijah Wood, Ian McKellen, Orlando Bloom, Viggo Mortensen", "Peter Jackson");
            var hdr3 = new Film("Der Herr der Ringe - Die Rückkehr des Königs", "Adventure", 201, "USA", 12,
                                "Elijah Wood, Ian McKellen, Orlando Bloom, Viggo Mortensen", "Peter Jackson");
            var tron = new Film("TRON", "Sci-Fi", 96, "USA", 12, "Jeff Bridges, Bruce Boxleitner, David Warner",
                                "Steven Lisberger");
            var tron2 = new Film("TRON: Legacy", "Sci-Fi", 125, "USA", 12, "Jeff Bridges, Garrett Hedlund, Olivia Wilde",
                                 "Joseph Kosinski");

            var saal1 = new Kinosaal("Saal 1", 10, 10);
            var saal2 = new Kinosaal("Saal 2", 10, 10);
            var saal3 = new Kinosaal("Saal 3", 10, 10);
        }

        // Testdaten für jeden Test neu initialisieren
        [TestInitialize]
        public virtual void CreateTestData()
        {
            _vorstellungen.RemoveAllElements();
            _filmprogramme.RemoveAllElements();

            IKinoInformationen kinoinfo = new KinoInformationen();

            var vorstellung1 = new Vorstellung(new DateTime(2011, 05, 26, 12, 00, 00, 00), _filme.GetElements()[0],
                                               _kinosäle.GetElements()[0], false, KinokartenPreis);
            var vorstellung2 = new Vorstellung(new DateTime(2011, 05, 26, 13, 00, 00, 00), _filme.GetElements()[1],
                                               _kinosäle.GetElements()[1], false, KinokartenPreis);
            var vorstellung3 = new Vorstellung(new DateTime(2011, 05, 26, 14, 00, 00, 00), _filme.GetElements()[2],
                                               _kinosäle.GetElements()[2], false, KinokartenPreis);
            var vorstellung4 = new Vorstellung(new DateTime(2011, 05, 26, 18, 00, 00, 00), _filme.GetElements()[3],
                                               _kinosäle.GetElements()[0], false, KinokartenPreis);
            var vorstellung5 = new Vorstellung(new DateTime(2011, 05, 26, 18, 00, 00, 00), _filme.GetElements()[4],
                                               _kinosäle.GetElements()[1], false, KinokartenPreis);
            var vorstellung6 = new Vorstellung(new DateTime(2011, 05, 27, 12, 00, 00, 00), _filme.GetElements()[0],
                                               _kinosäle.GetElements()[0], false, KinokartenPreis);
            var vorstellung7 = new Vorstellung(new DateTime(2011, 05, 27, 13, 00, 00, 00), _filme.GetElements()[1],
                                               _kinosäle.GetElements()[1], false, KinokartenPreis);
            var vorstellung8 = new Vorstellung(new DateTime(2011, 05, 27, 14, 00, 00, 00), _filme.GetElements()[2],
                                               _kinosäle.GetElements()[2], false, KinokartenPreis);
            var vorstellung9 = new Vorstellung(new DateTime(2011, 05, 27, 18, 00, 00, 00), _filme.GetElements()[3],
                                               _kinosäle.GetElements()[0], false, KinokartenPreis);
            var vorstellung10 = new Vorstellung(new DateTime(2011, 05, 27, 18, 00, 00, 00), _filme.GetElements()[4],
                                                _kinosäle.GetElements()[1], false, KinokartenPreis);
            var vorstellung11 = new Vorstellung(new DateTime(2011, 05, 28, 12, 00, 00, 00), _filme.GetElements()[0],
                                                _kinosäle.GetElements()[0], false, KinokartenPreis);
            var vorstellung12 = new Vorstellung(new DateTime(2011, 05, 28, 13, 00, 00, 00), _filme.GetElements()[1],
                                                _kinosäle.GetElements()[1], false, KinokartenPreis);
            var vorstellung13 = new Vorstellung(new DateTime(2011, 05, 28, 14, 00, 00, 00), _filme.GetElements()[2],
                                                _kinosäle.GetElements()[2], false, KinokartenPreis);
            var vorstellung14 = new Vorstellung(new DateTime(2011, 05, 28, 18, 00, 00, 00), _filme.GetElements()[3],
                                                _kinosäle.GetElements()[0], false, KinokartenPreis);
            var vorstellung15 = new Vorstellung(new DateTime(2011, 05, 28, 18, 00, 00, 00), _filme.GetElements()[4],
                                                _kinosäle.GetElements()[1], false, KinokartenPreis);

            var filmprogramm = new Filmprogramm(DateTime.Now, _vorstellungen.GetElements());

            _gewählte_Vorstellung = new PublicVorstellung(_filmprogramme.GetElements()[0].Vorstellungen[0]);
            _sitz = _gewählte_Vorstellung.VerfügbareKinokarten()[0].Sitz;
        }

        /// <summary>
        /// TF-10: Preis für eine Kinokarte abfragen.
        /// </summary>
        /// <description>
        /// Der Preis einer Kinokarte soll abgefragt werden.
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
        /// - ob der zurückgegebene Preis dem konfigurierten entspricht.
        /// </verification>
        [TestMethod()]
        public void GetPreisFürKinokarteTest_Success()
        {
            KinokartenInformationen target = new KinokartenInformationen();
            IPublicVorstellung vorstellung = _gewählte_Vorstellung;
            ISitz sitz = _sitz;
            bool rabatt = false;
            float expected = KinokartenPreis;
            float actual;
            actual = target.GetPreisFürKinokarte(vorstellung, sitz, rabatt);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TF-11: Verfügbare Kinokarten für eine Vorstellung abrufen.
        /// </summary>
        /// <description>
        /// Die verfügbaren Kinokarten einer Vorstellung sollen abgefragt werden.
        /// Damit eine Kinokarte verfügbar ist muss folgendes gelten:
        /// - Die Kinokarte darf nicht blockiert sein.
        /// - Die Kinokarte darf nicht reserviert sein.
        /// - Die Kinokarte darf nicht verkauft sein.
        /// </description>
        /// <precondition>
        /// - _gewählte_Vorstellung muss auf eine gültige Vorstellung verweisen,
        /// - _sitz muss auf einen Sitz in dieser Vorstellung verweisen, der noch nicht blockiert wurde.
        /// - Alle Kinokarten der _gewählten Vorstellung müssen nicht reserviert, gekauft oder blockiert sein! 
        /// </precondition>
        /// <input>
        /// Keine direkte Eingabe des Benutzers.
        /// </input>
        /// <output>
        /// Keine direkte Ausgabe an den Benutzer.
        /// </output>
        /// <verification>
        /// Es wird überprüft:
        /// - ob eine Liste von Kinokarten zurückgegeben wurde.
        /// - ob diese Liste nicht leer ist.
        /// - ob die Kinokarten in dieser Liste weder blockiert, reserviert oder verkauft sind.
        /// </verification>
        [TestMethod()]
        public void GetVerfügbareKinokartenFürVorstellungTest_Success()
        {
            KinokartenInformationen target = new KinokartenInformationen();
            IPublicVorstellung vorstellung = _gewählte_Vorstellung;
            EntityManager<Kinokarte> kinokarten = new EntityManager<Kinokarte>();

            // Vorstellung mit gleicher ID wie der gewählten PublicVorstellung finden
            Vorstellung v = _vorstellungen.GetElementWithId(_gewählte_Vorstellung.GetIdentifier());
            // Zugehörige Kinokarten der gewählten Vorstellung finden.
            List<Kinokarte> expected = kinokarten.GetElements().FindAll(k => k.Vorstellung == v);

            // Zufällig einige der Kinokarten Reservieren, blockieren oder verkaufen
            Random random = new Random();

            foreach (Kinokarte k in expected)
            {
                if (random.Next(2) < 1)
                {
                    switch(random.Next(3))
                    {
                        case 0:
                            k.Blockieren();
                            break;
                        case 1:
                            k.Reservieren();
                            break;
                        case 2:
                            k.Verkauft = true;
                            break;
                    }
                }
            }

            // Das erwartete Ergebnis aufräumen.
            expected.RemoveAll(delegate(Kinokarte k) { return (k.Blockiert || k.Verkauft || k.Reserviert); });

            // Verfügbare Kinokarten für die Vorstellung abfragen.
            List<IPublicKinokarte> actual;
            actual = target.GetVerfügbareKinokartenFürVorstellung(vorstellung);

            // Für den Vergleich werden Kinokarten benötigt.
            // GetVerfügbareKinokartenFürVorstellung gibt jedoch nur PublicKionokarten zurück.
            // Für den Vergleich mit den erwarteten Ergebnissen müssen also die zugehörigen Kinokarten extrahiert werden.
            List<Kinokarte> vergleichsListe = new List<Kinokarte>();
            foreach(IPublicKinokarte k in actual)
            {
                vergleichsListe.Add(kinokarten.GetElementWithId(k.GetIdentifier()));
            }
            
            // Überprüfen ob die erwarteten Kinokarten zurückgekommen sind.
            Assert.IsTrue(expected.Count == vergleichsListe.Count);

            bool valid = true;

            foreach (var k in vergleichsListe)
            {
                valid = expected.Contains(k);
                if (!valid)
                {
                    break;
                }

                if (k.Blockiert || k.Verkauft || k.Reserviert)
                {
                    valid = false;
                    break;
                }
            }

            Assert.IsTrue(valid);
        }

        /// <summary>
        /// TF-12: Wöchentliches Filmprogramm abrufen.
        /// </summary>
        /// <description>
        /// Das wöchentliche Filmprogramm soll abgefragt werden. 
        /// </description>
        /// <precondition>
        /// - Es muss sich ein valides Filmprogramm in den Testdaten befinden.
        /// </precondition>
        /// <input>
        /// Keine direkte Eingabe des Benutzers.
        /// </input>
        /// <output>
        /// Keine direkte Ausgabe an den Benutzer.
        /// </output>
        /// <verification>
        /// Es wird überprüft:
        /// - ob ein Filmprogramm zurückgegeben wurde.
        /// - ob das Filmprogramm Vorstellungen besitzt.
        /// - ob das Filmprogramm die erwarteten Vorstellungen besitzt. 
        /// </verification>
        [TestMethod()]
        public void GetWöchentlichesFilmprogrammTest_Success()
        {
            KinokartenInformationen target = new KinokartenInformationen();
            List<Vorstellung> erwarteteVorstellungen = _vorstellungen.GetElements();
            IPublicFilmprogramm actual;
            actual = target.GetWöchentlichesFilmprogramm();
            
            // Ist ein Filmprogramm zurückgegeben worden?
            Assert.IsNotNull(actual);

            Assert.IsTrue(erwarteteVorstellungen.Count == actual.Vorstellungen.Count);

            bool valid = true;
            foreach (var publicVorstellung in actual.Vorstellungen)
            {
                valid = erwarteteVorstellungen.Exists(v => v.GetIdentifier() == publicVorstellung.GetIdentifier());
                if (!valid)
                {
                    break;
                }
            }

            Assert.IsTrue(valid);
        }

        /// <summary>
        /// TF-13: Altersfreigabenüberprüfung prüfen.
        /// </summary>
        /// <description>
        /// Geburtsdatum gegen den 
        /// </description>
        /// <precondition>
        /// - Es muss sich ein valides Filmprogramm in den Testdaten befinden.
        /// </precondition>
        /// <input>
        /// Keine direkte Eingabe des Benutzers.
        /// </input>
        /// <output>
        /// Keine direkte Ausgabe an den Benutzer.
        /// </output>
        /// <verification>
        /// Es wird überprüft:
        /// - ob ein Filmprogramm zurückgegeben wurde.
        /// - ob das Filmprogramm Vorstellungen besitzt.
        /// - ob das Filmprogramm die erwarteten Vorstellungen besitzt. 
        /// </verification>
        [TestMethod()]
        public void PrüfeAltersfreigabeFürVorstellungTest_Success()
        {
            KinokartenInformationen target = new KinokartenInformationen();
            IPublicVorstellung vorstellung = _gewählte_Vorstellung;
            DateTime geburtsdatum = new DateTime(1980, 6, 10); 
            bool expected = true;
            bool actual;
            actual = target.PrüfeAltersfreigabeFürVorstellung(vorstellung, geburtsdatum);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TF-14: Altersfreigabe prüfen.
        /// </summary>
        /// <description>
        /// Das wöchentliche Filmprogramm soll abgefragt werden. 
        /// </description>
        /// <precondition>
        /// - Es muss sich ein valides Filmprogramm in den Testdaten befinden.
        /// </precondition>
        /// <input>
        /// Keine direkte Eingabe des Benutzers.
        /// </input>
        /// <output>
        /// Keine direkte Ausgabe an den Benutzer.
        /// </output>
        /// <verification>
        /// Es wird überprüft:
        /// - ob ein Filmprogramm zurückgegeben wurde.
        /// - ob das Filmprogramm Vorstellungen besitzt.
        /// - ob das Filmprogramm die erwarteten Vorstellungen besitzt. 
        /// </verification>
        [TestMethod()]
        public void PrüfeAltersfreigabeFürVorstellungTest_Failure()
        {
            KinokartenInformationen target = new KinokartenInformationen();
            IPublicVorstellung vorstellung = _gewählte_Vorstellung;
            DateTime geburtsdatum = new DateTime(2005, 6, 10);
            bool expected = false;
            bool actual;
            actual = target.PrüfeAltersfreigabeFürVorstellung(vorstellung, geburtsdatum);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for PrüfeAltersfreigabeFürVorstellung
        ///</summary>
        [TestMethod()]
        public void PrüfeAltersfreigabeFürVorstellungTest1()
        {
            KinokartenInformationen target = new KinokartenInformationen(); // TODO: Initialize to an appropriate value
            IPublicVorstellung vorstellung = null; // TODO: Initialize to an appropriate value
            IKunde kunde = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.PrüfeAltersfreigabeFürVorstellung(vorstellung, kunde);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PrüfeVerfügbarkeitVonSitzplatzFürVorstellung
        ///</summary>
        [TestMethod()]
        public void PrüfeVerfügbarkeitVonSitzplatzFürVorstellungTest()
        {
            KinokartenInformationen target = new KinokartenInformationen(); // TODO: Initialize to an appropriate value
            IPublicVorstellung vorstellung = null; // TODO: Initialize to an appropriate value
            ISitz sitz = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.PrüfeVerfügbarkeitVonSitzplatzFürVorstellung(vorstellung, sitz);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
