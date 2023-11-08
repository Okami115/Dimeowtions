using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject slider;

    private bool isActive = false;

    public void ToggleSlider()
    {
        isActive = !isActive;
        slider.SetActive(isActive);
    }
}
