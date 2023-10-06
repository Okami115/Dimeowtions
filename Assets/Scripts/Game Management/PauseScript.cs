using Menu;
using System;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private UIManager UIManager;

    public event Action<float> pauseEvent;

    public bool IsPaused { get => isPaused; set => isPaused = value; }
    private bool isPaused = false;


    public void OnPause()
    {
        if (isPaused)
        {
            pauseEvent?.Invoke(1.0f);
            isPaused = false;
            UIManager.TogglePausePanel(false);
        }
        else
        {
            pauseEvent?.Invoke(0.0f);
            isPaused = true;

            UIManager.TogglePausePanel(true);
        }
    }

}