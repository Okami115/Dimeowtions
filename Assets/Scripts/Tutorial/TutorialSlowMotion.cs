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
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private bool isSlowMoAfterJump;
    [SerializeField] private bool isSlowMoAfterDoor;
    [SerializeField] private bool isSlowMoAfterMoving;
    [SerializeField] private bool isSlowMoAfterChangeGrav;
    [SerializeField] private GameObject door;

    [SerializeField] private TutorialUIManager tutorialUIManager;
    [SerializeField] private CheckColision playerCollision;

    [SerializeField] private int tutorialStep;
    [SerializeField] private bool isThisLastStep;


    public event Action<int> tutorialStepInProgress; 
    public event Action<int> tutorialStepCompleted;
    public event Action tutorialFinished;


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

        playerCollision.deathActionColision += ExitSlowMotion;
        playerCollision.deathActionFall += ExitSlowMotion;
    }

    private void OnDisable()
    {
        if (isSlowMoAfterJump)
            player.jump -= ExitSlowMotion;
        if (isSlowMoAfterDoor)
            player.interaction -= ExitSlowMotion;
        if (isSlowMoAfterMoving)
            player.moveAction -= ExitSlowMotion;
        if (isSlowMoAfterChangeGrav)
            player.changeGravAction -= ExitSlowMotion;
    }

    private void OnTriggerEnter(Collider other)
    {       
        gameManager.InTutorial = true;
        Time.timeScale = 0.1f;
        tutorialUIManager.ToggleImage(true);
        tutorialUIManager.ChangeText();
        tutorialStepInProgress?.Invoke(tutorialStep);
    }

    private void ExitSlowMotion()
    {
        if (!playerStats.isPause)
        {
            tutorialUIManager.ToggleImage(false);
            gameManager.InTutorial = false;
        }

        Time.timeScale = 1f;

        tutorialStepCompleted?.Invoke(tutorialStep);

        if (isThisLastStep)
        {
            isThisLastStep = false;
            tutorialFinished?.Invoke();
        }
    }
}
