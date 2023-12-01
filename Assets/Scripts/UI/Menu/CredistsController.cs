using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CredistsController : MonoBehaviour
{
    [SerializeField] private MenuInputManger menuInputManger;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject credits;

    [SerializeField] private CreditScroll creditScroll;

    private void OnEnable()
    {
        menuInputManger.back += ShowMenu;
    }

    private void OnDisable()
    {
        menuInputManger.back -= ShowMenu;
    }

    public void ShowMenu()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }

    public void ShowCredits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }
}
