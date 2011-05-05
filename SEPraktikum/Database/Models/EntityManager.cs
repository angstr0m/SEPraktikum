using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Base.AbstractClasses;

namespace Database.Models
{
    public class EntityManager<T> : Subject
    {
        public EntityManager()
        {
        }

        public void AddElement(T elem)
        {
            DatabaseSimulation.Instance.AddValueToDatabase(elem);
        }

        public bool RemoveElement(T elem)
        {
            return DatabaseSimulation.Instance.RemoveValueFromDatabase(elem);
        }

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

        public override void AddObserver(Base.Interfaces.Observer observer)
        {
            DatabaseSimulation.Instance.AddObserver(observer);
        }

        public override void NotifyObservers()
        {
            base.NotifyObservers();
        }

        public override void RemoveObserver(Base.Interfaces.Observer observer)
        {
            DatabaseSimulation.Instance.RemoveObserver(observer);
        }
    }
}
