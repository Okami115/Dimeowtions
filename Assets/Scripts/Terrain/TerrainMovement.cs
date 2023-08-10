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
            Vector3 newPos = transform.position;

            newPos.z += destination.position.z * Time.deltaTime;

            transform.position = newPos;

            if (transform.position.z < destination.position.z)
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
