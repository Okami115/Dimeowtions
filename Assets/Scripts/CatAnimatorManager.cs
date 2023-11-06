using Menu;
using System;
using UnityEngine;

public class CatAnimatorManager : MonoBehaviour
{
    [SerializeField] private GameManager.GameManager gameManager;
    [SerializeField] private Animator animator;

    private void OnEnable()
    {
        gameManager.nextLevel += ChangeAnimation;
        OpenDoor.openDoor += ChangeOpenDoorAnimaton;
    }

    private void OnDisable()
    {
        gameManager.nextLevel -= ChangeAnimation;
        OpenDoor.openDoor -= ChangeOpenDoorAnimaton;
    }

    private void ChangeAnimation()
    {
        animator.SetInteger("Level", (int)gameManager.CurrentAesthetic);
    }

    void ChangeOpenDoorAnimaton()
    {
        animator.SetBool("isOpeningDoor", true);
    }
}
