using Menu;
using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private UIManager UIManager;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private AK.Wwise.Event pauseMusic ;
    [SerializeField] private AK.Wwise.Event unpauseMusic ;

    public void OnPause()
    {
        playerStats.isPause = !playerStats.isPause;
        UIManager.TogglePausePanel(playerStats.isPause);
        if (playerStats.isPause) pauseMusic.Post(gameObject);
        else unpauseMusic.Post(gameObject);
    }

}