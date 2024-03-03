using Manager;
using Menu;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialState : State
{
    GameObject noirSong;
    GameObject noirToSynth;
    UIManager uiManager;

    public TutorialState(StateMachine machine, GameManager gameManager, UIManager uiManager, GameObject noirSong, GameObject noirToSynth) : base(machine)
    {
        this.gameManager = gameManager;
        this.uiManager = uiManager;
        conditions.Add(typeof(EndLevelEgyptian), new EndLevelEgyptian(gameManager.playerStats));
        this.noirSong = noirSong;
        this.noirToSynth = noirToSynth;
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter: TUTORIAL :: State");
        gameManager.CurrentAesthetic = Aesthetic.Egyptian;
        gameManager.playerStats.distanceTraveled = 0;
        noirSong.GetComponent<PlaySound>().ChangeMusicState();
        //uiManager.TriggerObjetiveImage();
    }

    public override void Exit()
    {
        Debug.LogWarning("Exit: TUTORIAL :: State");
        gameManager.InTutorial = false;
        noirToSynth.GetComponent<PlaySound>().ChangeMusicState();
    }

    public override void Update()
    {
        if (CheckCondition<EndLevelEgyptian>())
        {
            machine.ChangeState<PortalState>();
            return;
        }
    }
}