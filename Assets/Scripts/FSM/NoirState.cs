using Manager;
using Menu;
using System.Threading;
using UnityEngine;

public class NoirState : State
{
    
    GameObject noirSong;
    public NoirState(StateMachine machine, GameManager gameManager, GameObject noirSong) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevelNoir), new EndLevelNoir(gameManager.playerStats));        
        this.noirSong = noirSong;
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter: NOIR :: State");
        gameManager.CurrentAesthetic = Aesthetic.Noir;
        gameManager.playerStats.distanceTraveled = 0;
        gameManager.CallInmortalState();
        gameManager.CallNextLevel();
        noirSong.GetComponent<PlaySound>().ChangeMusicState();

    }

    public override void Exit()
    {
        Debug.LogWarning("Exit: NOIR :: State");        
        
    }

    public override void Update()
    {
        if (CheckCondition<EndLevelNoir>() && !gameManager.playerStats.isEndlessActive)
        {
            machine.ChangeState<PortalState>();
            return;
        }
    }
}