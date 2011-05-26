﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Models;
using Database.Models;

namespace Cinema.InterfaceMembers
{
    public class KinoInformationen : IKinoInformationen
    {
        private EntityManager<Kinosaal> kinosäle;
        private EntityManager<Film> filme;
        private EntityManager<Sitz> sitze;

        KinoInformationen()
        {
            kinosäle = new EntityManager<Kinosaal>();
            filme = new EntityManager<Film>();
            sitze = new EntityManager<Sitz>();
        }

        #region Implementation of IKinoInformationen

        public List<ISitz> GetSitzplätzeInKinosaal(IKinosaal kinosaal)
        {
            throw new NotImplementedException();
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
