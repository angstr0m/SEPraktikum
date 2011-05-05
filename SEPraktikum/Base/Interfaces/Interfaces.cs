using Base.AbstractClasses;

namespace Base.Interfaces
{

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
