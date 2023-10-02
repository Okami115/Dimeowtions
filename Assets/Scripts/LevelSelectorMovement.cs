using System;
using UnityEngine;

public class LevelSelectorMovement : MonoBehaviour
{
    [SerializeField] private Transform[] positions;
    [SerializeField] private ArtStyle artStyleSO;
    private int currentPositionIndex;

    public static event Action changeArtStyle;

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

        UpdateArtStyle();
    }

    private void UpdateArtStyle()
    {
        switch (currentPositionIndex)
        {
            case 0:             
                artStyleSO.isNoirSelected = false;
                artStyleSO.isSynthwaveSelected = false;
                artStyleSO.isSpaceSelected = true;
                break;
            case 1:
                artStyleSO.isNoirSelected = false;
                artStyleSO.isSynthwaveSelected = true;
                artStyleSO.isSpaceSelected = false;
                break;
            case 2:
                artStyleSO.isNoirSelected = true;
                artStyleSO.isSynthwaveSelected = false;
                artStyleSO.isSpaceSelected = false;
                break;
            default:
                break;
        }

        changeArtStyle?.Invoke();
    }
}
