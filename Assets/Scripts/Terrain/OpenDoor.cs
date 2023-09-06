using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private player.PlayerMovement pm;
    public event Action<String> canOpen;

    private void Awake()
    {
        pm = FindAnyObjectByType<player.PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen?.Invoke("Press E to OPEN");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            pm.interaction += OpenningDoor;
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
        this.gameObject.SetActive(false);
    }
}
