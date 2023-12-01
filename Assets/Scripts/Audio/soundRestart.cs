using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundRestart : MonoBehaviour
{
    [SerializeField] public AK.Wwise.Event restartButton;
    [SerializeField] public AK.Wwise.Event resurrect;

    public void RestarButton()
    {
        resurrect.Post(gameObject);
        restartButton.Post(gameObject);
    }
}
