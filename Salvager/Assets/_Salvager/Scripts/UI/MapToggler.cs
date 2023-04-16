using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Assets._Salvager.Scripts.UI
{
    public class MapToggler : MonoBehaviour
    {
        [SerializeField]
        private GameEvent_Bool toggleMap; 

        public void ToggleMap(CallbackContext context)
        { 
            bool toggle = context.canceled ? false : true; 
            toggleMap.Raise(this.gameObject, toggle);
        }
    }
}
