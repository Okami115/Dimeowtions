using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelButtonsHandler : MonoBehaviour
{
    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;
    [SerializeField] private MoveCameraMenu moveCameraMenu;

    private void Start()
    {
        UpdateButtons();
    }

    private void OnEnable()
    {
        moveCameraMenu.moveCameraLeft += UpdateButtons;
        moveCameraMenu.moveCameraRight += UpdateButtons;
    }

    private void OnDisable()
    {
        moveCameraMenu.moveCameraLeft -= UpdateButtons;
        moveCameraMenu.moveCameraRight -= UpdateButtons;
    }

    private void UpdateButtons()
    {
        int currentIndex = moveCameraMenu.GetIndex();
        int maxIndex = moveCameraMenu.camaraPos.Length - 1;

        leftButton.SetActive(currentIndex > 0);
        rightButton.SetActive(currentIndex < maxIndex);
    }
}
