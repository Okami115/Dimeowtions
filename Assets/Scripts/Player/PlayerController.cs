using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;
using UnityEngine.Windows;
using Menu;

namespace player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;

        private Transform currentPos;

        [SerializeField] private Transform[] pos;
        private int halfPosCount;

        [SerializeField] private Transform Jumptarget;
        [SerializeField] private BoxCollider boxCollider;

        [SerializeField] private int moveVelocity = 100;
        [SerializeField] private int rotationVelocity = 300;
        [SerializeField] private int jumpVelocity = 500;
        [SerializeField] private int gravChangeVelocity = 1000;

        private bool isMovingAvailable = false;
        private bool isOpeningDoorAvailable = true;
        private bool isJumpingAvailable = false;
        private bool isAntiGravityAvailable = false;

        private int indexPos = 0;

        [SerializeField] private float timeOnAir;
        private float timmer;

        [SerializeField] private float maxJumpCooldown = 1;
        private float cooldown;

        private bool isCounting;
        private bool inCooldown;

        public event Action Paused;
        public event Action interaction;
        public event Action jump;
        public event Action moveAction;
        public event Action changeGravAction;
        public event Action<bool> jumpCooldown;

        private void Start()
        {
            currentPos = pos[indexPos];
            halfPosCount = pos.Length / 2;
            cooldown = maxJumpCooldown;
        }

        public void OnLeft()
        {
            if (!isCounting && isMovingAvailable && !playerStats.inPortalState || playerStats.isEndlessActive)
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
            if (!isCounting && isMovingAvailable && !playerStats.inPortalState || playerStats.isEndlessActive)
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
            if (isOpeningDoorAvailable && !playerStats.inPortalState || playerStats.isEndlessActive)
            {
                interaction?.Invoke();
                isJumpingAvailable = true;
            }
        }

        public void OnJump()
        {
            if (!inCooldown && isJumpingAvailable && !playerStats.inPortalState || playerStats.isEndlessActive)
            {
                boxCollider.enabled = false;
                inCooldown = true;
                isCounting = true;
                jump?.Invoke();
                jumpCooldown?.Invoke(true);
                isAntiGravityAvailable = true;
            }
        }

        public void OnCancelJump()
        {
            if(isCounting)
            {
                isCounting = false;
                float speed = 10000 * Time.deltaTime;

                transform.position = Vector3.MoveTowards(transform.position, currentPos.position, speed);
            }
        }

        public void OnGravitationalChange()
        {
            if (isAntiGravityAvailable && !inCooldown && !playerStats.inPortalState || playerStats.isEndlessActive)
            {
                inCooldown = true;

                for (int i = 0; i < pos.Length; i++)
                {
                    if (transform.position == pos[i].position)
                    {
                        if ((i + pos.Length / 2) >= pos.Length)
                        {
                            indexPos -= halfPosCount;
                            currentPos = pos[i -= halfPosCount];
                        }
                        else
                        {
                            indexPos += halfPosCount;
                            currentPos = pos[i += halfPosCount];
                        }

                        isMovingAvailable = true;
                        changeGravAction?.Invoke();
                        return;
                    }
                }
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
                    cooldown -= Time.deltaTime * playerStats.currentSpeed;

                    if (cooldown < 0)
                    {
                        boxCollider.enabled = true;
                        cooldown = maxJumpCooldown;
                        inCooldown = false;
                        jumpCooldown?.Invoke(false);
                    }
                }


                float speed = moveVelocity * Time.deltaTime;

                transform.position = Vector3.MoveTowards(transform.position, currentPos.position, speed);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, currentPos.rotation, rotationVelocity * Time.deltaTime);
            }
        }
    }
}
