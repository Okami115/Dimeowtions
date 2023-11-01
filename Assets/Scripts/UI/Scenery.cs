using System;
using UnityEngine;

public class Scenery : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;

    internal void Hide()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }

    }

    internal void Show()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(true);
        }
    }
}