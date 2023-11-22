using Manager;
using UnityEngine;

public class SynthwaveState : State
{
    public SynthwaveState(StateMachine machine, GameManager gameManager) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevelSynthwave), new EndLevelSynthwave(gameManager.playerStats));
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
        if (CheckCondition<EndLevelSynthwave>() && !gameManager.playerStats.isEndlessActive)
        {
            machine.ChangeState<PortalState>();
            return;
        }

    }
}
