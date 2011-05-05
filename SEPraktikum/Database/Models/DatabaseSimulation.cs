﻿using System;
using System.Collections;
using System.Collections.Generic;
using Base.AbstractClasses;
using Base.Interfaces;

namespace Database.Models
{
    class DatabaseSimulation : Subject, Model
    {
        private static DatabaseSimulation instance;
        private Dictionary<Type, dynamic> entityDict;

        private DatabaseSimulation() {
            entityDict = new Dictionary<Type, dynamic>();
        }

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

        public void AddValueToDatabase<T>(T value)
        {
            if (!entityDict.ContainsKey(typeof(T)))
            {
                entityDict[typeof(T)] = new List<T>();
            }

            entityDict[typeof(T)].Add(value);
        }

        public bool RemoveValueFromDatabase<T>(T value)
        {
            if (!entityDict.ContainsKey(typeof(T)))
            {
                return false;
            }

            return entityDict[typeof(T)].Remove(value);
        }

        public dynamic GetValuesFromDatabaseForType(Type type)
        {
            return entityDict[type];
        }
    }
}