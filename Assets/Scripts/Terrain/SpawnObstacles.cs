using Manager;
using Menu;
using Unity.VisualScripting;
using UnityEngine;

namespace Terrain
{
    public class SpawnObstacles : MonoBehaviour
    {

        [SerializeField] private GameObject[] Noir;
        [SerializeField] private GameObject[] Synthwave;
        [SerializeField] private GameObject[] SciFi;
        [SerializeField] private GameObject[] Egyptian;
        [SerializeField] private GameObject children;
        [SerializeField] private GameManager gameManager;
        private TerrainMovement tMovement;
        private Aesthetic currentAesthetic;

        private int value;

        private void Start()
        {
            tMovement = GetComponent<TerrainMovement>();
            tMovement.spawnSignal += SpawnRandomObstacles;
            gameManager.nextLevel += SpawnRandomObstacles;
        }

        private void SpawnRandomObstacles()
        {
            currentAesthetic = gameManager.CurrentAesthetic;
            Destroy(children);

            if (currentAesthetic == Aesthetic.Egyptian)
            {
                value = Random.Range(0, Egyptian.Length);
                children = Instantiate(Egyptian[value]);
            }
            else if(currentAesthetic == Aesthetic.Noir)
            {
                value = Random.Range(0, Noir.Length);
                children = Instantiate(Noir[value]); 
            }
            else if (currentAesthetic == Aesthetic.Synthwave)
            {
                value = Random.Range(0, Synthwave.Length);
                children = Instantiate(Synthwave[value]);
            }
            else if (currentAesthetic == Aesthetic.Scifi)
            {
                value = Random.Range(0, SciFi.Length);
                children = Instantiate(SciFi[value]);
            }


            children.transform.parent = this.transform;

            children.transform.localPosition = Vector3.zero;
            children.transform.localRotation = Quaternion.identity;
        }
    }
}