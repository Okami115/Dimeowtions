using Manager;
using player;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Menu
{
    public class UIManager : MonoBehaviour
    {
        //[SerializeField] private TextMeshProUGUI mensajesText;
        [SerializeField] private GameObject pausePanel;

        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private PlayerController player;
        [SerializeField] private CheckColision playerCollision;

        [SerializeField] private TextMeshProUGUI noirScoreText;
        [SerializeField] private TextMeshProUGUI synthwaveScoreText;
        [SerializeField] private TextMeshProUGUI spaceScoreText;

        [SerializeField] private GameObject scoreObjectContainer;

        public event Action nextLevel;
        [SerializeField] private GameManager gameManager;

        [SerializeField] public Animator portalAnimator;
        [SerializeField] public string portalBoolName;
        [SerializeField] public bool portalBool;

        [SerializeField] private GameObject portalVideoObject; 
        [SerializeField] private VideoPlayer portalVideo; 
        private bool isPortalVideoReachable;

        [SerializeField] private GameObject objetiveImage;
        [SerializeField] private Sprite objectiveSpriteFilled;
        [SerializeField] private Sprite objectiveSpriteEmpty;
        [SerializeField] private float changeInterval;
        [SerializeField] private int totalDuration;

        [SerializeField] private TutorialSlowMotion[] tutorialSlowMotions;

        private void OnEnable()
        {
            playerCollision.deathActionColision += CalculateScoreTexts;
            playerCollision.deathActionFall += CalculateScoreTexts;

            for (int i = 0; i < tutorialSlowMotions.Length; i++)
            {
                tutorialSlowMotions[i].tutorialFinished += TriggerObjetiveImage;
            }

            gameManager.CallPortal += CallPortal;
            portalVideo.loopPointReached += VideoPlaybackComplete;

            isPortalVideoReachable = true;
        }

        private void OnDisable()
        {
            playerCollision.deathActionColision -= CalculateScoreTexts;
            playerCollision.deathActionFall -= CalculateScoreTexts;

            for (int i = 0; i < tutorialSlowMotions.Length; i++)
            {
                tutorialSlowMotions[i].tutorialFinished -= TriggerObjetiveImage;
            }

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

        private void CalculateScoreTexts()
        {
            noirScoreText.text = playerStats.collectedObjectsEgypt.ToString() + " X ";
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

        public void TriggerObjetiveImage()
        {
            StartCoroutine(ObjetiveImageSequence());
        }

        private IEnumerator ObjetiveImageSequence()
        {
            objetiveImage.SetActive(true);

            bool isFilled = false;
            float elapsedTime = 0.0f;

            while (elapsedTime < totalDuration)
            {
                if (isFilled)
                    objetiveImage.GetComponent<Image>().sprite = objectiveSpriteFilled;
                else
                    objetiveImage.GetComponent<Image>().sprite = objectiveSpriteEmpty;

                isFilled = !isFilled; // Toggle between empty and filled

                elapsedTime += changeInterval;
                yield return new WaitForSeconds(changeInterval);
            }

            objetiveImage.SetActive(false);
        }
    }
}
