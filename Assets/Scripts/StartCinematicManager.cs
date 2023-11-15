using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class StartCinematicManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private int mainMenuLevelindex;

    // Update is called once per frame
    void Update()
    {
        if (video.isPaused || Keyboard.current.anyKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
        {
            sceneLoader.LoadLevel(mainMenuLevelindex);
        }
    }
}
