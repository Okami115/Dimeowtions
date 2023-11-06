using Menu;
using System.Threading;
using UnityEngine;

public class NoirState : State
{
    private readonly float delay;
    private float enterTime;

    public NoirState(StateMachine machine, GameManager.GameManager gameManager, int distance, float delay) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevel), new EndLevel(distance, gameManager.playerStats));
        this.delay = delay;
    }

    public override void Enter()
    {
        Debug.Log("Enter: NOIR :: State");
        Time.timeScale = 0.0f;
        enterTime = Time.unscaledTime;
        gameManager.CurrentAesthetic = GameManager.Aesthetic.Noir;
        gameManager.CallNextLevel();
        gameManager.playerStats.distanceTraveled = 0;
    }

    public override void Exit()
    {
        Debug.Log("Exit: NOIR :: State");
        
    }

    public override void Update()
    {
        if (CheckCondition<EndLevel>())
        {
            machine.ChangeState<SynthwaveState>();
        }
        if(Time.unscaledTime < enterTime + delay)
        {
            return;
        }
        Time.timeScale = 1.0f;
        //se va para el uiManager
        if (gameManager.uiManager.portal.isPaused)
        {
            Color color = new Color(1, 1, 1, 0);
            gameManager.uiManager.portalImage.color = color;
        }
    }
}
