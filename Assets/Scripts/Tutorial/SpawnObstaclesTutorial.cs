using System;
using Terrain;
using UnityEngine;
using UnityEngine.Events;

public class SpawnObstaclesTutorial : MonoBehaviour
{
    [SerializeField] private GameObject Base;
    [SerializeField] private GameObject Doors;
    [SerializeField] private GameObject Holes;
    [SerializeField] private GameObject Obstacles;
    [SerializeField] private GameObject children;
    [SerializeField] private TutorialSteps tutorialStepsSO;
    private TerrainMovement tMovement;

    public event Action avoidObstaclesCompleted;

    private int randomValue;

    private int obstaclesPassed;
    private int obstaclesPassedNeeded;

    private void Start()
    {
        tMovement = GetComponent<TerrainMovement>();
        tMovement.spawnSignal += SpawnRandomObstacles;
        obstaclesPassed = 0;
        obstaclesPassedNeeded = 10;
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
            randomValue = UnityEngine.Random.Range(0, 5);
            if (randomValue == 3)
            {
                children = Instantiate(Holes);
                obstaclesPassed++;
            }
            else if (randomValue == 4)
            {
                children = Instantiate(Obstacles);
                obstaclesPassed++;
            }
            else
                children = Instantiate(Base);

            //obstaclesPassed++;
            Debug.Log(obstaclesPassed);

            if (obstaclesPassed == obstaclesPassedNeeded)
            {
                avoidObstaclesCompleted?.Invoke();
            }
        }
        else if (tutorialStepsSO.isOpeningDoorAvailable)
        {
            randomValue = UnityEngine.Random.Range(0, 4);
            if (randomValue == 3)
                children = Instantiate(Doors);
            else
                children = Instantiate(Base);
        }

        children.transform.parent = this.transform;

        children.transform.localPosition = Vector3.zero;
        children.transform.localRotation = Quaternion.identity;
    }
}
