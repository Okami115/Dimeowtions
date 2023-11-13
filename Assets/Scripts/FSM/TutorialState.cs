using Manager;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialState : State
{
    private readonly float delay;
    private float enterTime;
    public TutorialState(StateMachine machine, GameManager gameManager, int distance, float delay) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevel), new EndLevel(distance, gameManager.playerStats));
        conditions.Add(typeof(Pause), new Pause(gameManager.playerStats));
        this.delay = delay;
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter: TUTORIAL :: State");
        Time.timeScale = 0.0f;
        enterTime = Time.unscaledTime;
        gameManager.CurrentAesthetic = Aesthetic.Noir;
        //gameManager.CallNextLevel();
        gameManager.playerStats.distanceTraveled = 0;
    }

    public override void Exit()
    {
        Debug.LogWarning("Exit: TUTORIAL :: State");
    }

    public override void Update()
    {
        if (CheckCondition<EndLevel>())
        {
            machine.ChangeState<SynthwaveState>();
        }
        if (CheckCondition<Pause>())
        {
            machine.ChangeState<PauseState>();
        }
        if (Time.unscaledTime < enterTime + delay)
        {
            Debug.Log("Timer: " + (int)Time.unscaledTime + " :: TUTORIAL :: STAY");
            Time.timeScale = 0.0f;
            return;
        }
        Debug.Log("Timer: " + (int)Time.unscaledTime + " :: TUTORIAL :: UPDATE");
        Time.timeScale = 1.0f;

    }

}