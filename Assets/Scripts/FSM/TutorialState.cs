using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialState : State
{
    private readonly float delay;
    private float enterTime;

    public TutorialState(StateMachine machine, GameManager.GameManager gameManager, int distance, float delay) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevel), new EndLevel(distance, gameManager.playerStats));
        this.delay = delay;
    }

    public override void Enter()
    {
        Debug.Log("Enter: TUTORIAL :: State");
        Time.timeScale = 0.0f;
        enterTime = Time.unscaledTime;
        gameManager.CurrentAesthetic = GameManager.Aesthetic.Noir;
        CallPortal();
        gameManager.playerStats.distanceTraveled = 0;
    }

    public override void Exit()
    {
        Debug.Log("Exit: TUTORIAL :: State");
    }

    public override void Update()
    {

        if (CheckCondition<EndLevel>())
        {
            machine.ChangeState<SynthwaveState>();
            return;
        }

        if (Time.unscaledTime < enterTime + delay)
        {
            return;
        }

        if(!gameManager.InTutorial) 
        { 
            Time.timeScale = 1.0f;
        }

    }

}
