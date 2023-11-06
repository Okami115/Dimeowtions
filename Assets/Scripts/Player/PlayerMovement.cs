using UnityEngine;
using System;

namespace player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Transform currentPos;

        [SerializeField] private Transform[] pos;
        [SerializeField] private Transform Jumptarget;
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private PauseState pauseScript;

        [SerializeField] private int moveVelocity = 100;
        [SerializeField] private int rotationVelocity = 300;
        [SerializeField] private int jumpVelocity = 500;

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
            if (!isCounting && !pauseScript.IsPaused)
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
            if (!isCounting && !pauseScript.IsPaused)
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
            if(!pauseScript.IsPaused)
            {
                interaction?.Invoke();
            }
        }

        public void OnJump()
        {
            if (!inCooldown && !pauseScript.IsPaused)
            {
                boxCollider.enabled = false;
                inCooldown = true;
                isCounting = true;
                jump?.Invoke();
            }
        }

        private void Update()
        {
            Debug.Log(indexPos);
            if (isCounting)
            {
                timmer += Time.deltaTime;

                float newDistance = jumpVelocity * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, Jumptarget.position, newDistance);

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


                float newDistance = moveVelocity * Time.deltaTime;

                transform.position = Vector3.MoveTowards(transform.position, currentPos.position, newDistance);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, currentPos.rotation, rotationVelocity * Time.deltaTime);
            }
        }
    }
}