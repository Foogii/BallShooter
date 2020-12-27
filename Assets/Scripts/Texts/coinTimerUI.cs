using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinTimerUI : MonoBehaviour
{
    Text coinTimer;

    // Start is called before the first frame update
    void Start()
    {
        coinTimer = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetFloat("coinTimer") <= 0)
        {
            coinTimer.text = "Earn More\nGold Coins";
        }
        else
        {
            coinTimer.text = (int)PlayerPrefs.GetFloat("coinTimer") + "s";
        }
    }
}
