using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

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

        [SerializeField] private GameManager.GameManager gameManager;

        [SerializeField] public RawImage portalImage;
        [SerializeField] public VideoPlayer portal;

        private void OnEnable()
        {
            OpenDoor.canOpen += ChangeMensajes;
            gameManager.nextLevel += SetSkybox;
        }

        private void OnDisable()
        {
            OpenDoor.canOpen -= ChangeMensajes;
            gameManager.nextLevel -= SetSkybox;
        }

        private void Update()
        {
            if (scoreText)
                scoreText.text = playerStats.collectedObjects.ToString();

            if (scoreTextLose)
                scoreTextLose.text = playerStats.collectedObjects.ToString();
        }



        public void TogglePausePanel(bool active)
        {
            pausePanel.SetActive(active);
        }

        private void ChangeMensajes(string mensajes)
        {
            mensajesText.text = mensajes;
        }

        private void SetSkybox()
        {
            if (playerStats.distanceTraveled == 5000)
            {
                // Trigger
                // Mover a scenography
                RenderSettings.skybox = synthweaveSkybox;
            }

            if (playerStats.distanceTraveled == 10000)
            {
                // Trigger
                // Mover a scenography
                RenderSettings.skybox = scifiSkybox;
            }
        }

    }

}
