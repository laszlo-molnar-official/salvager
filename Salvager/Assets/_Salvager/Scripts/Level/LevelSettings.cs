using Assets._Salvager.Scripts.Player;
using Assets.Scripts.Events;
using Pinwheel.Poseidon;
using UnityEngine;

namespace Assets._Salvager.Scripts.Level
{
    public class LevelSettings : MonoBehaviour
    {
        [SerializeField]
        private LevelTarget[] targets;
        [SerializeField]
        private GameEvent_Int sendLevelTargetNumber;

        public void SendLevelTargetNumber()
        { 
            sendLevelTargetNumber.Raise(this.gameObject, targets.Length);
        }

#if UNITY_EDITOR
        public void SetTargets(LevelTarget[] targets, PWater water)
        {
            this.targets = targets;
            for (int i = 0; i < targets.Length; ++i)
            { 
                var controllers = targets[i].GetComponentsInChildren<SimpleBuoyController>();
                if (controllers != null &&
                    controllers.Length != 0)
                {
                    for (int controllerIdx = 0; controllerIdx < controllers.Length; ++controllerIdx)
                    { 
                        controllers[controllerIdx].water = water;
                    }
                }
            }
        }
#endif // UNITY_EDITOR
    }
}
