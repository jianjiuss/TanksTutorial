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

        public string horizontalName;
        public string verticalName;
        

        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            tankAudioController = GetComponent<TankAudioController>();
        }

        void Update()
        {

        }

        private void FixedUpdate()
        {
            float horizontal = Input.GetAxis(horizontalName);
            float vertical = Input.GetAxis(verticalName);

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
