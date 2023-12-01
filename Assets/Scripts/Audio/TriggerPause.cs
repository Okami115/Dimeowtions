using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPause : MonoBehaviour
{
   
    [SerializeField] public AK.Wwise.Event musicPause;

    public void MusicPause()
    {
        musicPause.Post(gameObject);
    }

}

