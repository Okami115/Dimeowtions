using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnimationSciFi : MonoBehaviour
{
    [SerializeField] private Color firstColor;
    [SerializeField] private Color secondColor;

    [SerializeField] private Light light;

    [SerializeField] private float timeToFirst;
    [SerializeField] private float timeToSecond; 
    private float currentTime;

    private void Start()
    {
        timeToSecond += timeToFirst;
    }
    void Update()
    {
        currentTime += Time.deltaTime;

        if(timeToFirst > currentTime) 
        { 
            light.color = firstColor;
        }
        else if (timeToSecond > currentTime)
        { 
            light.color = secondColor;
        }
        else 
        {
            currentTime = 0;
        }

    }
}
