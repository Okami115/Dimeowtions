using Manager;
using UnityEngine;

public class SciFiState : State
{
    private readonly float delay;
    private float enterTime;
    public SciFiState(StateMachine machine, GameManager gameManager, int distance) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevel), new EndLevel(distance, gameManager.playerStats));
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter: SCIFI :: State");
        gameManager.CurrentAesthetic = Aesthetic.Scifi;
        gameManager.playerStats.distanceTraveled = 10000;
        gameManager.CallInmortalState();
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
            machine.ChangeState<PortalState>();
            return;
        }
    }
}
