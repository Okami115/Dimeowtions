using Manager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PlayButtonClickHandler : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private int playerDistanceTraveled;
    [SerializeField] private MenuInputManger menuInputManger;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform camZoomPos;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private int gameSceneIndexer;
    [SerializeField] private float fadeInDuration;
    [SerializeField] private float zoomDuration;
    [SerializeField] private string obstacleTag;

    [SerializeField] private Image panel;
    private Color initialColor;
    private Color targetColor;

    [SerializeField] private Aesthetic aestheticSelected;

    private void Start()
    {
        initialColor = panel.color;
        targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 1.0f);
    }

    private void OnEnable()
    {
        menuInputManger.onClick += TriggerRaycast;
    }

    private void OnDisable()
    {
        menuInputManger.onClick -= TriggerRaycast;
    }

    private void TriggerRaycast()
    {
        Vector3 raycastOrigin = mainCamera.transform.position;
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hitInfo;

        if (Physics.Raycast(raycastOrigin, ray.direction, out hitInfo))
        {
            if (hitInfo.collider.CompareTag(obstacleTag))
            {
                StartCoroutine(FadeInAnimation());
                StartCoroutine(ZoomAnimation());
            }
        }
    }

    public void TriggerCorrotines()
    {
        StartCoroutine(FadeInAnimation());
        StartCoroutine(ZoomAnimation());
    }

    private IEnumerator FadeInAnimation()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;

            float fadeInTime = elapsedTime / fadeInDuration;

            float alpha = Mathf.Lerp(initialColor.a, targetColor.a, fadeInTime);
            panel.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);

            yield return null;
        }

        panel.color = targetColor;
    }

    private IEnumerator ZoomAnimation()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < zoomDuration)
        {
            elapsedTime += Time.fixedDeltaTime;

            float zoomTime = elapsedTime / zoomDuration;

            float newZ = Mathf.Lerp(mainCamera.transform.position.z, camZoomPos.position.z, zoomTime);
            Vector3 newPosition = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, newZ);

            mainCamera.transform.position = newPosition;

            yield return null;
        }

        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, camZoomPos.position.z);

        if (playerStats.isEndlessActive)
        {
            playerStats.endlessAestheticSelected = aestheticSelected;
        }

        if (playerStats.isEndlessActive)
        {
            playerStats.endlessAestheticSelected = aestheticSelected;
        }

        sceneLoader.LoadLevel(gameSceneIndexer);
    }
}
