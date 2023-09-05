using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


namespace Menu
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI scoreTextLose;
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject pausePanel;

        [SerializeField] public int score = 0;

        private void Update()
        {
            if (scoreText)
            {
                scoreText.text = score.ToString();
                scoreTextLose.text = score.ToString();
            }
        }

        public void ToggleSetingsCanvas(bool active)
        {
            settingsPanel.SetActive(active);
        }

        public void TogglePausePanel(bool active)
        {
            pausePanel.SetActive(active);
        }
    }

}
