using player;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Text scoreTextLose;
        [SerializeField] private TextMeshProUGUI mensajesText;
        [SerializeField] private GameObject pausePanel;      
        [SerializeField] private Material synthweaveSkybox;
        [SerializeField] private Material scifiSkybox;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private PlayerMovementTutorial player;

        [SerializeField] private Image JumpCooldownImage;
        [SerializeField] private Sprite JumpCooldownSprite;
        [SerializeField] private Sprite NoJumpCooldownSprite;

        public event Action nextLevel;

        private void OnEnable()
        {
            OpenDoor.canOpen += ChangeMensajes;
            player.jumpCooldown += ChangeJumpCooldownImage;
        }

        private void OnDisable()
        {
            OpenDoor.canOpen -= ChangeMensajes;
            player.jumpCooldown -= ChangeJumpCooldownImage;
        }

        private void Update()
        {
            if (scoreText)
                scoreText.text = playerStats.collectedObjects.ToString();

            if (scoreTextLose)
                scoreTextLose.text = playerStats.collectedObjects.ToString();
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

        private void ChangeJumpCooldownImage(bool isCooldownActive)
        {
            if (!isCooldownActive)
                JumpCooldownImage.sprite = JumpCooldownSprite;
            else
                JumpCooldownImage.sprite = NoJumpCooldownSprite;
        }

    }

}
