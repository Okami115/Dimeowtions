using Manager;
using Menu;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortalState : State
{
    public PortalState(StateMachine machine,GameManager gameManager, UIManager uiManager) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(ClosePortal), new ClosePortal(uiManager));
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter: PORTAL :: State");
        gameManager.CallPortalState();
        Time.timeScale = 0.0f;
    }

    public override void Exit()
    {
        Debug.LogWarning("Exit: PORTAL :: State");
        Time.timeScale = 1.0f;
    }

    public override void Update()
    {
        gameManager.playerStats.isPause = true;
        if (CheckCondition<ClosePortal>())
        {
            gameManager.playerStats.isPause = false;
            if(gameManager.InTutorial) { machine.ChangeState<TutorialState>(); }
            if(gameManager.playerStats.distanceTraveled == 5000) { machine.ChangeState<SynthwaveState>(); }
            if(gameManager.playerStats.distanceTraveled == 10000) { machine.ChangeState<SciFiState>(); }
            if(gameManager.playerStats.distanceTraveled == 15000) { machine.ChangeState<NoirState>(); }
        }
    }
}
