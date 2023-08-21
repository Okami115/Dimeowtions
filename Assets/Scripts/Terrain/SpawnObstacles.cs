using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;

    private int value;

    private void Start()
    {
        SpawnRandomObstacles();
    }

    private void SpawnRandomObstacles()
    {
        value = Random.Range(0, obstacles.Length);

        Instantiate(obstacles[value], transform);
    }
}
