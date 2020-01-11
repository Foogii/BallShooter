﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    static public int numberOfBalls = 1;
    public int currNumBall = numberOfBalls;

    private float fireRate = 0.1f;

    public GameObject ballPrefab;

    BallBehaviour ballScript;

    GameObject gmObj;
    GameManager gm;

    LineRenderer lineRenderer;

    void Start()
    {
        numberOfBalls = 1;
        gmObj = GameObject.Find("GameManager");
        gm = (GameManager) gmObj.GetComponent<GameManager>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer = GetComponent<LineRenderer>();

        if (GameManager.roundEnd == false && gm.isGameOver == false)
        {
            currNumBall = numberOfBalls;
            Vector2 mouse_Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = new Vector2(mouse_Position.x - transform.position.x, mouse_Position.y - transform.position.y);

            if (mouse_Position.y > transform.position.y + 0.25)
                transform.up = direction;

                lineRenderer.SetPosition(0, mouse_Position);
                lineRenderer.SetPosition(1, mouse_Position);

            if (Input.GetMouseButtonUp(0))
            {
                GameManager.roundEnd = true;

                lineRenderer.SetPosition(0, new Vector2(-20, -20));
                lineRenderer.SetPosition(1, new Vector2(-20, -20));

                StartCoroutine(burstFire());

            }

        }
    }


    public IEnumerator burstFire()
    {

        for(int i = 0; i < numberOfBalls; i++)
        {
            Instantiate(ballPrefab, transform.up - new Vector3(0f, 3f, 0f), transform.rotation);
            currNumBall--;

            if(currNumBall < 0)
            {
                currNumBall = 0;
            }

            yield return new WaitForSeconds(fireRate);
        }
    }
}
