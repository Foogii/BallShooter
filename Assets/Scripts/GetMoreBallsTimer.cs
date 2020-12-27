using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMoreBallsTimer : MonoBehaviour
{
    static public float adTimer;
    Button getMoreBallsButton;

    // Start is called before the first frame update
    void Start()
    {
        getMoreBallsButton = GetComponent<Button>();

        if (!PlayerPrefs.HasKey("adTimer"))
        {
            adTimer = 0f; //Set to 300 for 5 min timer
        }
        else
        {
            adTimer = PlayerPrefs.GetFloat("adTimer");
        }
    }

    void Update()
    {
        if (adTimer >= 0)
        {
            adTimer -= Time.unscaledDeltaTime;
            PlayerPrefs.SetFloat("adTimer", adTimer);
            getMoreBallsButton.interactable = false;
        }
        else
        {
            getMoreBallsButton.interactable = true;
        }
    }
}
