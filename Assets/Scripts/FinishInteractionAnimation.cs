using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishInteractionAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string isOpeningDoorName;

    private void OnDisable()
    {
        animator.SetBool(isOpeningDoorName, false);
    }
}
