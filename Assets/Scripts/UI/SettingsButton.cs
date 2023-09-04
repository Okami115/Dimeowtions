using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private ArtStyle artStyleSO;

    [SerializeField] Image settingsButtonImage;
    [SerializeField] private Sprite[] settingsButtonSprites;

    // Start is called before the first frame update
    void Start()
    {
        if (artStyleSO.isNoirSelected)
            settingsButtonImage.sprite = settingsButtonSprites[0];
        else if (artStyleSO.isSpaceSelected)
            settingsButtonImage.sprite = settingsButtonSprites[1];
        else if (artStyleSO.isSynthwaveSelected)
            settingsButtonImage.sprite = settingsButtonSprites[2];
    }
}