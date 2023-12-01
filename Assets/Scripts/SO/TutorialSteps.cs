using UnityEngine;

[CreateAssetMenu(fileName = "New Art Style", menuName = "Custom/Tutorial Steps")]
public class TutorialSteps : ScriptableObject
{
    public int numberOfSteps;
    public int currentStepNumber;

    public bool isMovingAvailable;
    public bool isAvoidingObstacleAvailable;
    public bool isOpeningDoorAvailable;
    public bool isJumpingAvailable;
}
