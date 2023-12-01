using player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public AK.Wwise.Event lateralMovement;
    public AK.Wwise.Event jump;
    public AK.Wwise.Event gravitationalChange;
    public AK.Wwise.Event openDoor;
    

    [SerializeField] PlayerController pm;

    public void PlayLateralMovement()
    {
        lateralMovement.Post(gameObject);
    }

    public void PlayJump()
    {
        jump.Post(gameObject);
    }

    public void PlayGravitationalChange()
    {
        gravitationalChange.Post(gameObject);
    }

    public void PlayOpenDoor()
    {
        openDoor.Post(gameObject);
    }    

    

    private void Start()
    {
        pm.moveAction += PlayLateralMovement; 
        pm.jump += PlayJump;
        pm.changeGravAction += PlayGravitationalChange;
        pm.interaction += PlayOpenDoor;             
        
    }



}
