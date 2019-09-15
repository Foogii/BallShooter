using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObject : MonoBehaviour
{
    public Spawner spawnerScript;

    public int health;

    bool roundEnd = false;

    public static int spawnersChecked;

    public AudioClip deathSound;


    void Start()
    {
        health = Random.Range((int)currentRound.round, (int)currentRound.round * 2);
    }


    // Update is called once per frame
    void Update()
    {

        if(roundEnd == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.78f);
            roundEnd = false;
        }

        if(health <= 0)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Destroy(gameObject);
        }
    }

    public void moveDown()
    {

        roundEnd = true;

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "ball")
        {
            health--;
        }
    }

}
