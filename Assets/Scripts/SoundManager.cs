using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] soundManager = GameObject.FindGameObjectsWithTag("sound");
        if(soundManager.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
