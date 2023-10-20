using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private player.PlayerMovement pm;
    [SerializeField] private GameObject door;
    public static event Action<String> canOpen;
    public static event Action openDoor;

    private void Awake()
    {
        pm = FindAnyObjectByType<player.PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pm.interaction += OpenningDoor;
            canOpen?.Invoke("Press E to OPEN");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen?.Invoke("");
            pm.interaction -= OpenningDoor;
        }
    }

    private void OpenningDoor()
    {
        canOpen?.Invoke("");
        openDoor?.Invoke();
        Destroy(door);
    }
}
