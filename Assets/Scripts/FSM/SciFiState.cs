using UnityEngine;

public class SciFiState : State
{
    private readonly float delay;
    private float enterTime;
    public SciFiState(StateMachine machine, GameManager.GameManager gameManager, int distance, float delay) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevel), new EndLevel(distance, gameManager.playerStats));
        this.delay = delay;
    }

    public override void Enter()
    {
        Debug.Log("Enter: SCIFI :: State");
        Time.timeScale = 0.0f;
        enterTime = Time.unscaledTime;
        gameManager.CurrentAesthetic = GameManager.Aesthetic.Scifi;
        gameManager.playerStats.distanceTraveled = 10000;
        gameManager.CallNextLevel();
    }

    public override void Exit()
    {
        Debug.Log("Exit: SCIFI :: State");
    }

    public override void Update()
    {
        if (CheckCondition<EndLevel>())
        {
            machine.ChangeState<NoirState>();
        }
        if (Time.unscaledTime < enterTime + delay)
        {
            Debug.Log("Timer: " + (int)Time.unscaledTime + " :: SCIFI :: STAY");
            Time.timeScale = 0.0f;
            return;
        }
        Debug.Log("Timer: " + (int)Time.unscaledTime + " :: SCIFI :: UPDATE");
        Time.timeScale = 1.0f;
    }
}
