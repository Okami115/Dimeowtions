using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUIManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialStepsObject;
    [SerializeField] private Image tutorialStepsImage;
    [SerializeField] private Sprite[] tutorialStepsSprites;

    private int tutorialStepsWidth = 0;

    public void ChangeText()
    {
        tutorialStepsImage.sprite = tutorialStepsSprites[tutorialStepsWidth];
        tutorialStepsWidth++;
    }

    public void ToggleImage(bool active)
    {
        tutorialStepsObject.SetActive(active);
    }

}
