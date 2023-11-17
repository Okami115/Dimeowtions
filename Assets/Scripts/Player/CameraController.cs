using player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;
    [SerializeField] private Camera camera;


    private void OnEnable()
    {
        playerController.jump += ReduceFOV;
    }

    private void OnDisable()
    {
        playerController.jump -= ReduceFOV;
    }

    void Update()
    {
        if(camera.fieldOfView > 120)
        {
            camera.fieldOfView--;
        }
    }

    private void ReduceFOV()
    {
        camera.fieldOfView = 150;
    }
}
