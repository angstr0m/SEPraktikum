using System;
using System.Collections.Generic;
using Base.Interfaces;

namespace Base.AbstractClasses
{
    /// <summary>
    /// Observer pattern Observable implementation.
    /// </summary>
    /// <remarks></remarks>
    public abstract class Subject
    {
        /// <summary>
        /// Used to prevent the altering of the observer list while iterating over it.
        /// </summary>
        private bool flag_iterating;

        /// <summary>
        /// Set when, while an iteration was done, a new observer signed up.
        /// </summary>
        private bool flag_update_list;

        /// <summary>
        /// The list of the observers.
        /// </summary>
        private List<Observer> observers = new List<Observer>();

        /// <summary>
        /// Temporary copy of the observer-list.
        /// </summary>
        private List<Observer> observers_workingCopy;

        /// <summary>
        /// Adds the observer to the observer list.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <remarks></remarks>
        public virtual void AddObserver(Observer observer)
        {
            // Make sure the observer-list is not altered while it's beeing iterated.
            if (!flag_iterating)
            {
                observers.Add(observer);
            }
            else
            {
                observers_workingCopy.Add(observer);
                flag_update_list = true;
            }
        }

        /// <summary>
        /// Removes the observer from the observer list.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <remarks></remarks>
        public virtual void RemoveObserver(Observer observer)
        {
            // Make sure the observer-list is not altered while it's beeing iterated.
            if (!flag_iterating)
            {
                observers.Remove(observer);
            }
            else
            {
                observers_workingCopy.Remove(observer);
                flag_update_list = true;
            }
        }

        /// <summary>
        /// Notifies the observers.
        /// </summary>
        /// <remarks></remarks>
        public virtual void NotifyObservers()
        {
            // Iterate over all signed in observers and notify them that they should update themselves.
            flag_iterating = true; // Lock the observer list.
            observers_workingCopy = new List<Observer>(observers);
            foreach (Observer observer in observers)
            {
                //Console.WriteLine("Observer notified!");
                observer.UpdateObserver(this);
            }

            // Update the observer-list if necessary.
            if (flag_update_list)
            {
                flag_update_list = false;
                observers = observers_workingCopy;
            }

            flag_iterating = false; // Unlock the observer list.
        }
    }
}