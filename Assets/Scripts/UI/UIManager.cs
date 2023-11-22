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

        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private PlayerController player;
        [SerializeField] private CheckColision playerCollision;

        [SerializeField] private Image jumpCooldownImage;
        [SerializeField] private Sprite jumpCooldownSprite;
        [SerializeField] private Sprite noJumpCooldownSprite;

        [SerializeField] private TextMeshProUGUI noirScoreText;
        [SerializeField] private TextMeshProUGUI synthwaveScoreText;
        [SerializeField] private TextMeshProUGUI spaceScoreText;

        [SerializeField] private GameObject scoreObjectContainer;

        public event Action nextLevel;
        [SerializeField] private GameManager gameManager;

        //[SerializeField] public RawImage portalImage;
        //[SerializeField] public VideoPlayer portal;

        [SerializeField] public Animator portalAnimator;
        [SerializeField] public string portalBoolName;
        [SerializeField] public bool portalBool;

        [SerializeField] private GameObject portalVideoObject; 
        [SerializeField] private VideoPlayer portalVideo; 
        private bool isPortalVideoReachable; 

        private void OnEnable()
        {
            player.jumpCooldown += ChangeJumpCooldownImage;
            playerCollision.deathAction += CalculateScoreTexts;
            OpenDoor.canOpen += ChangeMensajes;
            gameManager.CallPortal += CallPortal;
            portalVideo.loopPointReached += VideoPlaybackComplete;

            isPortalVideoReachable = true;
        }

        private void OnDisable()
        {
            player.jumpCooldown -= ChangeJumpCooldownImage;
            playerCollision.deathAction -= CalculateScoreTexts;
            OpenDoor.canOpen -= ChangeMensajes;
            gameManager.nextLevel -= SetSkybox;
            gameManager.CallPortal -= CallPortal;
            portalVideo.loopPointReached -= VideoPlaybackComplete;

        }

        private void Start()
        {
            if (playerStats.isEndlessActive) scoreObjectContainer.SetActive(false);
            else scoreObjectContainer.SetActive(true);

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
            if(playerStats.collectedObjectsNoir == playerStats.objectsToCollectNoir)
            {
                RenderSettings.skybox = noirSkybox;
            }

            if (playerStats.collectedObjectsSynthwave == playerStats.objectsToCollectSynthwave)
            {
                // Trigger
                // Mover a scenography
                RenderSettings.skybox = synthweaveSkybox;
            }

            if (playerStats.collectedObjectsSpace == playerStats.objectsToCollectSpace)
            {
                // Trigger
                // Mover a scenography
                RenderSettings.skybox = scifiSkybox;
            }
        }

        private void Update()
        {

            if (isPortalVideoReachable)
            {
                portalVideo.Play();
                isPortalVideoReachable = false;
            }

            if (!portalAnimator.GetBool(portalBoolName))
            {
                portalBool = false;
            }

        }

        private void CallPortal()
        {
            portalAnimator.SetBool(portalBoolName, true);
            portalBool = true;
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

        private void VideoPlaybackComplete(VideoPlayer vp)
        {
            if (vp == portalVideo)
            {
                portalVideoObject.SetActive(false);
            }
        }
    }
}
