using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseState : State
{
    public static event Action<bool> pauseStateOn;
    private State currentState;
    public PauseState(StateMachine machine, GameManager.GameManager gameManager) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(Pause), new Pause(gameManager.playerStats));
    }

    public override void Enter()
    {
        pauseStateOn.Invoke(true);
    }

    public override void Exit()
    {
        pauseStateOn.Invoke(false);
    }

    public override void Update()
    {
        if (!CheckCondition<Pause>())
        {
            //machine.ChangeState<currentState>();
        }
    }
}
