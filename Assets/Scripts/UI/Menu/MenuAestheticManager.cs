using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuAesthetic
{
    Egypt,
    Noir,
    Synthwave,
    Scifi,
    end
}

public class MenuAestheticManager : MonoBehaviour
{
    private MenuAesthetic currentAesthetic;
    internal MenuAesthetic CurrentAesthetic { get => currentAesthetic; set => currentAesthetic = value; }

    private MenuAesthetic previousAesthetic;
    internal MenuAesthetic PreviousAesthetic { get => previousAesthetic; set => previousAesthetic = value; }

    [SerializeField] private MenuInputManger menuInputManger;
    [SerializeField] private PlayerStats playerStats;

    public event Action<MenuAesthetic, MenuAesthetic> menuAestheticChanged;

    private void OnEnable()
    {
        menuInputManger.moveCameraLeft += CalculateAestheticLeft;
        menuInputManger.moveCameraRight += CalculateAestheticRight;
    }

    private void OnDisable()
    {
        menuInputManger.moveCameraLeft -= CalculateAestheticLeft;
        menuInputManger.moveCameraRight -= CalculateAestheticRight;
    }

    void Awake()
    {
        ChangeAesthetic(MenuAesthetic.Egypt);
    }

    public void CalculateAestheticLeft()
    {
        if (currentAesthetic == MenuAesthetic.Synthwave)
            ChangeAesthetic(MenuAesthetic.Noir);
        else if (currentAesthetic == MenuAesthetic.Noir)
            ChangeAesthetic(MenuAesthetic.Egypt);
        else if (currentAesthetic == MenuAesthetic.Scifi)
            ChangeAesthetic(MenuAesthetic.Synthwave);
    }

    public void CalculateAestheticRight()
    {
        if (currentAesthetic == MenuAesthetic.Noir)
            ChangeAesthetic(MenuAesthetic.Synthwave);
        else if (currentAesthetic == MenuAesthetic.Egypt)
            ChangeAesthetic(MenuAesthetic.Noir);
        else if (currentAesthetic == MenuAesthetic.Synthwave)
            ChangeAesthetic(MenuAesthetic.Scifi);
    }

    public void ChangeAesthetic(MenuAesthetic newMenuAesthetic)
    {
        if (/*PlayerPrefs.GetInt("StoryMode") == 0*/ playerStats.isStoryModeFinished)
        {
            previousAesthetic = currentAesthetic;
            currentAesthetic = newMenuAesthetic;
            menuAestheticChanged?.Invoke(previousAesthetic, currentAesthetic);
        }
    }
}
