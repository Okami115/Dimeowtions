using Manager;
using Menu;
using System.Threading;
using UnityEngine;

public class NoirState : State
{
    public NoirState(StateMachine machine, GameManager gameManager) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevelNoir), new EndLevelNoir(gameManager.playerStats));
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter: NOIR :: State");
        gameManager.CurrentAesthetic = Aesthetic.Noir;
        gameManager.playerStats.distanceTraveled = 0;
        gameManager.CallInmortalState();
        gameManager.CallNextLevel();
    }

    public override void Exit()
    {
        Debug.LogWarning("Exit: NOIR :: State");
        
    }

    public override void Update()
    {
        if (CheckCondition<EndLevelNoir>())
        {
            machine.ChangeState<PortalState>();
            return;
        }

    }
}