using Manager;
using Menu;
using UnityEngine.UI;
using UnityEngine.Video;

public class EndState : State
{
    SceneLoader sceneManager;
    int endSceneIndex;

    public EndState(StateMachine machine, SceneLoader sceneManager, int endSceneIndex, GameManager gameManager) : base(machine)
    {
        this.sceneManager = sceneManager;
        this.endSceneIndex = endSceneIndex;
        this.gameManager = gameManager;
    }

    public override void Enter()
    {
        gameManager.playerStats.isEndlessAvailable = true;
        sceneManager.LoadLevel(endSceneIndex);
    }

    public override void Exit()
    {

    }

    public override void Update()
    {

    }
}
