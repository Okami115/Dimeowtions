using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class AestheticTransition
{
    public MenuAesthetic previousAesthetic;
    public MenuAesthetic currentAesthetic;
    public string triggerString;
}

public class TitleAnimationController : MonoBehaviour
{
    [SerializeField] private MenuAestheticManager menuAestheticManager;
    [SerializeField] private Animator titleAnimator;
    [SerializeField] public Image titleImage;

    [SerializeField] public List<AestheticTransition> aestheticTransitions = new List<AestheticTransition>();


    private void OnEnable()
    {
        menuAestheticManager.menuAestheticChanged += TriggerAnimation;
    }

    private void OnDisable()
    {
        menuAestheticManager.menuAestheticChanged -= TriggerAnimation;
    }

    private void TriggerAnimation(MenuAesthetic previousAesthetic, MenuAesthetic currentAesthetic)
    {
        foreach (var transition in aestheticTransitions)
        {
            if (transition.previousAesthetic == previousAesthetic && transition.currentAesthetic == currentAesthetic)
            {
                titleAnimator.SetTrigger(transition.triggerString);
                break;
            }
        }
    }
}