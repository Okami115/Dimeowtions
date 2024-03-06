using Manager;
using Menu;
using player;
using System;
using UnityEngine;

public class CatAnimatorManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController playerController;

    private void OnEnable()
    {
        gameManager.nextLevel += ChangeAnimation;
        OpenDoor.openDoor += ChangeOpenDoorAnimaton;
        playerController.jump += ChangeJumpAnimaton;
    }

    private void OnDisable()
    {
        gameManager.nextLevel -= ChangeAnimation;
        OpenDoor.openDoor -= ChangeOpenDoorAnimaton;
    }

    private void ChangeAnimation()
    {
        animator.SetBool("isChangingLevel", true);
        animator.SetInteger("Level", (int)gameManager.CurrentAesthetic);
    }

    void ChangeOpenDoorAnimaton()
    {
        animator.SetTrigger("OpenDoor");
    }

    void ChangeJumpAnimaton()
    {
        animator.SetTrigger("Jump");
    }

    public void ResetWalkStateSwitch()
    {
        animator.SetBool("isChangingLevel", false);
    }
}
