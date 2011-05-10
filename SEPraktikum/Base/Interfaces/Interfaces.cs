using Base.AbstractClasses;

namespace Base.Interfaces
{

    /// <summary>
    /// Used for shared properties of all models.
    /// </summary>
    /// <remarks></remarks>
    public interface Model
    {
    }

    /// <summary>
    /// Used for shared properties of all controllers.
    /// </summary>
    /// <remarks></remarks>
    public interface Controller
    {
    }

    /// <summary>
    /// Used for shared properties of all views.
    /// </summary>
    /// <remarks></remarks>
    public interface View
    {
        //void setModel<T>(T model) where T : Model;
        //void setController<T>(T controller) where T : Controller;
    }

    /// <summary>
    /// Observer functionality of the MVC-Pattern.
    /// </summary>
    /// <remarks></remarks>
    public interface Observer
    {
        /// <summary>
        /// The subject will call this method to notify the observer of an update. See MVC-Pattern.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject">The subject.</param>
        /// <remarks></remarks>
        void UpdateObserver<T>(T subject) where T : Subject;
    }

    
}
