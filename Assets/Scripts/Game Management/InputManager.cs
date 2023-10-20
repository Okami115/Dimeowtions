using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action onMoveLeft;
    public static event Action onMoveRight;

    public void OnMoveLeft()
    {
        onMoveLeft.Invoke();   
    }

    public void OnMoveRight()
    {
        onMoveRight.Invoke();      
    }
}