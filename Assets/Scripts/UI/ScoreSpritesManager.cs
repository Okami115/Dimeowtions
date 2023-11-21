using Manager;
using Menu;
using player;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSpritesManager : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private CheckColision playerCollision;
    [SerializeField] private GameObject[] scoreObjectsParents;
    [SerializeField] private GameObject[] scoreObjects;
    [SerializeField] private float relativeOffsetPorcentage;

    //[SerializeField] private UIManager uiManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Animator portalAnimator;
    [SerializeField] private string[] portalAnimatorPreviousTriggerNames;
    private int portalAnimatorPreviousTriggerSteps;

    private int lastCollectedIndex;
    int maxObjects = 0;

    private void OnEnable()
    {
        playerCollision.objectCollected += ChangeScoreSprite;
        gameManager.nextLevel += ResetCollectiblesIndexer;
    }

    private void OnDisable()
    {
        playerCollision.objectCollected -= ChangeScoreSprite;
        gameManager.nextLevel -= ResetCollectiblesIndexer;
    }


    private void Start()
    {
        for (int i = 0; i < scoreObjectsParents.Length; i++)
        {
            CalculateMaxObjects();

            for (int j = 1; j < maxObjects; j++)
            {
                GameObject newObj = Instantiate(scoreObjects[i], scoreObjects[i].transform.position, scoreObjects[i].transform.rotation, scoreObjectsParents[i].transform);
                float relativeOffset = Screen.width * relativeOffsetPorcentage;
                newObj.transform.position = newObj.transform.position + new Vector3(j * relativeOffset, 0f, 0f);
            }
        }

        ResetCollectiblesIndexer();

    }

    private void ChangeScoreSprite()
    {
        CalculateMaxObjects();

        if (lastCollectedIndex < maxObjects)
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

                        portalAnimator.SetTrigger(portalAnimatorPreviousTriggerNames[portalAnimatorPreviousTriggerSteps]);
                        portalAnimatorPreviousTriggerSteps++;
                    }
                }
            }         
        }        
    }

    private void ResetCollectiblesIndexer()
    {
        lastCollectedIndex = 0;
        portalAnimatorPreviousTriggerSteps = 0;
    }

    private void CalculateMaxObjects()
    {
        if (gameManager.CurrentAesthetic == Aesthetic.Noir)
            maxObjects = playerStats.objectsToCollectNoir;
        else if (gameManager.CurrentAesthetic == Aesthetic.Synthwave)
            maxObjects = playerStats.objectsToCollectSynthwave;
        else if (gameManager.CurrentAesthetic == Aesthetic.Scifi)
            maxObjects = playerStats.objectsToCollectSpace;
    }
}
