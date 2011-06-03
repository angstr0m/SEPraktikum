using System.Collections.Generic;

namespace Kino.Schnittstelle
{
    public interface IKinoInformationen
    {
        List<ISitz> GetSitzplätzeInKinosaal(IKinosaal kinosaal);

        List<IKinosaal> GetKinosäle();

        List<IFilm> GetFilme();
    }
}