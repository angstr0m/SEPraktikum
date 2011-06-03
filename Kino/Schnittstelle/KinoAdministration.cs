﻿using Database.Models;
using Kino.Models;

namespace Kino.Schnittstelle
{
    public class KinoAdministration : IKinoAdministration
    {
        #region Implementation of IKinoAdministration

        private EntityManager<Film> filme;
        private EntityManager<Kinosaal> kinosaele;


        public void TestdatenEinrichten()
        {
            filme = new EntityManager<Film>();
            kinosaele = new EntityManager<Kinosaal>();

            filme.RemoveAllElements();
            kinosaele.RemoveAllElements();


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

            filme.AddElement(hdr1);
            filme.AddElement(hdr2);
            filme.AddElement(hdr3);
            filme.AddElement(tron);
            filme.AddElement(tron2);

            kinosaele.AddElement(saal1);
            kinosaele.AddElement(saal2);
            kinosaele.AddElement(saal3);
        }

        #endregion
    }
}