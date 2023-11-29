using Manager;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseState : State
{
    
    public PauseState(StateMachine machine, GameManager gameManager) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(Pause), new Pause(gameManager.playerStats));
        
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter: PAUSE :: State");        

    }

    public override void Exit()
    {
        Debug.LogWarning("Exit: PAUSE :: State");        

    }

    public override void Update()
    {
        if (!CheckCondition<Pause>())
        {
            var lastState = machine.LastState.GetType();
            machine.ChangeState(lastState);
        }
    }
}
