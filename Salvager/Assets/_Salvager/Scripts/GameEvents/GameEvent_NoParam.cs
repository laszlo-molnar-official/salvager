using Globals.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Events
{
    [CreateAssetMenu(menuName = "Game Events/Event")]
    public class GameEvent_NoParam : ScriptableObject
    {
        [SerializeField, Tooltip("Raised if not empty just after the main event. " +
        "CAUTION! Doesn't take care of infinite call loops!")]
        private GameEvent_NoParam chainedEvent;
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener_NoParam> eventListeners = 
            new List<GameEventListener_NoParam>();

        public void Raise(GameObject raiser)
        {
            WriteLog(raiser);

            for(int i = eventListeners.Count - 1; i >= 0; --i)
            {
                eventListeners[i].OnEventRaised();
            }

            if (chainedEvent != null) chainedEvent.Raise(raiser);
        }

        public void RegisterListener(GameEventListener_NoParam listener)
        {
            if (!eventListeners.Contains(listener)) eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener_NoParam listener)
        {
            if (eventListeners.Contains(listener)) eventListeners.Remove(listener);
        }

        // TODO: WriteLog is duplicated in every type of GameEvent, should refactor
        protected void WriteLog(GameObject raiser)
        { 
            string msg = GetType().Name + ": " + this.name + " event raised by: " + 
                (raiser == null ? " manually from Editor " : 
                    ObjectNameHierarchyPrinter.Get(raiser.transform)) +
                ". Listeners (" + eventListeners.Count + ") called:\n";

            for(int i = eventListeners.Count - 1; i >= 0; --i)
            { 
                msg += ObjectNameHierarchyPrinter.Get(eventListeners[i].transform) + "\n";
            }

            Debug.Log(msg);
        }
    }
}
