using System;
using System.Collections;
using UnityEngine;

namespace player
{
    public class CheckColision : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;

        [SerializeField] private Transform pivot;

        [SerializeField] private LayerMask ground;

        [SerializeField] private GameObject pauseManager;
        
        [SerializeField] private string noirCoinTag;
        [SerializeField] private string synthwaveCoinTag;
        [SerializeField] private string spaceCoinTag;
        [SerializeField] private string egyptCoinTag;
        [SerializeField] private string infectedEgyptCoinTag;

        [SerializeField] public AK.Wwise.Event soundDefeat;
        [SerializeField] public AK.Wwise.Event soundItems;
        

        private string obstacleTag = "Obstacle"; 
        private string emptyTag = "Empty"; 
        private float raycastDistanceObjetc = 1f;
        Ray objetcRay;
        Ray groundRay;

        public event Action deathActionFall;
        public event Action deathActionColision;
        public event Action objectCollected;
        public event Action infectedObjectCollected;

        void Update()
        {

            RaycastHit hitInfo;
            objetcRay = new Ray(pivot.position, pivot.forward);
            groundRay = new Ray(pivot.position, -pivot.up);

            
            if (Physics.Raycast(objetcRay, out hitInfo, raycastDistanceObjetc))
            {

                if (hitInfo.collider.CompareTag(obstacleTag))
                {
                    pauseManager.SetActive(false);
                    deathActionColision?.Invoke();
                    playerStats.isPause = true;
                    hitInfo.collider.gameObject.SetActive(false);
                    soundDefeat.Post(gameObject);

                }
                
                if (hitInfo.collider.CompareTag(noirCoinTag))
                {
                    playerStats.collectedObjectsNoir += 1;
                    objectCollected?.Invoke();
                    Destroy(hitInfo.collider.gameObject);
                    soundItems.Post(gameObject);
                }
                else if (hitInfo.collider.CompareTag(synthwaveCoinTag))
                {
                    playerStats.collectedObjectsSynthwave += 1;
                    objectCollected?.Invoke();
                    Destroy(hitInfo.collider.gameObject);
                    soundItems.Post(gameObject);
                }
                else if (hitInfo.collider.CompareTag(spaceCoinTag))
                {
                    playerStats.collectedObjectsSpace += 1;
                    objectCollected?.Invoke();
                    Destroy(hitInfo.collider.gameObject);
                    soundItems.Post(gameObject);
                }
                else if (hitInfo.collider.CompareTag(egyptCoinTag))
                {
                    playerStats.collectedObjectsNoir += 1;
                    objectCollected?.Invoke();
                    Destroy(hitInfo.collider.gameObject);
                    soundItems.Post(gameObject);
                }
                else if (hitInfo.collider.CompareTag(infectedEgyptCoinTag))
                {
                    playerStats.collectedObjectsNoir -= 1;
                    infectedObjectCollected?.Invoke();
                    Destroy(hitInfo.collider.gameObject);
                    soundItems.Post(gameObject);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(objetcRay);
            Gizmos.DrawRay(groundRay);
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(emptyTag))
            {
                deathActionFall?.Invoke();
                playerStats.isPause = true;
                soundDefeat.Post(gameObject);                

            }
        }
    }
}