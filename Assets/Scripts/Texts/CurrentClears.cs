using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentClears : MonoBehaviour
{
    private GameManager gm;
    Text currentClears;

    // Start is called before the first frame update
    void Start()
    {
        currentClears = GetComponent<Text>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentClears.text = "x" + gm.clearUses;
    }
}
