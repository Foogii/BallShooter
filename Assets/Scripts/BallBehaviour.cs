using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    public GameObject player;
    public PlayerController playerSc;

    public float timeBeforeSpeedUp;

    GameObject gmObj;
    GameManager gm;

    public AudioClip highCoin;
    public AudioClip medCoin;
    public AudioClip lowCoin;
    public AudioClip eCoin;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gmObj = GameObject.Find("GameManager");
        gm = (GameManager)gmObj.GetComponent<GameManager>();
        player = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;

        if(transform.position.y < -19)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ballIncrease")
        {
            PlayerController.numberOfBalls++;
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "coin")
        {
            gm.coinsNum++;
            int rand = Random.Range(0, 3);
            if (rand <= 1f)
            {
                AudioSource.PlayClipAtPoint(highCoin, other.transform.position);
            }
            else if (rand > 1 && rand <= 2)
            {
                AudioSource.PlayClipAtPoint(medCoin, other.transform.position);
            }
            else
            {
                AudioSource.PlayClipAtPoint(lowCoin, other.transform.position);
            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "eCoin")
        {
            gm.eCoinsNum++;
            AudioSource.PlayClipAtPoint(eCoin, other.transform.position);
            Destroy(other.gameObject);
        }
    }

}
