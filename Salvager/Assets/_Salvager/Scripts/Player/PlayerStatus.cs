using Assets._Salvager.Scripts.Level;
using Assets.Scripts.Events;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Salvager.Scripts.Player
{
    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField]
        private GameEvent_NoParam getLevelTargetNumber;
        [SerializeField]
        private GameEvent_Int sendTargetsReachedNumber;
        [SerializeField]
        private string levelTargetTag = "LevelTarget";

        private List<LevelTargetCone> targetsReached = new();
        [SerializeField]
        private int targetNumber = -1;

        public void SetLevelTargetNumber(int targetNum) => targetNumber = targetNum;
        public void SendReachedTargetsNumber() => sendTargetsReachedNumber.
                                                    Raise(this.gameObject, targetsReached.Count);

        private void Start()
        {
            if (targetNumber == -1) getLevelTargetNumber.Raise(this.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(levelTargetTag))
            {
                var target = other.GetComponent<LevelTargetCone>();

                if (target != null) SetTargetCompleted(target);
                else Debug.LogError("PlayerStatus::OnTriggerEnter: no LevelTarget " +
                    "script found on target: " + other.gameObject.name);
            }
        }

        private void SetTargetCompleted(LevelTargetCone target)
        {
            if (!targetsReached.Contains(target))
            { 
                targetsReached.Add(target);
                target.SetCompleted();
                sendTargetsReachedNumber.Raise(this.gameObject, targetsReached.Count);
            }
        }
    }
}
