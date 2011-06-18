using SystemAdministration.Interfaces;
using Database.Models;
using Kino.Models;
using Kinokarten.Models;
using Kinokarten.Schnittstelle;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Kinokarten.Schnittstelle.Interfaces;
using Kino.Schnittstelle;
using System.Collections.Generic;
using NUnit.Framework;
using Users.Interfaces;
using Users.Models;
//using NUnit.Framework;
//using TestClass = NUnit.Framework.TestFixtureAttribute;
//using TestMethod = NUnit.Framework.TestAttribute;
//using TestCleanup = NUnit.Framework.TearDownAttribute;
//using TestInitialize = NUnit.Framework.SetUpAttribute;
//using ClassCleanup = NUnit.Framework.TestFixtureTearDownAttribute;
//using ClassInitialize = NUnit.Framework.TestFixtureSetUpAttribute;

using NUnitAssert = NUnit.Framework.Assert;

//using NUnitAssert = NUnit.Framework.Assert;



namespace TestAnwendungskern
{
    /// <summary>
    ///This is a test class for KinokartenInformationenTest and is intended
    ///to contain all KinokartenInformationenTest Unit Tests
    ///</summary>
    [TestFixture]
    public class KinokartenInformationenTest
    {
        EntityManager<Kinokarte> _kinokarten = new EntityManager<Kinokarte>();
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
        public static void InitializeTest(TestContext testContext)
        {
           
        }

        // Testdaten für jeden Test neu initialisieren
        [SetUp]
        public virtual void CreateTestData()
        {
            Console.WriteLine("Setup starts: " + DateTime.Now);

            

            Console.WriteLine("Filme erstellen Start: " + DateTime.Now);

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

            Console.WriteLine("Filme erstellen Ende: " + DateTime.Now);

            Console.WriteLine("Kinosäle erstellen Start: " + DateTime.Now);

            var saal1 = new Kinosaal("Saal 1", 10, 10);
            var saal2 = new Kinosaal("Saal 2", 10, 10);
            var saal3 = new Kinosaal("Saal 3", 10, 10);

            Console.WriteLine("Kinosäle erstellen Ende: " + DateTime.Now);

            Console.WriteLine("Vorstellungen erstellen Start: " + DateTime.Now);

            IKinoInformationen kinoinfo = new KinoInformationen();
            List<Film> filme = _filme.GetElements();
            List<Kinosaal> kinosäle = _kinosäle.GetElements();

            new Vorstellung(new DateTime(2011, 05, 26, 12, 00, 00, 00), filme[0],
                                               kinosäle[0], false, KinokartenPreis);
            new Vorstellung(new DateTime(2011, 05, 26, 13, 00, 00, 00), filme[1],
                                               kinosäle[1], false, KinokartenPreis);
            new Vorstellung(new DateTime(2011, 05, 26, 14, 00, 00, 00), filme[2],
                                               kinosäle[2], false, KinokartenPreis);
            new Vorstellung(new DateTime(2011, 05, 26, 18, 00, 00, 00), filme[3],
                                               kinosäle[0], false, KinokartenPreis);
            new Vorstellung(new DateTime(2011, 05, 26, 18, 00, 00, 00), filme[4],
                                               kinosäle[1], false, KinokartenPreis);
            new Vorstellung(new DateTime(2011, 05, 27, 12, 00, 00, 00), filme[0],
                                               kinosäle[0], false, KinokartenPreis);
            new Vorstellung(new DateTime(2011, 05, 27, 13, 00, 00, 00), filme[1],
                                               kinosäle[1], false, KinokartenPreis);
            new Vorstellung(new DateTime(2011, 05, 27, 14, 00, 00, 00), filme[2],
                                               kinosäle[2], false, KinokartenPreis);
            new Vorstellung(new DateTime(2011, 05, 27, 18, 00, 00, 00), filme[3],
                                               kinosäle[0], false, KinokartenPreis);
            new Vorstellung(new DateTime(2011, 05, 27, 18, 00, 00, 00), filme[4],
                                                kinosäle[1], false, KinokartenPreis);
            new Vorstellung(new DateTime(2011, 05, 28, 12, 00, 00, 00), filme[0],
                                                kinosäle[0], false, KinokartenPreis);
            new Vorstellung(new DateTime(2011, 05, 28, 13, 00, 00, 00), filme[1],
                                                kinosäle[1], false, KinokartenPreis);
            new Vorstellung(new DateTime(2011, 05, 28, 14, 00, 00, 00), filme[2],
                                                kinosäle[2], false, KinokartenPreis);
            new Vorstellung(new DateTime(2011, 05, 28, 18, 00, 00, 00), filme[3],
                                                kinosäle[0], false, KinokartenPreis);
            new Vorstellung(new DateTime(2011, 05, 28, 18, 00, 00, 00), filme[4],
                                                kinosäle[1], false, KinokartenPreis);

            Console.WriteLine("Vorstellungen erstellen Ende: " + DateTime.Now);

            var filmprogramm = new Filmprogramm(DateTime.Now, _vorstellungen.GetElements());

            _gewählte_Vorstellung = new PublicVorstellung(_filmprogramme.GetElements()[0].Vorstellungen[0]);
            _sitz = _gewählte_Vorstellung.VerfügbareKinokarten()[0].Sitz;

            Console.WriteLine("Setup ended: " + DateTime.Now);
        }

