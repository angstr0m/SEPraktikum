using System;
using Base.Interfaces;

namespace Cinema.Schnittstelle
{
    public interface IFilm
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