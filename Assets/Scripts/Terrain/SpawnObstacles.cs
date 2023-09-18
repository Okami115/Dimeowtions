using UnityEngine;

namespace Terrain
{
    public class SpawnObstacles : MonoBehaviour
    {

        [SerializeField] private GameObject[][] fragments;
        [SerializeField] private GameObject children;
        [SerializeField] private GameManager.GameManager gameManager;
        private TerrainMovement tMovement;
        private GameManager.Aesthetic currentAesthetic;

        private int value;

        private void Start()
        {
            tMovement = GetComponent<TerrainMovement>();
            tMovement.spawnSignal += SpawnRandomObstacles;
        }

        private void SpawnRandomObstacles()
        {
            currentAesthetic = gameManager.CurrentAesthetic;
            value = Random.Range(0, fragments.Length);
            Destroy(children);

            children = Instantiate(fragments[value][(int)currentAesthetic]);

            children.transform.parent = this.transform;

            children.transform.localPosition = Vector3.zero;
            children.transform.localRotation = Quaternion.identity;
        }
    }
}