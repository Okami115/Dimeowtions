using GameManager;
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

        [SerializeField] private GameManager.GameManager gameManager;

        [SerializeField] public RawImage portalImage;
        [SerializeField] public VideoPlayer portal;

        private void OnEnable()
        {
            OpenDoor.canOpen += ChangeMensajes;
            gameManager.nextLevel += SetSkybox;
            State.enterLevel += HandleTransition;
            PauseState.pauseStateOn += TogglePausePanel;
        }

        private void OnDisable()
        {
            OpenDoor.canOpen -= ChangeMensajes;
            gameManager.nextLevel -= SetSkybox;
            State.enterLevel -= HandleTransition;
            PauseState.pauseStateOn -= TogglePausePanel;
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
            if(playerStats.distanceTraveled == 100)
            {

                RenderSettings.skybox = synthweaveSkybox;
            }

            if (playerStats.distanceTraveled == 5100)
            {
                // Trigger
                // Mover a scenography
                RenderSettings.skybox = synthweaveSkybox;
            }

            if (playerStats.distanceTraveled == 10100)
            {
                // Trigger
                // Mover a scenography
                RenderSettings.skybox = scifiSkybox;
            }
        }

        private void HandleTransition()
        {

            Color color = new Color(1, 1, 1, 1);
            portalImage.enabled = true;
            portalImage.color = color;
            portal.Play();
        }

    }

}
