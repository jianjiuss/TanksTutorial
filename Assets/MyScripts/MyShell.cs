using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyScripts
{
    public class MyShell : MonoBehaviour
    {
        public GameObject shellExplosionParticleGo;
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var meshRenderer = gameObject.GetComponent<MeshRenderer>();

            var tempGo = GameObject.Instantiate(shellExplosionParticleGo, transform.position, transform.rotation);
            var shellExplosionParticle = tempGo.GetComponent<ParticleSystem>();
            shellExplosionParticle.Play();
            var duration = shellExplosionParticle.main.duration;
            
            audioSource.Play();

            GameObject.Destroy(gameObject, duration);
            GameObject.Destroy(tempGo, duration);
        }
    }
}
