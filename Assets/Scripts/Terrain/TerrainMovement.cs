using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Terrain
{
    public class TerrainMovement : MonoBehaviour
    {
        [SerializeField] private Transform destination;
        [SerializeField] private Transform spawn;
        [SerializeField] private float minDistanceToRespawn;
        
        private void Update()
        {
            transform.position += destination.position * Time.deltaTime;

            if (GetDistance() < minDistanceToRespawn)
            {
                ReSpawn();
            }
        }

        private void ReSpawn()
        {
            transform.position = spawn.position;
        }

        private float GetDistance()
        {
            return Vector3.Distance(transform.position, destination.position);
        }
    }

}
