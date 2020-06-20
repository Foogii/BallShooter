using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    GameObject backgroundObj;
    SpriteRenderer background;
    public SpriteRenderer character;
    public SpriteRenderer block;
    public SpriteRenderer ball;
    public SpriteRenderer ballIncrease;

    Resources Backgrounds;
    Resources Blocks;
    Resources Balls;
    Resources Characters;
    Resources BallIncrease;

    private void Awake()
    {
        backgroundObj = GameObject.Find("Background");
        background = backgroundObj.GetComponent<SpriteRenderer>();

        GameObject[] skinManager = GameObject.FindGameObjectsWithTag("skins");
        if (skinManager.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        if (!PlayerPrefs.HasKey("Background"))
        {
            background.sprite = Resources.Load<Sprite>("Default");
            PlayerPrefs.SetString("Background", background.sprite.name);
        }

        if (!PlayerPrefs.HasKey("Character"))
        {
            character.sprite = Resources.Load<Sprite>("Plain_Player");
            PlayerPrefs.SetString("Character", character.sprite.name);
        }

        if (!PlayerPrefs.HasKey("Block"))
        {
            block.sprite = Resources.Load<Sprite>("Plain_Box");
            PlayerPrefs.SetString("Block", block.sprite.name);
        }

        if (!PlayerPrefs.HasKey("Ball"))
        {
            ball.sprite = Resources.Load<Sprite>("Plain_Ball");
            PlayerPrefs.SetString("Ball", ball.sprite.name);

            ballIncrease.sprite = Resources.Load<Sprite>("Plain_Ball");
            PlayerPrefs.SetString("Ball", ballIncrease.sprite.name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        background.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Background"));
    }

    // Update is called once per frame
    void Update()
    {
        backgroundObj = GameObject.Find("Background");
        background = backgroundObj.GetComponent<SpriteRenderer>();

        background.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Background"));
        character.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Character"));
        block.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Block"));
        ball.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Ball"));
        ballIncrease.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Ball"));
    }
}
