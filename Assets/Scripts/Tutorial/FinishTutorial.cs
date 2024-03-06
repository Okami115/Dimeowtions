using System.Collections;
using System.Collections.Generic;
using Terrain;
using UnityEngine;

public class FinishTutorial : MonoBehaviour
{
    [SerializeField] private TerrainMovement terrainMovement;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private int mainMenuIndex;

    private void OnEnable()
    {
        terrainMovement.spawnSignal += TutorialFinished;
    }

    private void OnDisable()
    {
        terrainMovement.spawnSignal -= TutorialFinished;
    }

    private void TutorialFinished()
    {
        sceneLoader.LoadLevel(mainMenuIndex);
    }

}
