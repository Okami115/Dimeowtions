using System;
using TMPro;
using UnityEngine;


namespace Menu
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI scoreTextLose;
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
                scoreText.text = playerStats.score.ToString();

            if (scoreTextLose)
                scoreTextLose.text = playerStats.score.ToString();
        }

        public void Nextlevel()
        {
            // Mover a GameManager
            if (playerStats.score == 5000)
            {
                nextLevel?.Invoke();
                // Trigger
                // Mover a scenography
                RenderSettings.skybox = synthweaveSkybox;
            }

            if (playerStats.score == 10000)
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
