using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Terrain
{
    public class SpawnObstacles : MonoBehaviour
    {

        [SerializeField] private GameObject[] fragments;
        [SerializeField] private GameObject children;
        private TerrainMovement tMovement;

        private int value;

        private void Start()
        {
            tMovement = GetComponent<TerrainMovement>();
            tMovement.spawnSignal += SpawnRandomObstacles;
        }

        private void SpawnRandomObstacles()
        {
            value = Random.Range(0, fragments.Length);
            Debug.Break();
            Destroy(children);

            children = Instantiate(fragments[value]);

            children.transform.parent = this.transform;

            children.transform.localPosition = Vector3.zero;
            children.transform.localRotation = Quaternion.identity;
        }
    }
}