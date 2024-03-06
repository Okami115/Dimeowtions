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
    int currentObjectsCollected = 0;

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
                CalculateCurrentObjectsCollected();

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
            CalculateCurrentObjectsCollected();

            for (int i = 0; i < scoreObjectsParents.Length; i++)
            {
                //if (currentObjectsCollected < maxObjects)
                //{
                GameObject childObject = scoreObjectsParents[i].transform.GetChild(currentObjectsCollected).gameObject;

                if (childObject.activeInHierarchy)
                {
                    ScoreSprite scoreSprite = childObject.GetComponent<ScoreSprite>();

                    if (scoreSprite != null)
                    {
                        //lastCollectedIndex++;
                        scoreSprite.ChangeToFilledSprite();

                        if (currentObjectsCollected < portalAnimatorPreviousTriggerNames.Length)
                        {
                            portalAnimatorPreviousTriggerSteps++;
                            if (portalAnimatorPreviousTriggerSteps > maxObjects) portalAnimatorPreviousTriggerSteps = currentObjectsCollected;
                            portalAnimator.SetTrigger(portalAnimatorPreviousTriggerNames[portalAnimatorPreviousTriggerSteps - 1]);
                        }

                        if (currentObjectsCollected == maxObjects)
                            portalAnimator.SetBool(portalBoolPhasesFinishedName, true);
                    }
                }
                //}
            }
        }
                           
    }

    private void ChangeScoreSpriteInfected()
    {
        if (!playerStats.isEndlessActive)
        {
            CalculateMaxObjects();
            CalculateCurrentObjectsCollected();

            for (int i = 0; i < scoreObjectsParents.Length; i++)
            {
                GameObject childObject = scoreObjectsParents[i].transform.GetChild(currentObjectsCollected).gameObject;

                if (childObject.activeInHierarchy)
                {
                    ScoreSprite scoreSprite = childObject.GetComponent<ScoreSprite>();

                    if (scoreSprite != null)
                    {
                        //lastCollectedIndex--;
                        //if (lastCollectedIndex < 0) lastCollectedIndex = 0;

                        portalAnimatorPreviousTriggerSteps--;
                        if (portalAnimatorPreviousTriggerSteps < 0) portalAnimatorPreviousTriggerSteps = 0;
                        portalAnimator.SetTrigger(portalAnimatorPreviousTriggerNames[portalAnimatorPreviousTriggerSteps]);

                        scoreSprite.ChangeToEmptySprite();                           
                    }
                }
                
            }
        }

    }

    private void ResetCollectiblesIndexer()
    {
        //lastCollectedIndex = 0;
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
    
    private void CalculateCurrentObjectsCollected()
    {
        if (gameManager.CurrentAesthetic == Aesthetic.Egyptian)
            currentObjectsCollected  = playerStats.collectedObjectsEgypt;
        else if (gameManager.CurrentAesthetic == Aesthetic.Noir)
            currentObjectsCollected = playerStats.collectedObjectsNoir;
        else if (gameManager.CurrentAesthetic == Aesthetic.Synthwave)
            currentObjectsCollected = playerStats.collectedObjectsSynthwave;
        else if (gameManager.CurrentAesthetic == Aesthetic.Scifi)
            currentObjectsCollected = playerStats.collectedObjectsSpace;
    }
}
