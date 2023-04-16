using Assets._Salvager.Scripts.Player;
using Assets._Salvager.Scripts.UI;
using Assets.Scripts.Events;
using Pinwheel.Poseidon;
using UnityEngine;

namespace Assets._Salvager.Scripts.Level
{
    public class LevelSettings : MonoBehaviour
    {
        [SerializeField]
        private LevelSummary summary;
        [SerializeField]
        private LevelTarget[] targets;
        [SerializeField]
        private GameEvent_Int sendLevelTargetNumber;
        [SerializeField]
        private GameEvent_LevelSummary sendLevelSummary;

        public void SendLevelSummary() => sendLevelSummary.Raise(this.gameObject, summary);

        public void SendLevelTargetNumber()
        { 
            sendLevelTargetNumber.Raise(this.gameObject, targets.Length);
        }

        private void Start()
        {
            sendLevelSummary.Raise(this.gameObject, summary);
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
