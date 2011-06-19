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
    internal class TestElement : IDatabaseObject
    {
        #region Implementation of IDatabaseObject

        private int _id;

        public void SetIdentifier(int id)
        {
            _id = id;
        }

        public int GetIdentifier()
        {
            return _id;
        }

        #endregion
    }

    internal class PublicTestElement : IDatabaseObject
    {
        private TestElement _testElement;

        public PublicTestElement(TestElement privateElement)
        {
            _testElement = privateElement;
        }


        #region Implementation of IDatabaseObject

        private int _id;

        public void SetIdentifier(int id)
        {
            _testElement.SetIdentifier(id);
        }

        public int GetIdentifier()
        {
            return _testElement.GetIdentifier();
        }

        #endregion
    }
    
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
            Assert.DoesNotThrow(delegate { EntityManager<TestElement> target = new EntityManager<TestElement>(); });
            //Assert.DoesNotThrow(delegate { EntityManager<Film> target = new EntityManager<Film>(); });
            //Assert.DoesNotThrow(delegate { EntityManager<Kinokarte> target = new EntityManager<Kinokarte>(); });
            //Assert.DoesNotThrow(delegate { EntityManager<Sitz> target = new EntityManager<Sitz>(); });
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
            AddElementTestHelper(new TestElement());
        }

        /// <summary>
        ///A test for GetElementWithId
        ///</summary>
        public void GetElementWithIdTestHelper<T,I>(T element, I publicElement)
            where T : IDatabaseObject
            where I : IDatabaseObject
        {
            EntityManager<T> target = new EntityManager<T>();

            target.AddElement(element);

            int id = publicElement.GetIdentifier();
            T expected = element;
            T actual;
            actual = target.GetElementWithId(id);
            Assert.AreEqual(expected, actual);

            // Aufräumen
            target.RemoveAllElements();
        }

        /// <summary>
        /// TF-21: GetElementWithId prüfen
        /// </summary>
        /// <description>
        /// Es wird geprüft, ob ein Public-Objekt korrekt mit einem private Objekt in der Datenbank verknüpft werden kann. 
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
        /// - das das richtige, dem PublicTestELement zugehörige, TestElement zurückgegeben wird.
        /// </verification>
        [Test]
        public void GetElementWithIdTest()
        {
            TestElement testElement = new TestElement();
            PublicTestElement publicTestElement = new PublicTestElement(testElement);

            GetElementWithIdTestHelper(testElement, publicTestElement);
        }

        /// <summary>
        ///A test for GetElements
        ///</summary>
        public void GetElementsTestHelper<T>(List<T> testElements)
            where T : IDatabaseObject
        {
            EntityManager<T> target = new EntityManager<T>();
            List<T> expected = testElements;
            List<T> actual;

            // Elemente hinzufügen
            foreach (var elem in testElements)
            {
                target.AddElement(elem);
            }

            actual = target.GetElements();
            
            Assert.True(actual.Count == expected.Count);

            // Sind alle erwarteten Elemente enthalten?
            foreach (var elem in expected)
            {
                Assert.True(actual.Exists(delegate(T e) { return e.Equals(elem); }));
            }

            // Aufräumen
            target.RemoveAllElements();
        }

        /// <summary>
        /// TF-22: GetElements prüfen
        /// </summary>
        /// <description>
        /// Es wird geprüft, ob GetElements alle zuvor eingegebenen Objekte zuverlässig wieder zurück gibt. 
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
        /// - das die richtige Anzahl an Elementen zurückgegeben wird.
        /// - das die richtigen Elemente zurückgegeben werden.
        /// </verification>
        [Test]
        public void GetElementsTest()
        {
            List<TestElement> testElemente = new List<TestElement>();

            for (int i = 0; i < 10; i++)
            {
                testElemente.Add(new TestElement());
            }

            GetElementsTestHelper(testElemente);
        }

        /// <summary>
        ///A test for GetFreeIdentifier
        ///</summary>
        public void GetFreeIdentifierTestHelper<T>(List<T> testElements)
            where T : IDatabaseObject
        {
            EntityManager_Accessor<T> target = new EntityManager_Accessor<T>();
            int expected = testElements.Count;
            int actual;

            foreach (var testElement in testElements)
            {
                target.AddElement(testElement);    
            }
            
            actual = target.GetFreeIdentifier();
            Assert.AreEqual(expected, actual);

            if (testElements.Count > 0)
            {
                // Zufällig ein Element aus der Datenbank löschen.
                // Der Identifier dieses Objekts sollte nun wieder frei sein.
                Random random = new Random();

                T elementToRemove = testElements[random.Next(testElements.Count)];
                expected = elementToRemove.GetIdentifier();

                target.RemoveElement(elementToRemove);

                actual = target.GetFreeIdentifier();
                Assert.AreEqual(expected, actual);
            }

            // Aufräumen
            target.RemoveAllElements();
        }

        /// <summary>
        /// TF-23: GetFreeIdentifier prüfen
        /// </summary>
        /// <description>
        /// Es wird geprüft, ob bei verschiedenen Anzahlen von Elementen in der Datenbank, jeweils ein gültiger freier Identifier zurückgegeben wird. 
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
        /// - das der zurückgegebene Identifier der Anzahl der Elemente in der Datenbank entspricht.
        /// - ob bei dem Löschen eines Objekts dessen Identifikator wieder freí wird.
        /// </verification>
        [Test]
        //[DeploymentItem("Database.dll")]
        public void GetFreeIdentifierTest()
        {
            int[] testAnzahlen = new int[] { 0, 1, 2, 3, 7, 8, 10, 100, 300, 333 };

            foreach (var i in testAnzahlen)
            {
                List<TestElement> testElements = new List<TestElement>();

                for (int j = 0; j < i; j++)
                {
                    testElements.Add(new TestElement());
                }

                GetFreeIdentifierTestHelper(testElements);
            }
        }

        /// <summary>
        ///A test for RemoveAllElements
        ///</summary>
        public void RemoveAllElementsTestHelper<T>(List<T> testElements)
            where T : IDatabaseObject
        {
            EntityManager<T> target = new EntityManager<T>();

            foreach (var testElement in testElements)
            {
                target.AddElement(testElement);
            }

            target.RemoveAllElements();
            Assert.Null(DatabaseSimulation.Instance.GetValuesFromDatabaseForType(typeof(T)));
        }

        /// <summary>
        /// TF-24: RemoveAllElements prüfen
        /// </summary>
        /// <description>
        /// Es wird geprüft, ob bei verschiedenen Anzahlen von Elementen in der Datenbank, das löschen aller Elemente erfolgreich ist. 
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
        /// - das in der Datenbank, nach dem Löschen, keine Elemente des entsprechenden Typs mehr verbleiben.
        /// </verification>
        [Test]
        public void RemoveAllElementsTest()
        {
            int[] testAnzahlen = new int[] { 0, 1, 2, 3, 7, 8, 10, 100, 300, 333 };

            foreach (var i in testAnzahlen)
            {
                List<TestElement> testElements = new List<TestElement>();

                for (int j = 0; j < i; j++)
                {
                    testElements.Add(new TestElement());
                }

                RemoveAllElementsTestHelper(testElements);
            }
        }

        /// <summary>
        ///A test for RemoveElement
        ///</summary>
        public void RemoveElementTestHelper<T>(List<T> testElements, T element)
            where T : IDatabaseObject
        {
            if (testElements.Count == 0)
            {
                return;
            }

            Random random = new Random();
            T elementToRemove = testElements[random.Next(testElements.Count)];

            EntityManager<T> target = new EntityManager<T>();
            DatabaseSimulation databaseSimulation = DatabaseSimulation.Instance;
            T elem = elementToRemove;
            bool expected = true;
            bool actual;

            foreach (var testElement in testElements)
            {
                target.AddElement(testElement);
            }

            actual = target.RemoveElement(elem);
            Assert.AreEqual(expected, actual);

            // Das Element darf nicht mehrfach gelöscht werden können. 
            expected = false;

            actual = target.RemoveElement(elem);
            Assert.AreEqual(expected, actual);

            List<T> valuesInDatabase = databaseSimulation.GetValuesFromDatabaseForType(typeof(T));

            // Sicherstellen, das das Objekt wirklich aus der Datenbank gelöscht wurde.
            if (testElements.Count == 1)
            {
                Assert.True(valuesInDatabase.Count == 0);
            } else
            {
                Assert.False(valuesInDatabase.Contains(elementToRemove));
                Console.WriteLine("testElements: " + testElements.Count);
                Console.WriteLine(valuesInDatabase.Count);
                Assert.True(valuesInDatabase.Count == (testElements.Count - 1));
            }

            // Das versuchte löschen eines Objektes, welches sich nicht in der Datenbank befindet, darf keine Exceptions produzieren.
            Assert.DoesNotThrow(delegate { target.RemoveElement(element); });

            // Aufräumen
            target.RemoveAllElements();
        }

        /// <summary>
        /// TF-25: RemoveElementTest prüfen
        /// </summary>
        /// <description>
        /// Es wird geprüft, ob bei verschiedenen Anzahlen von Elementen in der Datenbank, das löschen eines Elements erfolgreich ist. 
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
        /// - das in der Datenbank, nach dem Löschen, das entsprechende Element nicht mehr vorhanden ist.
        /// </verification>
        [Test]
        public void RemoveElementTest()
        {
            int[] testAnzahlen = new int[] { 0, 1, 2, 3, 7, 8, 10, 100, 300, 333 };

            foreach (var i in testAnzahlen)
            {
                List<TestElement> testElements = new List<TestElement>();

                for (int j = 0; j < i; j++)
                {
                    testElements.Add(new TestElement());
                }

                RemoveElementTestHelper(testElements, new TestElement());
            }
        }
    }
}
