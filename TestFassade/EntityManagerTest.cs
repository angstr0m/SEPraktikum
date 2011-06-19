using Database.Models;
using Kino.Models;
using Kinokarten.Models;
using NUnit.Framework;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Database.Interfaces;
using System.Collections.Generic;
using Base.AbstractClasses;

namespace TestAnwendungskern
{
    
    
    /// <summary>
    ///This is a test class for EntityManagerTest and is intended
    ///to contain all EntityManagerTest Unit Tests
    ///</summary>
    [TestFixture]
    public class EntityManagerTest
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
        ///A test for EntityManager`1 Constructor
        ///</summary>
        public void EntityManagerConstructorTestHelper<T>()
            where T : IDatabaseObject
        {
            EntityManager<T> target = new EntityManager<T>();
        }

        /// <summary>
        /// TF-19: EntityManager Constructor prüfen
        /// </summary>
        /// <description>
        /// Es wird geprüft, ob ein EntityManager, für mehrere verschiedene Datentypen, erfolgreich erstellt werden kann. 
        /// </description>
        /// <precondition>
        /// 
        /// </precondition>
        /// <input>
        /// Keine direkte Eingabe des Benutzers.
        /// </input>
        /// <output>
        /// Keine direkte Ausgabe an den Benutzer.
        /// </output>
        /// <verification>
        /// Es wird verifiziert, dass das erzeugen meherer Entity-Manager, mit verschiedenen von IDatabaseObject abgeleiteten Klassen, keine Exceptions verursacht.
        /// </verification>
        [Test]
        public void EntityManagerConstructorTest()
        {
            Assert.DoesNotThrow(delegate { EntityManager<Film> target = new EntityManager<Film>(); });
            Assert.DoesNotThrow(delegate { EntityManager<Kinokarte> target = new EntityManager<Kinokarte>(); });
            Assert.DoesNotThrow(delegate { EntityManager<Sitz> target = new EntityManager<Sitz>(); });
        }

        /// <summary>
        ///A test for AddElement
        ///</summary>
        public void AddElementTestHelper<T>(T elementToAdd)
            where T : IDatabaseObject
        {
            EntityManager<T> target = new EntityManager<T>();
            T elem = elementToAdd;
            target.AddElement(elem);

            DatabaseSimulation database = DatabaseSimulation.Instance;

            List<T> actual = database.GetValuesFromDatabaseForType(typeof (T));

            // Tests durchführen
            Assert.NotNull(actual);
            Assert.True(actual.GetType() == typeof(List<T>));
            Assert.True(actual.Count != 0);
            Assert.True(actual[0].Equals(elementToAdd));

            // Aufräumen
            database.RemoveAllValuesFromDatabaseForType(typeof(T));
        }

        /// <summary>
        /// TF-20: AddElement prüfen
        /// </summary>
        /// <description>
        /// Es wird geprüft, ob ein EntityManager Objekte erfolgreich zur Datenbank hinzufügen kann. 
        /// </description>
        /// <precondition>
        /// 
        /// </precondition>
        /// <input>
        /// Keine direkte Eingabe des Benutzers.
        /// </input>
        /// <output>
        /// Keine direkte Ausgabe an den Benutzer.
        /// </output>
        /// <verification>
        /// Es wird verifiziert:
        /// - der Eintrag in der Datenbank darf nicht null sein
        /// - der Eintrag in der Datenbank muss den entsprechenden Typ besitzen
        /// - der Eintrag in der Datenbank muss gleich dem Element sein, welches AddElement in die Datenbank schreiben soll
        /// </verification>
        [Test]
        public void AddElementTest()
        {
            AddElementTestHelper(new Kinosaal("Testkinosaal", 10, 10));
        }

        /// <summary>
        ///A test for GetElementWithId
        ///</summary>
        public void GetElementWithIdTestHelper<T>()
            where T : IDatabaseObject
        {
            EntityManager<T> target = new EntityManager<T>(); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            T expected = default(T); // TODO: Initialize to an appropriate value
            T actual;
            actual = target.GetElementWithId(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        /// TF-21: GetElementWithId prüfen
        /// </summary>
        /// <description>
        /// Es wird geprüft, ob ein EntityManager Objekte erfolgreich zur Datenbank hinzufügen kann. 
        /// </description>
        /// <precondition>
        /// 
        /// </precondition>
        /// <input>
        /// Keine direkte Eingabe des Benutzers.
        /// </input>
        /// <output>
        /// Keine direkte Ausgabe an den Benutzer.
        /// </output>
        /// <verification>
        /// Es wird verifiziert:
        /// - der Eintrag in der Datenbank darf nicht null sein
        /// - der Eintrag in der Datenbank muss den entsprechenden Typ besitzen
        /// - der Eintrag in der Datenbank muss gleich dem Element sein, welches AddElement in die Datenbank schreiben soll
        /// </verification>
        [Test]
        public void GetElementWithIdTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call GetElementWithIdTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for GetElements
        ///</summary>
        public void GetElementsTestHelper<T>()
            where T : IDatabaseObject
        {
            EntityManager<T> target = new EntityManager<T>(); // TODO: Initialize to an appropriate value
            List<T> expected = null; // TODO: Initialize to an appropriate value
            List<T> actual;
            actual = target.GetElements();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [Test]
        public void GetElementsTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call GetElementsTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for GetFreeIdentifier
        ///</summary>
        public void GetFreeIdentifierTestHelper<T>()
            where T : IDatabaseObject
        {
            EntityManager_Accessor<T> target = new EntityManager_Accessor<T>(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetFreeIdentifier();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [Test]
        //[DeploymentItem("Database.dll")]
        public void GetFreeIdentifierTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call GetFreeIdentifierTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for RemoveAllElements
        ///</summary>
        public void RemoveAllElementsTestHelper<T>()
            where T : IDatabaseObject
        {
            EntityManager<T> target = new EntityManager<T>(); // TODO: Initialize to an appropriate value
            target.RemoveAllElements();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [Test]
        public void RemoveAllElementsTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call RemoveAllElementsTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for RemoveElement
        ///</summary>
        public void RemoveElementTestHelper<T>()
            where T : IDatabaseObject
        {
            EntityManager<T> target = new EntityManager<T>(); // TODO: Initialize to an appropriate value
            T elem = default(T); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.RemoveElement(elem);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [Test]
        public void RemoveElementTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call RemoveElementTestHelper<T>() with appropriate type parameters.");
        }
    }
}
