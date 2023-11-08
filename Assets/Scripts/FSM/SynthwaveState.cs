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
        CallPortal();
        gameManager.CallNextLevel();
        //gameManager.playerStats.distanceTraveled = 5000;
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
            return;
        }

        if (Time.unscaledTime < enterTime + delay)
        {
            return;
        }
        else if (Time.unscaledTime > enterTime + delay)
        {
            Time.timeScale = 1.0f;
        }
    }
}
