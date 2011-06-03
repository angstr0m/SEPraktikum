namespace Kino.Models
{
    internal class SitzIdentifikator
    {
        private readonly int _nummer;
        private readonly char _reihe;

        public SitzIdentifikator(char reihe, int nummer)
        {
            _reihe = reihe;
            _nummer = nummer;
        }

        public int Nummer
        {
            get { return _nummer; }
        }

        public char Reihe
        {
            get { return _reihe; }
        }
    }
}