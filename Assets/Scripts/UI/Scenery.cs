using System;
using UnityEngine;

public class Scenery : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;

    [SerializeField] private Material skyBox;
    internal void Hide()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }

    }

    internal void Show()
    {
        RenderSettings.skybox = skyBox;

        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(true);
        }
    }
}