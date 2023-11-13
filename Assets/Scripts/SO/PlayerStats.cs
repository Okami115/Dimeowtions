using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerStats", menuName = "Custom/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float currentSpeed;
    public float initialSpeed;
    public float maxSpeed;
    public int distanceTraveled;
    public int collectedObjectsNoir;
    public int collectedObjectsSynthwave;
    public int collectedObjectsSpace;
    public int objectsToCollectNoir;
    public int objectsToCollectSynthwave;
    public int objectsToCollectSpace;
    public int maxScore;
}
