using Menu;
using System;
using UnityEngine;

public class CatAnimatorManager : MonoBehaviour
{
    [SerializeField] private GameManager.GameManager gameManager;
    [SerializeField] private UIManager uiIManager;
    [SerializeField] private Animator animator;

    private int currentLevel = 0;

    private void OnEnable()
    {
        uiIManager.nextLevel += ChangeAnimation;
        OpenDoor.openDoor += ChangeOpenDoorAnimaton;
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
}
