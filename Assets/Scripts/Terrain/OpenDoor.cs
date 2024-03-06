using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private player.PlayerController pm;
    [SerializeField] private GameObject door;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider boxCollider;
    public static event Action openDoor;
    [SerializeField] private string doorOpenTriggerName;
    [SerializeField] private string doorOpenBoolName;

    private void Awake()
    {
        pm = FindAnyObjectByType<player.PlayerController>();
        animator.SetBool(doorOpenBoolName, true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pm.interaction += OpenningDoor;
            animator.SetBool(doorOpenBoolName, false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pm.interaction -= OpenningDoor;
            animator.SetBool(doorOpenBoolName, true);
        }
    }

    private void OpenningDoor()
    {
        openDoor?.Invoke();
        animator.SetTrigger(doorOpenTriggerName);
        animator.SetBool(doorOpenBoolName, true);
        boxCollider.enabled = false;
    }
}
