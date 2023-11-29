using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenuManager : MonoBehaviour
{
    public AK.Wwise.Event slideMenu;
    public AK.Wwise.Event playButton;
    public AK.Wwise.Event exitButton;
    public AK.Wwise.Event creditsButton;
    public AK.Wwise.Event pointerUI;

    [SerializeField] InputManager ip;

    public void SlideMenu()
    {
        slideMenu.Post(gameObject);
    }

    public void PlayButton()
    {
        playButton.Post(gameObject);
    }

    public void ExitButton() 
    {
        exitButton.Post(gameObject);
    }

    public void CreditsButton()
    {
        creditsButton.Post(gameObject);
    }
    public void PointerUI()
    {
        pointerUI.Post(gameObject);
    }
    public void Start()
    {
        InputManager.onMoveLeft += SlideMenu;
        InputManager.onMoveRight += SlideMenu;
        //InputManager.onClick += ClickMenu;
       
    }
}
