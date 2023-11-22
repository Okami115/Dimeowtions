using Manager;
using UnityEngine;

public class SciFiState : State
{
    public SciFiState(StateMachine machine, GameManager gameManager) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevelSpace), new EndLevelSpace(gameManager.playerStats));
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
        if (CheckCondition<EndLevelSpace>() && !gameManager.playerStats.isEndlessActive)
        {
            machine.ChangeState<PortalState>();
            return;
        }
    }
}
