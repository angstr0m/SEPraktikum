using Database.Interfaces;

namespace Kino.Schnittstelle
{
    public interface IFilm : IDatabaseObject
    {
        string Regisseur { get; }
        string Schauspieler { get; }
        int Altersfreigabe { get; }
        string HerkunftsLand { get; }
        int Dauer { get; }
        string Genre { get; }
        string Name { get; }
    }
}