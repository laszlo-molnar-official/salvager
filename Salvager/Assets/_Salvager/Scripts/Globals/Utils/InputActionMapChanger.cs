using UnityEngine;
using UnityEngine.InputSystem;

namespace Globals.Utils
{
    public class InputActionMapChanger : MonoBehaviour
    {
        public void ChangeMap(string mapName)
        {
            PlayerInput.GetPlayerByIndex(0).SwitchCurrentActionMap(mapName);            
        }
    }
}
