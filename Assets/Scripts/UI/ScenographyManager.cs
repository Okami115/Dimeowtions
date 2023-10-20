using Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenographyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] scenographyNoir; 
    [SerializeField] private GameObject[] scenographySynthWave; 
    [SerializeField] private GameObject[] scenographySciFi;

    [SerializeField] private UIManager uiManager;


    void Start()
    {
        uiManager.nextLevel += ChangeScenography;

        for (int i = 0; i < scenographyNoir.Length; i++) { scenographyNoir[i].SetActive(true); }
        for (int i = 0; i < scenographySynthWave.Length; i++) { scenographySynthWave[i].SetActive(false); }
        for (int i = 0; i < scenographySciFi.Length; i++) { scenographySciFi[i].SetActive(false); }
    }

    private void ChangeScenography()
    {
        for (int i = 0; i < scenographyNoir.Length; i++) { scenographyNoir[i].SetActive(false); }
        for (int i = 0; i < scenographySynthWave.Length; i++) { scenographySynthWave[i].SetActive(true); }
        for (int i = 0; i < scenographySciFi.Length; i++) { scenographySciFi[i].SetActive(false); }
    }

}
