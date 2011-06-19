using Kinokarten.Schnittstelle;
using System;
using Users.Interfaces;
using Kinokarten.Schnittstelle.Interfaces;
using Kino.Schnittstelle;
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
    ///This is a test class for KinokartenOperationenTest and is intended
    ///to contain all KinokartenOperationenTest Unit Tests
    ///</summary>
    [TestFixture]
    public class KinokartenOperationenTest
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


        /// <summary>
        ///A test for KinokartenOperationen Constructor
        ///</summary>
        [Test]
        public void KinokartenOperationenConstructorTest()
        {
            IBenutzerinformationen benutzerinformationen = null; // TODO: Initialize to an appropriate value
            KinokartenOperationen target = new KinokartenOperationen(benutzerinformationen);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BlockiereKinokarte
        ///</summary>
        [Test]
        public void BlockiereKinokarteTest()
        {
            IBenutzerinformationen benutzerinformationen = null; // TODO: Initialize to an appropriate value
            KinokartenOperationen target = new KinokartenOperationen(benutzerinformationen); // TODO: Initialize to an appropriate value
            IPublicVorstellung vorstellung = null; // TODO: Initialize to an appropriate value
            ISitz sitz = null; // TODO: Initialize to an appropriate value
            IKinokarteBlockierungZugangsSchlüssel expected = null; // TODO: Initialize to an appropriate value
            IKinokarteBlockierungZugangsSchlüssel actual;
            actual = target.BlockiereKinokarte(vorstellung, sitz);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BlockierungFürSitzplatzAufheben
        ///</summary>
        [Test]
        public void BlockierungFürSitzplatzAufhebenTest()
        {
            IBenutzerinformationen benutzerinformationen = null; // TODO: Initialize to an appropriate value
            KinokartenOperationen target = new KinokartenOperationen(benutzerinformationen); // TODO: Initialize to an appropriate value
            IPublicVorstellung vorstellung = null; // TODO: Initialize to an appropriate value
            ISitz sitz = null; // TODO: Initialize to an appropriate value
            IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel = null; // TODO: Initialize to an appropriate value
            target.BlockierungFürSitzplatzAufheben(vorstellung, sitz, zugangsSchlüssel);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for KinokarteReservieren
        ///</summary>
        [Test]
        public void KinokarteReservierenTest()
        {
            IBenutzerinformationen benutzerinformationen = null; // TODO: Initialize to an appropriate value
            KinokartenOperationen target = new KinokartenOperationen(benutzerinformationen); // TODO: Initialize to an appropriate value
            IPublicVorstellung vorstellung = null; // TODO: Initialize to an appropriate value
            ISitz sitz = null; // TODO: Initialize to an appropriate value
            bool rabatt = false; // TODO: Initialize to an appropriate value
            IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.KinokarteReservieren(vorstellung, sitz, rabatt, zugangsSchlüssel);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for KinokarteReservieren
        ///</summary>
        [Test]
        public void KinokarteReservierenTest1()
        {
            IBenutzerinformationen benutzerinformationen = null; // TODO: Initialize to an appropriate value
            KinokartenOperationen target = new KinokartenOperationen(benutzerinformationen); // TODO: Initialize to an appropriate value
            int kundennummer = 0; // TODO: Initialize to an appropriate value
            IPublicVorstellung vorstellung = null; // TODO: Initialize to an appropriate value
            ISitz sitz = null; // TODO: Initialize to an appropriate value
            bool rabatt = false; // TODO: Initialize to an appropriate value
            IKinokarteBlockierungZugangsSchlüssel zugangsSchlüssel = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.KinokarteReservieren(kundennummer, vorstellung, sitz, rabatt, zugangsSchlüssel);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
