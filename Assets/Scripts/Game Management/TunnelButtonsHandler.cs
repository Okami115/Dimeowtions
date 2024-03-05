using System.Collections.Generic;
using UnityEngine;

public class TunnelButtonsHandler : MonoBehaviour
{
    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;
    [SerializeField] private MenuAestheticManager menuAestheticManager;

    private void Start()
    {
        UpdateButtons(menuAestheticManager.PreviousAesthetic, menuAestheticManager.CurrentAesthetic);
    }

    private void OnEnable()
    {
        menuAestheticManager.menuAestheticChanged +=  UpdateButtons;
    }

    private void OnDisable()
    {
        menuAestheticManager.menuAestheticChanged -= UpdateButtons;
    }

    private void UpdateButtons(MenuAesthetic previousAesthetic, MenuAesthetic currentAesthetic)
    {
        var buttonStates = new Dictionary<MenuAesthetic, (bool left, bool right)>()
        {
            { MenuAesthetic.Egypt, (false, true) },
            { MenuAesthetic.Noir, (true, true) },
            { MenuAesthetic.Scifi, (true, false) },
            { MenuAesthetic.Synthwave, (true, true) },
        };

        if (buttonStates.TryGetValue(currentAesthetic, out var states))
        {
            leftButton.SetActive(states.left);
            rightButton.SetActive(states.right);
        }
        else
        {
            leftButton.SetActive(true);
            rightButton.SetActive(true);
        }
    }
}
