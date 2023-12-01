using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action onMoveLeftInput;
    public event Action onMoveRightInput;
    public event Action onOpenDoorInput;
    public event Action onJumpInput;
    public event Action onGravitationalChangeInput;

    public void OnLeft()
    {
        if (onMoveLeftInput != null)
        {
            onMoveLeftInput.Invoke();
        }
    }

    public void OnRight()
    {
        if (onMoveRightInput != null)
        {
            onMoveRightInput.Invoke();
        }
    }

    public void OnInteraction()
    {
        if (onOpenDoorInput != null)
        {
            onOpenDoorInput.Invoke();
        }
    }

    public void OnJump()
    {
        if (onJumpInput != null)
        {
            onJumpInput.Invoke();
        }
    }

    public void OnGravitationalChange()
    {
        if (onGravitationalChangeInput != null)
        {
            onGravitationalChangeInput.Invoke();
        }
    }

}