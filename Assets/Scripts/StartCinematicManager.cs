using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartCinematicManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private int mainMenuLevelindex;
    void Start()
    {
        video.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (video.isPaused)
        {
            sceneLoader.LoadLevel(mainMenuLevelindex);
        }
    }
}
