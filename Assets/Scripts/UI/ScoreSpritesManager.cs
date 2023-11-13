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
    [SerializeField] private float relativeOffsetPorcentage;

    [SerializeField] private UIManager uiManager;

    private int lastCollectedIndex;

    private void OnEnable()
    {
        playerCollision.objectCollected += ChangeScoreSprite;
        uiManager.nextLevel += ResetCollectiblesIndexer;
    }

    private void OnDisable()
    {
        playerCollision.objectCollected -= ChangeScoreSprite;
        uiManager.nextLevel -= ResetCollectiblesIndexer;
    }


    private void Start()
    {
        for (int i = 0; i < scoreObjectsParents.Length; i++)
        {
            for (int j = 1; j < playerStats.objectsToCollect; j++)
            {
                GameObject newObj = Instantiate(scoreObjects[i], scoreObjects[i].transform.position, scoreObjects[i].transform.rotation, scoreObjectsParents[i].transform);
                float relativeOffset = Screen.width * relativeOffsetPorcentage;
                newObj.transform.position = newObj.transform.position + new Vector3(j * relativeOffset, 0f, 0f);
            }
        }

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
                    }
                }
            }         
        }        
    }

    private void ResetCollectiblesIndexer()
    {
        lastCollectedIndex = 0;
    }
}
