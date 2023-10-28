using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimationSpeed : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerStats playerStats;

    [SerializeField] private float animationDuration;

    private void Update()
    {
        animator.speed = (animationDuration * playerStats.currentSpeed);
    }
}
