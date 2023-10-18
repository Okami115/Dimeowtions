using Menu;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

namespace GameManager
{
    public enum Aesthetic
    {
        Noir,
        Synthwave,
        Scifi,
        end
    }

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PauseScript pauseScript;
        [SerializeField] private UIManager uiManager;
        [SerializeField] private VideoPlayer portal;
        [SerializeField] private RawImage portalImage;
        [SerializeField] private GameObject pauseManager;

        private Color color;

        private Aesthetic currentAesthetic;
        internal Aesthetic CurrentAesthetic { get => currentAesthetic; }

        private void OnEnable()
        {
            pauseScript.pauseEvent += ControlTimeScale;
            uiManager.nextLevel += ChangeAestetic;
        }

        private void OnDisable()
        {
            pauseScript.pauseEvent -= ControlTimeScale;
            uiManager.nextLevel -= ChangeAestetic;
        }

        private void Start()
        {
            ControlTimeScale(0.0f);
            pauseManager.SetActive(false);
            currentAesthetic = Aesthetic.Noir;
            color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }

        private void Update()
        {
            if(portal.isPaused && !pauseScript.IsPaused)
            {
                color.a -= Time.deltaTime;

                if(color.a < 0.0f) { color.a = 0.0f; }

                portalImage.color = color;
                ControlTimeScale(1.0f);
                pauseManager.SetActive(true);
            }
        }

        private void ChangeAestetic()
        {
            portalImage.enabled = true;
            color.a = 1.0f;
            portalImage.color = color;
            ControlTimeScale(0.0f);
            portal.Play();
            currentAesthetic++;
        }

        private void ControlTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }

        public void ReloadScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(currentSceneIndex);
        }


    }
}