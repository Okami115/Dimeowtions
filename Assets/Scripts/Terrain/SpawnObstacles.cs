using Unity.VisualScripting;
using UnityEngine;

namespace Terrain
{
    public class SpawnObstacles : MonoBehaviour
    {

        [SerializeField] private GameObject[] Noir;
        [SerializeField] private GameObject[] Synthwave;
        [SerializeField] private GameObject[] SciFi;
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
            Destroy(children);

            if(currentAesthetic == GameManager.Aesthetic.Noir)
            {
                value = Random.Range(0, Noir.Length);
                children = Instantiate(Noir[value]); 
            }
            else if (currentAesthetic == GameManager.Aesthetic.Synthwave)
            {
                value = Random.Range(0, Synthwave.Length);
                children = Instantiate(Synthwave[value]);
            }
            else if (currentAesthetic == GameManager.Aesthetic.Scifi)
            {
                value = Random.Range(0, Synthwave.Length);
                children = Instantiate(SciFi[value]);
            }


            children.transform.parent = this.transform;

            children.transform.localPosition = Vector3.zero;
            children.transform.localRotation = Quaternion.identity;
        }
    }
}