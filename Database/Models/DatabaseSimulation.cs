using System;
using System.Collections.Generic;
using Base.AbstractClasses;
using Base.Interfaces;

namespace Database.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    internal class DatabaseSimulation : Subject, Model
    {
        /// <summary>
        /// 
        /// </summary>
        private static DatabaseSimulation instance;

        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<Type, dynamic> entityDict;

        /// <summary>
        /// Prevents a default instance of the <see cref="DatabaseSimulation"/> class from being created.
        /// </summary>
        /// <remarks></remarks>
        private DatabaseSimulation()
        {
            entityDict = new Dictionary<Type, dynamic>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <remarks></remarks>
        public static DatabaseSimulation Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseSimulation();
                }
                return instance;
            }
        }

        /// <summary>
        /// Adds the value to database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <remarks></remarks>
        public void AddValueToDatabase<T>(T value)
        {
            if (!entityDict.ContainsKey(typeof (T)))
            {
                entityDict[typeof (T)] = new List<T>();
                ((List<T>) entityDict[typeof (T)]).Capacity = 1000000; // Dauerndes resizen vermeiden. Speicherplatz sollte kein Problem sein...hoffentlich :(.
            }

            ((List<T>)entityDict[typeof (T)]).Add(value);
            
            NotifyObservers();
        }

        /// <summary>
        /// Removes the value from database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool RemoveValueFromDatabase<T>(T value)
        {
            if (!entityDict.ContainsKey(typeof (T)))
            {
                return false;
            }

            bool rv = ((List<T>)entityDict[typeof (T)]).Remove(value);

            NotifyObservers();

            return rv;
        }

        /// <summary>
        /// Gets the type of the values from database for.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public dynamic GetValuesFromDatabaseForType(Type type)
        {
            if (entityDict.ContainsKey(type))
            {
                return entityDict[type];
            }
            else
            {
                return null;
            }
        }

        public void RemoveAllValuesFromDatabaseForType(Type type)
        {
            if (entityDict.ContainsKey(type))
            {
                entityDict.Remove(type);
            }
        }
    }
}