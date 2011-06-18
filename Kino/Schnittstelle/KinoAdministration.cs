using Database.Models;
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
        }

        #endregion
    }
}