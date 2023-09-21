using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private string interactionAnimationName;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerStats playerStats;

    [SerializeField] private float interactionAnimationDuration;

    private float animatorDefaultSpeed;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animatorDefaultSpeed = 1.0f;
    }

    private void OnEnable()
    {
        OpenDoor.openDoor += TriggerIntractionAnimation;
    }

    private void OnDisable()
    {

        OpenDoor.openDoor -= TriggerIntractionAnimation;
    }

    void TriggerIntractionAnimation()
    {
        float speedFactor = playerStats.currentSpeed / playerStats.maxSpeed;
        animator.speed = (interactionAnimationDuration / playerStats.initialSpeed) / speedFactor;

        animator.Play(interactionAnimationName);

        //animator.speed = animatorDefaultSpeed;
    }
}
