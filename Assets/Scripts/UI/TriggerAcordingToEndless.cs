using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAcordingToEndless : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    void Start()
    {
        gameObject.SetActive(!playerStats.isEndlessActive);
    }

}
