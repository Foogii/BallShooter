using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider SFXSlider;
    public Slider MusicSlider;

    private void Start()
    {
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
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
