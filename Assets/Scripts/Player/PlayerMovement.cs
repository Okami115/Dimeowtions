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
        [SerializeField] private Transform Jumptarget;
        [SerializeField] private BoxCollider boxCollider;

        private int moveVelocity = 100;
        private int rotationVelocity = 300;
        private int jumpVelocity = 500;

        private int indexPos = 0;

        [SerializeField] private float timeOnAir;
        private float timmer;

        [SerializeField] private const float maxJumpCooldown = 1;
        private float cooldown = maxJumpCooldown;

        private bool isCounting => timmer == 0;
        private bool inCooldown;

        public event Action Paused;
        public event Action interaction;
        public event Action jump;
        public event Action moveAction;

        private void Start()
        {
            currentPos = pos[indexPos];
        }

        public void OnLeft()
        {
            if(!isCounting) 
            {
                indexPos++;
                if (indexPos > pos.Length - 1)
                    indexPos = 0;

                currentPos = pos[indexPos];
                moveAction?.Invoke();
            }

        }

        public void OnRight()
        {
            if(!isCounting)
            {
                indexPos--;
                if (indexPos < 0)
                    indexPos = pos.Length - 1;

                currentPos = pos[indexPos];
                moveAction?.Invoke();
            }

        }

        public void OnInteraction()
        {
            interaction?.Invoke();
        }

        public void OnJump()
        {
            if(!inCooldown)
            {
                boxCollider.enabled = false;
                inCooldown = true;
                jump?.Invoke();
            }
        }

        private void Update()
        {
            if (isCounting)
            {
                timmer += Time.deltaTime;

                float speed = jumpVelocity * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, Jumptarget.position, speed);

                if (timmer >= timeOnAir)
                {
                    currentPos = pos[indexPos];
                    timmer = 0;
                }
            }
            else
            {

                if(inCooldown)
                {
                    cooldown -= Time.deltaTime;

                    if (cooldown < 0)
                    {
                        boxCollider.enabled = true;
                        cooldown = maxJumpCooldown;
                        inCooldown = false;
                    }
                }


                float speed = moveVelocity * Time.deltaTime;

                transform.position = Vector3.MoveTowards(transform.position, currentPos.position, speed);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, currentPos.rotation, rotationVelocity * Time.deltaTime);
            }
        }
    }
}
