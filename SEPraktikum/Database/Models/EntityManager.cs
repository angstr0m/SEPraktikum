using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Base.AbstractClasses;

namespace Database.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks></remarks>
    public class EntityManager<T> : Subject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityManager&lt;T&gt;"/> class.
        /// </summary>
        /// <remarks></remarks>
        public EntityManager()
        {
        }

        /// <summary>
        /// Adds the element.
        /// </summary>
        /// <param name="elem">The elem.</param>
        /// <remarks></remarks>
        public void AddElement(T elem)
        {
            DatabaseSimulation.Instance.AddValueToDatabase(elem);
        }

        /// <summary>
        /// Removes the element.
        /// </summary>
        /// <param name="elem">The elem.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool RemoveElement(T elem)
        {
            return DatabaseSimulation.Instance.RemoveValueFromDatabase(elem);
        }

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<T> GetElements()
        {
            List<T> returnList = DatabaseSimulation.Instance.GetValuesFromDatabaseForType(typeof (T));
            if(returnList == null)
            {
                return new List<T>();
            } else
            {
                return returnList;
            }
        }

        /// <summary>
        /// Adds the observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <remarks></remarks>
        public override void AddObserver(Base.Interfaces.Observer observer)
        {
            DatabaseSimulation.Instance.AddObserver(observer);
        }

        /// <summary>
        /// Notifies the observers.
        /// </summary>
        /// <remarks></remarks>
        public override void NotifyObservers()
        {
            base.NotifyObservers();
        }

        /// <summary>
        /// Removes the observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <remarks></remarks>
        public override void RemoveObserver(Base.Interfaces.Observer observer)
        {
            DatabaseSimulation.Instance.RemoveObserver(observer);
        }
    }
}
