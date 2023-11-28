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
    }

    public override void Update()
    {
        gameManager.playerStats.isPause = true;
        if (CheckCondition<ClosePortal>())
        {
            gameManager.playerStats.isPause = false;

            if (!gameManager.playerStats.isEndlessActive)
            {
                if (gameManager.InTutorial) { machine.ChangeState<TutorialState>(); }
                if (gameManager.playerStats.collectedObjectsNoir == gameManager.playerStats.objectsToCollectNoir) { machine.ChangeState<SynthwaveState>(); }
                if (gameManager.playerStats.collectedObjectsSynthwave == gameManager.playerStats.objectsToCollectSynthwave) { machine.ChangeState<SciFiState>(); }
                if (gameManager.playerStats.collectedObjectsSpace == gameManager.playerStats.objectsToCollectSpace) { machine.ChangeState<EndState>(); }
            }
            else
            {
                if (gameManager.playerStats.endlessAestheticSelected == Aesthetic.Noir)
                    machine.ChangeState<NoirState>();
                else if (gameManager.playerStats.endlessAestheticSelected == Aesthetic.Synthwave)
                    machine.ChangeState<SynthwaveState>();
                else if (gameManager.playerStats.endlessAestheticSelected == Aesthetic.Scifi)
                    machine.ChangeState<SciFiState>();
            }
            
        }
    }
}
