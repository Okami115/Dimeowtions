using UnityEngine;

public class LevelSelectorMovement : MonoBehaviour
{
    [SerializeField] private Transform[] positions;
    private int currentPositionIndex;

    private void OnEnable()
    {
         InputManager.onMoveLeft += MovePlatformLeft;
         InputManager.onMoveRight += MovePlatformRight;
    }

    private void OnDisable()
    {
        InputManager.onMoveLeft -= MovePlatformLeft;
        InputManager.onMoveRight -= MovePlatformRight;
    }


    private void Start()
    {
        currentPositionIndex = positions.Length - 1;
        MoveToCurrentPosition();
    }

    private void MovePlatformLeft()
    {
        currentPositionIndex = Mathf.Max(currentPositionIndex - 1, 0);
        MoveToCurrentPosition();
    }

    private void MovePlatformRight()
    {
        currentPositionIndex = Mathf.Min(currentPositionIndex + 1, positions.Length - 1);
        MoveToCurrentPosition();
    }

    private void MoveToCurrentPosition()
    {
        if (positions.Length > 0 && currentPositionIndex >= 0 && currentPositionIndex < positions.Length)
        {
            transform.position = positions[currentPositionIndex].position;
        }
    }
}
