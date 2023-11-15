using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Menu
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Text scoreTextLose;
        [SerializeField] private TextMeshProUGUI mensajesText;
        [SerializeField] private GameObject pausePanel;

        [SerializeField] private Material noirSkybox;
        [SerializeField] private Material synthweaveSkybox;
        [SerializeField] private Material scifiSkybox;

        [SerializeField] private PlayerStats playerStats;

        [SerializeField] private GameManager gameManager;

        [SerializeField] public RawImage portalImage;
        [SerializeField] public VideoPlayer portal;

        private void OnEnable()
        {
            OpenDoor.canOpen += ChangeMensajes;
            gameManager.nextLevel += SetSkybox;
            gameManager.CallPortal += CallPortal;
        }

        private void OnDisable()
        {
            OpenDoor.canOpen -= ChangeMensajes;
            gameManager.nextLevel -= SetSkybox;
            gameManager.CallPortal -= CallPortal;
        }

        private void Update()
        {
            if (scoreText)
                scoreText.text = playerStats.collectedObjects.ToString();

            if (scoreTextLose)
                scoreTextLose.text = playerStats.collectedObjects.ToString();

            if (portal.isPaused)
            {
                portal.frame = 0;
                Color color = new Color(1, 1, 1, 0);
                portalImage.color = color;
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

        private void SetSkybox()
        {
            if(playerStats.distanceTraveled == 0)
            {
                RenderSettings.skybox = noirSkybox;
            }

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

        private void CallPortal()
        {
            Color color = new Color(1, 1, 1, 1);
            portalImage.color = color;
            portalImage.enabled = true;
            portal.Stop();
            portal.time = 0;
            portal.Play();
        }

    }

}
