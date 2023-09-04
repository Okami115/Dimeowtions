using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private player.PlayerMovement pm;

    private void Awake()
    {
        pm = FindAnyObjectByType<player.PlayerMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("SUB");
            pm.interaction += OpenningDoor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("DESUB");
            pm.interaction -= OpenningDoor;
        }
    }

    private void OpenningDoor(bool canOpen)
    {
        if(canOpen) 
        { 
            this.gameObject.SetActive(false);
        }
    }
}
