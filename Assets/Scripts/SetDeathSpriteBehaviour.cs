using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDeathSpriteBehaviour : StateMachineBehaviour
{
    [SerializeField] private Sprite deathSprite;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CatDeathUI animManager = animator.GetComponent<CatDeathUI>();
        if (animManager != null)
        {
            animManager.TriggerDeathUI(deathSprite);
        }
    }
}
