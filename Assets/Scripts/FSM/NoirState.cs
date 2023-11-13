using Manager;
using Menu;
using System.Threading;
using UnityEngine;

public class NoirState : State
{
    private readonly float delay;
    private float enterTime;

    public NoirState(StateMachine machine, GameManager gameManager, int distance, float delay) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevel), new EndLevel(distance, gameManager.playerStats));
        conditions.Add(typeof(Pause), new Pause(gameManager.playerStats));
        this.delay = delay;
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter: NOIR :: State");
        Time.timeScale = 0.0f;
        enterTime = Time.unscaledTime;
        gameManager.CurrentAesthetic = Aesthetic.Noir;
        gameManager.playerStats.distanceTraveled = 0;
        gameManager.CallNextLevel();
    }

    public override void Exit()
    {
        Debug.LogWarning("Exit: NOIR :: State");
        
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
            Debug.Log("Timer: " + (int)Time.unscaledTime + " :: NOIR :: STAY");
            Time.timeScale = 0.0f;
            return;
        }
        Debug.Log("Timer: " + (int)Time.unscaledTime + " :: NOIR :: UPDATE");
        Time.timeScale = 1.0f;
    }
}