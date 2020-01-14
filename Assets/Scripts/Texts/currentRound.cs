using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currentRound : MonoBehaviour
{

    static public int round;
    Text Round;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Round") <= 1)
            round = 1;
        Round = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Round.text = "" + round;
    }
}
