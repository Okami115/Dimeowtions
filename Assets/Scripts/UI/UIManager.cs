using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


namespace Menu
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI scoreTextLose;
        [SerializeField] private TextMeshProUGUI mensajesText;
        [SerializeField] private GameObject pausePanel;

        private OpenDoor[] openDoorList;

        [SerializeField] public int score = 0;

        private void Start()
        {
            openDoorList = FindObjectsOfType<OpenDoor>();

            for (int i = 0; i < openDoorList.Length; i++)
            {
                openDoorList[i].canOpen += ChangeMensajes;
            }
        }

        private void Update()
        {
            if (scoreText)
                scoreText.text = score.ToString();

            if (scoreTextLose)
                scoreTextLose.text = score.ToString();
        }

        public void TogglePausePanel(bool active)
        {
            pausePanel.SetActive(active);
        }

        private void ChangeMensajes(string mensajes)
        {
            mensajesText.text = mensajes;
        }

    }

}
