using System.Collections.Generic;
using Base.AbstractClasses;
using Base.Interfaces;
using Database.Interfaces;

namespace Database.Models
{
    //TODO EntityManager mit verketten Listen implementieren!
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks></remarks>
    public class EntityManager<T> : Subject, Observer where T : IDatabaseObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityManager&lt;T&gt;"/> class.
        /// </summary>
        /// <remarks></remarks>
        public EntityManager()
        {
            DatabaseSimulation.Instance.AddObserver(this);
        }

        #region Observer Members

        public void UpdateObserver<T>(T subject) where T : Subject
        {
            NotifyObservers();
        }

        #endregion

        /// <summary>
        /// Searches for a free identifier and returns it.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private int GetFreeIdentifier()
        {
            int id = 0;
            bool isFree = false;

            List<T> elements = GetElements();

            while (!isFree)
            {
                id++;

                isFree = true;
                foreach (T elem in elements)
                {
                    if (elem.GetIdentifier() == id)
                    {
                        isFree = false;
                        break;
                    }
                }

                if (isFree)
                {
                    break;
                }
            }

            return id;
        }

        /// <summary>
        /// Adds the element.
        /// </summary>
        /// <param name="elem">The elem.</param>
        /// <remarks></remarks>
        public void AddElement(T elem)
        {
            elem.SetIdentifier(GetFreeIdentifier());
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

        public T GetElementWithId(int id)
        {
            var searchList = (List<T>) DatabaseSimulation.Instance.GetValuesFromDatabaseForType(typeof (T));

            if (searchList != null)
            {
                return searchList.Find(delegate(T t) { return t.GetIdentifier() == id; });
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<T> GetElements()
        {
            var returnList = (List<T>) DatabaseSimulation.Instance.GetValuesFromDatabaseForType(typeof (T));
            if (returnList == null)
            {
                return new List<T>();
            }
            else
            {
                return returnList;
            }
        }

        public void RemoveAllElements()
        {
            DatabaseSimulation.Instance.RemoveAllValuesFromDatabaseForType(typeof (T));
        }
    }
}