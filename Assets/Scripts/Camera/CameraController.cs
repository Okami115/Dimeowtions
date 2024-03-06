using player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;
    [SerializeField] private Camera camera;
    [SerializeField] private float JumpMultiplier;
    [SerializeField] private float MoveMultiplier;

    private void OnEnable()
    {
        playerController.jump += ReduceFOV;
        playerController.moveAction += IncreaseFOV;
    }

    private void OnDisable()
    {
        playerController.jump -= ReduceFOV;
        playerController.moveAction -= IncreaseFOV;
    }

    void Update()
    {
        if(camera.fieldOfView > 120)
            camera.fieldOfView -= Time.deltaTime * JumpMultiplier;

        if (camera.fieldOfView < 120)
            camera.fieldOfView += Time.deltaTime * MoveMultiplier;
    }

    private void ReduceFOV()
    {
        camera.fieldOfView = 150;
    }

    private void IncreaseFOV()
    {
        camera.fieldOfView = 90;
    }
}
