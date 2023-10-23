using TMPro;
using UnityEngine;

public class TutorialUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nextStepText;

    public void ChangeText(string nextStepName)
    {
        nextStepText.text = nextStepName;
    }

}
