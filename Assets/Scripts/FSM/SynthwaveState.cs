using Manager;
using UnityEngine;

public class SynthwaveState : State
{
    private readonly float delay;
    private float enterTime;
    public SynthwaveState(StateMachine machine, GameManager gameManager, int distance, float delay) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevel), new EndLevel(distance, gameManager.playerStats));
        conditions.Add(typeof(Pause), new Pause(gameManager.playerStats));
        this.delay = delay;
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter: SYNTHWAVE :: State");
        Time.timeScale = 0.0f;
        enterTime = Time.unscaledTime;
        gameManager.CurrentAesthetic = Aesthetic.Synthwave;
        gameManager.playerStats.distanceTraveled = 5000;
        gameManager.CallNextLevel();
    }

    public override void Exit()
    {
        Debug.LogWarning("Exit: SYNTHWAVE :: State");
    }

    public override void Update()
    {
        if (CheckCondition<EndLevel>())
        {
            machine.ChangeState<SciFiState>();
        }
        if (CheckCondition<Pause>())
        {
            machine.ChangeState<PauseState>();
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
