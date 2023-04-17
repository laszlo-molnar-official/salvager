using Globals.Utils;
using UnityEngine;

namespace Assets.Scripts.Events.Raisers
{
    public class RaiseGameEventNoParam : MonoBehaviour
    {
        public GameEvent_NoParam Event;

        [ContextMenu("Raise")]
        public void Raise()
        {
            if (Event != null) Event.Raise(this.gameObject);
            else
            {
                Debug.LogError("RaiseGameEventNoParam::Raise: no event found, GameObject: " +
                    ObjectNameHierarchyPrinter.Get(transform));
            }
        }
    }
}
