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

        [SerializeField] public int score = 0;

        private void Start()
        {
            if (menuPanel)
                ToggleMenuCanvas(true);
            Time.timeScale = 0f;
        }

        private void Update()
        {
            if (scoreText)
                scoreText.text = score.ToString();

            if (scoreTextLose)
                scoreTextLose.text = score.ToString();
        }
        public void ToggleMenuCanvas(bool active)
        {
            menuPanel.SetActive(active);
            Time.timeScale = 1f;
        }

        public void ToggleSetingsCanvas(bool active)
        {
            settingsPanel.SetActive(active);
        }
    }

}
