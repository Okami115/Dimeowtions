using Manager;
using player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSlowMotion : MonoBehaviour
{
    public event Action<string> triggerExitEvent;
    [SerializeField] private PlayerController player;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private bool isSlowMoAfterJump;
    [SerializeField] private bool isSlowMoAfterDoor;
    [SerializeField] private bool isSlowMoAfterMoving;
    [SerializeField] private bool isSlowMoAfterChangeGrav;
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
        if (isSlowMoAfterChangeGrav)
            player.changeGravAction += ExitSlowMotion;
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.InTutorial = true;
        Time.timeScale = 0.1f;
        tutorialUIManager.ToggleImage(true);
        tutorialUIManager.ChangeText();
    }

    private void ExitSlowMotion()
    {
        Time.timeScale = 1f;
        tutorialUIManager.ToggleImage(false);
        gameManager.InTutorial = false;
    }
}
