using Manager;
using UnityEngine;

public class SciFiState : State
{
    private readonly float delay;
    private float enterTime;
    public SciFiState(StateMachine machine, GameManager gameManager, int distance, float delay) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevel), new EndLevel(distance, gameManager.playerStats));
        conditions.Add(typeof(Pause), new Pause(gameManager.playerStats));
        this.delay = delay;
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter: SCIFI :: State");
        Time.timeScale = 0.0f;
        enterTime = Time.unscaledTime;
        gameManager.CurrentAesthetic = Aesthetic.Scifi;
        gameManager.playerStats.distanceTraveled = 10000;
        gameManager.CallNextLevel();
    }

    public override void Exit()
    {
        Debug.LogWarning("Exit: SCIFI :: State");
    }

    public override void Update()
    {
        if (CheckCondition<EndLevel>())
        {
            machine.ChangeState<NoirState>();
        }
        if (CheckCondition<Pause>())
        {
            machine.ChangeState<PauseState>();
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
