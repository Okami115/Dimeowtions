using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using AK.Wwise;

public class SliderController : MonoBehaviour
{
    public Slider thisSlider;
    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;

    private void Start()
    {
        thisSlider.onValueChanged.AddListener(delegate { SetSpecificVolume("Master"); });
        SetSpecificVolume("Master");
    }
    
    public void SetSpecificVolume(string whatValue)
    {
                

        if (whatValue == "Master")
        {
            masterVolume = thisSlider.value;
            AkSoundEngine.SetRTPCValue("MasterVolume", masterVolume);
        }

        if (whatValue == "Music")
        {
            masterVolume = thisSlider.value;
            AkSoundEngine.SetRTPCValue("MusicVolume", masterVolume);
        }

        if (whatValue == "SFX")
        {
            masterVolume = thisSlider.value;
            AkSoundEngine.SetRTPCValue("SFXVolume", masterVolume);
        }
    }
}
