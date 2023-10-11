using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;
using UnityEngine.Windows;

namespace player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Transform currentPos;

        [SerializeField] private Transform[] pos;

        private float moveVelocity = 100;
        private const int rotationVelocity = 300;

        private int indexPos = 0;
        
        public event Action Paused;
        public event Action interaction;

        private void Start()
        {
            currentPos = pos[indexPos];
        }

        public void OnLeft()
        {
            indexPos++;
            if (indexPos >= pos.Length - 1)
                indexPos = 0;

            currentPos = pos[indexPos];
        }

        public void OnRight()
        {
            indexPos--;
            if (indexPos < 0)
                indexPos = pos.Length - 1;

            currentPos = pos[indexPos];
        }

        public void OnInteraction()
        {
            interaction?.Invoke();
        }

        private void Update()
        {
            float distanciaEsteFrame = moveVelocity * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, currentPos.position, distanciaEsteFrame);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, currentPos.rotation, rotationVelocity * Time.deltaTime);
        }

    }


}
