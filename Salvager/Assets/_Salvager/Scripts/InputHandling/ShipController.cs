using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets._Salvager.Scripts.InputHandling
{ 
    public class ShipController : MonoBehaviour
    {
        [SerializeField]
        private float speedMultiplier = 1;
        [SerializeField]
        private float rotationMultiplier = 1;
        [SerializeField]
        private float maxRotationPower = 1.5f;
        [SerializeField]
        private float maxThrottlePower = 3f;

        private float throttlePower;
        private float rotationPower;
        private float rotationModifier;
        private float throttleModifier;

        // Between -1 .. 1 where 1 means 100%, the sign means the direction
        public float CurrentRotationPower() => rotationPower / maxRotationPower;
        public float CurrentThrottlePower() => throttlePower / maxThrottlePower;

        private void Update()
        {
            HandleThrottleInput();
            HandleTurnInput();
        }

        private void HandleThrottleInput()
        {
            throttlePower = ApplyModifier(throttlePower, maxThrottlePower, throttleModifier);
            transform.localPosition += transform.forward * throttlePower * speedMultiplier * Time.deltaTime;
        }

        private void HandleTurnInput()
        {
            rotationPower = ApplyModifier(rotationPower, maxRotationPower, rotationModifier);
            transform.Rotate(new Vector3(0, rotationPower, 0) * rotationMultiplier * Time.deltaTime);
        }

        private float ApplyModifier(float power, float maxPower, float modifier)
        {
            if (modifier != 0)
            {
                power += modifier * Time.deltaTime;

                if (power > maxPower) power = maxPower;
                else if (power < -maxPower) power = -maxPower;
            }
            else
            {
                power -= power * Time.deltaTime;
                if (Mathf.Abs(power) < 0.1f) power = 0;
            }

            return power;
        }

        private void OnDirections(InputAction.CallbackContext context)
        {
            if (!context.canceled)
            { 
                Vector2 direction = context.ReadValue<Vector2>();
                rotationModifier = direction.x;
                throttleModifier = direction.y;
            }
            else
            {
                throttleModifier = 0;
                rotationModifier = 0;
            }            
        }
    }
}
