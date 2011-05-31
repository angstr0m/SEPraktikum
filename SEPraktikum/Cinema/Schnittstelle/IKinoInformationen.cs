using System.Collections.Generic;

namespace Cinema.Schnittstelle
{
    public interface IKinoInformationen
    {
        List<ISitz> GetSitzplätzeInKinosaal(IKinosaal kinosaal);

        List<IKinosaal> GetKinosäle();

        List<IFilm> GetFilme();
    }
}
