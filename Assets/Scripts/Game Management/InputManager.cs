using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action onMoveLeft;
    public static event Action onMoveRight;
    public static event Action onClick;

    public void OnMoveLeft()
    {
        if (onMoveLeft != null)
        {
            onMoveLeft.Invoke();
        }
    }

    public void OnMoveRight()
    {
        if (onMoveRight != null)
        {
            onMoveRight.Invoke();
        }
    }

    public void OnClick()
    {
        if (onClick != null)
        {
            onClick.Invoke();
        }
    }
}