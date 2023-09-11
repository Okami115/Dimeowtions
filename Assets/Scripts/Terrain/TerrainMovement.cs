using Menu;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Terrain
{
    public class TerrainMovement : MonoBehaviour
    {
        [SerializeField] private Transform destination;
        [SerializeField] private Transform spawn;
        [SerializeField] private float initialSpeed = 1.0f;
        [SerializeField] private float maxSpeed = 10.0f;
        [SerializeField] private float accelerationRate = 0.01f;
        [SerializeField] private float minDistanceToRespawn;

        [SerializeField] private UIManager ui;
        [SerializeField] private float currentSpeed;

        public event Action spawnSignal;

        private void Start()
        {
            currentSpeed = initialSpeed;
        }

        private void Update()
        {
            if (currentSpeed < maxSpeed)
            {
                currentSpeed += accelerationRate * Time.deltaTime;
            }

            Vector3 newPos = transform.position;

            newPos.z += destination.position.z * Time.deltaTime * currentSpeed;

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
            ui.score += 100;
        }
    }
}
