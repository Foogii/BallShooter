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

    private void Awake()
    {
        health = Random.Range((int)currentRound.round, (int)currentRound.round * 2);
        maxHealth = health;
    }

    private void Start()
    {
        gmObj = GameObject.Find("GameManager");
        gm = (GameManager)gmObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Destroy(gameObject);

            gm.score += maxHealth;

            Debug.Log(gm.score);
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
            health--;
        }
    }


}
