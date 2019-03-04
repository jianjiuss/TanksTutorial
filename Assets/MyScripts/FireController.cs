using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyScripts
{
    public class FireController : MonoBehaviour
    {
        public GameObject shellPrefabs;
        public KeyCode fireKey;
        public float shellVelocityRatio;
        public float fireInterSeptal;

        private float fireHoldTime;
        public float maxFireHoldTime;
        private bool isKeyHold;

        private float intervalTimeTick;
        public float fireIntervalTime;
        private bool canFire;

        public Slider fireArrow;
        private GameObject fireArrowGo;

        private Transform shotPoint;

        private TankAudioController audioController;
        void Awake()
        {
            shotPoint = ((GameObject)(GameObject.Find("ShellShotPoint"))).transform;
            canFire = true;
            fireArrowGo = fireArrow.gameObject;
            audioController = GetComponent<TankAudioController>();
        }

        void Update()
        {
            if(!canFire)
            {
                intervalTimeTick += Time.deltaTime;
                if(intervalTimeTick >= fireIntervalTime)
                {
                    canFire = true;
                    intervalTimeTick = 0;
                }
                return;
            }

            if (isKeyHold)
            {
                fireHoldTime += Time.deltaTime;
                fireArrow.value = fireHoldTime / maxFireHoldTime;
                if(fireHoldTime >= maxFireHoldTime || Input.GetKeyUp(fireKey))
                {
                    Fire(fireHoldTime);
                    fireHoldTime = 0;

                    canFire = false;
                    isKeyHold = false;
                    fireArrow.value = 0;
                    fireArrowGo.SetActive(false);
                }
            }

            if (Input.GetKeyDown(fireKey))
            {
                audioController.PlayChargingClip();
                isKeyHold = true;
                fireArrowGo.SetActive(true);
            }
        }

        private void Fire(float holdTime)
        {
            var shellGo = GameObject.Instantiate(shellPrefabs, shotPoint.position, shotPoint.rotation) as GameObject;
            Rigidbody rigidbody = shellGo.GetComponent<Rigidbody>();
            rigidbody.velocity = shellGo.transform.forward * (holdTime + 2) * (shellVelocityRatio * 2);

            audioController.PlayFireClip();
        }
    }
}
