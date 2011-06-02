using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database.Models;
using Users.Models;

namespace Users.Interfaces
{
    public class Benutzerinformationen : IBenutzerinformationen
    {
        private EntityManager<IKunde> _daten_ikunde;
        private IKunde Besucher;
        private int benutzteKundennummern = 0;
        
        private void EntityManagerInitialisieren()
        {
            if (_daten_ikunde == null)
            {
                _daten_ikunde = new EntityManager<IKunde>();
            }
        }

        public Benutzerinformationen()
        {
            EntityManagerInitialisieren();
            
            KundeHinzufügen("Besucher", null,new DateTime(), null,0,null);
        }

        public void KundeHinzufügen(string name, List<Models.Adress> adress, DateTime birthDateTime, string phone, float discount, Finances.Models.Zahlungsinformationen zahlungsinformationen)
        {
            _daten_ikunde.AddElement(new Kunde(benutzteKundennummern ,name, adress,birthDateTime, phone, discount, zahlungsinformationen));

            benutzteKundennummern++;
        }

        public void KundeEntfernen(IKunde kunde)
        {
            _daten_ikunde.RemoveElement(kunde);
        }

        public IKunde GetKunde(int kundennummer)
        {
            return _daten_ikunde.GetElements().Find(delegate(IKunde k) { return k.Kundennummer == kundennummer; });
        }

        public IKunde GetBesucher()
        {
            return _daten_ikunde.GetElements().Find(delegate(IKunde k) { return k.Name == "Besucher"; });
        }
       
    }
}
