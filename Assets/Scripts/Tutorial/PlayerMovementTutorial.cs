using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;
using UnityEngine.Windows;

namespace player
{
    public class PlayerMovementTutorial : MonoBehaviour
    {
        private Transform currentPos;

        [SerializeField] private Transform[] pos;
        [SerializeField] private Transform Jumptarget;
        [SerializeField] private BoxCollider boxCollider;

        private bool isMovingAvailable = false;
        private bool isOpeningDoorAvailable = true;
        private bool isJumpingAvailable = false;

        private int moveVelocity = 100;
        private int rotationVelocity = 300;
        private int jumpVelocity = 500;

        private int indexPos = 0;

        [SerializeField] private float timeOnAir;
        private float timmer;

        [SerializeField] private const float maxJumpCooldown = 1;
        private float cooldown = maxJumpCooldown;

        private bool isCounting;
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
            if (!isCounting && isMovingAvailable)
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
            if (!isCounting && isMovingAvailable)
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
            if (isOpeningDoorAvailable)
            {
                interaction?.Invoke();
                isJumpingAvailable = true;
            }
        }

        public void OnJump()
        {
            if (!inCooldown && isJumpingAvailable)
            {
                boxCollider.enabled = false;
                inCooldown = true;
                isCounting = true;
                jump?.Invoke();
                isMovingAvailable = true;
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
                    isCounting = false;
                    currentPos = pos[indexPos];
                    timmer = 0;
                }
            }
            else
            {

                if (inCooldown)
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
