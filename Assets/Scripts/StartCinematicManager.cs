using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class StartCinematicManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private int mainMenuLevelindex;
    [SerializeField] private float holdDuration = 1.0f;

    private bool isHoldingKey = false;
    private float holdTimer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (video.isPaused)
            LoadNextScene();

        if (isHoldingKey )
        {
            holdTimer += Time.deltaTime;

            if (holdTimer >= holdDuration)
            {
                LoadNextScene();
            }

            if (!Keyboard.current.anyKey.isPressed)
            {
                isHoldingKey = false;
                holdTimer = 0.0f;
            }
        }
    }

    public void OnSkipCinematic()
    {
        isHoldingKey = true;
        holdTimer = 0.0f;
    }

    private void LoadNextScene()
    {
        sceneLoader.LoadLevel(mainMenuLevelindex);
    }
}
