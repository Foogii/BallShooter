using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    GameObject backgroundObj;
    SpriteRenderer background;
    //public SpriteRenderer character;
    public SpriteRenderer block;
    public SpriteRenderer ball;
    public SpriteRenderer ballIncrease;

    Resources Backgrounds;
    Resources Blocks;
    Resources Balls;
    //Resources Characters;
    Resources BallIncrease;

    private void Awake()
    {
        GameObject[] skinManager = GameObject.FindGameObjectsWithTag("skins");
        if (skinManager.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        backgroundObj = GameObject.Find("Background");
        background = backgroundObj.GetComponent<SpriteRenderer>();

        background.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Background"));
    }

    // Update is called once per frame
    void Update()
    {
        backgroundObj = GameObject.Find("Background");
        background = backgroundObj.GetComponent<SpriteRenderer>();

        background.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Background"));
        //character.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Character"));
        block.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Block"));
        ball.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Ball"));
        ballIncrease.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Ball"));
    }
}
