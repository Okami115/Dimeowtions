using Manager;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseState : State
{
    private float speed;
    private float aceleration;
    public PauseState(StateMachine machine, GameManager gameManager) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(Pause), new Pause(gameManager.playerStats));
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter: PAUSE :: State");
        Time.timeScale = 0.0f;
        speed = gameManager.playerStats.currentSpeed;
        aceleration = gameManager.playerStats.accelerationRate;
        gameManager.playerStats.currentSpeed = 0.0f;
        gameManager.playerStats.accelerationRate = 0.0f;
    }

    public override void Exit()
    {
        Debug.LogWarning("Exit: PAUSE :: State");
        gameManager.playerStats.currentSpeed = speed;
        gameManager.playerStats.accelerationRate = aceleration;
    }

    public override void Update()
    {
        if (!CheckCondition<Pause>())
        {
            machine.ChangeState<NoirState>();
        }
    }
}