        [TearDown]
        public virtual void CleanUp()
        {
            Console.WriteLine("RemoveAllElementsBegin: " + DateTime.Now);
            
            _filme.RemoveAllElements();
            _kinosäle.RemoveAllElements();
            _vorstellungen.RemoveAllElements();
            _filmprogramme.RemoveAllElements();
            _kinokarten.RemoveAllElements();

            Console.WriteLine("RemoveAllElementsEnd: " + DateTime.Now);
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
        [Test]
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
        [Test]
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
        [Test]
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
            int i = 0;
            foreach (var publicVorstellung in actual.Vorstellungen)
            {
                valid = erwarteteVorstellungen.Exists(v => v.GetIdentifier() == publicVorstellung.GetIdentifier());
                if (!valid)
                {
                    break;
                }

                Console.WriteLine(i++);
            }

            Assert.IsTrue(valid);
        }

        /// <summary>
        /// TF-13: Altersfreigabenüberprüfung prüfen.
        /// </summary>
        /// <description>
        /// Das Geburtsdatum wírd mit der Altersfreigabe des Films der Vorstellung verglichen.
        /// </description>
        /// <precondition>
        /// - _gewählte_Vorstellung muss auf eine gültige Vorstellung verweisen
        /// - Der Film der gewählten Vorstellung muss eine Altersfreigabe muss kleiner gleich 18 besitzen.
        /// </precondition>
        /// <input>
        /// Keine direkte Eingabe des Benutzers.
        /// </input>
        /// <output>
        /// Keine direkte Ausgabe an den Benutzer.
        /// </output>
        /// <verification>
        /// Wird true zurückgegeben, wenn das Geburtsdatum ein anschauen der Vorstellung erlaubt?
        /// </verification>
        [Test]
        public void PrüfeAltersfreigabeFürVorstellungTest_Success()
        {
            KinokartenInformationen target = new KinokartenInformationen();
            IPublicVorstellung vorstellung = _gewählte_Vorstellung;
            DateTime geburtsdatum1 = (DateTime.Now.AddYears(-_gewählte_Vorstellung.Altersfreigabe)).AddDays(-1);
            DateTime geburtsdatum2 = (DateTime.Now.AddYears(-_gewählte_Vorstellung.Altersfreigabe)).AddYears(-5);
            bool expected = true;
            bool actual;

            actual = target.PrüfeAltersfreigabeFürVorstellung(vorstellung, geburtsdatum1);
            Assert.AreEqual(expected, actual);

            actual = target.PrüfeAltersfreigabeFürVorstellung(vorstellung, geburtsdatum2);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TF-14: Altersfreigabenüberprüfung prüfen.
        /// </summary>
        /// <description>
        /// Das Geburtsdatum wírd mit der Altersfreigabe des Films der Vorstellung verglichen.
        /// </description>
        /// <precondition>
        /// - _gewählte_Vorstellung muss auf eine gültige Vorstellung verweisen
        /// - Der Film der gewählten Vorstellung muss eine Altersfreigabe muss kleiner gleich 18 besitzen.
        /// </precondition>
        /// <input>
        /// Keine direkte Eingabe des Benutzers.
        /// </input>
        /// <output>
        /// Keine direkte Ausgabe an den Benutzer.
        /// </output>
        /// <verification>
        /// Wird false zurückgegeben, wenn das Geburtsdatum ein anschauen der Vorstellung verbietet?
        /// </verification>
        [Test]
        public void PrüfeAltersfreigabeFürVorstellungTest_Failure()
        {
            KinokartenInformationen target = new KinokartenInformationen();
            IPublicVorstellung vorstellung = _gewählte_Vorstellung;

            DateTime geburtsdatum1 = (DateTime.Now.AddYears(-_gewählte_Vorstellung.Altersfreigabe)).AddDays(1);
            DateTime geburtsdatum2 = (DateTime.Now.AddYears(-_gewählte_Vorstellung.Altersfreigabe)).AddYears(3);

            bool expected = false;
            bool actual;
            actual = target.PrüfeAltersfreigabeFürVorstellung(vorstellung, geburtsdatum1);
            Assert.AreEqual(expected, actual);

            actual = target.PrüfeAltersfreigabeFürVorstellung(vorstellung, geburtsdatum2);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TF-15: Altersfreigabenüberprüfung prüfen.
        /// </summary>
        /// <description>
        /// Das Geburtsdatum des Kunden wírd mit der Altersfreigabe des Films der Vorstellung verglichen.
        /// </description>
        /// <precondition>
        /// - _gewählte_Vorstellung muss auf eine gültige Vorstellung verweisen
        /// - Der Film der gewählten Vorstellung muss eine Altersfreigabe muss kleiner gleich 18 besitzen.
        /// </precondition>
        /// <input>
        /// Keine direkte Eingabe des Benutzers.
        /// </input>
        /// <output>
        /// Keine direkte Ausgabe an den Benutzer.
        /// </output>
        /// <verification>
        /// Wird true zurückgegeben, wenn das Geburtsdatum ein anschauen der Vorstellung erlaubt?
        /// </verification>
        [Test]
        public void PrüfeAltersfreigabeFürVorstellungTest1_Success()
        {
            KinokartenInformationen target = new KinokartenInformationen();
            IPublicVorstellung vorstellung = _gewählte_Vorstellung;

            DateTime geburtsdatum1 = (DateTime.Now.AddYears(-_gewählte_Vorstellung.Altersfreigabe)).AddDays(-1);
            DateTime geburtsdatum2 = (DateTime.Now.AddYears(-_gewählte_Vorstellung.Altersfreigabe)).AddYears(-5);
            IKunde kunde1 = new Kunde(1,"Testkunde",null, geburtsdatum1, "123", 0, null);
            IKunde kunde2 = new Kunde(1, "Testkunde", null, geburtsdatum2, "123", 0, null);
            
            bool expected = true;
            bool actual;

            actual = target.PrüfeAltersfreigabeFürVorstellung(vorstellung, kunde1);
            Assert.AreEqual(expected, actual);

            actual = target.PrüfeAltersfreigabeFürVorstellung(vorstellung, kunde2);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TF-16: Altersfreigabenüberprüfung prüfen.
        /// </summary>
        /// <description>
        /// Das Geburtsdatum des Kunden wírd mit der Altersfreigabe des Films der Vorstellung verglichen.
        /// </description>
        /// <precondition>
        /// - _gewählte_Vorstellung muss auf eine gültige Vorstellung verweisen
        /// - Der Film der gewählten Vorstellung muss eine geeignete Altersfreigabe besitzen.
        /// </precondition>
        /// <input>
        /// Keine direkte Eingabe des Benutzers.
        /// </input>
        /// <output>
        /// Keine direkte Ausgabe an den Benutzer.
        /// </output>
        /// <verification>
        /// Wird false zurückgegeben, wenn das Geburtsdatum ein anschauen der Vorstellung verbietet?
        /// </verification>
        [Test]
        public void PrüfeAltersfreigabeFürVorstellungTest1_Failure()
        {
            KinokartenInformationen target = new KinokartenInformationen();
            IPublicVorstellung vorstellung = _gewählte_Vorstellung;

            DateTime geburtsdatum1 = (DateTime.Now.AddYears(-_gewählte_Vorstellung.Altersfreigabe)).AddDays(1);
            DateTime geburtsdatum2 = (DateTime.Now.AddYears(-_gewählte_Vorstellung.Altersfreigabe)).AddYears(3);
            IKunde kunde1 = new Kunde(1, "Testkunde", null, geburtsdatum1, "123", 0, null);
            IKunde kunde2 = new Kunde(1, "Testkunde", null, geburtsdatum2, "123", 0, null);
            
            bool expected = false;
            bool actual;
            
            actual = target.PrüfeAltersfreigabeFürVorstellung(vorstellung, kunde1);
            Assert.AreEqual(expected, actual);

            actual = target.PrüfeAltersfreigabeFürVorstellung(vorstellung, kunde2);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TF-17: Verfügbarkeit von Sitzplatz prüfen
        /// </summary>
        /// <description>
        /// Der angegebene Sitzplatz wird auf Verfügbarkeit geprüft.
        /// Damit ein Sitzplatz verfügbar ist, muss die entsprechende Kinokarte der gewählten Vorstellung weder Reserviert, oder Verkauft sein.
        /// </description>
        /// <precondition>
        /// - _gewählte_Vorstellung muss auf eine gültige Vorstellung verweisen
        /// - Der Film der gewählten Vorstellung muss eine geeignete Altersfreigabe besitzen.
        /// </precondition>
        /// <input>
        /// Keine direkte Eingabe des Benutzers.
        /// </input>
        /// <output>
        /// Keine direkte Ausgabe an den Benutzer.
        /// </output>
        /// <verification>
        /// Wird false zurückgegeben, wenn das Geburtsdatum ein anschauen der Vorstellung verbietet?
        /// </verification>
        [Test]
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
