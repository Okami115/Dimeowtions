using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] platforms;

    public void StartLevel()
    {
        for (int i = 0; i < platforms.Length; i++) 
        {
            platforms[i].SetActive(true);       
        }
    }
}
