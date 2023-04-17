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
        private GameEvent_NoParam getLevelSummaryRef;
        [SerializeField]
        private GameEvent_Int sendTargetsReachedNumber;
        [SerializeField]
        private GameEvent_NoParam sendTargetsCollected;
        [SerializeField]
        private string levelTargetTag = "LevelTarget";

        private List<LevelTargetCone> targetsReached = new();
        private int targetNumber = -1;
        private LevelSummary summaryRef;
        private bool levelOngoing;

        public void SetLevelTargetNumber(int targetNum) => targetNumber = targetNum;
        public void StartLevel() => levelOngoing = true;
        public void PauseGame() => levelOngoing = false;
        public void ResumeGame() => levelOngoing = true;
        public void LevelFinished() => levelOngoing = false;
        public void SendReachedTargetsNumber() => sendTargetsReachedNumber.
                                                    Raise(this.gameObject, targetsReached.Count);

        public void SetLevelSummary(LevelSummary summary)
        {
            summaryRef = summary;
            summaryRef.Init();
        }
        
        private void Start()
        {
            if (targetNumber == -1) getLevelTargetNumber.Raise(this.gameObject);
            if (summaryRef == null) getLevelSummaryRef.Raise(this.gameObject);
        }

        private void FixedUpdate()
        {
            if (levelOngoing &&
                summaryRef != null)
            {
                summaryRef.UpdateStats(Time.fixedDeltaTime);
            }
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

                if (targetsReached.Count == targetNumber)
                {
                    sendTargetsCollected.Raise(this.gameObject);
                }
            }
        }
    }
}
