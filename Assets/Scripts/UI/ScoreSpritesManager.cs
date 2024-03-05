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
    [SerializeField] private float[] relativeOffsetPorcentage;

    //[SerializeField] private UIManager uiManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Animator portalAnimator;
    [SerializeField] public string portalBoolPhasesFinishedName;
    [SerializeField] private string[] portalAnimatorPreviousTriggerNames;
    private int portalAnimatorPreviousTriggerSteps;

    private int lastCollectedIndex;
    int maxObjects = 0;

    private void OnEnable()
    {
        playerCollision.objectCollected += ChangeScoreSprite;
        playerCollision.infectedObjectCollected += ChangeScoreSpriteInfected;
        gameManager.nextLevel += ResetCollectiblesIndexer;
    }

    private void OnDisable()
    {
        playerCollision.objectCollected -= ChangeScoreSprite;
        playerCollision.infectedObjectCollected -= ChangeScoreSpriteInfected;
        gameManager.nextLevel -= ResetCollectiblesIndexer;
    }


    private void Start()
    {
        if (!playerStats.isEndlessActive)
        {
            for (int i = 0; i < scoreObjectsParents.Length; i++)
            {
                CalculateMaxObjects();

                for (int j = 1; j < maxObjects; j++)
                {
                    GameObject newObj = Instantiate(scoreObjects[i], scoreObjects[i].transform.position, scoreObjects[i].transform.rotation, scoreObjectsParents[i].transform);
                    float relativeOffset = Screen.width * relativeOffsetPorcentage[i];
                    newObj.transform.position = newObj.transform.position + new Vector3(j * relativeOffset, 0f, 0f);
                }
            }

        }
        
        ResetCollectiblesIndexer();

    }

    private void ChangeScoreSprite()
    {
        if (!playerStats.isEndlessActive)
        {
            CalculateMaxObjects();

            for (int i = 0; i < scoreObjectsParents.Length; i++)
            {
                if (lastCollectedIndex < maxObjects)
                {
                    GameObject childObject = scoreObjectsParents[i].transform.GetChild(lastCollectedIndex).gameObject;

                    if (childObject.activeInHierarchy)
                    {
                        ScoreSprite scoreSprite = childObject.GetComponent<ScoreSprite>();

                        if (scoreSprite != null)
                        {
                            scoreSprite.ChangeToFilledSprite();
                            lastCollectedIndex++;

                            if (lastCollectedIndex <= portalAnimatorPreviousTriggerNames.Length)
                            {
                                portalAnimator.SetTrigger(portalAnimatorPreviousTriggerNames[portalAnimatorPreviousTriggerSteps]);
                                portalAnimatorPreviousTriggerSteps++;
                            }

                            if (lastCollectedIndex == maxObjects)
                                portalAnimator.SetBool(portalBoolPhasesFinishedName, true);
                        }
                    }
                }
            }
        }
                           
    }

    private void ChangeScoreSpriteInfected()
    {
        if (!playerStats.isEndlessActive)
        {
            CalculateMaxObjects();

            for (int i = 0; i < scoreObjectsParents.Length; i++)
            {
                if (lastCollectedIndex > 0 && lastCollectedIndex < maxObjects)
                {
                    lastCollectedIndex--;
                    GameObject childObject = scoreObjectsParents[i].transform.GetChild(lastCollectedIndex).gameObject;

                    if (childObject.activeInHierarchy)
                    {
                        ScoreSprite scoreSprite = childObject.GetComponent<ScoreSprite>();

                        if (scoreSprite != null)
                        {
                            scoreSprite.ChangeToEmptySprite();                           
                        }
                    }
                }
            }
        }

    }

    private void ResetCollectiblesIndexer()
    {
        lastCollectedIndex = 0;
        portalAnimatorPreviousTriggerSteps = 0;
        portalAnimator.SetBool(portalBoolPhasesFinishedName, false);
    }

    private void CalculateMaxObjects()
    {
        if (gameManager.CurrentAesthetic == Aesthetic.Egyptian)
            maxObjects = playerStats.objectsToCollectEgypt;
        else if (gameManager.CurrentAesthetic == Aesthetic.Noir)
            maxObjects = playerStats.objectsToCollectNoir;
        else if (gameManager.CurrentAesthetic == Aesthetic.Synthwave)
            maxObjects = playerStats.objectsToCollectSynthwave;
        else if (gameManager.CurrentAesthetic == Aesthetic.Scifi)
            maxObjects = playerStats.objectsToCollectSpace;
    }
}
