using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject optionsPanel;

    private void Start()
    {
        menuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void ToggleMenuPanel(bool active)
    {
        menuPanel.SetActive(active);
    }

    public void ToggleOptionsPanel(bool active)
    {
        optionsPanel.SetActive(active);
    }
}
