using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMoreBallsTimerUI : MonoBehaviour
{
    Text adTimer;

    // Start is called before the first frame update
    void Start()
    {
        adTimer = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetFloat("adTimer") <= 0)
        {
            adTimer.text = "Get More Balls";
        }
        else
        {
            adTimer.text = (int)PlayerPrefs.GetFloat("adTimer") + "s";
        }
    }
}
