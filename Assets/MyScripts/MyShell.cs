using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyScripts
{
    public class MyShell : MonoBehaviour
    {
        public GameObject shellExplosionParticleGo;
        public int damage = 40;

        private AudioSource audioSource;
        private CapsuleCollider capsuleCollider;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            capsuleCollider = GetComponent<CapsuleCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag.Equals("Explosion"))
            {
                return;
            }

            capsuleCollider.enabled = false;
            var meshRenderer = gameObject.GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;

            if(other.tag.Equals("Player"))
            {
                var healthComponent = other.GetComponent<MyTankHealth>();
                healthComponent.TakeDamage(damage);
            }

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
