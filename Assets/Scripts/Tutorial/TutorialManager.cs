using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TutorialSteps tutorialStepsSO;
    [SerializeField] private player.PlayerMovement pm;
    [SerializeField] private player.CheckColision cc;

    [SerializeField] private string moveStepText;
    [SerializeField] private string avoidCollisionStepText;
    [SerializeField] private string openDoorStepText;
    [SerializeField] private string jumpStepText;
    [SerializeField] private string tutorialCompleteText;
    
    public TextMeshProUGUI tutorialText;
    public float tutorialSpeed = 0.1f;
    private bool isTutorialActive = true;

    private void OnEnable()
    {
        pm.moveAction += OnMoveStep;
        OpenDoor.openDoor += OpenDoorStep;
        pm.jump += JumpStep;
        cc.collisionEffective += CollisionStep;
    }

    private void OnDisable()
    {
        pm.moveAction -= OnMoveStep;
        OpenDoor.openDoor -= OpenDoorStep;
        pm.jump -= JumpStep;
        cc.collisionEffective -= CollisionStep;
    }

    private void Start()
    {
        RestartTutorial();
        //StartCoroutine(StartTutorial());
    }

    private void Update()
    {
        //Time.timeScale = 1f;
        //yield return new WaitForSeconds(2f); // Optional delay at the start.
        if (isTutorialActive)
        {
            //Time.timeScale = tutorialSpeed;
            if (tutorialStepsSO.currentStepNumber == tutorialStepsSO.numberOfSteps)
            {
                isTutorialActive = false;
                tutorialText.text = tutorialCompleteText;
            }
        }
    }

    private void NextStep()
    {
        tutorialStepsSO.currentStepNumber++;
    }

    private void OnMoveStep()
    {
        if (tutorialStepsSO.isMovingAvailable)
        {
            tutorialStepsSO.isMovingAvailable = false;
            tutorialStepsSO.isAvoidingObstacleAvailable = true;
            tutorialText.text = avoidCollisionStepText;
            NextStep();
        }
    }

    private void CollisionStep()
    {
        if (tutorialStepsSO.isAvoidingObstacleAvailable)
        {
            tutorialStepsSO.isAvoidingObstacleAvailable = false;
            tutorialStepsSO.isOpeningDoorAvailable = true;
            tutorialText.text = openDoorStepText;
            NextStep();
        }
    }

    private void OpenDoorStep()
    {
        if (tutorialStepsSO.isOpeningDoorAvailable)
        {
            tutorialStepsSO.isOpeningDoorAvailable = false;
            tutorialStepsSO.isJumpingAvailable = true;
            tutorialText.text = jumpStepText;
            NextStep();
        }
    }

    private void JumpStep()
    {
        if (tutorialStepsSO.isJumpingAvailable)
        {
            tutorialStepsSO.isJumpingAvailable = false;
            NextStep();
        }
    }

    private void RestartTutorial()
    {
        tutorialStepsSO.currentStepNumber = 0;
        tutorialText.text = moveStepText;

        tutorialStepsSO.isMovingAvailable = true;
        tutorialStepsSO.isAvoidingObstacleAvailable = false;
        tutorialStepsSO.isOpeningDoorAvailable = false;
        tutorialStepsSO.isJumpingAvailable = false;
    }
}
