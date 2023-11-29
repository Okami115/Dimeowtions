using Manager;
using UnityEngine;

public class SynthwaveState : State
{
    GameObject synthToSciFi;
    public SynthwaveState(StateMachine machine, GameManager gameManager, GameObject synthToSciFi) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevelSynthwave), new EndLevelSynthwave(gameManager.playerStats));
        this.synthToSciFi = synthToSciFi;
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
        synthToSciFi.GetComponent<PlaySound>().ChangeMusicState();

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
