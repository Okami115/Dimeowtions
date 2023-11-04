using System.Threading;
using UnityEngine;

public class NoirState : State
{

    public NoirState(StateMachine machine, GameManager.GameManager gameManager, int distance) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevel), new EndLevel(distance, gameManager.playerStats));
    }

    public override void Enter()
    {
        Debug.Log("Enter: NOIR :: State");
        Time.timeScale = 0.0f;
        gameManager.CurrentAesthetic = GameManager.Aesthetic.Noir;
        Color color = new Color ( 1, 1, 1, 1 );
        gameManager.uiManager.portalImage.enabled = true;
        gameManager.uiManager.portalImage.color = color;
        gameManager.playerStats.distanceTraveled = 0;
        gameManager.uiManager.portal.Play();
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

        if (gameManager.uiManager.portal.isPlaying)
        {
            Time.timeScale = 0.0f;
        }
        else if (gameManager.uiManager.portal.isPaused && !gameManager.InTutorial)
        {
            Time.timeScale = 1.0f;
            Color color = new Color(1, 1, 1, 1);
            color.a = 0;
            gameManager.uiManager.portalImage.color = color;
        }
    }
}
