using Menu;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            ControlTimeScale(1.0f);
            currentAesthetic = Aesthetic.Noir;
        }

        private void ChangeAestetic()
        {
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