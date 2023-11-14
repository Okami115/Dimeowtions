using Menu;
using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private UIManager UIManager;
    [SerializeField] private PlayerStats playerStats;

    public void OnPause()
    {
        playerStats.isPause = !playerStats.isPause;
        UIManager.TogglePausePanel(playerStats.isPause);
    }

}