using Assets._Salvager.Scripts.InputHandling;
using Pinwheel.Poseidon;
using UnityEngine;

namespace Assets._Salvager.Scripts.Water
{
    public class ObjectBuoyancer : MonoBehaviour
    {
        [SerializeField]
        private PWater water;
        [SerializeField]
        private ShipController shipController;
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
        [SerializeField, Tooltip("Buoyancy power decreases as throttle and " +
        "rotation power increases. This is the minimum percentage that'll stay active when " +
        "throttle and rotation is on 100%. 0 .. 1 where 1 is 100%"),
        Range(0, 1)]
        private float minBuoyancy;
        [SerializeField, Tooltip("The ship leans when turning"),
        Range(0, 20)]
        private float speedLeanMultiplier;
        [SerializeField, Tooltip("How quickly the rotating of the ship body will happen"),
        Range(0, 20)]
        private float shipBodyInertia = 2;
        

        private void Update()
        {
            if (water != null)
            { 
                var speedMod = GetSpeedMod();
                var xAngle = speedMod * AngleBetweenBuoys(backBuoy.position, frontBuoy.position);
                var zAngle = speedMod * AngleBetweenBuoys(rightBuoy.position, leftBuoy.position);

                // modify Z-axis leaning with the leaning because of the ship is turning
                zAngle -= speedLeanMultiplier * shipController.CurrentRotationPower();

                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, 
                                            Quaternion.Euler(
                                                xAngle,
                                                transform.localRotation.eulerAngles.y,
                                                zAngle),
                                                shipBodyInertia * Time.deltaTime);
            }
        }

        // calculate the angle of angular offsets accounting the ship throttle and
        // rotational power
        private float GetSpeedMod()
        { 
            float xSpeedMod = Mathf.Abs(shipController.CurrentThrottlePower());
            float zSpeedMod = Mathf.Abs(shipController.CurrentRotationPower());
            float speedMod = 1 - (xSpeedMod > zSpeedMod ? xSpeedMod : zSpeedMod);
            
            return speedMod < minBuoyancy ? minBuoyancy : speedMod;
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
