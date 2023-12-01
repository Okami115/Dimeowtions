using UnityEngine;

public class SetTitleTransitionLastFrame : StateMachineBehaviour
{
    public Sprite lastFrameSprite;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        TitleAnimationController titleAnimationController = animator.gameObject.GetComponent<TitleAnimationController>();

        if (titleAnimationController != null && titleAnimationController.titleImage != null)
        {
            titleAnimationController.titleImage.sprite = lastFrameSprite;
        }
    }
}