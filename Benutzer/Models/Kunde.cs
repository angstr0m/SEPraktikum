using System;
using System.Collections.Generic;
using Finances.Models;
using Users.Interfaces;

namespace Users.Models
{
    public class Kunde : Benutzer, IKunde
    {
        private readonly List<Adress> _adresse;
        private readonly DateTime _geburtsdatum;
        private readonly int _kundennummer;
        private readonly float _rabatt;
        private readonly String _telefonnummer;
        private readonly string name;
        private readonly Zahlungsinformationen zahlungsinformationen;
        private int id;

        public Kunde(int _kundennummer, string name, List<Adress> _adresse, DateTime _geburtsdatum,
                     string _telefonnummer, float _rabatt, Zahlungsinformationen zahlungsinformationen)
        {
            this.name = name;
            this._kundennummer = _kundennummer;
            this._adresse = _adresse;
            this._geburtsdatum = _geburtsdatum;
            this._telefonnummer = _telefonnummer;
            this._rabatt = _rabatt;
            this.zahlungsinformationen = zahlungsinformationen;
        }

        #region IKunde Members

        public Zahlungsinformationen Zahlungsinformationen
        {
            get { return zahlungsinformationen; }
        }

        public float Rabatt
        {
            get { return _rabatt; }
        }

        public string Telefonnummer
        {
            get { return _telefonnummer; }
        }

        public DateTime Geburtsdatum
        {
            get { return _geburtsdatum; }
        }

        public List<Adress> Adresse
        {
            get { return _adresse; }
        }

        public string Name
        {
            get { return name; }
        }

        public int Kundennummer
        {
            get { return _kundennummer; }
        }

        public int Id
        {
            get { return id; }
        }

        public void AddAdress(Adress newAdress)
        {
            throw new Exception("Not implemented");
        }

        public void RemoveAdress(Adress adress)
        {
            throw new Exception("Not implemented");
        }

        #endregion

        public void SetIdentifier(int id)
        {
            this.id = id;
        }

        public int GetIdentifier()
        {
            return id;
        }
    }
}