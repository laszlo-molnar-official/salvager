using Assets.Scripts.Events;
using UnityEngine;

namespace Assets._Salvager.Scripts.Level
{
    public class ExitSign : MonoBehaviour
    {
        [SerializeField]
        private string playerShipTag = "Player";
        [SerializeField]
        private GameEvent_NoParam setLevelFinished;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(playerShipTag))
            {
                setLevelFinished.Raise(this.gameObject);
                this.gameObject.SetActive(false);
            }            
        }
    }
}
