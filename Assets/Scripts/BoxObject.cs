using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObject : MonoBehaviour
{
    public int health;

    public static int spawnersChecked;

    public AudioClip deathSound;

    private void Awake()
    {
        health = Random.Range((int)currentRound.round, (int)currentRound.round * 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Destroy(gameObject);
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
