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
        [SerializeField] private float accelerationRate = 0.001f;
        [SerializeField] private float minDistanceToRespawn;

        [SerializeField] private UIManager ui;

        public event Action spawnSignal;

        private void Start()
        {
            playerStats.currentSpeed = playerStats.initialSpeed;
            playerStats.score = 0;
        }

        private void Update()
        {
            if (playerStats.currentSpeed < playerStats.maxSpeed)
            {
                playerStats.currentSpeed += accelerationRate * Time.deltaTime;
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
            ui.Nextlevel();
            playerStats.score += 100;
        }
    }
}
