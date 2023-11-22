using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessModeManager : MonoBehaviour
{

    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Image endlessModeImage;

    [SerializeField] private Sprite[] baseSprites;
    [SerializeField] private Sprite[] highlitedSprites;

    private int modeIndexer;
     
    // Start is called before the first frame update
    void Start()
    {
        playerStats.isEndlessActive = false;
        modeIndexer = 0;
    }

    public void ToggleEndlessMode()
    {
        if (playerStats.isEndlessAvailable)
        {
            playerStats.isEndlessActive = !playerStats.isEndlessActive;

            if (!playerStats.isEndlessActive) modeIndexer = 0;
            else modeIndexer = 1;

            endlessModeImage.sprite = baseSprites[modeIndexer];
        }
    }

    public void ApplyBaseSprite()
    {
        endlessModeImage.sprite = baseSprites[modeIndexer];
    }

    public void ApplySelectedSprite()
    {
        endlessModeImage.sprite = highlitedSprites[modeIndexer];
    }
}
