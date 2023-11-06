using UnityEngine;

public class SynthwaveState : State
{

    public SynthwaveState(StateMachine machine, GameManager.GameManager gameManager, int distance) : base(machine)
    {
        this.gameManager = gameManager;
        conditions.Add(typeof(EndLevel), new EndLevel(distance, gameManager.playerStats));
    }

    public override void Enter()
    {
        Debug.Log("Enter: SYNTHWAVE :: State");
        Time.timeScale = 0.0f;
        gameManager.CurrentAesthetic = GameManager.Aesthetic.Synthwave;
        gameManager.CallNextLevel();
        Color color = new Color ( 1, 1, 1, 1 );
        gameManager.uiManager.portalImage.enabled = true;
        gameManager.uiManager.portalImage.color = color;
        gameManager.uiManager.portal.Play();
    }

    public override void Exit()
    {
        Debug.Log("Exit: SYNTHWAVE :: State");
    }

    public override void Update()
    {
        if (CheckCondition<EndLevel>())
        {
            machine.ChangeState<SciFiState>();
        }

        if (gameManager.uiManager.portal.isPlaying)
        {
            Time.timeScale = 0.0f;
        }
        else if (gameManager.uiManager.portal.isPaused)
        {
            Time.timeScale = 1.0f;
            Color color = new Color(1, 1, 1, 1);
            color.a = 0;
            gameManager.uiManager.portalImage.color = color;
        }
    }
}
