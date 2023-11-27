using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CredistsController : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject credits;

    [SerializeField] private CreditScroll creditScroll;

    private void OnEnable()
    {
        InputManager.onMoveLeft += ShowMenu;
        InputManager.onMoveRight += ShowMenu;
        creditScroll.endCredits += ShowMenu;
    }

    private void OnDisable()
    {
        InputManager.onMoveLeft -= ShowMenu;
        InputManager.onMoveRight -= ShowMenu;
        creditScroll.endCredits -= ShowMenu;
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
