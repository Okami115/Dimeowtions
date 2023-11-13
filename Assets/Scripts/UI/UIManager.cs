using player;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI mensajesText;
        [SerializeField] private GameObject pausePanel;      
        [SerializeField] private Material synthweaveSkybox;
        [SerializeField] private Material scifiSkybox;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private PlayerMovementTutorial player;
        [SerializeField] private CheckColision playerCollision;
     
        [SerializeField] private Image jumpCooldownImage;
        [SerializeField] private Sprite jumpCooldownSprite;
        [SerializeField] private Sprite noJumpCooldownSprite;

        [SerializeField] private TextMeshProUGUI noirScoreText;
        [SerializeField] private TextMeshProUGUI synthwaveScoreText;
        [SerializeField] private TextMeshProUGUI spaceScoreText;


        public event Action nextLevel;

        private void OnEnable()
        {
            player.jumpCooldown += ChangeJumpCooldownImage;
            playerCollision.deathAction += CalculateScoreTexts;
        }

        private void OnDisable()
        {
            player.jumpCooldown -= ChangeJumpCooldownImage;
            playerCollision.deathAction -= CalculateScoreTexts;
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
