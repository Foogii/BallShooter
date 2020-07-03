using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    protected Slider SFXSlider;
    protected Slider MusicSlider;
    public AudioMixer mixer;

    private void Awake()
    {
        GameObject[] soundManager = GameObject.FindGameObjectsWithTag("sound");
        if(soundManager.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume")) * 20);
        mixer.SetFloat("BoxVolume", Mathf.Log10(PlayerPrefs.GetFloat("SFXVolume")) * 20);
        mixer.SetFloat("CoinsVolume", Mathf.Log10(PlayerPrefs.GetFloat("SFXVolume")) * 20);
    }
}
