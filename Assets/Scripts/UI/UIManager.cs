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
          ToggleCanvas(true);
          Time.timeScale = 0f;
        }
            ToggleMenuCanvas(true);

        public void ToggleCanvas(bool active)
        {
            menu.SetActive(active);
            Time.timeScale = 1f;
        }

        private void Update()
        {
            scoreText.text = score.ToString();
            scoreTextLose.text = score.ToString();
        }
        public void ToggleMenuCanvas(bool active)
        {
            menuPanel.SetActive(active);
        }

        public void ToggleSetingsCanvas(bool active)
        {
            settingsPanel.SetActive(active);
        }
    }

}
