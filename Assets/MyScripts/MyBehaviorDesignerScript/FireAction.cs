using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyScripts
{
    public class FireAction : Action
    {
        public Transform target;

        private FireController fireController;

        public override void OnAwake()
        {
            fireController = GetComponent<FireController>();
        }

        public override TaskStatus OnUpdate()
        {
            fireController.Fire(1);
            return TaskStatus.Success;
        }
    }
}
