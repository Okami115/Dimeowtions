using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("StoryMode"))
        {
            PlayerPrefs.SetInt("StoryMode", 1);
            playerStats.isStoryModeFinished = PlayerPrefs.GetInt("StoryMode") != 0;
        }
        //else
        //{
        //    playerStats.isStoryModeFinished = PlayerPrefs.GetInt("StoryMode") != 0;
        //}

        if (!playerStats.isStoryModeFinished)
        {
            leftArrow.SetActive(false);
            rightArrow.SetActive(false);
        }
        else
        {
            leftArrow.SetActive(false);
            rightArrow.SetActive(true);
        }
    }
}
