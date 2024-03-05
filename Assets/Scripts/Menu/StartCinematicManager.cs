using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private int mainMenuLevelindex;
    [SerializeField] private float transitionTime = 2.0f;
    [SerializeField] private bool isSkippable;

    [SerializeField] private RectTransform panelTransform;
    [SerializeField] private float maxWidth;

    private bool transitioning = false;
    private float transitionTimer = 0.0f;
    private Vector2 originalSizeDelta;

    private void Start()
    {
        if (panelTransform)
            originalSizeDelta = panelTransform.sizeDelta;
    }

    private void Update()
    {
        if (isSkippable)
        {
            if (transitioning)
            {
                transitionTimer += Time.deltaTime;
                float progress = Mathf.Clamp01(transitionTimer / transitionTime);
                float newWidth = Mathf.Lerp(0f, maxWidth, progress);

                Vector2 newSizeDelta = panelTransform.sizeDelta;
                newSizeDelta.x = newWidth;
                panelTransform.sizeDelta = newSizeDelta;

                if (transitionTimer >= transitionTime)
                {
                    transitioning = false;
                    LoadNextScene();
                }
            }
            else
                panelTransform.sizeDelta = originalSizeDelta;
        }

        if (video.isPaused)
            LoadNextScene();
    }

    public void SkipCinematic(InputAction.CallbackContext context)
    {
        if (context.started)
            transitioning = true;
        else if (context.canceled)
        {
            transitioning = false;
            transitionTimer = 0.0f;
        }
    }

    private void LoadNextScene()
    {
        sceneLoader.LoadLevel(mainMenuLevelindex);
    }
}