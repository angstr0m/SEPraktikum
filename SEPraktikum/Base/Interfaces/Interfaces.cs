using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base
{
    //public interface Model : Subject
    //{
    //    void AddObserver(Interfaces.View view);
    //    void RemoveObserver(Interfaces.View view);
    //    void NotifyObservers();
    //}

    public interface Model
    {
    }

    public interface Controller
    {
    }

    public interface View
    {
        //void setModel<T>(T model) where T : Model;
        //void setController<T>(T controller) where T : Controller;
    }

    public interface Observer
    {
        void UpdateObserver<T>(T subject) where T : Subject;
    }

    
}
