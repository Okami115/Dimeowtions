using Manager;
using Menu;
using UnityEngine.UI;
using UnityEngine.Video;

public class EndState : State
{
    SceneLoader sceneManager;
    int endSceneIndex;

    public EndState(StateMachine machine, SceneLoader sceneManager, int endSceneIndex) : base(machine)
    {
        this.sceneManager = sceneManager;
        this.endSceneIndex = endSceneIndex;
    }

    public override void Enter()
    {
        sceneManager.LoadLevel(endSceneIndex);
    }

    public override void Exit()
    {

    }

    public override void Update()
    {

    }
}
