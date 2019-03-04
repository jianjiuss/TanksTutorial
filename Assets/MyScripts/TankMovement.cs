using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyScripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class TankMovement : MonoBehaviour
    {
        private Rigidbody rigidbody;
        private TankAudioController tankAudioController;

        public float speed;
        public float rotationSpeed;

        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            tankAudioController = GetComponent<TankAudioController>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal1");
            float vertical = Input.GetAxis("Vertical1");

            rigidbody.velocity = speed * transform.forward * vertical;
            rigidbody.angularVelocity = rotationSpeed * horizontal * transform.up;

            if(horizontal != 0 || vertical != 0)
            {
                tankAudioController.SetEngineState(EngineState.Driving);
            }
            else
            {
                tankAudioController.SetEngineState(EngineState.Idle);
            }
        }
    }
}
