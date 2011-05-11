using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Interfaces
{
    public interface IDatabaseObject
    {
        void SetIdentifier(int id);

        int GetIdentifier();
    }
}
