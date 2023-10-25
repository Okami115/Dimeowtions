using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimationSpeed : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerStats playerStats;

    [SerializeField] private string animationName;
    [SerializeField] private float animationDuration;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
        animator.speed = (animationDuration * playerStats.currentSpeed);
        animator.Play(animationName);
    }
}
