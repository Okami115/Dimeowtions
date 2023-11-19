using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Video;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private int mainMenuLevelindex;
    [SerializeField] private float holdDuration = 1.0f;
    [SerializeField] private bool isSkeappeable;

    [SerializeField] Image emptySprite;
    [SerializeField] Image fullSprite;

    private bool transitioning = false;
    float transitionTime = 3.0f;
    float transitionTimer = 0.0f;

    private void Start()
    {
        if (isSkeappeable)
        {
            emptySprite.color = new Color(1f, 1f, 1f, 1f);
            fullSprite.color = new Color(1f, 1f, 1f, 0f);
        }
    }

    private void Update()
    {
        if (isSkeappeable) 
        {
            if (transitioning)
            {
                transitionTimer += Time.deltaTime;
                float progress = Mathf.Clamp01(transitionTimer / transitionTime);

                emptySprite.color = new Color(1f, 1f, 1f, 1f - progress);
                fullSprite.color = new Color(1f, 1f, 1f, progress);

                if (transitionTimer >= transitionTime)
                {
                    transitioning = false;
                    transitionTimer = 0.0f;
                    LoadNextScene();
                }
            }
        }
        
        if (video.isPaused)
            LoadNextScene();
        
       
    }

    public void SkipCinematic(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            transitioning = true;
        }
        else if (context.canceled)
        {
            transitioning = false;
            transitionTimer = 0.0f;

            emptySprite.color = new Color(1f, 1f, 1f, 1f);
            fullSprite.color = new Color(1f, 1f, 1f, 0f);
        }
    }

    private void LoadNextScene()
    {
        sceneLoader.LoadLevel(mainMenuLevelindex);
    }
}
