using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyScripts
{
    public class MyExplosion : MonoBehaviour
    {
        public float explosionForce = 2000;
        public float explosionRadius = 4;

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag.Equals("Player"))
            {
                Rigidbody rigidbody = other.GetComponent<Rigidbody>();
                
                rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }
}
