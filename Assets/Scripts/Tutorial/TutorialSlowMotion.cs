using player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSlowMotion : MonoBehaviour
{
    public event Action<string> triggerExitEvent;
    [SerializeField] private PlayerMovementTutorial player;
    [SerializeField] private GameManager.GameManager gameManager;
    [SerializeField] private string nextStepName;
    [SerializeField] private bool isSlowMoAfterJump;
    [SerializeField] private bool isSlowMoAfterDoor;
    [SerializeField] private bool isSlowMoAfterMoving;
    [SerializeField] private GameObject door;

    [SerializeField] private TutorialUIManager tutorialUIManager;

    private void OnEnable()
    {
        if (isSlowMoAfterJump)
            player.jump += ExitSlowMotion;

        if (isSlowMoAfterDoor)
            player.interaction += ExitSlowMotion;
        if (isSlowMoAfterMoving)
            player.moveAction += ExitSlowMotion;
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.InTutorial = true;
        Time.timeScale = 0.1f;
        tutorialUIManager.ChangeText(nextStepName);
    }

    private void ExitSlowMotion()
    {
        Time.timeScale = 1f;
        tutorialUIManager.ChangeText("");
        Destroy(door);
        gameManager.InTutorial = false;
    }
}
