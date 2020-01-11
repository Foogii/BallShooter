using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentBallTotal : MonoBehaviour
{
    private PlayerController player;
    Text ballTotal;

    // Start is called before the first frame update
    void Start()
    {
        ballTotal = GetComponent<Text>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        ballTotal.text = "x" + player.currNumBall;
    }
}
