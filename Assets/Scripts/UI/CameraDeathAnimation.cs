using player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDeathAnimation : MonoBehaviour
{
    [SerializeField] private CheckColision playerCollision;
    [SerializeField] Transform cameraTransform;

    [SerializeField] private Vector3 deathCameraOffsetPositionFall;
    [SerializeField] private Vector3 deathCameraOffsetRotationFall;
    [SerializeField] private float deathAnimationLenghtFall;

    [SerializeField] private Vector3 deathCameraOffsetPositionCollision;
    [SerializeField] private Vector3 deathCameraOffsetRotationCollision;
    [SerializeField] private float deathAnimationLenghtCollision;

    [SerializeField] private GameObject[] UI;
    [SerializeField] private float fadeInDuration;

    private void OnEnable()
    {
        playerCollision.deathActionFall += StartCameraDeathAnimationFall;
        playerCollision.deathActionColision += StartCameraDeathAnimationCollision;
    }

    private void OnDisable()
    {
        playerCollision.deathActionFall -= StartCameraDeathAnimationFall;
        playerCollision.deathActionColision -= StartCameraDeathAnimationCollision;
    }

    private void StartCameraDeathAnimationFall()
    {
        StartCoroutine(AnimateCameraPositionFall());
    }

    private void StartCameraDeathAnimationCollision()
    {
        StartCoroutine(AnimateCameraPositionCollision());
    }

    private IEnumerator AnimateCameraPositionFall()
    {
        Vector3 startPosition = cameraTransform.position;
        Quaternion startRotation = cameraTransform.rotation;

        Vector3 endPositionOffset = deathCameraOffsetPositionFall;
        Quaternion endRotationOffset = Quaternion.Euler(deathCameraOffsetRotationFall);

        Vector3 endPosition = startPosition + cameraTransform.TransformDirection(endPositionOffset);
        Quaternion endRotation = startRotation * endRotationOffset;

        float elapsedTime = 0.0f;

        while (elapsedTime < deathAnimationLenghtFall)
        {
            float t = elapsedTime / deathAnimationLenghtFall;
            cameraTransform.position = Vector3.Lerp(startPosition, endPosition, t);
            cameraTransform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cameraTransform.position = endPosition;
        cameraTransform.rotation = endRotation;

        ResetUI();
    }

    private IEnumerator AnimateCameraPositionCollision()
    {
        Vector3 startPosition = cameraTransform.position;
        Quaternion startRotation = cameraTransform.rotation;
        
        Vector3 endPositionOffset = deathCameraOffsetPositionCollision;
        Quaternion endRotationOffset = Quaternion.Euler(deathCameraOffsetRotationCollision);

        Vector3 endPosition = startPosition + cameraTransform.TransformDirection(endPositionOffset);
        Quaternion endRotation = startRotation * endRotationOffset;
        
        float elapsedTime = 0.0f;

        while (elapsedTime < deathAnimationLenghtCollision)
        {
            float t = elapsedTime / deathAnimationLenghtCollision;
            cameraTransform.position = Vector3.Lerp(startPosition, endPosition, t);
            cameraTransform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cameraTransform.position = endPosition;
        cameraTransform.rotation = endRotation;

        ResetUI();
    }

    private IEnumerator FadeInPanel(CanvasGroup panelCanvasGroup, float duration)
    {
        float elapsedTime = 0.0f;
        float startAlpha = 0f; 
        float targetAlpha = 1f;

        while (elapsedTime < duration)
        {
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
            panelCanvasGroup.alpha = newAlpha;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panelCanvasGroup.alpha = targetAlpha;
    }

    private void ResetUI()
    {
        UI[1].SetActive(false); 

        UI[0].SetActive(true);

        CanvasGroup panelCanvasGroup = UI[0].GetComponent<CanvasGroup>();

        if (panelCanvasGroup != null)
        {
            StartCoroutine(FadeInPanel(panelCanvasGroup, fadeInDuration));
        }
    }
}
