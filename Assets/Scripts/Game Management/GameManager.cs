using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] platforms;
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