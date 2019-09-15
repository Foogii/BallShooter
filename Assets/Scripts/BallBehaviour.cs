using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public PlayerController playerSc;
    public Rigidbody2D rb;



    void Start()
    {

        player = GetComponent<GameObject>();
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(transform.up * speed);
    }

    // Update is called once per frame
    void Update()
    {


        if(transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        ///////////////////// Y Axis ////////////////////

        //if (other.gameObject.tag == "Ceiling")
        //{

        //    Vector3 rot = transform.rotation.eulerAngles;
        //    rot = new Vector3(rot.x, rot.y, rot.z + 180);

        //    if (other.transform.position.y > transform.position.y)
        //    {
        //        transform.rotation = Quaternion.Euler(-rot);
        //    }

        //    if (other.transform.position.y > transform.position.y)
        //    {
        //        transform.rotation = Quaternion.Euler(-rot);
        //    }

        //}

        //if (other.gameObject.tag == "Wall")
        //{


        //    /////////////////// X Axis //////////////////////

        //    if (other.transform.position.x > transform.position.x)
        //    {
        //        transform.rotation = Quaternion.Inverse(transform.rotation);
        //    }

        //    if (other.transform.position.x < transform.position.x)
        //    {
        //        transform.rotation = Quaternion.Inverse(transform.rotation);
        //    }

            
        //}

        //if (other.gameObject.tag == "Box")
        //{


        //    Vector3 rot = transform.rotation.eulerAngles;
        //    rot = new Vector3(rot.x, rot.y, rot.z + 180);

        //    /////////////////// Y Axis //////////////////////

        //    if (Mathf.Abs(other.transform.position.y - transform.position.y) > Mathf.Abs(other.transform.position.x - transform.position.x))
        //    {
        //        if (other.transform.position.y > transform.position.y)
        //        {
        //            transform.rotation = Quaternion.Euler(-rot);
        //        }

        //        if (other.transform.position.y < transform.position.y)
        //        {
        //            transform.rotation = Quaternion.Euler(-rot);
        //        }
        //    }
        //    /////////////////// X Axis //////////////////////

        //    //if (Mathf.Abs(other.transform.position.y - transform.position.y) < Mathf.Abs(other.transform.position.x - transform.position.x))
        //    //{
        //        if (other.transform.position.x > transform.position.x)
        //        {
        //            transform.rotation = Quaternion.Inverse(transform.rotation);
        //        }

        //        if (other.transform.position.x < transform.position.x)
        //        {
        //            transform.rotation = Quaternion.Inverse(transform.rotation);
        //        }
        //    //}

        //}

        

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ballIncrease")
        {
            PlayerController.numberOfBalls++;
            Destroy(other.gameObject);
        }
    }

}
