using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace player
{
    public class CheckColision : MonoBehaviour
    {
        [SerializeField] private Transform pivot;

        [SerializeField] private GameObject[] UI;

        private string obstacleTag = "Obstacle"; 
        private string doorTag = "Door"; 
        private string emptyTag = "Empty"; 
        private float raycastDistanceObjetc = 1f;
        private float raycastDistanceEmpty = 2f;

        void Update()
        {

            Ray objetcRay = new Ray(pivot.position, pivot.forward);
            Ray groundRay = new Ray(pivot.position, -pivot.up);
            RaycastHit hitInfo;


            if (Physics.Raycast(objetcRay, out hitInfo, raycastDistanceObjetc))
            {

                if (hitInfo.collider.CompareTag(obstacleTag))
                {
                    UI[2].SetActive(false);
                    UI[1].SetActive(true);
                    Time.timeScale = 0.0f;
                }

                if (hitInfo.collider.CompareTag(doorTag))
                {
                    Debug.Log("enter");
                }
            }

            if (Physics.Raycast(groundRay, out hitInfo, raycastDistanceEmpty))
            {

                if (hitInfo.collider.CompareTag(emptyTag))
                {
                    UI[2].SetActive(false);
                    UI[1].SetActive(true);
                    Time.timeScale = 0.0f;
                    
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(pivot.position, transform.forward);
            Gizmos.DrawRay(pivot.position, -transform.up);
        }
    }
}