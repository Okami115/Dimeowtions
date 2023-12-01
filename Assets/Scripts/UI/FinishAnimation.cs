using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string booleanName;
    [SerializeField] private bool isActive;

    private void OnDisable()
    {
        animator.SetBool(booleanName, isActive);
    }
}
