using Manager;
using Menu;
using player;
using System;
using UnityEngine;

public class CatAnimatorManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Animator animator;

    private void OnEnable()
    {
        gameManager.nextLevel += ChangeAnimation;
        OpenDoor.openDoor += ChangeOpenDoorAnimaton;
        player.jump += ChangeJumpAnimaton;
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

    void ChangeJumpAnimaton()
    {
        animator.SetBool("isJumping", true);
    }
}
