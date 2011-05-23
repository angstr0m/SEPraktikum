using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database.Models;
using Users.Models;

namespace Users.Interfaces
{
    class Kundeninformationen : IKundeninformationen
    {
        private EntityManager<IKunde> _daten_ikunde;
        private int benutzteKundennummern = 0;
        
        private void EntityManagerInitialisieren()
        {
            if (_daten_ikunde == null)
            {
                _daten_ikunde = new EntityManager<IKunde>();
            }
        }

        public void KundeHinzufügen(string name, List<Models.Adress> adress, DateTime birthDateTime, string phone, float discount, Finances.Models.Account account)
        {
            EntityManagerInitialisieren();

            benutzteKundennummern ++;

            _daten_ikunde.AddElement(new Kunde(benutzteKundennummern ,name, adress,birthDateTime, phone, discount, account));
        }

        public void KundeEntfernen(IKunde kunde)
        {
            _daten_ikunde.RemoveElement(kunde);
        }

        public IKunde GetKunde(int kundennummer)
        {
            return _daten_ikunde.GetElements().Find(delegate(IKunde k) { return k.CustomerId == kundennummer; });
        }
    }
}
