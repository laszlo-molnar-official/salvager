using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets._Salvager.Scripts.UI
{
    public class OpenMenu : MonoBehaviour
    {
        [SerializeField]
        private GameEvent_NoParam eventToRaise;

        public void Open(InputAction.CallbackContext context)
        { 
            if (context.started) eventToRaise.Raise(this.gameObject);
        }
    }
}
