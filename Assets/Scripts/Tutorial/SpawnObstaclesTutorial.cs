using Menu;
using System.Collections;
using System.Collections.Generic;
using Terrain;
using UnityEngine;

public class SpawnObstaclesTutorial : MonoBehaviour
{
    [SerializeField] private GameObject Base;
    [SerializeField] private GameObject Doors;
    [SerializeField] private GameObject Holes;
    [SerializeField] private GameObject children;
    [SerializeField] private TutorialSteps tutorialStepsSO;
    private TerrainMovement tMovement;

    private int value;

    private void Start()
    {
        tMovement = GetComponent<TerrainMovement>();
        tMovement.spawnSignal += SpawnRandomObstacles;
    }

    private void SpawnRandomObstacles()
    {
        Destroy(children);

        if (tutorialStepsSO.isMovingAvailable || tutorialStepsSO.isJumpingAvailable)
        {
            children = Instantiate(Base);
        }
        else if (tutorialStepsSO.isAvoidingObstacleAvailable)
        {
            value = Random.Range(0, 4);
            if (value == 3)
                children = Instantiate(Holes);
            else
                children = Instantiate(Base);

            Debug.Log(value);
        }
        else if (tutorialStepsSO.isOpeningDoorAvailable)
        {
            value = Random.Range(0, 4);
            if (value == 3)
                children = Instantiate(Doors);
            else
                children = Instantiate(Base);
        }

        children.transform.parent = this.transform;

        children.transform.localPosition = Vector3.zero;
        children.transform.localRotation = Quaternion.identity;
    }
}
