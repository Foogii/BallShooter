using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coins : MonoBehaviour
{
    Text coinsTxt;
    Text eCoinsTxt;

    // Start is called before the first frame update
    void Start()
    {
        coinsTxt = GetComponent<Text>();
        eCoinsTxt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "Coins")
            coinsTxt.text = "" + PlayerPrefs.GetInt("Coins");
        else
            eCoinsTxt.text = "" + PlayerPrefs.GetInt("eCoins");
    }
}
