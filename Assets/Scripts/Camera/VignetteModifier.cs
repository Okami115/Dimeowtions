using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteModifier : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postProcessVolume;
    [SerializeField] private GameManager gameManager;
    private Vignette vignette;

    private bool enterPortal;
    private bool exitPortal;

    private void OnEnable()
    {
        gameManager.CallPortal += EnterPortal;
        gameManager.ExitPortal += ExitPortal;
    }

    private void OnDisable()
    {
        gameManager.CallPortal -= EnterPortal;
        gameManager.ExitPortal -= ExitPortal;
    }

    private void Start()
    {
        postProcessVolume.profile.TryGetSettings(out vignette);
    }

    private void Update()
    {
        if(enterPortal) { vignette.intensity.value += Time.deltaTime; }
        if(exitPortal) { vignette.intensity.value -= Time.deltaTime; }

        if(vignette.intensity.value < 0) { vignette.intensity.value = 0; }
        if(vignette.intensity.value > 1) { vignette.intensity.value = 1; }
    }

    private void EnterPortal()
    {
        enterPortal = true;
        exitPortal = false;
    }

    private void ExitPortal()
    {
        enterPortal = false;
        exitPortal = true;
    }
}
