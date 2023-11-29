using player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDeathAnimation : MonoBehaviour
{
    [SerializeField] private CheckColision playerCollision;
    [SerializeField] Transform cameraTransform;

    [SerializeField] private Vector3 deathCameraOffsetPosition;
    [SerializeField] private Vector3 deathCameraOffsetRotation;
    [SerializeField] private float deathAnimationLenght;

    [SerializeField] private GameObject[] UI;

    private void OnEnable()
    {
        playerCollision.deathAction += StartCameraDeathAnimation;
    }

    private void OnDisable()
    {
        playerCollision.deathAction -= StartCameraDeathAnimation;
    }

    private void StartCameraDeathAnimation()
    {
        StartCoroutine(AnimateCameraPosition());
    }

    private IEnumerator AnimateCameraPosition()
    {
        Vector3 startPosition = cameraTransform.position;
        Quaternion startRotation = cameraTransform.rotation;
        
        Vector3 endPositionOffset = deathCameraOffsetPosition;
        Quaternion endRotationOffset = Quaternion.Euler(deathCameraOffsetRotation);

        Vector3 endPosition = startPosition + cameraTransform.TransformDirection(endPositionOffset);
        Quaternion endRotation = startRotation * endRotationOffset;
        
        float elapsedTime = 0.0f;

        while (elapsedTime < deathAnimationLenght)
        {
            float t = elapsedTime / deathAnimationLenght;
            cameraTransform.position = Vector3.Lerp(startPosition, endPosition, t);
            cameraTransform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cameraTransform.position = endPosition;
        cameraTransform.rotation = endRotation;

        UI[1].SetActive(false);
        UI[0].SetActive(true);
    }
}
