using Assets.Scripts.Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets._Salvager.Scripts.InputHandling
{ 
    public class ShipController : MonoBehaviour
    {
        [SerializeField]
        private GameEvent_NoParam setLevelStarted;
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
        private bool levelStartSent;
        private Rigidbody rb;

        // Between -1 .. 1 where 1 means 100%, the sign means the direction
        public float CurrentRotationPower() => rotationPower / maxRotationPower;
        public float CurrentThrottlePower() => throttlePower / maxThrottlePower;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            HandleThrottleInput();
            HandleTurnInput();

            // quick hacks to relieve Rigidbody velocity caused by collision with objects.
            if (rb.velocity.x != 0 || 
                rb.velocity.y != 0 || 
                rb.velocity.z != 0) 
            {
                rb.velocity *= 0.8f;
            }

            if (rb.angularVelocity.x != 0 || 
                rb.angularVelocity.y != 0 || 
                rb.angularVelocity.z != 0) 
            {
                rb.angularVelocity *= 0.8f;
            }
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

                if (!levelStartSent)
                {
                    levelStartSent = true;
                    setLevelStarted.Raise(this.gameObject);
                }
            }
            else
            {
                throttleModifier = 0;
                rotationModifier = 0;
            }            
        }
    }
}
