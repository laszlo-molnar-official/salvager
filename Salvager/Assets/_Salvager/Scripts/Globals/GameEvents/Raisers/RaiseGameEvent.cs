using Globals.Utils;
using UnityEngine;

namespace Globals.GameEvents.Raisers
{
    public class RaiseGameEvent<T> : MonoBehaviour
    {
        public T param;
        public GameEvent<T> Event;

        public void Raise()
        {
            if (Event != null) Event.Raise(this.gameObject, param);
            else
            {
                Debug.LogError("RaiseGameEvent<T>::Raise: no event found, GameObject: " +
                    ObjectNameHierarchyPrinter.Get(transform));
            }
        }
    }

    public class RaiseGameEvent<T, U> : MonoBehaviour
    {
        public T param;
        public U param2;
        public GameEvent<T, U> Event;

        public void Raise()
        {
            if (Event != null) Event.Raise(this.gameObject, param, param2);
            else
            {
                Debug.LogError("RaiseGameEvent<T, U>::Raise: no event found, GameObject: " +
                    ObjectNameHierarchyPrinter.Get(transform));
            }
        }
    }

    public class RaiseGameEvent<T, U, V> : MonoBehaviour
    {
        public T param;
        public U param2;
        public V param3;
        public GameEvent<T, U, V> Event;

        public void Raise()
        {
            if (Event != null) Event.Raise(this.gameObject, param, param2, param3);
            else
            {
                Debug.LogError("RaiseGameEvent<T, U, V>::Raise: no event found, GameObject: " +
                    ObjectNameHierarchyPrinter.Get(transform));
            }
        }
    }
}
