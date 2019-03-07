using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

        public GameObject gameoverTextGo;

        void Awake()
        {
            if(ins == null)
            {
                DontDestroyOnLoad(gameObject);
                ins = this;
            }
            if(this != ins)
            {
                Destroy(gameObject);
                return;
            }
            
        }

        private void Start()
        {
            gameoverTextGo = GameObject.Find("GameOverText");
            gameoverTextGo.SetActive(false);

            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            gameoverTextGo = GameObject.Find("GameOverText");
            gameoverTextGo.SetActive(false);
        }

        void Update()
        {

        }

        public void GameOver()
        {
            var cameraControllerGo = GameObject.FindGameObjectWithTag("MainCamera");
            var cameraController = cameraControllerGo.GetComponent<MyCameraController>();
            cameraController.Stop = true;

            GameObject winPlayer = GameObject.FindGameObjectWithTag("Player");

            var gameoverText = gameoverTextGo.GetComponent<Text>();
            gameoverText.text = winPlayer.name + "  Win";
            gameoverTextGo.SetActive(true);

            StartCoroutine(Restart());
        }

        IEnumerator Restart()
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("main");
        }
    }
}

