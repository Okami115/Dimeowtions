using UnityEngine;

public class WalkStateExitBehaviour : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CatAnimatorManager animManager = animator.GetComponent<CatAnimatorManager>();
        if (animManager != null)
        {
            animManager.ResetWalkStateSwitch();
        }
    }
}
