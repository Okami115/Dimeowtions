using player;
using UnityEngine;
using UnityEngine.UI;

public class CatDeathUI : MonoBehaviour
{
    [SerializeField] private CheckColision playerCollision;
    [SerializeField] private Animator catAnimator;
    [SerializeField] private string deathTrigger;

    [SerializeField] private GameObject deathObject;

    private void OnEnable()
    {
        playerCollision.deathActionFall += StartDeathUIAnimation;
        playerCollision.deathActionColision += StartDeathUIAnimation;
    }

    private void OnDisable()
    {
        playerCollision.deathActionFall -= StartDeathUIAnimation;
        playerCollision.deathActionColision -= StartDeathUIAnimation;
    }

    private void StartDeathUIAnimation()
    {
        catAnimator.SetTrigger(deathTrigger);
    }

    public void TriggerDeathUI(Sprite deathSprite)
    {
        deathObject.SetActive(true);

        deathObject.GetComponent<Image>().sprite = deathSprite;
    }
}
