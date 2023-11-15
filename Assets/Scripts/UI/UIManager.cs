using Manager;
using player;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Menu
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI mensajesText;
        [SerializeField] private GameObject pausePanel;

        [SerializeField] private Material noirSkybox;
        [SerializeField] private Material synthweaveSkybox;
        [SerializeField] private Material scifiSkybox;

        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private PlayerController player;
        [SerializeField] private CheckColision playerCollision;
     
        [SerializeField] private Image jumpCooldownImage;
        [SerializeField] private Sprite jumpCooldownSprite;
        [SerializeField] private Sprite noJumpCooldownSprite;

        [SerializeField] private TextMeshProUGUI noirScoreText;
        [SerializeField] private TextMeshProUGUI synthwaveScoreText;
        [SerializeField] private TextMeshProUGUI spaceScoreText;


        public event Action nextLevel;
        [SerializeField] private GameManager gameManager;

        [SerializeField] public RawImage portalImage;
        [SerializeField] public VideoPlayer portal;

        private void OnEnable()
        {
            player.jumpCooldown += ChangeJumpCooldownImage;
            playerCollision.deathAction += CalculateScoreTexts;
            OpenDoor.canOpen += ChangeMensajes;
            gameManager.nextLevel += SetSkybox;
            gameManager.CallPortal += CallPortal;
        }

        private void OnDisable()
        {
            player.jumpCooldown -= ChangeJumpCooldownImage;
            playerCollision.deathAction -= CalculateScoreTexts;
        }

        private void Update()
        {
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

        private void ChangeJumpCooldownImage(bool isCooldownActive)
        {
            if (!isCooldownActive)
                jumpCooldownImage.sprite = jumpCooldownSprite;
            else
                jumpCooldownImage.sprite = noJumpCooldownSprite;
        }

        private void CalculateScoreTexts()
        {
            noirScoreText.text = playerStats.collectedObjectsNoir.ToString() + " X ";
            synthwaveScoreText.text = playerStats.collectedObjectsSynthwave.ToString() + " X ";
            spaceScoreText.text = playerStats.collectedObjectsSpace.ToString() + " X ";
        }
    }
}
