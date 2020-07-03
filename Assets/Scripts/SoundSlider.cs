using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSlider : SoundManager
{
    private void Update()
    {
        if (this.gameObject.name == "SFXSlider")
        {
            SFXSlider = this.gameObject.GetComponent<Slider>();
            SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }

        if (this.gameObject.name == "MusicSlider")
        {
            MusicSlider = this.gameObject.GetComponent<Slider>();
            MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
    }

    public void SetVolume(float slider)
    {
        slider = MusicSlider.value;

        mixer.SetFloat("MusicVolume", Mathf.Log10(slider) * 20);
        PlayerPrefs.SetFloat("MusicVolume", slider);
    }

    public void SFXVolume(float slider)
    {
        slider = SFXSlider.value;

        mixer.SetFloat("CoinsVolume", Mathf.Log10(slider) * 20);
        mixer.SetFloat("BoxVolume", Mathf.Log10(slider) * 20);

        PlayerPrefs.SetFloat("SFXVolume", slider);
    }
}
