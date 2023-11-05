using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform camZoomPos;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private int gameSceneIndexer;
    [SerializeField] private float fadeInDuration;
    [SerializeField] private float zoomDuration;
    [SerializeField] private string obstacleTag = "Button";

    [SerializeField] private Image panel;
    private Color initialColor;
    private Color targetColor;

    private void Start()
    {
        initialColor = panel.color;
        targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 1.0f);
    }

    private void OnEnable()
    {
        InputManager.onClick += TriggerRaycast;
    }

    private void OnDisable()
    {
        InputManager.onClick -= TriggerRaycast;
    }

    private void TriggerRaycast()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.CompareTag(obstacleTag))
            {
                StartCoroutine(FadeInAnimation());
                StartCoroutine(ZoomAnimation());
            }
        }
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

            //mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, camZoomPos.position, zoomTime);

            float newZ = Mathf.Lerp(mainCamera.transform.position.z, camZoomPos.position.z, zoomTime);
            Vector3 newPosition = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, newZ);

            mainCamera.transform.position = newPosition;

            yield return null;
        }

        mainCamera.transform.position = new Vector3 (mainCamera.transform.position.x, mainCamera.transform.position.y, camZoomPos.position.z);

        sceneLoader.LoadLevel(gameSceneIndexer);
    }

    //private IEnumerator ShrinkAnimation()
    //{
    //    float fadeInElapsedTime = 0.0f;
    //    float zoomElapsedTime = 0.0f;

    //    while (fadeInElapsedTime < fadeInDuration || zoomElapsedTime < zoomDuration)
    //    {
    //        fadeInElapsedTime += Time.deltaTime;
    //        zoomElapsedTime += Time.deltaTime;

    //        float fadeInTime = fadeInElapsedTime / fadeInDuration;
    //        float zoomTime = zoomElapsedTime / zoomDuration;

    //        float alpha = Mathf.Lerp(initialColor.a, targetColor.a, fadeInTime);
    //        panel.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);

    //        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, camZoomPos.position, zoomTime);
    //        yield return null;
    //    }

    //    panel.color = targetColor;
    //    mainCamera.transform.position = camZoomPos.position;

    //    sceneLoader.LoadLevel(gameSceneIndexer);
    //}
}
