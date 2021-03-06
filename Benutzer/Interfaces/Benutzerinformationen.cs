﻿using System;
using System.Collections.Generic;
using Database.Models;
using Finances.Models;
using Users.Models;

namespace Users.Interfaces
{
    public class Benutzerinformationen : IBenutzerinformationen
    {
        private IKunde Besucher;
        private EntityManager<IKunde> _daten_ikunde;
        private int benutzteKundennummern;

        public Benutzerinformationen()
        {
            EntityManagerInitialisieren();

            KundeHinzufügen("Besucher", null, new DateTime(), null, 0, null);
        }

        #region IBenutzerinformationen Members

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

        #endregion

        public void KundeHinzufügen(string name, List<Adress> adress, DateTime birthDateTime, string phone,
                                    float discount, Zahlungsinformationen zahlungsinformationen)
        {
            _daten_ikunde.AddElement(new Kunde(benutzteKundennummern, name, adress, birthDateTime, phone, discount,
                                               zahlungsinformationen));

            benutzteKundennummern++;
        }

        private void EntityManagerInitialisieren()
        {
            if (_daten_ikunde == null)
            {
                _daten_ikunde = new EntityManager<IKunde>();
            }
        }
    }
}