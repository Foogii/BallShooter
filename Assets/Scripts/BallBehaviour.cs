using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public PlayerController playerSc;
    bool contacted = false;

    public float timeBeforeSpeedUp;

    GameObject gmObj;
    GameManager gm;

    public AudioClip highCoin;
    public AudioClip medCoin;
    public AudioClip lowCoin;
    public AudioClip eCoin;

    void Start()
    {
        gmObj = GameObject.Find("GameManager");
        gm = (GameManager)gmObj.GetComponent<GameManager>();
        player = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);

        if(transform.position.y < -3)
        {
            Destroy(gameObject);
        }

        contacted = false;

        if(timeBeforeSpeedUp <= 0)
        {
            speed = 20;
        }
        else
        {
            timeBeforeSpeedUp -= Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y, rot.z + 180);

        ///////////////////// Y Axis ////////////////////
        if (other.gameObject.tag == "Ceiling")
        {
            transform.rotation = Quaternion.Euler(-rot);
        }

        ///////////////// X Axis //////////////////////
        if (other.gameObject.tag == "Wall")
        {
            transform.rotation = Quaternion.Inverse(transform.rotation);
        }

        if (other.gameObject.tag == "Box")
        {
            foreach(ContactPoint2D hitPos in other.contacts)
            {

                if (!contacted)
                {
                    //if (Mathf.Abs(hitPos.normal.y) > 0 && Mathf.Abs(hitPos.normal.x) > 0)
                    //{
                    //    // greater than 45, less than 135,
                    //    if(Mathf.Abs(transform.rotation.z) >= 45 && Mathf.Abs(transform.rotation.z) <= 135)
                    //        transform.rotation = Quaternion.Inverse(transform.rotation);
                    //    else
                    //        transform.rotation = Quaternion.Euler(-rot);

                    //    contacted = true;
                    //    //Debug.Log("hit corner:" + hitPos.normal);
                    //}
                    if (Mathf.Abs(hitPos.normal.y) > Mathf.Abs(hitPos.normal.x))
                    {
                        transform.rotation = Quaternion.Euler(-rot);
                        contacted = true;
                        //Debug.Log("hit top/bottom:" + hitPos.normal);
                    }
                    else if (Mathf.Abs(hitPos.normal.y) < Mathf.Abs(hitPos.normal.x))
                    {
                        transform.rotation = Quaternion.Inverse(transform.rotation);
                        contacted = true;
                        //Debug.Log("hit side:" + hitPos.normal);
                    }
                }
            }

            /////////////////// Y Axis //////////////////////
            //if (Mathf.Abs(other.transform.position.y - transform.position.y) > Mathf.Abs(other.transform.position.x - transform.position.x))
            //{
            //    transform.rotation = Quaternion.Euler(-rot);
            //}

            /////////////////// X Axis //////////////////////
            //else if (Mathf.Abs(other.transform.position.y - transform.position.y) < Mathf.Abs(other.transform.position.x - transform.position.x))
            //{
            //    transform.rotation = Quaternion.Inverse(transform.rotation);
            //}
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
