using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currentRound : MonoBehaviour
{

    static public int round = 1;
    Text Round;

    // Start is called before the first frame update
    void Start()
    {
        round = 1;
        Round = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Round.text = "" + round;
    }
}
