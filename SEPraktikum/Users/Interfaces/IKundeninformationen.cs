using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finances.Models;
using Users.Models;

namespace Users.Interfaces
{
    interface IKundeninformationen
    {
        void KundeHinzufügen(string name, List<Adress> adress, DateTime birthDateTime, string phone, float discount, Account account);

        void KundeEntfernen(IKunde kunde);

        IKunde GetKunde(int kundennummer);
    }
}
