using UnityEngine;

public class SynthwaveState : State
{
    private readonly float delay;
    private float enterTime;
    public SynthwaveState(StateMachine machine, GameManager.GameManager gameManager, int distance, float delay) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevel), new EndLevel(distance, gameManager.playerStats));
        this.delay = delay;
    }

    public override void Enter()
    {
        Debug.Log("Enter: SYNTHWAVE :: State");
        Time.timeScale = 0.0f;
        enterTime = Time.unscaledTime;
        gameManager.CurrentAesthetic = GameManager.Aesthetic.Synthwave;
        gameManager.playerStats.distanceTraveled = 5000;
        gameManager.CallNextLevel();
    }

    public override void Exit()
    {
        Debug.Log("Exit: SYNTHWAVE :: State");
    }

    public override void Update()
    {
        if (CheckCondition<EndLevel>())
        {
            machine.ChangeState<SciFiState>();
        }
        if (Time.unscaledTime < enterTime + delay)
        {
            Debug.Log("Timer: " + (int)Time.unscaledTime + " :: SYNTHWAVE :: STAY");
            Time.timeScale = 0.0f;
            return;
        }
        Debug.Log("Timer: " + (int)Time.unscaledTime + " :: SYNTHWAVE :: UPDATE");
        Time.timeScale = 1.0f;
    }
}
