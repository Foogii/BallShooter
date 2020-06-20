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
        float getAspect;

        getAspect = (float)Screen.width / (float)Screen.height;
        if (getAspect == (9f / 16f))
        {
            gameObject.transform.localScale = new Vector2(4.6f, 4.6f);
        }
        else if (getAspect == (9f / 19f))
        {
            gameObject.transform.localScale = new Vector2(3.8f, 3.8f);
        }      

        double tempHp = (((2 * currentRound.round) + Math.Pow(1.03, currentRound.round)) / 1.5) + UnityEngine.Random.Range(0f, 5f);

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
