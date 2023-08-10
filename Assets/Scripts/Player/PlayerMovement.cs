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

            transform.position = currentPos.position;
            Debug.Log(currentPos.position);
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

            transform.position = currentPos.position;
            Debug.Log(currentPos.position);
        }

    }


}
