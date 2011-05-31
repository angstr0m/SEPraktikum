namespace Cinema.Models
{
    internal class SitzIdentifikator
    {
        private char _reihe;
        private int _nummer;

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
