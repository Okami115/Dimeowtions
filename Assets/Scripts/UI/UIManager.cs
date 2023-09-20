using System;
using TMPro;
using UnityEngine;


namespace Menu
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI scoreTextLose;
        [SerializeField] private TextMeshProUGUI mensajesText;
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private Material synthweaveSkybox;

        private OpenDoor[] openDoorList;

        [SerializeField] public int score = 0;
        public event Action nextLevel;

        private void Start()
        {
            openDoorList = FindObjectsOfType<OpenDoor>();

            for (int i = 0; i < openDoorList.Length; i++)
            {
                openDoorList[i].canOpen += ChangeMensajes;
            }
        }

        private void Update()
        {
            if (scoreText)
                scoreText.text = score.ToString();

            if (scoreTextLose)
                scoreTextLose.text = score.ToString();


        }

        public void Nextlevel()
        {
            if (score == 5000)
            {
                nextLevel?.Invoke();
                RenderSettings.skybox = synthweaveSkybox;
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

    }

}
