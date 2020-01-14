using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    Text score;
    Text highscore;


    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        highscore = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Score")
            score.text = "Score: " + PlayerPrefs.GetInt("Score");
        else
            highscore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
    }
}
