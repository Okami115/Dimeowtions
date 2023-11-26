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
    public Sprite lastFrameSprite;
    public string stateName;
}

public class TitleAnimationController : MonoBehaviour
{
    [SerializeField] private MenuAestheticManager menuAestheticManager;
    [SerializeField] private Animator titleAnimator;
    [SerializeField] private Image titleImage;

    [SerializeField] private List<AestheticTransition> aestheticTransitions = new List<AestheticTransition>();

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
                StartCoroutine(SetLastFrameSpriteAfterAnimation(transition.lastFrameSprite, transition.stateName));
                break;
            }
        }
    }

    private IEnumerator SetLastFrameSpriteAfterAnimation(Sprite lastFrameSprite, string stateName)
    {
        while (AnimatorIsPlaying(stateName))
        {
            yield return null;
        }

        titleImage.sprite = lastFrameSprite;
    }

    private bool AnimatorIsPlaying()
    {
        return titleAnimator.GetCurrentAnimatorStateInfo(0).length >
               titleAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    private bool AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && titleAnimator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
}