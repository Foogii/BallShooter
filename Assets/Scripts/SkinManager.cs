using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    GameObject backgroundObj;
    GameObject characterObj;
    SpriteRenderer background;
    SpriteRenderer character;
    public SpriteRenderer block;
    public SpriteRenderer ball;
    public SpriteRenderer ballIncrease;

    private void Awake()
    {
        backgroundObj = GameObject.Find("Background");
        background = backgroundObj.GetComponent<SpriteRenderer>();

        characterObj = GameObject.Find("PlayerSprite");
        character = characterObj.GetComponent<SpriteRenderer>();

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
        character.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Character"));
        block.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Block"));
        ball.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Ball"));
        ballIncrease.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Ball"));
    }

    // Update is called once per frame
    void Update()
    {
        backgroundObj = GameObject.Find("Background");
        background = backgroundObj.GetComponent<SpriteRenderer>();

        characterObj = GameObject.Find("PlayerSprite");
        character = characterObj.GetComponent<SpriteRenderer>();

        background.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Background"));
        character.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Character"));
        block.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Block"));
        ball.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Ball"));
        ballIncrease.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("Ball"));
    }
}
