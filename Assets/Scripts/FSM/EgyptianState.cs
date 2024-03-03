using Manager;
using Menu;
using System.Threading;
using UnityEngine;

public class EgyptianState : State
{
    GameObject noirSong;
    public EgyptianState(StateMachine machine, GameManager gameManager, GameObject noirSong) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevelEgyptian), new EndLevelEgyptian(gameManager.playerStats));        
        this.noirSong = noirSong;
    }

    public override void Enter()
    {
        Debug.LogWarning("Enter: EGYPTIAN :: State");
        gameManager.CurrentAesthetic = Aesthetic.Egyptian;
        gameManager.playerStats.distanceTraveled = 0;
        gameManager.CallInmortalState();
        gameManager.CallNextLevel();
        //noirSong.GetComponent<PlaySound>().ChangeMusicState();
    }

    public override void Exit()
    {
        Debug.LogWarning("Exit: EGYPTIAN :: State");        
    }

    public override void Update()
    {
        if (CheckCondition<EndLevelEgyptian>() && !gameManager.playerStats.isEndlessActive)
        {
            machine.ChangeState<PortalState>();
            return;
        }
    }
}