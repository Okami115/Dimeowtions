using player;
using UnityEngine;

public class CatDeathUI : MonoBehaviour
{
    [SerializeField] private CheckColision playerCollision;
    [SerializeField] private Animator catAnimator;
    [SerializeField] private string deathTrigger;

    private void OnEnable()
    {
        playerCollision.deathAction += StartDeathUIAnimation;
    }

    private void OnDisable()
    {
        playerCollision.deathAction -= StartDeathUIAnimation;
    }

    private void StartDeathUIAnimation()
    {
        catAnimator.SetTrigger(deathTrigger);
    }
}
