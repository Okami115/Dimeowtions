using Manager;
using Menu;
using UnityEngine;

public class PortalState : State
{
    public PortalState(StateMachine machine,GameManager gameManager, UIManager uiManager) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(ClosePortal), new ClosePortal(uiManager));
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter: PORTAL :: State");
        gameManager.CallPortalState();
    }

    public override void Exit()
    {
        Debug.LogWarning("Exit: PORTAL :: State");
        gameManager.ExitPortalState();
    }

    public override void Update()
    {
        gameManager.playerStats.isPause = true;
        if (CheckCondition<ClosePortal>())
        {
            gameManager.playerStats.isPause = false;
            if(gameManager.playerStats.collectedObjectsSpace == gameManager.playerStats.objectsToCollectSpace) {  machine.ChangeState<EndState>(); return; }
            if(gameManager.playerStats.collectedObjectsSynthwave == gameManager.playerStats.objectsToCollectSynthwave) { machine.ChangeState<SciFiState>(); return; }
            if(gameManager.playerStats.collectedObjectsNoir == gameManager.playerStats.objectsToCollectNoir) { machine.ChangeState<SynthwaveState>(); return; }
            if(gameManager.InTutorial) { machine.ChangeState<TutorialState>(); return; }
        }
    }
}
