using System;
using UnityEngine;

public class MenuInputManger : MonoBehaviour
{
    public event Action moveCameraLeft;
    public event Action moveCameraRight;
    public event Action back;
    public event Action onClick;

    public void OnMoveLeft()
    {
        moveCameraLeft?.Invoke();
    }

    public void OnMoveRight()
    {
        moveCameraRight?.Invoke();
    }

    public void OnPause()
    {
        back?.Invoke();
    }

    public void OnClick()
    {
        onClick?.Invoke();
    }
}