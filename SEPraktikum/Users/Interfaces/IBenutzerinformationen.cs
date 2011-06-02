using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finances.Models;
using Users.Models;

namespace Users.Interfaces
{
    public interface IBenutzerinformationen
    {
        void KundeHinzufügen(string name, List<Adress> adress, DateTime birthDateTime, string phone, float discount, Zahlungsinformationen zahlungsinformationen);

        void KundeEntfernen(IKunde kunde);

        IKunde GetKunde(int kundennummer);

        IKunde GetBesucher();
     
    }
}
