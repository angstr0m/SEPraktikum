using System.Collections.Generic;
using Cinema.Models;
using Database.Models;

namespace Cinema.Schnittstelle
{
    public class KinoInformationen : IKinoInformationen
    {
        private EntityManager<Kinosaal> kinosäle;
        private EntityManager<Film> filme;
        private EntityManager<Sitz> sitze;

        public KinoInformationen()
        {
            kinosäle = new EntityManager<Kinosaal>();
            filme = new EntityManager<Film>();
            sitze = new EntityManager<Sitz>();
        }

        #region Implementation of IKinoInformationen

        public List<ISitz> GetSitzplätzeInKinosaal(IKinosaal kinosaal)
        {
            Kinosaal tempKinosaal = kinosäle.GetElementWithId(kinosaal.GetIdentifier());
        }

        public List<IKinosaal> GetKinosäle()
        {
            List<Kinosaal> tempList = kinosäle.GetElements();
            List<IKinosaal> returnList = new List<IKinosaal>();

            foreach (Kinosaal kinosaal in tempList)
            {
                returnList.Add(kinosaal as IKinosaal);
            }

            return returnList;
        }

        public List<IFilm> GetFilme()
        {
            List<Film> tempList = filme.GetElements();
            List<IFilm> returnList = new List<IFilm>();

            foreach (Film film in tempList)
            {
                returnList.Add(film as IFilm);
            }

            return returnList;
        }

        #endregion
    }
}
