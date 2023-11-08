using Menu;
using player;
using System;
using UnityEngine;

public class CatAnimatorManager : MonoBehaviour
{
    [SerializeField] private GameManager.GameManager gameManager;
    [SerializeField] private PlayerMovementTutorial player;
    [SerializeField] private UIManager uiIManager;
    [SerializeField] private Animator animator;

    private int currentLevel = 0;

    private void OnEnable()
    {
        uiIManager.nextLevel += ChangeAnimation;
        OpenDoor.openDoor += ChangeOpenDoorAnimaton;
        player.jump += ChangeJumpAnimaton;
    }

    private void OnDisable()
    {
        uiIManager.nextLevel -= ChangeAnimation;
        OpenDoor.openDoor -= ChangeOpenDoorAnimaton;
    }

    private void ChangeAnimation()
    {
        currentLevel = animator.GetInteger("Level");
        animator.SetInteger("Level", currentLevel + 1);
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
