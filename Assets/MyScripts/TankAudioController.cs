using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyScripts
{
    public class TankAudioController : MonoBehaviour
    {
        private AudioSource engineAudioSource;
        private AudioSource tankAudioSource;

        public AudioClip engineDrivingClip;
        public AudioClip engineIdleClip;

        public AudioClip shotChargingClip;
        public AudioClip shotFiringClip;

        private EngineState curEngineState;
        private bool isEngineStateChanged;

        void Awake()
        {
            var audioSources = GetComponents<AudioSource>();
            engineAudioSource = audioSources[0];
            tankAudioSource = audioSources[1];
        }

        void Start()
        {
            engineAudioSource.playOnAwake = true;
            engineAudioSource.loop = true;

            tankAudioSource.playOnAwake = false;
            tankAudioSource.loop = false;

            Play(engineAudioSource, engineIdleClip);
        }

        void Update()
        {
            if(isEngineStateChanged)
            {
                if(curEngineState == EngineState.Driving)
                {
                    Play(engineAudioSource, engineDrivingClip);
                }
                else if (curEngineState == EngineState.Idle)
                {
                    Play(engineAudioSource, engineIdleClip);
                }
                else if(curEngineState == EngineState.Stop)
                {
                    engineAudioSource.Stop();
                }
                isEngineStateChanged = false;
            }
        }

        private void Play(AudioSource source, AudioClip clip)
        {
            source.clip = clip;
            source.Play();
        }

        public void PlayFireClip()
        {
            Play(tankAudioSource, shotFiringClip);
        }

        public void PlayChargingClip()
        {
            Play(tankAudioSource, shotChargingClip);
        }

        public void SetEngineState(EngineState engineState)
        {
            if(curEngineState != engineState)
            {
                curEngineState = engineState;
                isEngineStateChanged = true;
            }
        }
    }

    public enum EngineState
    {
        Idle,Driving,Stop
    }
}