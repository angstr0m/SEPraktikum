using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.InterfaceMembers
{
    public interface IKinoInformationen
    {
        List<ISitz> GetSitzplätzeInKinosaal(IKinosaal kinosaal);

        List<IKinosaal> GetKinosäle();

        List<IFilm> GetFilme();
    }
}
