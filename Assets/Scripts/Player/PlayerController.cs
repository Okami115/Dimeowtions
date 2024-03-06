using UnityEngine;
using System;

namespace player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private InputManager inputManager;

        private Transform currentPos;

        [SerializeField] private Transform[] pos;
        private int halfPosCount;

        [SerializeField] private Transform Jumptarget;
        [SerializeField] private BoxCollider boxCollider;

        [SerializeField] private int moveVelocity = 100;
        [SerializeField] private int rotationVelocity = 300;
        [SerializeField] private int jumpVelocity = 500;
        [SerializeField] private int gravChangeVelocity = 1000;

        [SerializeField] private TutorialSlowMotion[] tutorialSlowMotions;
        private bool isMovingAvailable;
        private bool isOpeningDoorAvailable;
        private bool isJumpingAvailable;
        private bool isAntiGravityAvailable;

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

            if (playerStats.isEndlessActive)
            {
                isMovingAvailable = true;
                isOpeningDoorAvailable = true;
                isJumpingAvailable = true; 
                isAntiGravityAvailable = true;
            }
            else
            {
                isMovingAvailable = false;
                isOpeningDoorAvailable = false;
                isJumpingAvailable = false;
                isAntiGravityAvailable = false;
            }
        }

        private void OnEnable()
        {
            inputManager.onMoveLeftInput += OnMoveLeft;
            inputManager.onMoveRightInput += OnMoveRight;
            inputManager.onOpenDoorInput += OnInteraction;
            inputManager.onJumpInput += OnJump;
            inputManager.onGravitationalChangeInput += OnGravitationalChange;

            if (!playerStats.isEndlessActive)
            {
                for (int i = 0; i < tutorialSlowMotions.Length; i++)
                {
                    tutorialSlowMotions[i].tutorialStepInProgress += CompleteTutorialStep;
                    tutorialSlowMotions[i].tutorialStepCompleted += ResetTutorialMovility;
                }
            }
        }

        private void OnDisable()
        {
            inputManager.onMoveLeftInput -= OnMoveLeft;
            inputManager.onMoveRightInput -= OnMoveRight;
            inputManager.onOpenDoorInput -= OnInteraction;
            inputManager.onJumpInput -= OnJump;
            inputManager.onGravitationalChangeInput -= OnGravitationalChange;

            if (!playerStats.isEndlessActive)
            {
                for (int i = 0; i < tutorialSlowMotions.Length; i++)
                {
                    tutorialSlowMotions[i].tutorialStepInProgress -= CompleteTutorialStep;
                    tutorialSlowMotions[i].tutorialStepCompleted -= ResetTutorialMovility;
                }
            }
        }

        public void OnMoveLeft()
        {
            if (!isCounting && !inCooldown && isMovingAvailable)
            {
                indexPos++;
                if (indexPos > pos.Length - 1)
                    indexPos = 0;

                currentPos = pos[indexPos];
                moveAction?.Invoke();
            }
        }

        public void OnMoveRight()
        {
            if (!isCounting && !inCooldown && isMovingAvailable)
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
                jumpCooldown?.Invoke(true);
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

                        changeGravAction?.Invoke();
                        return;
                    }
                }
            }
        }

        private void CompleteTutorialStep(int tutorialStep)
        {
            switch (tutorialStep)
            {
                case 0:
                    isOpeningDoorAvailable = true;
                    break;
                case 1:
                    isJumpingAvailable = true;
                    break;
                case 2:
                    isAntiGravityAvailable = true;
                     break;
                case 3:
                    isMovingAvailable = true;
                    break;
                default:
                    break;
            }
        }

        private void ResetTutorialMovility(int tutorialStep)
        {
            bool enableAll = (tutorialStep == tutorialSlowMotions.Length - 1);

            isMovingAvailable = enableAll;
            isOpeningDoorAvailable = enableAll;
            isJumpingAvailable = enableAll;
            isAntiGravityAvailable = enableAll;
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
