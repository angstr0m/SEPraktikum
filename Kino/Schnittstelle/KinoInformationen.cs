using System.Collections.Generic;
using Database.Models;
using Kino.Models;

namespace Kino.Schnittstelle
{
    public class KinoInformationen : IKinoInformationen
    {
        private readonly EntityManager<Film> filme;
        private readonly EntityManager<Kinosaal> kinosäle;
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
            return tempKinosaal.GetSitzplätze();
        }

        public List<IKinosaal> GetKinosäle()
        {
            List<Kinosaal> tempList = kinosäle.GetElements();
            var returnList = new List<IKinosaal>();

            foreach (Kinosaal kinosaal in tempList)
            {
                returnList.Add(kinosaal);
            }

            return returnList;
        }

        public List<IFilm> GetFilme()
        {
            List<Film> tempList = filme.GetElements();
            var returnList = new List<IFilm>();

            foreach (Film film in tempList)
            {
                returnList.Add(film);
            }

            return returnList;
        }

        #endregion
    }
}