using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyScripts
{
    public class MyTankHealth : MonoBehaviour
    {
        public int hp = 100;
        public GameObject explosionParticleGo;
        public AudioClip tankExplosionClip;

        private int curHp;

        private Slider healthSlider;
        private TankAudioController audioController;

        private void Awake()
        {
            GameObject go = transform.Find("Canvas").Find("Health").gameObject;
            healthSlider = go.GetComponent<Slider>();
            audioController = GetComponent<TankAudioController>();
        }

        private void Start()
        {
            curHp = hp;
        }

        public void TakeDamage(int damageValue)
        {
            curHp -= damageValue;

            if (curHp <= 0)
            {
                healthSlider.value = 0;
                Explosion();
            }
            else
            {
                healthSlider.value = (float)curHp / hp;
            }
        }

        private void Explosion()
        {
            var go =GameObject.Instantiate(explosionParticleGo, transform.position, transform.rotation);
            var explosionParticle = go.GetComponent<ParticleSystem>();
            var audioSource = go.AddComponent<AudioSource>();
            audioSource.spatialBlend = 1;
            audioSource.clip = tankExplosionClip;
            audioSource.Play();
            explosionParticle.Play();

            audioController.SetEngineState(EngineState.Stop);
            GameObject.Destroy(go, explosionParticle.main.duration);

            GameObject.Destroy(gameObject);

            GameManager.Ins.GameOver();
        }
    }
}