using Manager;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialState : State
{
    GameObject noirSong;
    GameObject noirToSynth;
    public TutorialState(StateMachine machine, GameManager gameManager, GameObject noirSong, GameObject noirToSynth) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevelNoir), new EndLevelNoir(gameManager.playerStats));
        this.noirSong = noirSong;
        this.noirToSynth = noirToSynth;
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter: TUTORIAL :: State");
        gameManager.CurrentAesthetic = Aesthetic.Noir;
        gameManager.playerStats.distanceTraveled = 0;
        noirSong.GetComponent<PlaySound>().ChangeMusicState();
    }

    public override void Exit()
    {
        Debug.LogWarning("Exit: TUTORIAL :: State");
        gameManager.InTutorial = false;
        noirToSynth.GetComponent<PlaySound>().ChangeMusicState();

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