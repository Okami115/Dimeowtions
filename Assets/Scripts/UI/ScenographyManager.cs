using Manager;
using Menu;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ScenographyManager : MonoBehaviour
{
    [Obsolete]
    [SerializeField] private GameObject[] scenographyNoir; 
    [Obsolete]
    [SerializeField] private GameObject[] scenographySynthWave; 
    [Obsolete]
    [SerializeField] private GameObject[] scenographySciFi;

    private Aesthetic currentAesthetic;

    [SerializeField] private GameManager gameManager;

    private Scenery currentScenery = null;
    [SerializeField] private IdSceneryPair[] sceneries;

    void Start()
    {
        gameManager.nextLevel += ChangeScenography;
        ChangeScenography();
    }

    private void ChangeScenography()
    {
        if(currentScenery)
            currentScenery.Hide();
        currentAesthetic = gameManager.CurrentAesthetic;
        for (int i = 0; i < sceneries.Length; i++)
        {
            if (sceneries[i].id == currentAesthetic)
            {
                currentScenery = sceneries[i].scenery;
                break;
            }
        }
        currentScenery.Show();
    }

}
