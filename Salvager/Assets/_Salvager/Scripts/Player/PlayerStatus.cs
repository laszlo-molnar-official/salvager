using Assets._Salvager.Scripts.Level;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Salvager.Scripts.Player
{
    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField]
        private string levelTargetTag = "LevelTarget";

        private List<LevelTargetCone> targetsReached = new();

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
            }
        }
    }
}
