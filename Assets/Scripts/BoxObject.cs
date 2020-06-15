using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoxObject : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public static int spawnersChecked;

    public AudioClip deathSound;

    GameObject gmObj;
    GameManager gm;

    ShopManager shopSc;
    GameObject shopObj;

    private void Awake()
    {
        float height = Screen.height / (3090/23);
        float width = height;

        gameObject.transform.localScale = new Vector2(width, height);

        double tempHp = ((2 * currentRound.round) + Math.Pow(1.03, currentRound.round)) / 1.5; ;

        //health = Random.Range((int)currentRound.round, (int)currentRound.round * 2);
        health = (int)tempHp;
        maxHealth = health;
    }

    private void Start()
    {
        gmObj = GameObject.Find("GameManager");
        gm = (GameManager)gmObj.GetComponent<GameManager>();

        shopObj = GameObject.Find("ShopManager");
        shopSc = (ShopManager)shopObj.GetComponent<ShopManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Destroy(gameObject);

            gm.score += maxHealth * (int)shopSc.scoreMultiplier;
        }
    }

    public void moveDown()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 4.57f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "ball")
        {
            health -= 1 * shopSc.ballDamage;
            var val = 1 * shopSc.ballDamage; //Determines how much the score will be increased by
            gm.score += val * (int)shopSc.scoreMultiplier; //Increase the score
        }
    }


}
