using Globals.Utils;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Globals.GameEvents
{
    public class GameEventListener<T> : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
#if ODIN_INSPECTOR        
        [ValueDropdown("GetAssets")]
#endif
        public GameEvent<T> Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<T> Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public virtual void OnEventRaised(T param)
        {
            if (Response != null) Response.Invoke(param);
            else
            {
                Debug.LogError("GameEventListener<T>::OnEventRaised: no Response found. " +
                "GameObject: " + ObjectNameHierarchyPrinter.Get(transform));
            }            
        }

#if UNITY_EDITOR && ODIN_INSPECTOR
        private ValueDropdownList<GameEvent<T>> GetAssets()
        { 
            ValueDropdownList<GameEvent<T>> result = new();
            var items = AssetDatabase.FindAssets("t:" + typeof(GameEvent<T>));
            foreach (var item in items)
            {
                var path = AssetDatabase.GUIDToAssetPath(item);
                var obj = (AssetDatabase.LoadAssetAtPath<GameEvent<T>>(path));
                if (obj != null) result.Add(obj.name, obj);
            }

            return result;
        }
#endif
    }

    public class GameEventListener<T, U> : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent<T, U> Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<T, U> Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public virtual void OnEventRaised(T param, U param2)
        {
            if (Response != null) Response.Invoke(param, param2);
            else
            {
                Debug.LogError("GameEventListener<T, U>::OnEventRaised: no Response found. " +
                "GameObject: " + ObjectNameHierarchyPrinter.Get(transform));
            }            
        }
    }

    public class GameEventListener<T, U, V> : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent<T, U, V> Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<T, U, V> Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public virtual void OnEventRaised(T param, U param2, V param3)
        {
            if (Response != null) Response.Invoke(param, param2, param3);
            else
            {
                Debug.LogError("GameEventListener<T, U, V>::OnEventRaised: no Response found. " +
                "GameObject: " + ObjectNameHierarchyPrinter.Get(transform));
            }            
        }
    }
}