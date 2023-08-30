using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


namespace Menu
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI scoreTextLose;

        [SerializeField] public int score = 0;

        private void Start()
        {
          ToggleCanvas(true);
          Time.timeScale = 0f;
        }

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
    }

}
