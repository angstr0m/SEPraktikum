﻿using System.Collections.Generic;
using Database.Models;
using Cinema.Models;

namespace Cinema.Schnittstelle
{
    public interface IKinoInformationen
    {
        List<ISitz> GetSitzplätzeInKinosaal(IKinosaal kinosaal);

        List<IKinosaal> GetKinosäle();

        List<IFilm> GetFilme();

        
        
    }
}