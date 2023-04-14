using Pinwheel.Poseidon;
using UnityEngine;

namespace Assets._Salvager.Scripts.Water
{
    public class ObjectBuoyancer : MonoBehaviour
    {
        [SerializeField]
        private PWater water;
        [SerializeField]
        private bool applyRipple;
        [SerializeField]
        private Transform frontBuoy;
        [SerializeField]
        private Transform backBuoy;
        [SerializeField]
        private Transform leftBuoy;
        [SerializeField]
        private Transform rightBuoy;

        void Update()
        {
            if (water != null)
            { 
                var xAngle = AngleBetweenBuoys(backBuoy.position, frontBuoy.position);
                var zAngle = AngleBetweenBuoys(rightBuoy.position, leftBuoy.position);

                transform.localRotation = Quaternion.Euler(
                    xAngle,
                    transform.localRotation.eulerAngles.y,
                    zAngle);
            }
        }

        private float AngleBetweenBuoys(Vector3 buoy1, Vector3 buoy2)
        { 
            var direction = BuoyPosition(buoy1) - BuoyPosition(buoy2);
            return Mathf.Rad2Deg * Mathf.Asin(direction.y / direction.magnitude);
        }

        private Vector3 BuoyPosition(Vector3 buoy)
        {
            Vector3 localPos = water.transform.InverseTransformPoint(buoy);
            localPos.y = 0;
            localPos = water.GetLocalVertexPosition(localPos, applyRipple);

            Vector3 worldPos = water.transform.TransformPoint(localPos);
            return worldPos;
        }
    }
}
