using Cinema.Models;

namespace Cinema.Schnittstelle
{
    public class KinoAdministration : IKinoAdministration
    {
        #region Implementation of IKinoAdministration

        public void TestdatenEinrichten()
        {
            IFilm hdr1 = new Film("Herr der Ringe - Die Gefährten", "Adventure", 178, "USA", 12, "Elijah Wood, Ian McKellen, Orlando Bloom, Viggo Mortensen", "Peter Jackson");
            IFilm hdr2 = new Film("Der Herr der Ringe - Die zwei Türme", "Adventure", 179, "USA", 12, "Elijah Wood, Ian McKellen, Orlando Bloom, Viggo Mortensen", "Peter Jackson");
            IFilm hdr3 = new Film("Der Herr der Ringe - Die Rückkehr des Königs", "Adventure", 201, "USA", 12, "Elijah Wood, Ian McKellen, Orlando Bloom, Viggo Mortensen", "Peter Jackson");
            IFilm tron = new Film("TRON", "Sci-Fi", 96, "USA", 12, "Jeff Bridges, Bruce Boxleitner, David Warner", "Steven Lisberger");
            IFilm tron2 = new Film("TRON: Legacy", "Sci-Fi", 125, "USA", 12, "Jeff Bridges, Garrett Hedlund, Olivia Wilde", "Joseph Kosinski");

            IKinosaal saal1 = new Kinosaal("Saal 1", 10, 10);
            IKinosaal saal2 = new Kinosaal("Saal 2", 10, 10);
            IKinosaal saal3 = new Kinosaal("Saal 3", 10, 10);
        }

        #endregion
    }
}
