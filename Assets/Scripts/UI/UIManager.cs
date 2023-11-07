using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Text scoreTextLose;
        [SerializeField] private TextMeshProUGUI mensajesText;
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private Material synthweaveSkybox;
        [SerializeField] private Material scifiSkybox;
        [SerializeField] private PlayerStats playerStats;

        public event Action nextLevel;

        private void OnEnable()
        {
            OpenDoor.canOpen += ChangeMensajes;
        }

        private void OnDisable()
        {
            OpenDoor.canOpen -= ChangeMensajes;
        }

        private void Update()
        {
            if (scoreText)
                scoreText.text = playerStats.collectedObjects.ToString();

            if (scoreTextLose)
                scoreTextLose.text = "Score: " + playerStats.collectedObjects.ToString();
        }

        public void Nextlevel()
        {
            // Mover a GameManager
            if (playerStats.distanceTraveled == 5000)
            {
                nextLevel?.Invoke();
                // Trigger
                // Mover a scenography
                RenderSettings.skybox = synthweaveSkybox;
            }

            if (playerStats.distanceTraveled == 10000)
            {
                nextLevel?.Invoke();
                // Trigger
                // Mover a scenography
                RenderSettings.skybox = scifiSkybox;
            }
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
