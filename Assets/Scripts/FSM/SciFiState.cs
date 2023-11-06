using UnityEngine;

public class SciFiState : State
{

    public SciFiState(StateMachine machine, GameManager.GameManager gameManager, int distance) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevel), new EndLevel(distance, gameManager.playerStats));
    }

    public override void Enter()
    {
        Debug.Log("Enter: SCIFI :: State");
        Time.timeScale = 0.0f;
        gameManager.CurrentAesthetic = GameManager.Aesthetic.Scifi;
        gameManager.CallNextLevel();
        Color color = new Color ( 1, 1, 1, 1 );
        gameManager.uiManager.portalImage.enabled = true;
        gameManager.uiManager.portalImage.color = color;
        gameManager.uiManager.portal.Play();
    }

    public override void Exit()
    {
        Debug.Log("Exit: SCIFI :: State");
    }

    public override void Update()
    {
        if (CheckCondition<EndLevel>())
        {
            machine.ChangeState<NoirState>();
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
