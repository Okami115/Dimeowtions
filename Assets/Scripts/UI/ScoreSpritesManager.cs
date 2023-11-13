using Menu;
using player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSpritesManager : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private CheckColision playerCollision;
    [SerializeField] private GameObject[] scoreObjectsParents;
    [SerializeField] private GameObject[] scoreObjects;
    [SerializeField] private float offset;

    [SerializeField] private UIManager uiManager;
    private int levelIndexer = 0;

    private int lastCollectedIndex;

    private void OnEnable()
    {
        playerCollision.objectCollected += ChangeScoreSprite;
        uiManager.nextLevel += ToggleScoreSpriteParents;
    }

    private void OnDisable()
    {
        playerCollision.objectCollected -= ChangeScoreSprite;
        uiManager.nextLevel -= ToggleScoreSpriteParents;
    }


    private void Start()
    {
        for (int i = 0; i < scoreObjectsParents.Length; i++)
        {
            for (int j = 0; j < playerStats.objectsToCollect; j++)
            {
                GameObject newObj = Instantiate(scoreObjects[i], scoreObjects[i].transform.position, scoreObjects[i].transform.rotation, scoreObjectsParents[i].transform);
                newObj.transform.position = newObj.transform.position + new Vector3(j * offset, 0f, 0f);
            }
        }

        ToggleScoreSpriteParents();
    }

    private void ToggleScoreSpriteParents()
    {
        for(int i = 0; i < scoreObjectsParents.Length;i++)
        {
            if (i == levelIndexer)
            {
                scoreObjectsParents[i].SetActive(true);
            }
            else
            {
                scoreObjectsParents[i].SetActive(false);
            }
        }

        levelIndexer++;
        lastCollectedIndex = 0;
    }

    private void ChangeScoreSprite()
    {       
        if (lastCollectedIndex < playerStats.objectsToCollect)
        {
            for (int i = 0; i < scoreObjectsParents.Length; i++)
            {
                GameObject childObject = scoreObjectsParents[i].transform.GetChild(lastCollectedIndex).gameObject;

                if (childObject.activeInHierarchy)
                {
                    ScoreSprite scoreSprite = childObject.GetComponent<ScoreSprite>();

                    if (scoreSprite != null)
                    {
                        scoreSprite.ChangeToFilledSprite();
                        lastCollectedIndex++;
                        Debug.Log(lastCollectedIndex);
                    }
                }
            }         
        }        
    }
}
