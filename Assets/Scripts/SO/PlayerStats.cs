using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerStats", menuName = "Custom/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float currentSpeed;
    public float initialSpeed;
    public float maxSpeed;
    public int distanceTraveled;
    public int collectedObjects;
    public int maxScore;
}
