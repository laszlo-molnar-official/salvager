using Globals.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Globals.GameEvents
{
    public abstract class GameEvent<T> : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener<T>> eventListeners = 
            new List<GameEventListener<T>>();

        public void Raise(GameObject raiser, T param)
        {
            WriteLog(raiser);
            for(int i = eventListeners.Count - 1; i >= 0; --i)
            { 
                eventListeners[i].OnEventRaised(param);
            }
        }

        public void RegisterListener(GameEventListener<T> listener)
        {
            if (!eventListeners.Contains(listener)) eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener<T> listener)
        {
            if (eventListeners.Contains(listener)) eventListeners.Remove(listener);
        }

        protected void WriteLog(GameObject raiser)
        { 
            string msg = GetType().Name + ": " + this.name + " event raised by: " + 
                ObjectNameHierarchyPrinter.Get(raiser.transform) +
                ". Listeners (" + eventListeners.Count + ") called:\n";

            for(int i = eventListeners.Count - 1; i >= 0; --i)
            { 
                msg += ObjectNameHierarchyPrinter.Get(eventListeners[i].transform) + "\n";
            }

            Debug.Log(msg);
        }
    }

    public abstract class GameEvent<T, U> : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener<T, U>> eventListeners = 
            new List<GameEventListener<T, U>>();

        public void Raise(GameObject raiser, T param, U param2)
        {
            WriteLog(raiser);

            for(int i = eventListeners.Count - 1; i >= 0; --i)
            { 
                eventListeners[i].OnEventRaised(param, param2);
            }
        }

        public void RegisterListener(GameEventListener<T, U> listener)
        {
            if (!eventListeners.Contains(listener)) eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener<T, U> listener)
        {
            if (eventListeners.Contains(listener)) eventListeners.Remove(listener);
        }

        protected void WriteLog(GameObject raiser)
        { 
            string msg = GetType().Name + ": " + this.name + " event raised by: " + 
                ObjectNameHierarchyPrinter.Get(raiser.transform) +
                ". Listeners (" + eventListeners.Count + ") called:\n";

            for(int i = eventListeners.Count - 1; i >= 0; --i)
            { 
                msg += ObjectNameHierarchyPrinter.Get(eventListeners[i].transform) + "\n";
            }

            Debug.Log(msg);
        }
    }

    public abstract class GameEvent<T, U, V> : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener<T, U, V>> eventListeners = 
            new List<GameEventListener<T, U, V>>();

        public void Raise(GameObject raiser, T param, U param2, V param3)
        {
            WriteLog(raiser);

            for(int i = eventListeners.Count - 1; i >= 0; --i)
            { 
                eventListeners[i].OnEventRaised(param, param2, param3);
            }
        }

        public void RegisterListener(GameEventListener<T, U, V> listener)
        {
            if (!eventListeners.Contains(listener)) eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener<T, U, V> listener)
        {
            if (eventListeners.Contains(listener)) eventListeners.Remove(listener);
        }

        protected void WriteLog(GameObject raiser)
        { 
            string msg = GetType().Name + ": " + this.name + " event raised by: " + 
                ObjectNameHierarchyPrinter.Get(raiser.transform) +
                ". Listeners called (" + eventListeners.Count + "):\n";

            for(int i = eventListeners.Count - 1; i >= 0; --i)
            { 
                msg += ObjectNameHierarchyPrinter.Get(eventListeners[i].transform) + "\n";
            }

            Debug.Log(msg);
        }
    }
}