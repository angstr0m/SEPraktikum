using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    /// <summary>
    /// Observer pattern Observable implementation.
    /// </summary>
    public abstract class Subject
    {
        private bool flag_iterating = false;
        private bool flag_update_list = false;
        private List<Observer> observers_workingCopy;
        private List<Observer> observers = new List<Observer>();
        
        public void AddObserver(Observer observer)
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
        
        public void RemoveObserver(Observer observer)
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
        
        public void NotifyObservers()
        {
            // Iterate over all signed in observers and notify them that they should update themselves.
            flag_iterating = true; // Lock the observer list.
            observers_workingCopy = new List<Observer>(observers);
            foreach (Observer observer in observers)
            {
                System.Console.WriteLine("Observer notified!");
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
