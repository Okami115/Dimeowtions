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


    void Start()
    {
        playerStats.isEndlessActive = false;
        modeIndexer = 0;

        if (!playerStats.isStoryModeFinished)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void ToggleEndlessMode()
    {
        
        playerStats.isEndlessActive = !playerStats.isEndlessActive;

        if (!playerStats.isStoryModeFinished) modeIndexer = 0;
        else modeIndexer = 1;

        endlessModeImage.sprite = baseSprites[modeIndexer];
        
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
