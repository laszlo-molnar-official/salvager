using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Salvager.Scripts.InputHandling
{ 
    public class ShipController : MonoBehaviour
    {
        public float Speed = 1;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.localPosition += transform.forward * Speed * Time.deltaTime;        
        }
    }
}
