using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] platforms;
        [SerializeField] private PauseScript pauseScript;

        private void OnEnable()
        {
            pauseScript.pauseEvent += ControlTimeScale;
        }

        private void OnDisable()
        {
            pauseScript.pauseEvent -= ControlTimeScale;
        }

        private void Start()
        {
            ControlTimeScale(1.0f);
        }

        private void ControlTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }

        public void StartLevel()
        {
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].SetActive(true);
            }
        }

        public void ReloadScene()
        {

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;


            SceneManager.LoadScene(currentSceneIndex);
        }


    }
}