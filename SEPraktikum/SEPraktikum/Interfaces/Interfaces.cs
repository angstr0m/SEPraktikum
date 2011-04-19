using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEPraktikum.Interfaces
{
    public interface Model
    {
        void AddObserver(Interfaces.View view);
        void RemoveObserver(Interfaces.View view);
        void NotifyObservers();
    }

    public interface View
    {
        void Update(Interfaces.Model model);
    }

    public interface Controller
    {
        public void SetModel(Interfaces.Model model);
        public void SetView(Interfaces.View view);
    }
}
