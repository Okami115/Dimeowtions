using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private player.PlayerMovementTutorial pm;
    [SerializeField] private GameObject door;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider boxCollider;
    public static event Action<String> canOpen;
    public static event Action openDoor;
    [SerializeField] private string doorOpenTriggerName;

    private void Awake()
    {
        pm = FindAnyObjectByType<player.PlayerMovementTutorial>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pm.interaction += OpenningDoor;
            canOpen?.Invoke("");
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
        animator.SetTrigger(doorOpenTriggerName);
        boxCollider.enabled = false;
    }
}
