using Menu;
using System;
using UnityEngine;

namespace Terrain
{
    public class TerrainMovement : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;

        [SerializeField] private Transform destination;
        [SerializeField] private Transform spawn;
        [SerializeField] private float minDistanceToRespawn;

        [SerializeField] private UIManager ui;

        public event Action spawnSignal;

        private void Start()
        {
            playerStats.currentSpeed = playerStats.initialSpeed;
            playerStats.distanceTraveled = 0;
        }

        private void Update()
        {
            if (playerStats.currentSpeed < playerStats.maxSpeed)
            {
                playerStats.currentSpeed += playerStats.accelerationRate * Time.deltaTime;
            }

            Vector3 newPos = transform.position;

            newPos.z += destination.position.z * Time.deltaTime * playerStats.currentSpeed;

            transform.position = newPos;

            if (transform.position.z < destination.position.z)
            {
                ReSpawn();
            }
            
        }

        private void ReSpawn()
        {
            transform.position += spawn.position;
            spawnSignal?.Invoke();

            playerStats.distanceTraveled += 100;
        }
    }
}
