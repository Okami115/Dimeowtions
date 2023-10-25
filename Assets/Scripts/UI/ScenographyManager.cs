using GameManager;
using Menu;
using UnityEngine;

public class ScenographyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] scenographyNoir; 
    [SerializeField] private GameObject[] scenographySynthWave; 
    [SerializeField] private GameObject[] scenographySciFi;

    private Aesthetic currentAesthetic;
    [SerializeField] private GameManager.GameManager gameManager;

    [SerializeField] private UIManager uiManager;


    void Start()
    {
        uiManager.nextLevel += ChangeScenography;

        ChangeScenography();
    }

    private void ChangeScenography()
    {
        currentAesthetic = gameManager.CurrentAesthetic;

        if (currentAesthetic == Aesthetic.Noir)
        {
            for (int i = 0; i < scenographyNoir.Length; i++) { scenographyNoir[i].SetActive(true); }
            for (int i = 0; i < scenographySynthWave.Length; i++) { scenographySynthWave[i].SetActive(false); }
            for (int i = 0; i < scenographySciFi.Length; i++) { scenographySciFi[i].SetActive(false); }
        }
        else if (currentAesthetic == Aesthetic.Synthwave)
        {
            for (int i = 0; i < scenographyNoir.Length; i++) { scenographyNoir[i].SetActive(false); }
            for (int i = 0; i < scenographySynthWave.Length; i++) { scenographySynthWave[i].SetActive(true); }
            for (int i = 0; i < scenographySciFi.Length; i++) { scenographySciFi[i].SetActive(false); }
        }
        else if (currentAesthetic == Aesthetic.Scifi)
        {
            for (int i = 0; i < scenographyNoir.Length; i++) { scenographyNoir[i].SetActive(false); }
            for (int i = 0; i < scenographySynthWave.Length; i++) { scenographySynthWave[i].SetActive(false); }
            for (int i = 0; i < scenographySciFi.Length; i++) { scenographySciFi[i].SetActive(true); }
        }
    }

}
