using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyScripts
{

    public class GameManager : MonoBehaviour
    {
        private static GameManager ins;

        public static GameManager Ins
        {
            get
            {
                return ins;
            }
        }

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            ins = this;
        }

        void Update()
        {

        }
    }
}
