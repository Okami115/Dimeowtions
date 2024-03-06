using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] public AK.Wwise.Event sound;

    public void ChangeMusicState()
    {
        sound.Post(gameObject);
    }
   
}
