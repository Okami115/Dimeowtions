using UnityEngine;
using UnityEngine.UI;

public class MenuRandomizer : MonoBehaviour
{
    [SerializeField] RawImage menuBackground;
    [SerializeField] private Image settingsButtonImage;

    [SerializeField] private Sprite[] menuBackgrounds;
    [SerializeField] private Sprite[] settingsButtonSprites;

    private void Start()
    {
        if (menuBackgrounds.Length == 0)
        {
            Debug.LogError("No sprites assigned to the menuLayouts array.");
            return;
        }

        int randomIndex = Random.Range(0, menuBackgrounds.Length);

        menuBackground.texture = menuBackgrounds[randomIndex].texture;
        settingsButtonImage.sprite = settingsButtonSprites[randomIndex];
    }

}
