using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        health = Random.Range((int)currentRound.round, (int)currentRound.round * 2);
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

            gm.score += maxHealth * (int)shopSc.scoreMultiplier; //This is incorrect, fix this SOON
        }
    }

    public void moveDown()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.78f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "ball")
        {
            health -= 1 * shopSc.ballDamage;
        }
    }


}
