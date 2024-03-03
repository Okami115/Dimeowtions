using Manager;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerStats", menuName = "Custom/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float accelerationRate;
    public float currentSpeed;
    public float initialSpeed;
    public float maxSpeed;
    public int distanceTraveled;
    public int collectedObjectsEgypt;
    public int collectedObjectsNoir;
    public int collectedObjectsSynthwave;
    public int collectedObjectsSpace;

    public int objectsToCollectEgypt;
    public int objectsToCollectNoir;
    public int objectsToCollectSynthwave;
    public int objectsToCollectSpace;

    public int maxScore;
    public bool isPause;
    public bool isEndlessActive;
    public bool isEndlessAvailable;
    public bool isStoryModeFinished;
    public Aesthetic endlessAestheticSelected;
    public bool inPortalState;
}
