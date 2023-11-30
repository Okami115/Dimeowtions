using Manager;
using Menu;
using UnityEngine;

public class PortalState : State
{
    GameObject noirSong;
    GameObject noirToSynth;
    GameObject synthToSciFi;


    public PortalState(StateMachine machine,GameManager gameManager, UIManager uiManager, GameObject noirSong, GameObject noirToSynth, GameObject synthToSciFi) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(ClosePortal), new ClosePortal(uiManager));
        this.noirSong = noirSong;
        this.noirToSynth = noirToSynth;
        this.synthToSciFi = synthToSciFi;
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter: PORTAL :: State");
        gameManager.CallPortalState();

        if (gameManager.playerStats.isEndlessActive)
        {
            Aesthetic aesthetic = GetCurrentAesthetic();

            if (aesthetic == Aesthetic.Noir)
            {
                noirSong.GetComponent<PlaySound>().ChangeMusicState();
            }
            else if (aesthetic == Aesthetic.Synthwave)
            {
                noirToSynth.GetComponent<PlaySound>().ChangeMusicState();
            }
            else if (aesthetic == Aesthetic.Scifi)
            {
                synthToSciFi.GetComponent<PlaySound>().ChangeMusicState();
            }
        }
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
                Aesthetic aesthetic = GetCurrentAesthetic();

                if (aesthetic == Aesthetic.Noir)              
                    machine.ChangeState<NoirState>();
                else if (aesthetic == Aesthetic.Synthwave)
                    machine.ChangeState<SynthwaveState>();
                else if (aesthetic == Aesthetic.Scifi)
                    machine.ChangeState<SciFiState>();
            }
        }
    }

    private Aesthetic GetCurrentAesthetic()
    {
        Aesthetic aesthetic;
        if (gameManager.playerStats.endlessAestheticSelected == Aesthetic.Noir)
        {
            aesthetic = Aesthetic.Noir;
            return aesthetic;
        }
        else if (gameManager.playerStats.endlessAestheticSelected == Aesthetic.Synthwave)
        {
            aesthetic = Aesthetic.Synthwave;
            return aesthetic;
        }
        else if (gameManager.playerStats.endlessAestheticSelected == Aesthetic.Scifi)
        {
            aesthetic = Aesthetic.Scifi;
            return aesthetic;
        }
        else
            return Aesthetic.Noir;
    }
}
