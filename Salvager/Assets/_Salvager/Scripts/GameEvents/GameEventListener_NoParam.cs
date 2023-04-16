using Globals.Utils;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Events
{
    public class GameEventListener_NoParam : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent_NoParam Event;

        [Tooltip("Fire response after this delay")]
        public float ResponseDelay;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response;
        
        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        [ContextMenu("Call OnEventRaised")]
        public virtual void OnEventRaised()
        {
            if (Response != null) 
            { 
                if (ResponseDelay == 0) Response.Invoke();
                else StartCoroutine(DelayedResponse());
            }
            else
            {
                Debug.LogError("GameEventListener_NoParam::Raise: no Response found, GameObject: " +
                    ObjectNameHierarchyPrinter.Get(transform));
            }            
            
        }

        private IEnumerator DelayedResponse()
        {
            yield return new WaitForSeconds(ResponseDelay);
            if (Response != null) Response.Invoke();
        }
    }
}
