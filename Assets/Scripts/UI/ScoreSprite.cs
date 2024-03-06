using UnityEngine;
using UnityEngine.UI;

public class ScoreSprite : MonoBehaviour
{
    [SerializeField] private Sprite baseSprite;
    [SerializeField] private Sprite filledSprite;

    private void Awake()
    {
        gameObject.GetComponent<Image>().sprite = baseSprite;
    }

    public void ChangeToFilledSprite()
    {
        gameObject.GetComponent<Image>().sprite = filledSprite;
    }

    public void ChangeToEmptySprite()
    {
        gameObject.GetComponent<Image>().sprite = baseSprite;
    }

}
