using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

namespace player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Transform currentPos;

        [SerializeField] private Transform left;
        [SerializeField] private Transform mid;
        [SerializeField] private Transform right;
        [SerializeField] private Transform rightMid;
        [SerializeField] private Transform leftMid;
        [SerializeField] private Transform top;
        [SerializeField] private Transform rightTop;
        [SerializeField] private Transform leftTop;
        private float velocidad = 100;

        private void Start()
        {
            currentPos = mid;
        }

        public void OnLeft()
        {
            if(currentPos == right) 
            {
                currentPos = mid;
            }
            else if (currentPos == mid)
            {
                currentPos = left;
            }
            else if ( currentPos == left)
            {
                currentPos = leftMid;
            }
            else if(currentPos == leftMid)
            {
                currentPos = leftTop;
            }
            else if( currentPos == leftTop)
            {
                currentPos = top;
            }
            else if (currentPos == top)
            {
                currentPos = rightTop;
            }
            else if (currentPos == rightTop)
            {
                currentPos = rightMid;
            }
            else
            {
                currentPos = right;
            }
        }

        public void OnRight()
        {
            if (currentPos == left)
            {
                currentPos = mid;
            }
            else if (currentPos == mid)
            {
                currentPos = right;
            }
            else if (currentPos == right)
            {
                currentPos = rightMid;
            }
            else if(currentPos == rightMid)
            {
                currentPos = rightTop;
            }
            else if (currentPos == rightTop)
            {
                currentPos = top;
            }
            else if (currentPos == top)
            {
                currentPos = leftTop;
            }
            else if(currentPos == leftTop)
            {
                currentPos = leftMid;
            }
            else
            {
                currentPos = left;
            }
        }



        private void Update()
        {
            Vector3 direccion = currentPos.position - transform.position;

            float distanciaEsteFrame = velocidad * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, currentPos.position, distanciaEsteFrame);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, currentPos.rotation, 300 * Time.deltaTime);
        }
    }


}
