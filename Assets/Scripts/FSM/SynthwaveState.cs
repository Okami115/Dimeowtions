using Manager;
using UnityEngine;

public class SynthwaveState : State
{
    private readonly float delay;
    private float enterTime;
    public SynthwaveState(StateMachine machine, GameManager gameManager, int distance) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevel), new EndLevel(distance, gameManager.playerStats));
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter: SYNTHWAVE :: State");
        gameManager.CurrentAesthetic = Aesthetic.Synthwave;
        gameManager.playerStats.distanceTraveled = 5000;
        gameManager.CallInmortalState();
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
            machine.ChangeState<PortalState>();
            return;
        }

    }
}
