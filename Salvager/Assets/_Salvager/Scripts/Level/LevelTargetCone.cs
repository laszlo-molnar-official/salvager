using UnityEngine;

namespace Assets._Salvager.Scripts.Level
{
    public class LevelTargetCone : MonoBehaviour
    {
        [SerializeField]
        private LevelTarget levelTarget;

        public void SetCompleted() => levelTarget.SetCompleted();
    }
}
